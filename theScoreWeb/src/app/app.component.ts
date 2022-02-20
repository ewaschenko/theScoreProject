// Angular Libraries
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';

// Models
import { Rushing, RushingSearch} from './Shared/models/index';

// Services
import { RushingService } from './Shared/services/rushing.service';

// Other Libraries
import { debounceTime, take } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [RushingService]
})
export class AppComponent implements OnInit {
	rushingSource: MatTableDataSource<Rushing>;
  	displayedColumns: string[] = ['Player', 'Team', 'Position', 'Att', 'Att/G', 'Yds', 'Yds/G', 'Avg', 'TD', 'Lng', '1st', '1st%', '20+', '40+', "FUM"];

	rushingForm: FormGroup;

	currentPage: number = 0;
  	pageSize: number = 25;
  	totalCount: number = 0;

	isLoading: boolean = false;

	searchFiler: RushingSearch = {
		Player: "",
		SortValue: "",
		SortDirection: "",
		CurrentPage: this.currentPage,
		PageSize: this.pageSize
	};

  	constructor(
		private formBuilder: FormBuilder,
		private rushingService: RushingService,
		private snackBar: MatSnackBar) {
    	this.rushingSource = new MatTableDataSource();	
  	}

	ngOnInit() {
		this.createForm();
		this.getRushing();
	}

	/**
	 * Creates search form and sets up debounceTime timer for input
	 */
	createForm(): void {
		this.rushingForm = this.formBuilder.group({
			player: new FormControl("")
		});

		const initiateSearch = this.rushingForm.get('player')?.valueChanges.pipe(debounceTime(1000));
		initiateSearch?.subscribe(x => this.getRushing());
	}

	/**
	 * Calls the Rushing service to excecute the search.
	 */
	getRushing(): void {
		this.isLoading = true;

		this.searchFiler.Player = this.rushingForm.get('player')?.value;
		this.rushingService.getRushing(this.searchFiler).pipe(take(1)).subscribe(
			response => {
				this.rushingSource.data = response.rushings;
				this.totalCount = response.totalCount;
				this.isLoading = false;
			},
			error => {
				this.snackBar.open("Error Getting Rushing List, Please Try Again", "Close", { duration: 7500 });
				this.isLoading = false;
			}
		);
	}
	
	/**
	 * Calls the Rushing serivce to add the Rushing JSON players
	 */
	postRushing(): void {
		if(this.rushingSource.data.length != 0){
			return;
		}

		this.isLoading = true;
		this.rushingService.postRushing().pipe(take(1)).subscribe(
			response => {
				this.rushingSource.data = response.rushings;
				this.totalCount = response.totalCount;
				this.isLoading = false;
				this.snackBar.open("Rushing List Added", "Close", { duration: 4000 });
			},
			error => {
				this.snackBar.open("Error Adding Rushing, Please Try Again", "Close", { duration: 7500 });
				this.isLoading = false;
			}
		);
	}

	/**
	 * Called when the page size or page number is changed, updates search filter then runs search
	 * @param event {PageEvent}: The updated Pagination object
	 */
	handlePagination(event: PageEvent): void {
		this.currentPage = event.pageIndex;
		this.searchFiler.CurrentPage = event.pageIndex;
		this.pageSize = event.pageSize;
		this.searchFiler.PageSize = event.pageSize;
		this.getRushing();
	}

	/**
	 * Called on each sort click, updates search filter then runs search
	 * @param event {Sort}: The updated Sort object
	 */
	announceSortChange(event: Sort): void {
		this.searchFiler.SortValue = event.active;
		this.searchFiler.SortDirection = event.direction;
		this.getRushing();
	}
}

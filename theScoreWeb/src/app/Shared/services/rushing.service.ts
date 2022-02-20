// Angular Libraries
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

// Models
import { RushingList, RushingSearch } from '../models/index';

// External Libraries
import { Observable } from 'rxjs';

import * as $ from 'jquery';

@Injectable()
export class RushingService {
    constructor(private http: HttpClient) { }

    getRushing(search: RushingSearch): Observable<RushingList> {
        let queryParams = $.param(search)
        return this.http.get<RushingList>('api/Rushing?' + queryParams, { withCredentials: true });
    }

    postRushing(): Observable<RushingList> {
        return this.http.post<RushingList>('api/Rushing', { withCredentials: true });
    }
}
// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using theScoreAPI.Context;

#nullable disable

namespace theScoreAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("theScoreAPI.Shared.Models.Rushing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Att")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AttG")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Avg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FUM")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FirstDownPercent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FirstDowns")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Lng")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LngDistance")
                        .HasColumnType("int");

                    b.Property<string>("Player")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RushingFourty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RushingTwenty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TD")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Team")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Yds")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("YdsG")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Rushings");
                });
#pragma warning restore 612, 618
        }
    }
}

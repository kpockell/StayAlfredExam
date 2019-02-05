import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-unit-view',
  templateUrl: './unit-view.component.html',
  styleUrls: ['./unit-view.component.scss']
})
export class UnitViewComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  units: any[];
  dataSource: MatTableDataSource<Unit>;
  displayedColumns = ['CompositeId', 'BuildingId', 'Bedrooms', 'Bathrooms'];

  constructor(private http: HttpClient) {
  }

  async ngOnInit() {

    await this.http.get('api/Units').subscribe((units: any[]) => {
      this.units = units

      this.dataSource = new MatTableDataSource(this.units);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });

  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}

export class Unit {
  UnitId: string;
  CompositeId: string;
  Bathrooms: number;
  Bedrooms: number;
  BuldingId: string;
  SquareFootage: string;
}

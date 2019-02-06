import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { forEach } from '@angular/router/src/utils/collection';
import { ActivatedRoute } from '@angular/router';
import { combineLatest } from 'rxjs';
import { Unit } from 'src/app/modules/unit/components/unit-view/unit-view.component';

@Component({
  selector: 'app-view-reservation',
  templateUrl: './view-reservation.component.html',
  styleUrls: ['./view-reservation.component.scss']
})
export class ViewReservationsComponent implements OnInit {
  
  dataSource: MatTableDataSource<Reservation>;
  displayedColumns = ['GuestId', 'UnitId', 'CheckInDate', 'CheckOutDate'];
  unitId: string;
  reservations: Reservation[] = [];
  currentGuestId: string;

  constructor(private http: HttpClient,
    private route: ActivatedRoute) { }

  async ngOnInit() {
    this.route.params.subscribe(params => {
      this.unitId = params['unitId']; // (+) converts string 'id' to a number
      combineLatest(
        this.http.get('api/Guests'),
        this.http.get(`api/Units/${this.unitId}`),
        this.http.get(`api/Reservations/${this.unitId}`)
      ).subscribe(([guests, unit, reservations]) => {
        for (let reservation of (<any[]>reservations)) {
          this.currentGuestId = reservation.GuestId;
          //let guest = (<any[]>guests).find(this.getGuest);
          this.reservations.push(
            {
              UnitId: (<Unit>unit).CompositeId,
              GuestId: reservation.GuestId,
              CheckInDate: reservation.CheckInDate,
              CheckOutDate: reservation.CheckOutDate
            }
          );

        }
        this.dataSource = new MatTableDataSource(this.reservations);

      });
    });
  }
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  getGuest(guest) {
    return guest.GuestId === this.currentGuestId;
  }

}

class Reservation {
  GuestId: string;
  UnitId: string;
  CheckInDate: Date;
  CheckOutDate: Date;
}

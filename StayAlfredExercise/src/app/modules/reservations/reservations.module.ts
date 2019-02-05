import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ViewReservationsComponent } from './components/view-reservation/view-reservation.component';
import { AddReservationComponent } from './components/add-reservation/add-reservation.component';

@NgModule({
  declarations: [ViewReservationsComponent, AddReservationComponent],
  imports: [
    CommonModule
  ]
})
export class ReservationsModule { }

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UnitViewComponent } from 'src/app/modules/unit/components/unit-view/unit-view.component';
import { AddUnitComponent } from './modules/unit/components/add-unit/add-unit.component';
import { AddBuildingComponent } from './modules/building/components/add-building/add-building.component';
import { ViewReservationsComponent } from './modules/reservations/components/view-reservation/view-reservation.component';
import { AddReservationComponent } from './modules/reservations/components/add-reservation/add-reservation.component';

const routes: Routes = [
  { path: '', component: UnitViewComponent },
  { path: 'add-unit', component: AddUnitComponent },
  { path: 'add-building', component: AddBuildingComponent },
  { path: 'reservations/:unitId', component: ViewReservationsComponent },
  { path: 'add-reservation', component: AddReservationComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

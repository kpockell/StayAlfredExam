import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UiModule } from 'src/app/modules/ui/ui.module';
import { UnitViewComponent } from 'src/app/modules/unit/components/unit-view/unit-view.component';
import { HttpClientModule } from '@angular/common/http';
import { AddUnitComponent } from './modules/unit/components/add-unit/add-unit.component';
import { ToastrModule, ToastContainerModule } from 'ngx-toastr';
import { AddBuildingComponent } from './modules/building/components/add-building/add-building.component';
import { ViewReservationsComponent } from './modules/reservations/components/view-reservation/view-reservation.component';
import { AddReservationComponent } from './modules/reservations/components/add-reservation/add-reservation.component';

@NgModule({
  declarations: [
    AppComponent,
    UnitViewComponent,
    AddUnitComponent,
    AddBuildingComponent,
    ViewReservationsComponent,
    AddReservationComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: 'toast-bottom-center',
      preventDuplicates: true,
    }),
    UiModule,
    AppRoutingModule,
    HttpClientModule,
    ToastContainerModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

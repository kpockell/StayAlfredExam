import { Component, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastContainerDirective, ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { VALID } from '@angular/forms/src/model';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Unit } from 'src/app/modules/unit/components/unit-view/unit-view.component';

@Component({
  selector: 'app-add-reservation',
  templateUrl: './add-reservation.component.html',
  styleUrls: ['./add-reservation.component.scss']
})
export class AddReservationComponent implements OnInit {

  newReservation: FormGroup;
  guests$: Observable<Guest>;
  units$: Observable<Unit>;

  @ViewChild(ToastContainerDirective) toastContainer: ToastContainerDirective;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private http: HttpClient,
    public toastr: ToastrService,
    vcr: ViewContainerRef,
  ) {

    this.newReservation = fb.group({
      GuestId: ['', Validators.required],
      UnitId: ['', Validators.required],
      CheckInDate: ['', Validators.required],
      CheckOutDate: ['', Validators.required],
    });

    this.toastr.overlayContainer = this.toastContainer;
  }
  ngOnInit() {
    this.guests$ = this.http.get('api/Guests').pipe(map((guest) => {
      return <Guest>guest
    }));
    this.units$ = this.http.get('api/Units').pipe(map((unit) => {
      return <Unit>unit
    }));

  }

  onSubmit() {
    if (this.newReservation.valid) {
      this.http.post('api/reservations', this.newReservation.value).toPromise().then(
        (response: any) => {
          this.toastr.success('Reservation successfully added.');
          this.newReservation.reset();
        },
        (error: any) => {
          this.toastr.error('An unknown error occurred');
          console.log(error);
        });
    }
  }
}

export class Guest {
  FirstName: string;
  LastName: string;
}

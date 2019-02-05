import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-unit',
  templateUrl: './add-unit.component.html',
  styleUrls: ['./add-unit.component.scss']
})
export class AddUnitComponent implements OnInit {
  newUnit: FormGroup;
  buildings$: Observable<Building>;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private http: HttpClient,
    public toastr: ToastrService,
    vcr: ViewContainerRef,
  ) {

    this.newUnit = fb.group({
      Bedrooms: ['', Validators.required],
      Bathrooms: ['', Validators.required],
      BuildingId: ['', Validators.required],
      UnitNumber: ['', Validators.required],
      SquareFootage: ['', Validators.required],
    });

   
  }

  ngOnInit() {
    this.buildings$ = this.http.get('api/Buildings').pipe(map((building) => {
      return <Building>building
    }));
  }

  onSubmit() {
    if (this.newUnit.valid) {
      this.http.post('api/Units', this.newUnit.value).toPromise().then(
        (response: any) => {
          this.toastr.success('Unit successfully added.');
          this.newUnit.reset();
        },
        (error: any) => {
          this.toastr.error('An unknown error occurred');
          console.log(error);
        });
    }
  }

}

class Building {
  BuildingId: string;
  BuildingName: string;
}

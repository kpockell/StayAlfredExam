import { Component, OnInit, ViewContainerRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService, ToastContainerDirective } from 'ngx-toastr';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-building',
  templateUrl: './add-building.component.html',
  styleUrls: ['./add-building.component.scss']
})
export class AddBuildingComponent implements OnInit {

  newBuilding: FormGroup;
  @ViewChild(ToastContainerDirective) toastContainer: ToastContainerDirective;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private http: HttpClient,
    public toastr: ToastrService,
    vcr: ViewContainerRef,
  ) {

    this.newBuilding = fb.group({
      BuildingId: ['', Validators.required],
      BuildingName: ['', Validators.required],
    });

    this.toastr.overlayContainer = this.toastContainer;
  }
  ngOnInit() {
  }

  onSubmit() {
    if (this.newBuilding.valid) {
      this.http.post('api/buildings', this.newBuilding.value).toPromise().then(
        (response: any) => {
          this.toastr.success('Building successfully added.');
          this.newBuilding.reset();
        },
        (error: any) => {
          this.toastr.error('An unknown error occurred');
          console.log(error);
        });
    }
  }
}

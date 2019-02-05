import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewReservationsComponent } from './view-reservation.component';

describe('ViewReservationComponent', () => {
  let component: ViewReservationsComponent;
  let fixture: ComponentFixture<ViewReservationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ViewReservationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewReservationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

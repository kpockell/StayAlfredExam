import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UnitViewComponent } from './components/unit-view/unit-view.component';
import { AddUnitComponent } from './components/add-unit/add-unit.component';

@NgModule({
  declarations: [UnitViewComponent, AddUnitComponent],
  imports: [
    CommonModule
  ]
})
export class UnitModule { }

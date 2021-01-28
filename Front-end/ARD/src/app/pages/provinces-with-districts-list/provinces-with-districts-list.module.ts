import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProvincesWithDistrictsListRoutingModule } from './provinces-with-districts-list-routing.module';
import { ProvincesWithDistrictsListComponent } from './provinces-with-districts-list.component';

@NgModule({
  declarations: [ProvincesWithDistrictsListComponent],
  imports: [
    CommonModule,
    ProvincesWithDistrictsListRoutingModule
  ]
})
export class ProvincesWithDistrictsListModule { }

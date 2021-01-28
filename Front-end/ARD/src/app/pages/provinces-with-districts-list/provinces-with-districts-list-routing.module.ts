import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProvincesWithDistrictsListComponent } from './provinces-with-districts-list.component';

const routes: Routes = [
  { path: '', component: ProvincesWithDistrictsListComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProvincesWithDistrictsListRoutingModule { }

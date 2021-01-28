import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'formStudent',
    loadChildren: () => import('./pages/student-form/student-form.module').then(m => m.StudentFormModule),
  },
  {
    path: 'listStudent',
    loadChildren: () => import('./pages/student-list/student-list.module').then(m => m.StudentListModule),
  },
  {
    path: 'formAddress',
    loadChildren: () => import('./pages/address-form/address-form.module').then(m => m.AddressFormModule),
  },
  {
    path: 'listAddress',
    loadChildren: () => import('./pages/address-list/address-list.module').then(m => m.AddressListModule),
  },
  {path: '', redirectTo: '/formStudent', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

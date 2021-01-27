import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddressListComponent } from './address-list.component';

import { AddressListRoutingModule } from './address-list-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [AddressListComponent],
  imports: [
    CommonModule,
    AddressListRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class AddressListModule { }

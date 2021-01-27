import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AddressService } from 'src/app/services/address.service';

import { NewAddress } from '../../models/newAddress';

@Component({
  selector: 'app-address-form',
  templateUrl: './address-form.component.html',
  styleUrls: ['./address-form.component.css']
})
export class AddressFormComponent implements OnInit {

  registerForm: FormGroup;
  newAddress: NewAddress;

  constructor(private addressService: AddressService) { }

  ngOnInit(): void {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = new FormGroup({
      province: new FormControl(''),
      district: new FormControl(''),
      addressDetail: new FormControl('')
    }
    )
  }

  register() {
    this.newAddress = Object.assign({}, this.registerForm.value);
    this.addressService.addAddress(this.newAddress);
    console.log(this.newAddress);
  }
}

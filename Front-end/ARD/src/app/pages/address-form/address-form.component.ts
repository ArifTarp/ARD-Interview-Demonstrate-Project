import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
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

  header:string;
  buttonText:string;

  constructor(private addressService: AddressService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.setValuesByRoute();
  }

  setValuesByRoute() {
    this.createRegisterForm();
    var provinceName = this.route.snapshot.paramMap.get('provinceName');
    var districtName = this.route.snapshot.paramMap.get('districtName');
    var addressDetail = this.route.snapshot.paramMap.get('addressDetail');

    this.registerForm.get('province').setValue(provinceName, { onlySelf: true })
    this.registerForm.get('district').setValue(districtName, { onlySelf: true })
    this.registerForm.get('addressDetail').setValue(addressDetail, { onlySelf: true })    

    if (provinceName && districtName && addressDetail) {
      this.header = "Update Address";
      this.buttonText = "Update";
    }
    else{
      this.header = "Add Address";
      this.buttonText = "Register";
    }
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

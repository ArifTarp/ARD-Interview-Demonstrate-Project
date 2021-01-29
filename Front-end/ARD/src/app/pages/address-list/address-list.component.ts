import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Address } from 'src/app/models/Address';
import { AddressService } from 'src/app/services/address.service';

@Component({
  selector: 'app-address-list',
  templateUrl: './address-list.component.html',
  styleUrls: ['./address-list.component.css']
})
export class AddressListComponent implements OnInit {

  addresses: Address[];

  constructor(private addressService: AddressService, private router: Router) { }

  ngOnInit(): void {
    this.getAddresses();
  }

  getAddresses(){
    this.addressService.getAddressesWithProvinceAndDistrictAndStudent().subscribe(data => {
      this.addresses = data;
    });
  }
}

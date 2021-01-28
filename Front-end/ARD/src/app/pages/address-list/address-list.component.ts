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
    this.addressService.getAddressesWithProvinceAndDistrictAndStudents().subscribe(data => {
      this.addresses = data;
    });
  }

  edit(addressId){
    var address = this.addresses.find(a=>a.id==addressId);
    this.router.navigate(['/formAddress',
    {
      id:address.id,
      provinceName:address.province.name,
      districtName:address.district.name,
      addressDetail:address.addressDetail
    }]);
  }

  delete(addressId){
    this.addressService.deleteAddress(addressId);
  }

}

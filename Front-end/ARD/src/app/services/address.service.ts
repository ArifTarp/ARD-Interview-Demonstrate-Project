import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from '@angular/router';

import { Province } from '../models/Province';
import { Observable } from "rxjs";

import { NewAddress } from "../models/newAddress";
import { AlertifyService } from "./alertify.service";
import { Address } from "../models/Address";

@Injectable({
    providedIn: "root"
})
export class AddressService {
    path = "https://localhost:44332/api/";

    constructor(private httpClient: HttpClient, private router: Router, private alertifyService: AlertifyService) { }

    public getProvincesWithDistricts(): Observable<Province[]> {
        return this.httpClient.get<Province[]>(this.path + "provinces/getAllWithDistricts");
    }

    public addAddress(newAddress: NewAddress): void {
        this.httpClient.post<NewAddress>(this.path + "addresses/add", newAddress).subscribe(data => {
            //this.router.navigateByUrl('/studentDetail/' + String(data.id))
            this.alertifyService.success("Registrary of the address named " + data.province + "/" + data.district + " is successful");
        });
    }

    public getAddressesWithProvinceAndDistrictAndStudents(): Observable<Address[]> {
        return this.httpClient.get<Address[]>(this.path + "addresses/getAllWithProvinceAndDistrictAndStudents");
    }

    public deleteAddress(addressId: number): void {
        this.httpClient.delete(this.path + "addresses/delete/" + addressId).subscribe(data=>{
          this.alertifyService.success("The address is deleted successful");
          window.location.reload();
        });
    }
}

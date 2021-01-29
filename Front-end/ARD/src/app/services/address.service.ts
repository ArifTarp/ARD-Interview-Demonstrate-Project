import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from '@angular/router';
import { Observable } from "rxjs";

import { AlertifyService } from "./alertify.service";
import { Address } from "../models/Address";

@Injectable({
    providedIn: "root"
})
export class AddressService {
    path = "https://localhost:44332/api/";

    constructor(private httpClient: HttpClient, private router: Router, private alertifyService: AlertifyService) { }

    public getAddressesWithProvinceAndDistrictAndStudent(): Observable<Address[]> {
        return this.httpClient.get<Address[]>(this.path + "addresses/getAllWithProvinceAndDistrictAndStudent");
    }
}

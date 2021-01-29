import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from '@angular/router';

import { Province } from '../models/Province';
import { Observable } from "rxjs";

@Injectable({
    providedIn: "root"
})
export class ProvinceService {
    path = "https://localhost:44332/api/";

    constructor(private httpClient: HttpClient) { }

    public getProvincesWithDistricts(): Observable<Province[]> {
        return this.httpClient.get<Province[]>(this.path + "provinces/getAllWithDistricts");
    }
}

import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from '@angular/router';

import { NewStudent } from "../models/newStudent";
import { AlertifyService } from "./alertify.service";

@Injectable({
    providedIn: "root"
})
export class StudentService {
    path = "https://localhost:44332/api/";

    constructor(private httpClient: HttpClient, private router: Router, private alertifyService: AlertifyService) { }

    public addStudent(newStudent: NewStudent): void {
        this.httpClient.post<NewStudent>(this.path + "students/add", newStudent).subscribe(data => {
            //this.router.navigateByUrl('/studentDetail/' + String(data.id))
            this.alertifyService.success("Registrary of the student named " + data.firstName + data.lastName + " is successful");
        });
    }
}

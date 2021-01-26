import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from '@angular/router';

import { Student } from '../models/student';

@Injectable({
    providedIn: "root"
})
export class StudentService {
    path = "https://localhost:44348/api/";

    constructor(private httpClient: HttpClient, private router: Router) { }

    public addStudent(student: Student): void {
        this.httpClient.post<Student>(this.path + "students/add", student).subscribe(data => {
            this.router.navigateByUrl('/studentDetail/' + String(data.id))
        });
    }
}
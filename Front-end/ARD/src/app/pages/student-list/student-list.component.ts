import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Student } from 'src/app/models/student';
import { AlertifyService } from 'src/app/services/alertify.service';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {

  students: Student[];

  constructor(
    private studentService: StudentService, 
    private router: Router, 
    private alertifyService: AlertifyService) { }

  ngOnInit(): void {
    this.getStudents();
  }

  getStudents(){
    this.studentService.getStudents().subscribe(data => {
      this.students = data;
    },error=>{
      this.alertifyService.error("Get list of student is unsuccessful");
    });
  }

  edit(studentId){
    var student = this.students.find(s=>s.id==studentId);
    this.router.navigate(['/formStudent',
    {
      id:student.id,
      firstName:student.firstName,
      lastName:student.lastName,
      schoolIdentity:student.schoolIdentity,
      provinceId:student.address.province.id,
      districtId:student.address.district.id,
      addressDetail:student.address.addressDetail
    }]);
  }

  delete(studentId){
    this.studentService.deleteStudent(studentId);
  }
}

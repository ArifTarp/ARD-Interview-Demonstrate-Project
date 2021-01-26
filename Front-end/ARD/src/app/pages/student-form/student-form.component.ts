import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

import { Student } from './../../models/student';
import { Address } from './../../models/address';


@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.css']
})
export class StudentFormComponent implements OnInit {

  student: Student;
  registerForm: FormGroup;
  address: Address;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      schoolIdentity: new FormControl(''),
      address: new FormControl('')
    }
    )
  }

  changeProvince(e) {
    
    /*this.fruits.setValue(e.target.value, {
      onlySelf: true
    })*/
  }

  changeDistrict(e) {
    
  }

  register(){}
}

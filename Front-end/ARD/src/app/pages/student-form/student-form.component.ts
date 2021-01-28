import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

import { NewStudent } from './../../models/newStudent';
import { Province } from './../../models/province';

import { StudentService } from 'src/app/services/student.service';
import { AddressService } from 'src/app/services/address.service';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.css']
})
export class StudentFormComponent implements OnInit {

  newStudent: NewStudent;
  registerForm: FormGroup;

  provinces: Province[] = [];

  selectedProvince: Province;

  header:string;
  buttonText:string;
  isUpdate: boolean;

  constructor(private formBuilder: FormBuilder, private studentService: StudentService, private addressService: AddressService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.getProvincesWithDistricts(()=>this.setValuesByRoute());
    this.setStaticsValue();
  }

  getProvincesWithDistricts(callback) {
    this.addressService.getProvincesWithDistricts().subscribe(data => {
      this.provinces = data;
      callback();
    });
  }

  setValuesByRoute() {
    this.createRegisterForm();
    var firstName = this.route.snapshot.paramMap.get('firstName');
    var lastName = this.route.snapshot.paramMap.get('lastName');
    var schoolIdentity = this.route.snapshot.paramMap.get('schoolIdentity');
    var provinceId = parseInt(this.route.snapshot.paramMap.get('provinceId'));
    var districtId = parseInt(this.route.snapshot.paramMap.get('districtId'));   

    if (firstName && lastName && schoolIdentity && provinceId && districtId) {
      this.registerForm.get('firstName').setValue(firstName, { onlySelf: true })
      this.registerForm.get('lastName').setValue(lastName, { onlySelf: true })
      this.registerForm.get('schoolIdentity').setValue(schoolIdentity, { onlySelf: true })
      this.registerForm.get('provinceId').setValue(provinceId, { onlySelf: true })
      this.registerForm.get('districtId').setValue(districtId, { onlySelf: true }) 
      
      this.selectedProvince = this.provinces.find(p => p.id == parseInt(this.route.snapshot.paramMap.get('provinceId')));
      this.isUpdate = true;
    }
    else{
      this.isUpdate = false;
    }
  }

  createRegisterForm() {
    this.registerForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      schoolIdentity: new FormControl(''),
      provinceId: new FormControl(0),
      districtId: new FormControl(0)
    })
  }

  setStaticsValue(){
    if (this.isUpdate) {
      this.header = "Update Student";
      this.buttonText = "Update";
    }
    else {
      this.header = "Add Student";
      this.buttonText = "Register";
    }
  }

  changeProvince(e) {
    this.selectedProvince = this.provinces.find(p => p.id == e.target.value);
    this.registerForm.get('provinceId').setValue(parseInt(e.target.value), { onlySelf: true })
  }

  changeDistrict(e) {
    this.registerForm.get('districtId').setValue(parseInt(e.target.value), { onlySelf: true })
  }

  register() {
    this.newStudent = {
      firstName:this.registerForm.value.firstName,
      lastName:this.registerForm.value.lastName,
      schoolIdentity:this.registerForm.value.schoolIdentity,
      provinceId:parseInt(this.registerForm.value.provinceId),
      districtId:parseInt(this.registerForm.value.districtId),
    }
    
    if (this.isUpdate) {
      this.newStudent.id = parseInt(this.route.snapshot.paramMap.get('id'));
      this.studentService.updateStudent(this.newStudent);
    }
    else{
      this.studentService.addStudent(this.newStudent);
    }
  }
}

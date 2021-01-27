import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

import { NewStudent } from './../../models/newStudent';
import { Province } from './../../models/province';

import { StudentService } from 'src/app/services/student.service';
import { AddressService } from 'src/app/services/address.service';
import { District } from 'src/app/models/district';
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
  initialFormModel;

  constructor(private formBuilder: FormBuilder, private studentService: StudentService, private addressService: AddressService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.setInitialFormModel();
    this.createRegisterForm();
    this.getProvincesWithDistricts();
  }

  setInitialFormModel(){
    this.initialFormModel = {
      firstName: this.route.snapshot.paramMap.get('firstName'),
      lastName: this.route.snapshot.paramMap.get('lastName'),
      schoolIdentity: this.route.snapshot.paramMap.get('schoolIdentity'),
      province: this.route.snapshot.paramMap.get('province'),
      district: this.route.snapshot.paramMap.get('district'),
    }
  }

  getProvincesWithDistricts() {
    this.addressService.getProvincesWithDistricts().subscribe(data => {
      this.provinces = data;
    });
  }

  createRegisterForm() {
    this.registerForm = new FormGroup({
      firstName: new FormControl(this.initialFormModel['firstName']),
      lastName: new FormControl(this.initialFormModel['lastName']),
      schoolIdentity: new FormControl(this.initialFormModel['schoolIdentity']),
      provinceId: new FormControl(this.initialFormModel['provinceId']),
      districtId: new FormControl(this.initialFormModel['districtId'])
    })
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
    
    this.studentService.addStudent(this.newStudent);
  }
}

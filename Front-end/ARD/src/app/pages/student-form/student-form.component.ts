import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { NewStudent } from './../../models/newStudent';
import { Province } from './../../models/province';

import { StudentService } from 'src/app/services/student.service';
import { ActivatedRoute } from '@angular/router';
import { District } from 'src/app/models/district';
import { ProvinceService } from 'src/app/services/province.service';
import { AlertifyService } from 'src/app/services/alertify.service';


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
  selectedDistrict: District;


  header: string;
  buttonText: string;
  isUpdate: boolean;

  isSubmitted: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private studentService: StudentService,
    private provinceService: ProvinceService,
    private route: ActivatedRoute,
    private alertifyService: AlertifyService) { }

  ngOnInit(): void {
    this.getProvincesWithDistricts(() => this.setValuesByRoute());
  }

  getProvincesWithDistricts(callback) {
    this.provinceService.getProvincesWithDistricts().subscribe(data => {
      this.provinces = data;
      callback();
    });
  }

  setValuesByRoute() {
    this.createRegisterForm();
    var firstName = this.getFromRoute("firstName");
    var lastName = this.getFromRoute("lastName");
    var schoolIdentity = this.getFromRoute("schoolIdentity");
    var provinceId = this.getFromRoute("provinceId");
    var districtId = this.getFromRoute("districtId");
    var addressDetail = this.getFromRoute("addressDetail");

    if (firstName && lastName && schoolIdentity && provinceId && districtId) {
      this.setRegisterFormFromRoute(firstName, lastName, schoolIdentity, provinceId, districtId, addressDetail);

      this.selectedProvince = this.provinces.find(p => p.id == parseInt(this.route.snapshot.paramMap.get('provinceId')));

      this.setSelectedDistrict(districtId);

      this.isUpdate = true;
    }
    else {
      this.isUpdate = false;
    }
    this.setStaticsValue();
  }

  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      schoolIdentity: ['', [Validators.required]],
      provinceId: [0, [Validators.required]],
      districtId: [0, [Validators.required]],
      addressDetail: ['', [Validators.required]],
    })
  }

  getFromRoute(param) {
    return this.route.snapshot.paramMap.get(param);
  }

  setRegisterFormFromRoute(firstName, lastName, schoolIdentity, provinceId, districtId, addressDetail) {
    this.setValueToRegisterForm('firstName', firstName);
    this.setValueToRegisterForm('lastName', lastName);
    this.setValueToRegisterForm('schoolIdentity', schoolIdentity);
    this.setValueToRegisterForm('provinceId', provinceId);
    this.setValueToRegisterForm('districtId', districtId);
    this.setValueToRegisterForm('addressDetail', addressDetail);
  }

  setValueToRegisterForm(to, from) {
    this.registerForm.get(to).setValue(from, { onlySelf: true })
  }

  setSelectedDistrict(districtId) {
    for (let index = 0; index < this.provinces.length; index++) {
      var district = this.provinces[index].districts.find(d => d.id == districtId)
      if (district) {
        this.selectedDistrict = district;
        break;
      }
    }
  }

  setStaticsValue() {
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
    this.setSelectedDistrict(e.target.value);
    this.registerForm.get('districtId').setValue(parseInt(e.target.value), { onlySelf: true })
  }

  register() {
    this.isSubmitted = true;
    var formValues = this.registerForm.value;

    if (!this.registerForm.valid || this.registerForm.get('provinceId').value == 0 || this.registerForm.get('districtId').value == 0 ) {
      this.alertifyService.warning("Please fill empty fields...");
    }
    else {
      this.newStudent = {
        firstName: formValues.firstName,
        lastName: formValues.lastName,
        schoolIdentity: formValues.schoolIdentity,
        provinceId: parseInt(formValues.provinceId),
        districtId: parseInt(formValues.districtId),
        addressDetail: formValues.addressDetail
      }

      if (this.isUpdate) {
        this.newStudent.id = parseInt(this.getFromRoute('id'));
        this.studentService.updateStudent(this.newStudent);
      }
      else {
        this.studentService.addStudent(this.newStudent);
      }
    }
  }
}

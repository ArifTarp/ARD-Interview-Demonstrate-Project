import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentFormRoutingModule } from './student-form-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { StudentFormComponent } from './student-form.component';

import { StudentService } from '../../services/student.service';

@NgModule({
  declarations: [StudentFormComponent],
  imports: [
    CommonModule,
    StudentFormRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [StudentService]
})
export class StudentFormModule { }

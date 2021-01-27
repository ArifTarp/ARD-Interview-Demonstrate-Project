import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentListComponent } from './student-list.component';
import { StudentListRoutingModule } from './student-list-routing.module';



@NgModule({
  declarations: [StudentListComponent],
  imports: [
    CommonModule,
    StudentListRoutingModule
  ]
})
export class StudentListModule { }

import { District } from "./district";
import { Province } from "./Province";
import { Student } from "./student";

export class Address {
    id:number;
    province:Province;
    district:District;
    addressDetail:string;
    students:Student;
}
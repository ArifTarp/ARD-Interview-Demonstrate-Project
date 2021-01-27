import { District } from "./district";
import { Province } from "./Province";

export class Address {
    id?:number;
    province:Province;
    district:District;
    addressDetail?:string;
}
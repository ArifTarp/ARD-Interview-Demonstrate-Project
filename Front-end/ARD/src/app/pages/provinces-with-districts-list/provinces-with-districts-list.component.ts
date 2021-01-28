import { Component, OnInit } from '@angular/core';
import { Province } from 'src/app/models/province';
import { ProvinceService } from 'src/app/services/province.service';

@Component({
  selector: 'app-provinces-with-districts-list',
  templateUrl: './provinces-with-districts-list.component.html',
  styleUrls: ['./provinces-with-districts-list.component.css']
})
export class ProvincesWithDistrictsListComponent implements OnInit {

  provinces:Province[];
  constructor(private provinceService:ProvinceService) { }

  ngOnInit(): void {
    this.getProvinces();
  }

  getProvinces(){
    this.provinceService.getProvincesWithDistricts().subscribe(data => {
      this.provinces = data;
    });
  }
}

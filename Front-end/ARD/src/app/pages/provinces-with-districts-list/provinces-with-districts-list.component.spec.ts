import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvincesWithDistrictsListComponent } from './provinces-with-districts-list.component';

describe('ProvincesWithDistrictsListComponent', () => {
  let component: ProvincesWithDistrictsListComponent;
  let fixture: ComponentFixture<ProvincesWithDistrictsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProvincesWithDistrictsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvincesWithDistrictsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

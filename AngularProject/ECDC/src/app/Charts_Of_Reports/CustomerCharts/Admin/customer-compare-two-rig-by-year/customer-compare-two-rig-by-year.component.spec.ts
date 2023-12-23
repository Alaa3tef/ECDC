import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerCompareTwoRigByYearComponent } from './customer-compare-two-rig-by-year.component';

describe('CustomerCompareTwoRigByYearComponent', () => {
  let component: CustomerCompareTwoRigByYearComponent;
  let fixture: ComponentFixture<CustomerCompareTwoRigByYearComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerCompareTwoRigByYearComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerCompareTwoRigByYearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

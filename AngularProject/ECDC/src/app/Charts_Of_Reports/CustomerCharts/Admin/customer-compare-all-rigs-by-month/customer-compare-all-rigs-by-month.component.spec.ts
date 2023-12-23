import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerCompareAllRigsByMonthComponent } from './customer-compare-all-rigs-by-month.component';

describe('CustomerCompareAllRigsByMonthComponent', () => {
  let component: CustomerCompareAllRigsByMonthComponent;
  let fixture: ComponentFixture<CustomerCompareAllRigsByMonthComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerCompareAllRigsByMonthComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerCompareAllRigsByMonthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

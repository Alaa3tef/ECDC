import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerCompareByMonthUserComponent } from './customer-compare-by-month-user.component';

describe('CustomerCompareByMonthUserComponent', () => {
  let component: CustomerCompareByMonthUserComponent;
  let fixture: ComponentFixture<CustomerCompareByMonthUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerCompareByMonthUserComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerCompareByMonthUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

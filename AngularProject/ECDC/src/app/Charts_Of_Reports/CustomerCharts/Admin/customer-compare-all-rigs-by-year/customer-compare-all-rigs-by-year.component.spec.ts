import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerCompareAllRigsByYearComponent } from './customer-compare-all-rigs-by-year.component';

describe('CustomerCompareAllRigsByYearComponent', () => {
  let component: CustomerCompareAllRigsByYearComponent;
  let fixture: ComponentFixture<CustomerCompareAllRigsByYearComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerCompareAllRigsByYearComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerCompareAllRigsByYearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

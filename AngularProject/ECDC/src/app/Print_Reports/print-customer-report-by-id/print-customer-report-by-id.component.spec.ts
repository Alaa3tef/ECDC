import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintCustomerReportByIdComponent } from './print-customer-report-by-id.component';

describe('PrintCustomerReportByIdComponent', () => {
  let component: PrintCustomerReportByIdComponent;
  let fixture: ComponentFixture<PrintCustomerReportByIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintCustomerReportByIdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintCustomerReportByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

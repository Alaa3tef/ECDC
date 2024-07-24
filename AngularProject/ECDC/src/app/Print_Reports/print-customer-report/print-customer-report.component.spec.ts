import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintCustomerReportComponent } from './print-customer-report.component';

describe('PrintCustomerReportComponent', () => {
  let component: PrintCustomerReportComponent;
  let fixture: ComponentFixture<PrintCustomerReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintCustomerReportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintCustomerReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

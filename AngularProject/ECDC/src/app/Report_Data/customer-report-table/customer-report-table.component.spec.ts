import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerReportTableComponent } from './customer-report-table.component';

describe('CustomerReportTableComponent', () => {
  let component: CustomerReportTableComponent;
  let fixture: ComponentFixture<CustomerReportTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerReportTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerReportTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

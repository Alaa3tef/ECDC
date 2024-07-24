import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCustomerReportComponent } from './edit-customer-report.component';

describe('EditCustomerReportComponent', () => {
  let component: EditCustomerReportComponent;
  let fixture: ComponentFixture<EditCustomerReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditCustomerReportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditCustomerReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

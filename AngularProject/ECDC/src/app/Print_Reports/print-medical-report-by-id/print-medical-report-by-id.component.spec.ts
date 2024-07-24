import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintMedicalReportByIdComponent } from './print-medical-report-by-id.component';

describe('PrintMedicalReportByIdComponent', () => {
  let component: PrintMedicalReportByIdComponent;
  let fixture: ComponentFixture<PrintMedicalReportByIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintMedicalReportByIdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintMedicalReportByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

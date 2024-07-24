import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintMedicalReportComponent } from './print-medical-report.component';

describe('PrintMedicalReportComponent', () => {
  let component: PrintMedicalReportComponent;
  let fixture: ComponentFixture<PrintMedicalReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintMedicalReportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintMedicalReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

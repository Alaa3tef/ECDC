import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetMedicalReportByMonthWithChartComponent } from './get-medical-report-by-month-with-chart.component';

describe('GetMedicalReportByMonthWithChartComponent', () => {
  let component: GetMedicalReportByMonthWithChartComponent;
  let fixture: ComponentFixture<GetMedicalReportByMonthWithChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetMedicalReportByMonthWithChartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetMedicalReportByMonthWithChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetMedicalHistoryReportByYearWithChartComponent } from './get-medical-history-report-by-year-with-chart.component';

describe('GetMedicalHistoryReportByYearWithChartComponent', () => {
  let component: GetMedicalHistoryReportByYearWithChartComponent;
  let fixture: ComponentFixture<GetMedicalHistoryReportByYearWithChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetMedicalHistoryReportByYearWithChartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetMedicalHistoryReportByYearWithChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

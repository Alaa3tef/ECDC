import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetMedicalReportByYearWithChartComponent } from './get-medical-report-by-year-with-chart.component';

describe('GetMedicalReportByYearWithChartComponent', () => {
  let component: GetMedicalReportByYearWithChartComponent;
  let fixture: ComponentFixture<GetMedicalReportByYearWithChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetMedicalReportByYearWithChartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetMedicalReportByYearWithChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

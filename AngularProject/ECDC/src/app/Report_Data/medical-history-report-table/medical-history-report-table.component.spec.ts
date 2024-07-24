import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicalHistoryReportTableComponent } from './medical-history-report-table.component';

describe('MedicalHistoryReportTableComponent', () => {
  let component: MedicalHistoryReportTableComponent;
  let fixture: ComponentFixture<MedicalHistoryReportTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MedicalHistoryReportTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MedicalHistoryReportTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

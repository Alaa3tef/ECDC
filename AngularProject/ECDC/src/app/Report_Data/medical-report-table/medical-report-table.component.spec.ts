import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicalReportTableComponent } from './medical-report-table.component';

describe('MedicalReportTableComponent', () => {
  let component: MedicalReportTableComponent;
  let fixture: ComponentFixture<MedicalReportTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MedicalReportTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MedicalReportTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

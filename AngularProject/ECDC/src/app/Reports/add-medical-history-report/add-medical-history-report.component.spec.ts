import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMedicalHistoryReportComponent } from './add-medical-history-report.component';

describe('AddMedicalHistoryReportComponent', () => {
  let component: AddMedicalHistoryReportComponent;
  let fixture: ComponentFixture<AddMedicalHistoryReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddMedicalHistoryReportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddMedicalHistoryReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

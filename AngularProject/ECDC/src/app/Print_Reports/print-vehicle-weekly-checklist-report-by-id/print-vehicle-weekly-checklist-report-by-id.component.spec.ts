import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintVehicleWeeklyChecklistReportByIdComponent } from './print-vehicle-weekly-checklist-report-by-id.component';

describe('PrintVehicleWeeklyChecklistReportByIdComponent', () => {
  let component: PrintVehicleWeeklyChecklistReportByIdComponent;
  let fixture: ComponentFixture<PrintVehicleWeeklyChecklistReportByIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintVehicleWeeklyChecklistReportByIdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintVehicleWeeklyChecklistReportByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

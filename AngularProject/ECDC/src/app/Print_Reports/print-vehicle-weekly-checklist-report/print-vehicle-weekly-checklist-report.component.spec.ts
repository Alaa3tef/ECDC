import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintVehicleWeeklyChecklistReportComponent } from './print-vehicle-weekly-checklist-report.component';

describe('PrintVehicleWeeklyChecklistReportComponent', () => {
  let component: PrintVehicleWeeklyChecklistReportComponent;
  let fixture: ComponentFixture<PrintVehicleWeeklyChecklistReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintVehicleWeeklyChecklistReportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintVehicleWeeklyChecklistReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

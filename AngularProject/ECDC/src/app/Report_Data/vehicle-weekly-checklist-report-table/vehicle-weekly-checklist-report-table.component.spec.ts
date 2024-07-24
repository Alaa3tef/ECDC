import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleWeeklyChecklistReportTableComponent } from './vehicle-weekly-checklist-report-table.component';

describe('VehicleWeeklyChecklistReportTableComponent', () => {
  let component: VehicleWeeklyChecklistReportTableComponent;
  let fixture: ComponentFixture<VehicleWeeklyChecklistReportTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VehicleWeeklyChecklistReportTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VehicleWeeklyChecklistReportTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

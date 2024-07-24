import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditVehicleWeeklyChecklistReportComponent } from './edit-vehicle-weekly-checklist-report.component';

describe('EditVehicleWeeklyChecklistReportComponent', () => {
  let component: EditVehicleWeeklyChecklistReportComponent;
  let fixture: ComponentFixture<EditVehicleWeeklyChecklistReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditVehicleWeeklyChecklistReportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditVehicleWeeklyChecklistReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddVehicleWeeklyChecklistReportComponent } from './add-vehicle-weekly-checklist-report.component';

describe('AddVehicleWeeklyChecklistReportComponent', () => {
  let component: AddVehicleWeeklyChecklistReportComponent;
  let fixture: ComponentFixture<AddVehicleWeeklyChecklistReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddVehicleWeeklyChecklistReportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddVehicleWeeklyChecklistReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

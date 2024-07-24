import { TestBed } from '@angular/core/testing';

import { AddNewVehicleWeeklyChecklistReportService } from './add-new-vehicle-weekly-checklist-report.service';

describe('AddNewVehicleWeeklyChecklistReportService', () => {
  let service: AddNewVehicleWeeklyChecklistReportService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddNewVehicleWeeklyChecklistReportService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

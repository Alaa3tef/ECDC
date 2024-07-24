import { TestBed } from '@angular/core/testing';

import { AddNewDailyLiftingReportService } from './add-new-daily-lifting-report.service';

describe('AddNewDailyLiftingReportService', () => {
  let service: AddNewDailyLiftingReportService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddNewDailyLiftingReportService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

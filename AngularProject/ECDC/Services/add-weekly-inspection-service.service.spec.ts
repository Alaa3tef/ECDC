import { TestBed } from '@angular/core/testing';

import { AddWeeklyInspectionServiceService } from './add-weekly-inspection-service.service';

describe('AddWeeklyInspectionServiceService', () => {
  let service: AddWeeklyInspectionServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddWeeklyInspectionServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

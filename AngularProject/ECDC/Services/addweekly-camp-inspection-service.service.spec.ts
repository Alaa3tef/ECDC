import { TestBed } from '@angular/core/testing';

import { AddweeklyCampInspectionServiceService } from './addweekly-camp-inspection-service.service';

describe('AddweeklyCampInspectionServiceService', () => {
  let service: AddweeklyCampInspectionServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddweeklyCampInspectionServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { WeeklyClinicService } from './weekly-clinic.service';

describe('WeeklyClinicService', () => {
  let service: WeeklyClinicService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WeeklyClinicService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

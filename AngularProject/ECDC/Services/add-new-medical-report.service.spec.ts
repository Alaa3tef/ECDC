import { TestBed } from '@angular/core/testing';

import { AddNewMedicalReportService } from './add-new-medical-report.service';

describe('AddNewMedicalReportService', () => {
  let service: AddNewMedicalReportService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddNewMedicalReportService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

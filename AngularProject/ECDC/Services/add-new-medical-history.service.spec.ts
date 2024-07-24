import { TestBed } from '@angular/core/testing';

import { AddNewMedicalHistoryService } from './add-new-medical-history.service';

describe('AddNewMedicalHistoryService', () => {
  let service: AddNewMedicalHistoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddNewMedicalHistoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

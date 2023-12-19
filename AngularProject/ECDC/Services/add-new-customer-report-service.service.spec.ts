import { TestBed } from '@angular/core/testing';

import { AddNewCustomerReportServiceService } from './add-new-customer-report-service.service';

describe('AddNewCustomerReportServiceService', () => {
  let service: AddNewCustomerReportServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddNewCustomerReportServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

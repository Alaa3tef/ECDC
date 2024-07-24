import { TestBed } from '@angular/core/testing';

import { RigCertificatesService } from './rig-certificates.service';

describe('RigCertificatesService', () => {
  let service: RigCertificatesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RigCertificatesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

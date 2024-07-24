import { TestBed } from '@angular/core/testing';

import { AllEditGuard } from './all-edit.guard';

describe('AllEditGuard', () => {
  let guard: AllEditGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(AllEditGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});

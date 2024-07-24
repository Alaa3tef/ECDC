import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CraneDailyLiftingReportsComponent } from './crane-daily-lifting-reports.component';

describe('CraneDailyLiftingReportsComponent', () => {
  let component: CraneDailyLiftingReportsComponent;
  let fixture: ComponentFixture<CraneDailyLiftingReportsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CraneDailyLiftingReportsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CraneDailyLiftingReportsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

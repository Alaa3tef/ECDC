import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintDailyLiftingReportByIdComponent } from './print-daily-lifting-report-by-id.component';

describe('PrintDailyLiftingReportByIdComponent', () => {
  let component: PrintDailyLiftingReportByIdComponent;
  let fixture: ComponentFixture<PrintDailyLiftingReportByIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintDailyLiftingReportByIdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintDailyLiftingReportByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

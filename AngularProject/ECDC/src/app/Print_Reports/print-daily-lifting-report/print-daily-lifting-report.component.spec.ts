import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintDailyLiftingReportComponent } from './print-daily-lifting-report.component';

describe('PrintDailyLiftingReportComponent', () => {
  let component: PrintDailyLiftingReportComponent;
  let fixture: ComponentFixture<PrintDailyLiftingReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintDailyLiftingReportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintDailyLiftingReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

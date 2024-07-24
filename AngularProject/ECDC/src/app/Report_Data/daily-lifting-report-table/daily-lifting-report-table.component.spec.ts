import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DailyLiftingReportTableComponent } from './daily-lifting-report-table.component';

describe('DailyLiftingReportTableComponent', () => {
  let component: DailyLiftingReportTableComponent;
  let fixture: ComponentFixture<DailyLiftingReportTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DailyLiftingReportTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DailyLiftingReportTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDailyLiftingReportComponent } from './add-daily-lifting-report.component';

describe('AddDailyLiftingReportComponent', () => {
  let component: AddDailyLiftingReportComponent;
  let fixture: ComponentFixture<AddDailyLiftingReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddDailyLiftingReportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddDailyLiftingReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

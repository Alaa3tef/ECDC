import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditDailyLiftingReportComponent } from './edit-daily-lifting-report.component';

describe('EditDailyLiftingReportComponent', () => {
  let component: EditDailyLiftingReportComponent;
  let fixture: ComponentFixture<EditDailyLiftingReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditDailyLiftingReportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditDailyLiftingReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

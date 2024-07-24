import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCraneDailyLiftingReportsComponent } from './add-crane-daily-lifting-reports.component';

describe('AddCraneDailyLiftingReportsComponent', () => {
  let component: AddCraneDailyLiftingReportsComponent;
  let fixture: ComponentFixture<AddCraneDailyLiftingReportsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCraneDailyLiftingReportsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddCraneDailyLiftingReportsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeeklyClinicChartComponent } from './weekly-clinic-chart.component';

describe('WeeklyClinicChartComponent', () => {
  let component: WeeklyClinicChartComponent;
  let fixture: ComponentFixture<WeeklyClinicChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeeklyClinicChartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WeeklyClinicChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeeklyInspectionComponent } from './weekly-inspection.component';

describe('WeeklyInspectionComponent', () => {
  let component: WeeklyInspectionComponent;
  let fixture: ComponentFixture<WeeklyInspectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeeklyInspectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WeeklyInspectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

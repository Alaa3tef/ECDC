import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeeklyInspectionByIdComponent } from './weekly-inspection-by-id.component';

describe('WeeklyInspectionByIdComponent', () => {
  let component: WeeklyInspectionByIdComponent;
  let fixture: ComponentFixture<WeeklyInspectionByIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeeklyInspectionByIdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WeeklyInspectionByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeeklyInspectionTableComponent } from './weekly-inspection-table.component';

describe('WeeklyInspectionTableComponent', () => {
  let component: WeeklyInspectionTableComponent;
  let fixture: ComponentFixture<WeeklyInspectionTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeeklyInspectionTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WeeklyInspectionTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

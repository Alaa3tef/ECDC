import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeeklyCampInspectionTableComponent } from './weekly-camp-inspection-table.component';

describe('WeeklyCampInspectionTableComponent', () => {
  let component: WeeklyCampInspectionTableComponent;
  let fixture: ComponentFixture<WeeklyCampInspectionTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeeklyCampInspectionTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WeeklyCampInspectionTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

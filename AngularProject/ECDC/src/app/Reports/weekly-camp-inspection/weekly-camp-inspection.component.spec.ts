import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeeklyCampInspectionComponent } from './weekly-camp-inspection.component';

describe('WeeklyCampInspectionComponent', () => {
  let component: WeeklyCampInspectionComponent;
  let fixture: ComponentFixture<WeeklyCampInspectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeeklyCampInspectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WeeklyCampInspectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

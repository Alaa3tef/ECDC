import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditWeeklyInspectionComponent } from './edit-weekly-inspection.component';

describe('EditWeeklyInspectionComponent', () => {
  let component: EditWeeklyInspectionComponent;
  let fixture: ComponentFixture<EditWeeklyInspectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditWeeklyInspectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditWeeklyInspectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

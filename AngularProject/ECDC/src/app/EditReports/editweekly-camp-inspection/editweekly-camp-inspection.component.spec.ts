import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditweeklyCampInspectionComponent } from './editweekly-camp-inspection.component';

describe('EditweeklyCampInspectionComponent', () => {
  let component: EditweeklyCampInspectionComponent;
  let fixture: ComponentFixture<EditweeklyCampInspectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditweeklyCampInspectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditweeklyCampInspectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

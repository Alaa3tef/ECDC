import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditWeeklyClinicComponent } from './edit-weekly-clinic.component';

describe('EditWeeklyClinicComponent', () => {
  let component: EditWeeklyClinicComponent;
  let fixture: ComponentFixture<EditWeeklyClinicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditWeeklyClinicComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditWeeklyClinicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

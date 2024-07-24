import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddWeeklyClinicComponent } from './add-weekly-clinic.component';

describe('AddWeeklyClinicComponent', () => {
  let component: AddWeeklyClinicComponent;
  let fixture: ComponentFixture<AddWeeklyClinicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddWeeklyClinicComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddWeeklyClinicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

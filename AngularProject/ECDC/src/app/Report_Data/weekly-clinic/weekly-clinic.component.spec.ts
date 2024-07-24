import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeeklyClinicComponent } from './weekly-clinic.component';

describe('WeeklyClinicComponent', () => {
  let component: WeeklyClinicComponent;
  let fixture: ComponentFixture<WeeklyClinicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WeeklyClinicComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WeeklyClinicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

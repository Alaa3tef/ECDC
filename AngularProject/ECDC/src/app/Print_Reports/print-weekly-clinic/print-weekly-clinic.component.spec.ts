import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintWeeklyClinicComponent } from './print-weekly-clinic.component';

describe('PrintWeeklyClinicComponent', () => {
  let component: PrintWeeklyClinicComponent;
  let fixture: ComponentFixture<PrintWeeklyClinicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintWeeklyClinicComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintWeeklyClinicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

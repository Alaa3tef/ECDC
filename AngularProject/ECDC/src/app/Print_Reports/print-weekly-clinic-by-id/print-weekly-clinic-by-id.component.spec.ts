import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintWeeklyClinicByIdComponent } from './print-weekly-clinic-by-id.component';

describe('PrintWeeklyClinicByIdComponent', () => {
  let component: PrintWeeklyClinicByIdComponent;
  let fixture: ComponentFixture<PrintWeeklyClinicByIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintWeeklyClinicByIdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintWeeklyClinicByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

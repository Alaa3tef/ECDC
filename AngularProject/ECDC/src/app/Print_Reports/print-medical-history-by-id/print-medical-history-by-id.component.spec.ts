import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintMedicalHistoryByIdComponent } from './print-medical-history-by-id.component';

describe('PrintMedicalHistoryByIdComponent', () => {
  let component: PrintMedicalHistoryByIdComponent;
  let fixture: ComponentFixture<PrintMedicalHistoryByIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintMedicalHistoryByIdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintMedicalHistoryByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

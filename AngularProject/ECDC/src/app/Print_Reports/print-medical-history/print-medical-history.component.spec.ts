import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintMedicalHistoryComponent } from './print-medical-history.component';

describe('PrintMedicalHistoryComponent', () => {
  let component: PrintMedicalHistoryComponent;
  let fixture: ComponentFixture<PrintMedicalHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintMedicalHistoryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintMedicalHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

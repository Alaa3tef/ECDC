import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintWeeklyInspectionComponent } from './print-weekly-inspection.component';

describe('PrintWeeklyInspectionComponent', () => {
  let component: PrintWeeklyInspectionComponent;
  let fixture: ComponentFixture<PrintWeeklyInspectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintWeeklyInspectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintWeeklyInspectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

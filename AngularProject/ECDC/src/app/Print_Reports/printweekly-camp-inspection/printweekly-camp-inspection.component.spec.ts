import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintweeklyCampInspectionComponent } from './printweekly-camp-inspection.component';

describe('PrintweeklyCampInspectionComponent', () => {
  let component: PrintweeklyCampInspectionComponent;
  let fixture: ComponentFixture<PrintweeklyCampInspectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintweeklyCampInspectionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintweeklyCampInspectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

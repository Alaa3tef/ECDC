import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintweeklyCampInspectionByIDComponent } from './printweekly-camp-inspection-by-id.component';

describe('PrintweeklyCampInspectionByIDComponent', () => {
  let component: PrintweeklyCampInspectionByIDComponent;
  let fixture: ComponentFixture<PrintweeklyCampInspectionByIDComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintweeklyCampInspectionByIDComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintweeklyCampInspectionByIDComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

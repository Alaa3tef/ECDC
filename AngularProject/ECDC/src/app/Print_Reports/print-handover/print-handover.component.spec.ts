import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintHandoverComponent } from './print-handover.component';

describe('PrintHandoverComponent', () => {
  let component: PrintHandoverComponent;
  let fixture: ComponentFixture<PrintHandoverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintHandoverComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintHandoverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

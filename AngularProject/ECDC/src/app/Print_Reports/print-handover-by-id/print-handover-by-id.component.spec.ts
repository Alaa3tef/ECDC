import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintHandoverByIdComponent } from './print-handover-by-id.component';

describe('PrintHandoverByIdComponent', () => {
  let component: PrintHandoverByIdComponent;
  let fixture: ComponentFixture<PrintHandoverByIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintHandoverByIdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintHandoverByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

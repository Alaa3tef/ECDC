import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintCorrectiveByIdComponent } from './print-corrective-by-id.component';

describe('PrintCorrectiveByIdComponent', () => {
  let component: PrintCorrectiveByIdComponent;
  let fixture: ComponentFixture<PrintCorrectiveByIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintCorrectiveByIdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintCorrectiveByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintCorrectiveComponent } from './print-corrective.component';

describe('PrintCorrectiveComponent', () => {
  let component: PrintCorrectiveComponent;
  let fixture: ComponentFixture<PrintCorrectiveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintCorrectiveComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintCorrectiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

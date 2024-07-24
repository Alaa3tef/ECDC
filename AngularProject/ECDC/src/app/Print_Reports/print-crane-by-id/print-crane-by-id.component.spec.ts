import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintCraneByIdComponent } from './print-crane-by-id.component';

describe('PrintCraneByIdComponent', () => {
  let component: PrintCraneByIdComponent;
  let fixture: ComponentFixture<PrintCraneByIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintCraneByIdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintCraneByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

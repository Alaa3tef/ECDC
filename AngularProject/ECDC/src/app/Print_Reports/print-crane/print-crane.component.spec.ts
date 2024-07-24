import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintCraneComponent } from './print-crane.component';

describe('PrintCraneComponent', () => {
  let component: PrintCraneComponent;
  let fixture: ComponentFixture<PrintCraneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintCraneComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintCraneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

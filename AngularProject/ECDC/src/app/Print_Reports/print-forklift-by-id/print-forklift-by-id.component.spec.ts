import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintForkliftByIdComponent } from './print-forklift-by-id.component';

describe('PrintForkliftByIdComponent', () => {
  let component: PrintForkliftByIdComponent;
  let fixture: ComponentFixture<PrintForkliftByIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintForkliftByIdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintForkliftByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

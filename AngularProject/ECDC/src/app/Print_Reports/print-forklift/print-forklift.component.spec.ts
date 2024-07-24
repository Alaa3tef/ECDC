import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintForkliftComponent } from './print-forklift.component';

describe('PrintForkliftComponent', () => {
  let component: PrintForkliftComponent;
  let fixture: ComponentFixture<PrintForkliftComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintForkliftComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintForkliftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

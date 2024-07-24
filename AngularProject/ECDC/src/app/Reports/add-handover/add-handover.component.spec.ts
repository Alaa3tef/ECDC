import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddHandoverComponent } from './add-handover.component';

describe('AddHandoverComponent', () => {
  let component: AddHandoverComponent;
  let fixture: ComponentFixture<AddHandoverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddHandoverComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddHandoverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

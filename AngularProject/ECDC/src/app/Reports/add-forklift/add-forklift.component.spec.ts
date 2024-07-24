import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddForkliftComponent } from './add-forklift.component';

describe('AddForkliftComponent', () => {
  let component: AddForkliftComponent;
  let fixture: ComponentFixture<AddForkliftComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddForkliftComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddForkliftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

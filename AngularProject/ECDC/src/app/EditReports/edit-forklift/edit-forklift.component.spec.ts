import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditForkliftComponent } from './edit-forklift.component';

describe('EditForkliftComponent', () => {
  let component: EditForkliftComponent;
  let fixture: ComponentFixture<EditForkliftComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditForkliftComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditForkliftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

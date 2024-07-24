import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCorrectiveObservationComponent } from './edit-corrective-observation.component';

describe('EditCorrectiveObservationComponent', () => {
  let component: EditCorrectiveObservationComponent;
  let fixture: ComponentFixture<EditCorrectiveObservationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditCorrectiveObservationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditCorrectiveObservationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

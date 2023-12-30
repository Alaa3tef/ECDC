import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCorrectiveObservationComponent } from './add-corrective-observation.component';

describe('AddCorrectiveObservationComponent', () => {
  let component: AddCorrectiveObservationComponent;
  let fixture: ComponentFixture<AddCorrectiveObservationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCorrectiveObservationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddCorrectiveObservationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

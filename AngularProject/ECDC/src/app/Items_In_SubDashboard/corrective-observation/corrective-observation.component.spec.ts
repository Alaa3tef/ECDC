import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorrectiveObservationComponent } from './corrective-observation.component';

describe('CorrectiveObservationComponent', () => {
  let component: CorrectiveObservationComponent;
  let fixture: ComponentFixture<CorrectiveObservationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CorrectiveObservationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CorrectiveObservationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

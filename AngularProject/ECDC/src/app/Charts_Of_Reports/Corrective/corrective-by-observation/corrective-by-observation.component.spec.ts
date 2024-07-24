import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorrectiveByObservationComponent } from './corrective-by-observation.component';

describe('CorrectiveByObservationComponent', () => {
  let component: CorrectiveByObservationComponent;
  let fixture: ComponentFixture<CorrectiveByObservationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CorrectiveByObservationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CorrectiveByObservationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

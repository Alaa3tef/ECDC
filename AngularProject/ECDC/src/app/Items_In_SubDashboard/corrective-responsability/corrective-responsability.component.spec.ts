import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorrectiveResponsabilityComponent } from './corrective-responsability.component';

describe('CorrectiveResponsabilityComponent', () => {
  let component: CorrectiveResponsabilityComponent;
  let fixture: ComponentFixture<CorrectiveResponsabilityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CorrectiveResponsabilityComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CorrectiveResponsabilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorrectiveByResponsabilityComponent } from './corrective-by-responsability.component';

describe('CorrectiveByResponsabilityComponent', () => {
  let component: CorrectiveByResponsabilityComponent;
  let fixture: ComponentFixture<CorrectiveByResponsabilityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CorrectiveByResponsabilityComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CorrectiveByResponsabilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

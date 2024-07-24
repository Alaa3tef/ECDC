import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCorrectiveResponsabilityComponent } from './add-corrective-responsability.component';

describe('AddCorrectiveResponsabilityComponent', () => {
  let component: AddCorrectiveResponsabilityComponent;
  let fixture: ComponentFixture<AddCorrectiveResponsabilityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCorrectiveResponsabilityComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddCorrectiveResponsabilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

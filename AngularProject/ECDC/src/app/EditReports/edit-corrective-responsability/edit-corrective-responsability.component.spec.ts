import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCorrectiveResponsabilityComponent } from './edit-corrective-responsability.component';

describe('EditCorrectiveResponsabilityComponent', () => {
  let component: EditCorrectiveResponsabilityComponent;
  let fixture: ComponentFixture<EditCorrectiveResponsabilityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditCorrectiveResponsabilityComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditCorrectiveResponsabilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

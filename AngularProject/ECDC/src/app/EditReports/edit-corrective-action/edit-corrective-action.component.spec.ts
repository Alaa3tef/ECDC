import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCorrectiveActionComponent } from './edit-corrective-action.component';

describe('EditCorrectiveActionComponent', () => {
  let component: EditCorrectiveActionComponent;
  let fixture: ComponentFixture<EditCorrectiveActionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditCorrectiveActionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditCorrectiveActionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

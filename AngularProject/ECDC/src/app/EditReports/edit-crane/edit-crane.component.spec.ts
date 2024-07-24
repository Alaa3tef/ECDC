import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCraneComponent } from './edit-crane.component';

describe('EditCraneComponent', () => {
  let component: EditCraneComponent;
  let fixture: ComponentFixture<EditCraneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditCraneComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditCraneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

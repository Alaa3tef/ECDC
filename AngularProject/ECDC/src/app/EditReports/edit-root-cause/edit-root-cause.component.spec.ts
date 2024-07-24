import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditRootCauseComponent } from './edit-root-cause.component';

describe('EditRootCauseComponent', () => {
  let component: EditRootCauseComponent;
  let fixture: ComponentFixture<EditRootCauseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditRootCauseComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditRootCauseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

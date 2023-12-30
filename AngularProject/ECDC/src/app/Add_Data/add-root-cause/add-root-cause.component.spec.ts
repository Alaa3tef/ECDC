import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRootCauseComponent } from './add-root-cause.component';

describe('AddRootCauseComponent', () => {
  let component: AddRootCauseComponent;
  let fixture: ComponentFixture<AddRootCauseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddRootCauseComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddRootCauseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

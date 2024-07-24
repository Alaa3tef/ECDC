import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorrectiveBySuggestedDateComponent } from './corrective-by-suggested-date.component';

describe('CorrectiveBySuggestedDateComponent', () => {
  let component: CorrectiveBySuggestedDateComponent;
  let fixture: ComponentFixture<CorrectiveBySuggestedDateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CorrectiveBySuggestedDateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CorrectiveBySuggestedDateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

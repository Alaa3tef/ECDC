import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorrectiveByStandardComponent } from './corrective-by-standard.component';

describe('CorrectiveByStandardComponent', () => {
  let component: CorrectiveByStandardComponent;
  let fixture: ComponentFixture<CorrectiveByStandardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CorrectiveByStandardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CorrectiveByStandardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

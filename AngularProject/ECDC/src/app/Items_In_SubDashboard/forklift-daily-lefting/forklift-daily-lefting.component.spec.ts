import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForkliftDailyLeftingComponent } from './forklift-daily-lefting.component';

describe('ForkliftDailyLeftingComponent', () => {
  let component: ForkliftDailyLeftingComponent;
  let fixture: ComponentFixture<ForkliftDailyLeftingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ForkliftDailyLeftingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ForkliftDailyLeftingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

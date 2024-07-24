import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditForkliftDailyLeftingComponent } from './edit-forklift-daily-lefting.component';

describe('EditForkliftDailyLeftingComponent', () => {
  let component: EditForkliftDailyLeftingComponent;
  let fixture: ComponentFixture<EditForkliftDailyLeftingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditForkliftDailyLeftingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditForkliftDailyLeftingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

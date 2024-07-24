import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddForkliftDailyLeftingComponent } from './add-forklift-daily-lefting.component';

describe('AddForkliftDailyLeftingComponent', () => {
  let component: AddForkliftDailyLeftingComponent;
  let fixture: ComponentFixture<AddForkliftDailyLeftingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddForkliftDailyLeftingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddForkliftDailyLeftingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

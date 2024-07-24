import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditMobileCraneDailyLeftingComponent } from './edit-mobile-crane-daily-lefting.component';

describe('EditMobileCraneDailyLeftingComponent', () => {
  let component: EditMobileCraneDailyLeftingComponent;
  let fixture: ComponentFixture<EditMobileCraneDailyLeftingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditMobileCraneDailyLeftingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditMobileCraneDailyLeftingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

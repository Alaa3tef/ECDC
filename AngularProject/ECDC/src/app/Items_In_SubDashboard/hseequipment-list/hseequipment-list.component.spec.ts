import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HSEEquipmentListComponent } from './hseequipment-list.component';

describe('HSEEquipmentListComponent', () => {
  let component: HSEEquipmentListComponent;
  let fixture: ComponentFixture<HSEEquipmentListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HSEEquipmentListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HSEEquipmentListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

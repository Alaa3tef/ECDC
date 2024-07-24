import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddHSEEquipmentListComponent } from './add-hseequipment-list.component';

describe('AddHSEEquipmentListComponent', () => {
  let component: AddHSEEquipmentListComponent;
  let fixture: ComponentFixture<AddHSEEquipmentListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddHSEEquipmentListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddHSEEquipmentListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

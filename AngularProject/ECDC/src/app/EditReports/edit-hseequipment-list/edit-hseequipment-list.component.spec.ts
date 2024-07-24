import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditHSEEquipmentListComponent } from './edit-hseequipment-list.component';

describe('EditHSEEquipmentListComponent', () => {
  let component: EditHSEEquipmentListComponent;
  let fixture: ComponentFixture<EditHSEEquipmentListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditHSEEquipmentListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditHSEEquipmentListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditRigCertificatesComponent } from './edit-rig-certificates.component';

describe('EditRigCertificatesComponent', () => {
  let component: EditRigCertificatesComponent;
  let fixture: ComponentFixture<EditRigCertificatesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditRigCertificatesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditRigCertificatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

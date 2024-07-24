import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRigCertificatesComponent } from './add-rig-certificates.component';

describe('AddRigCertificatesComponent', () => {
  let component: AddRigCertificatesComponent;
  let fixture: ComponentFixture<AddRigCertificatesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddRigCertificatesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddRigCertificatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

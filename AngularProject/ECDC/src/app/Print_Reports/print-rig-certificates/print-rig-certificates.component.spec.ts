import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintRigCertificatesComponent } from './print-rig-certificates.component';

describe('PrintRigCertificatesComponent', () => {
  let component: PrintRigCertificatesComponent;
  let fixture: ComponentFixture<PrintRigCertificatesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintRigCertificatesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintRigCertificatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

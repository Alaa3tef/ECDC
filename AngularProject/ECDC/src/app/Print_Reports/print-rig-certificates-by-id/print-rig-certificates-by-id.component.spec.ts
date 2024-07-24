import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintRigCertificatesByIdComponent } from './print-rig-certificates-by-id.component';

describe('PrintRigCertificatesByIdComponent', () => {
  let component: PrintRigCertificatesByIdComponent;
  let fixture: ComponentFixture<PrintRigCertificatesByIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintRigCertificatesByIdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrintRigCertificatesByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

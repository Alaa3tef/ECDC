import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RigCertificatesComponent } from './rig-certificates.component';

describe('RigCertificatesComponent', () => {
  let component: RigCertificatesComponent;
  let fixture: ComponentFixture<RigCertificatesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RigCertificatesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RigCertificatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

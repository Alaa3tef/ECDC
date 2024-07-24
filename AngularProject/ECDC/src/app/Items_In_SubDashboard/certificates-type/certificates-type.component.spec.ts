import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CertificatesTypeComponent } from './certificates-type.component';

describe('CertificatesTypeComponent', () => {
  let component: CertificatesTypeComponent;
  let fixture: ComponentFixture<CertificatesTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CertificatesTypeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CertificatesTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

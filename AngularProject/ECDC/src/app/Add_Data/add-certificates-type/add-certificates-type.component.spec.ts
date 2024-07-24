import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCertificatesTypeComponent } from './add-certificates-type.component';

describe('AddCertificatesTypeComponent', () => {
  let component: AddCertificatesTypeComponent;
  let fixture: ComponentFixture<AddCertificatesTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCertificatesTypeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddCertificatesTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

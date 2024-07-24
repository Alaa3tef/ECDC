import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCertificatesTypeComponent } from './edit-certificates-type.component';

describe('EditCertificatesTypeComponent', () => {
  let component: EditCertificatesTypeComponent;
  let fixture: ComponentFixture<EditCertificatesTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditCertificatesTypeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditCertificatesTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

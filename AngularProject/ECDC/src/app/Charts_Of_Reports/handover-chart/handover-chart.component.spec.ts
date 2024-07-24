import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HandoverChartComponent } from './handover-chart.component';

describe('HandoverChartComponent', () => {
  let component: HandoverChartComponent;
  let fixture: ComponentFixture<HandoverChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HandoverChartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HandoverChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

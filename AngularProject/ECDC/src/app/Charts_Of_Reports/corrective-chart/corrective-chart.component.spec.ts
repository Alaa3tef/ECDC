import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorrectiveChartComponent } from './corrective-chart.component';

describe('CorrectiveChartComponent', () => {
  let component: CorrectiveChartComponent;
  let fixture: ComponentFixture<CorrectiveChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CorrectiveChartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CorrectiveChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

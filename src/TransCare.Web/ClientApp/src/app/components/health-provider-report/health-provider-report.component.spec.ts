import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthProviderReportComponent } from './health-provider-report.component';

describe('HealthProviderReportComponent', () => {
  let component: HealthProviderReportComponent;
  let fixture: ComponentFixture<HealthProviderReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HealthProviderReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HealthProviderReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

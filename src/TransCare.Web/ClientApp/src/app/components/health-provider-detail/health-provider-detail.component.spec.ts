import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthProviderDetailComponent } from './health-provider-detail.component';

describe('HealthProviderDetailComponent', () => {
  let component: HealthProviderDetailComponent;
  let fixture: ComponentFixture<HealthProviderDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HealthProviderDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HealthProviderDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

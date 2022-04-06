import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthProviderNearMeComponent } from './health-provider-near-me.component';

describe('HealthProviderNearMeComponent', () => {
  let component: HealthProviderNearMeComponent;
  let fixture: ComponentFixture<HealthProviderNearMeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HealthProviderNearMeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HealthProviderNearMeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

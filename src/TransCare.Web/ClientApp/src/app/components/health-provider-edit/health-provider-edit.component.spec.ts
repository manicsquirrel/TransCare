import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthProviderEditComponent } from './health-provider-edit.component';

describe('HealthProviderEditComponent', () => {
  let component: HealthProviderEditComponent;
  let fixture: ComponentFixture<HealthProviderEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HealthProviderEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HealthProviderEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

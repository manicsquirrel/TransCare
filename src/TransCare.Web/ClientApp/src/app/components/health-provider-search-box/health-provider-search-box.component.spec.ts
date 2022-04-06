import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthProviderSearchBoxComponent } from './health-provider-search-box.component';

describe('HealthProviderSearchBoxComponent', () => {
  let component: HealthProviderSearchBoxComponent;
  let fixture: ComponentFixture<HealthProviderSearchBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HealthProviderSearchBoxComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HealthProviderSearchBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

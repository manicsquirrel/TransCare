import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthProviderSearchResultComponent } from './health-provider-search-result.component';

describe('HealthProviderSearchResultComponent', () => {
  let component: HealthProviderSearchResultComponent;
  let fixture: ComponentFixture<HealthProviderSearchResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HealthProviderSearchResultComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HealthProviderSearchResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

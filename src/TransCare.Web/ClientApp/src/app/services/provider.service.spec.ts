import { TestBed } from '@angular/core/testing';

import { HealthProviderService } from './provider.service';

describe('ProviderService', () => {
  let service: HealthProviderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HealthProviderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { ProviderBaseService } from './provider-base.service';

describe('ProviderBaseService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProviderBaseService = TestBed.get(ProviderBaseService);
    expect(service).toBeTruthy();
  });
});

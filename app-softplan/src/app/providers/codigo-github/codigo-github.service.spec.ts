import { TestBed } from '@angular/core/testing';

import { CodigoGithubService } from './codigo-github.service';

describe('CodigoGithubService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CodigoGithubService = TestBed.get(CodigoGithubService);
    expect(service).toBeTruthy();
  });
});

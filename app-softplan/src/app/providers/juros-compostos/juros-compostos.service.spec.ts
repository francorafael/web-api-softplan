import { TestBed } from '@angular/core/testing';

import { JurosCompostosService } from './juros-compostos.service';

describe('JurosCompostosService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: JurosCompostosService = TestBed.get(JurosCompostosService);
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { VinculacionService } from './vinculacion.service';

describe('VinculacionService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VinculacionService = TestBed.get(VinculacionService);
    expect(service).toBeTruthy();
  });
});

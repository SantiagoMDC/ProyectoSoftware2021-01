import { TestBed } from '@angular/core/testing';

import { VeterinariaService } from './veterinaria.service';

describe('VeterinariaService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VeterinariaService = TestBed.get(VeterinariaService);
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { AmbientalService } from './ambiental.service';

describe('AmbientalService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AmbientalService = TestBed.get(AmbientalService);
    expect(service).toBeTruthy();
  });
});

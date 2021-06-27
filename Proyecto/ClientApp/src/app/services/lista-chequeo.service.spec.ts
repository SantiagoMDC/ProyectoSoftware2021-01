import { TestBed } from '@angular/core/testing';

import { ListaChequeoService } from './lista-chequeo.service';

describe('ListaChequeoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ListaChequeoService = TestBed.get(ListaChequeoService);
    expect(service).toBeTruthy();
  });
});

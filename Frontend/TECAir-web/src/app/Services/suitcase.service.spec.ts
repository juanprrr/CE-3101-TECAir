import { TestBed } from '@angular/core/testing';

import { SuitcaseService } from './suitcase.service';

describe('SuitcaseService', () => {
  let service: SuitcaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SuitcaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

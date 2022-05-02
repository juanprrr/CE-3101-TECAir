import { TestBed } from '@angular/core/testing';

import { FlightRequestService } from './flight-request.service';

describe('FlightRequestService', () => {
  let service: FlightRequestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FlightRequestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

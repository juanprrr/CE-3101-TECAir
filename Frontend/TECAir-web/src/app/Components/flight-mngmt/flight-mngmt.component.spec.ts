import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightMngmtComponent } from './flight-mngmt.component';

describe('FlightMngmtComponent', () => {
  let component: FlightMngmtComponent;
  let fixture: ComponentFixture<FlightMngmtComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FlightMngmtComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FlightMngmtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpenFlightComponent } from './open-flight.component';

describe('OpenFlightComponent', () => {
  let component: OpenFlightComponent;
  let fixture: ComponentFixture<OpenFlightComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OpenFlightComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OpenFlightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

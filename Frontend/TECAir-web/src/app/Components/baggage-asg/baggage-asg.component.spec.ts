import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BaggageAsgComponent } from './baggage-asg.component';

describe('BaggageAsgComponent', () => {
  let component: BaggageAsgComponent;
  let fixture: ComponentFixture<BaggageAsgComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BaggageAsgComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BaggageAsgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

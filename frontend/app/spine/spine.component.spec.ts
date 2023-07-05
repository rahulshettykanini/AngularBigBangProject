import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpineComponent } from './spine.component';

describe('SpineComponent', () => {
  let component: SpineComponent;
  let fixture: ComponentFixture<SpineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

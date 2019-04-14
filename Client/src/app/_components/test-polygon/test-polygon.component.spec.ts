import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestPolygonComponent } from './test-polygon.component';

describe('TestPolygonComponent', () => {
  let component: TestPolygonComponent;
  let fixture: ComponentFixture<TestPolygonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestPolygonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestPolygonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

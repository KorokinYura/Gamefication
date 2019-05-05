import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UnactiveTasksComponent } from './unactive-tasks.component';

describe('UnactiveTasksComponent', () => {
  let component: UnactiveTasksComponent;
  let fixture: ComponentFixture<UnactiveTasksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UnactiveTasksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UnactiveTasksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

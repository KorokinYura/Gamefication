import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InactiveTasksComponent } from './inactive-tasks.component';

describe('InactiveTasksComponent', () => {
  let component: InactiveTasksComponent;
  let fixture: ComponentFixture<InactiveTasksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InactiveTasksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InactiveTasksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

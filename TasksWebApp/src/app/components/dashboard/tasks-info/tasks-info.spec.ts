import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TasksInfo } from './tasks-info';

describe('TasksInfo', () => {
  let component: TasksInfo;
  let fixture: ComponentFixture<TasksInfo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TasksInfo]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TasksInfo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

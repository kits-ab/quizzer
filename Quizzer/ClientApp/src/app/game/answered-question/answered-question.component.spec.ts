import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AnsweredQuestionComponent } from './answered-question.component';

describe('AnsweredQuestionComponent', () => {
  let component: AnsweredQuestionComponent;
  let fixture: ComponentFixture<AnsweredQuestionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AnsweredQuestionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AnsweredQuestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SingleAnswerQuestionComponent } from './single-answer-question.component';

describe('SingleAnswerQuestionComponent', () => {
  let component: SingleAnswerQuestionComponent;
  let fixture: ComponentFixture<SingleAnswerQuestionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SingleAnswerQuestionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SingleAnswerQuestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SingleAnswerAnsweredQuestionComponent } from './single-answer-answered-question.component';

describe('SingleAnswerAnsweredQuestionComponent', () => {
  let component: SingleAnswerAnsweredQuestionComponent;
  let fixture: ComponentFixture<SingleAnswerAnsweredQuestionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SingleAnswerAnsweredQuestionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SingleAnswerAnsweredQuestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

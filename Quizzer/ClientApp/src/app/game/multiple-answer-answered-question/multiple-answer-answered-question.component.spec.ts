import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MultipleAnswerAnsweredQuestionComponent } from './multiple-answer-answered-question.component';

describe('SingleAnswerAnsweredQuestionComponent', () => {
  let component: MultipleAnswerAnsweredQuestionComponent;
  let fixture: ComponentFixture<MultipleAnswerAnsweredQuestionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MultipleAnswerAnsweredQuestionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MultipleAnswerAnsweredQuestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});


export interface MultipleAnswerAnsweredQuestion {
  type: 'MultipleAnswerAnsweredQuestion';
  
  targetPlayerId: string;
  text: string;
  options: Option[];
  answers: Answer[];
}

interface Option {
  
  text: string;
  id: string;
}

interface Answer {
  
  optionIds: string[];
  playerId: string;
}


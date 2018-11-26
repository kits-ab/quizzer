
export interface SingleAnswerAnsweredQuestion {
  type: 'SingleAnswerAnsweredQuestion';
  
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
  
  optionId: string;
  playerId: string;
}


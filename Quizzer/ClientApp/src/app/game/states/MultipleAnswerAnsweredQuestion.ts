
export interface MultipleAnswerAnsweredQuestion {
  type: 'MultipleAnswerAnsweredQuestion';
  
  targetPlayerName: string;
  targetPlayerAnswerOptionIds: string[];
  text: string;
  options: Option[];
  otherPlayerAnswers: Answer[];
}

interface Option {
  
  id: string;
  text: string;
}

interface Answer {
  
  optionIds: string[];
  playerId: string;
}


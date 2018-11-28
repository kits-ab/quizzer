
export interface MultipleAnswerAnsweredQuestion {
  type: 'MultipleAnswerAnsweredQuestion';
  
  targetPlayerName: string;
  targetPlayerAnswerOptionIds: string[];
  text: string;
  options: Option[];
  otherPlayerAnswers: Answer[];
}

interface Option {
  
  text: string;
  id: string;
}

interface Answer {
  
  optionIds: string[];
  playerId: string;
}


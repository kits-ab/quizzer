
export interface SingleAnswerAnsweredQuestion {
  type: 'SingleAnswerAnsweredQuestion';
  
  targetPlayerName: string;
  targetPlayerAnswerOptionId: string;
  text: string;
  options: Option[];
  otherPlayerAnswers: Answer[];
}

interface Option {
  
  id: string;
  text: string;
}

interface Answer {
  
  optionId: string;
  playerId: string;
}


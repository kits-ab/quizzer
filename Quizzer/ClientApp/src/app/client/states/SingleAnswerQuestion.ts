
export interface SingleAnswerQuestion {
  type: 'SingleAnswerQuestion';
  
  options: Option[];
}

interface Option {
  
  id: string;
  text: string;
}


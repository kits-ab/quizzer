namespace Quizzer.Domain

open System

module MultipleAnswerQuestion =
    let create (questionText, optionTexts) = MultipleAnswerQuestion {
        Question = questionText
        Options = Map.ofSeq (Seq.map (fun optionText -> (OptionId(Guid.NewGuid()), { Text = optionText })) optionTexts)
    }

    let isValidAnswer (question : MultipleAnswerQuestion, answer : MultipleAnswer) =
        Seq.forall (fun x -> Seq.contains x (IdObjectCollection.Ids question.Options)) answer.OptionIds
namespace Quizzer.Domain

open System

module MultipleAnswerQuestion =
    let create (questionText, optionTexts) = MultipleAnswerQuestion {
        Text = questionText
        Options = Map.ofSeq (Seq.map (fun optionText -> (OptionId(Guid.NewGuid()), { Text = optionText })) optionTexts)
    }

    let isValidAnswer (question : MultipleAnswerQuestion, answer : MultipleAnswer) =
        Seq.forall (fun x -> Seq.contains x (Map.keys question.Options)) answer.OptionIds
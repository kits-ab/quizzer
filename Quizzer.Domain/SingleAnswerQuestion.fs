namespace Quizzer.Domain

open System

module SingleAnswerQuestion =
    let create (questionText, optionTexts) = SingleAnswerQuestion {
        Question = questionText
        Options = Map.ofSeq (Seq.map (fun optionText -> (OptionId(Guid.NewGuid()), { Text = optionText })) optionTexts)
    }

    let isValidAnswer (question : SingleAnswerQuestion, answer : SingleAnswer) =
        Seq.contains answer.OptionId (IdObjectCollection.Ids question.Options)
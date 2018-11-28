namespace Quizzer.Domain

open System

module SingleAnswerQuestion =
    let create (questionText, optionTexts) = SingleAnswerQuestion {
        Text = questionText
        Options = Map.ofSeq (Seq.map (fun optionText -> (OptionId(Guid.NewGuid()), { Text = optionText })) optionTexts)
    }

    let isValidAnswer (question : SingleAnswerQuestion, answer : SingleAnswer) =
        Seq.contains answer.OptionId (Map.keys question.Options)
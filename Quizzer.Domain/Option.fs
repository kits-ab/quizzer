namespace Quizzer.Domain

open System

type OptionId = OptionId of Guid

type OptionData = { Text : string }

type Option = { Data : OptionData }

type OptionCollection = IdObjectCollection<OptionId, OptionData>
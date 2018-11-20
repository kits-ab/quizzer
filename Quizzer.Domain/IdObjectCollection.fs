namespace Quizzer.Domain

type IdObjectCollection<'Id, 'Object when 'Id : comparison and 'Object : comparison> = Map<'Id, 'Object> 

module IdObjectCollection =
    let Ids idObjectCollection = 
        Map.fold (fun keys key _ -> key::keys) [] idObjectCollection
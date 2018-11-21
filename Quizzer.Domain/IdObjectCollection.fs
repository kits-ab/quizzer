namespace Quizzer.Domain

type IdObjectCollection<'Id, 'Object when 'Id : comparison and 'Object : comparison> = Map<'Id, 'Object> 

module IdObjectCollection =
    let Ids idObjectCollection = 
        Seq.map (fun (id, _) -> id) (Map.toSeq idObjectCollection)
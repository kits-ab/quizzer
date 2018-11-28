module Map 
    let keys(map: Map<_,_>) = 
        Seq.map (fun (id, _) -> id) (Map.toSeq map)
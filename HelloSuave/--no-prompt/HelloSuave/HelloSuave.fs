open Suave                 // always open suave
open Suave.Successful      // for OK-result
open Suave.Web             // for config

open Suave.Filters
open Suave.Operators

open Suave.RequestErrors

let webPart =  
    choose [  
        path "/" >=> (OK "Home")  
        path "/about" >=> (OK "About")
        path "/articles" >=> (OK "List of articles")
        pathScan "/articles/%s/%d"
            (fun (c, id) -> OK (sprintf "Category: %s; Id: %d" c id))
        path "/articles/browse" >=> request (fun r -> 
                                            let genre = match r.queryParam "genre" with
                                                        | Choice1Of2 genre -> genre
                                                        | _ -> ""
                                            let limit = match r.queryParam "limit" with
                                                        | Choice1Of2 limit -> int limit
                                                        | _ -> 0
                                            OK (sprintf "Genre: %s and number of articles limit: %d" genre limit))
        pathScan "/articles/details/%d"
            (fun id -> OK (sprintf "Content of the article with ID: %d" id))       
    ] 

startWebServer defaultConfig webPart

module View

open Suave.Html
let index =
    html [] [
        head [] [
            title [] "Web Application F# CSCorner"
        ]

        body [] [
            div ["id", "header"] [
                tag "h1" [] [
                    a "/" [] [Text "F# Suave Introduction"]
                ]
            ]

            div ["id", "footer"] [
                Text "Share the love with "
                a "http://fsharp.org" [] [Text "F#"]
                Text " and "
                a "http://suave.io" [] [Text "Suave.io"]
            ]
        ]
    ]
    |> htmlToString
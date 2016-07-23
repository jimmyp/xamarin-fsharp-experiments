namespace testfsharp

open System
open Xamarin.Forms

type ContentView() = 
    inherit ContentView()
    do base.Content <- Label(Text = "Hello ContentView")


namespace testfsharp

open System
open Xamarin.Forms

type ContentPage() = 
    inherit ContentPage()
    do 
        let layout = StackLayout()
        layout.Children.Add(Label(Text = "Hello ContentPage"))
        base.Content <- layout


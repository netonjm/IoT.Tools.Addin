namespace NewApp

open System
open Gtk

module Program =

[<EntryPoint>]
let main (argv :string[]) = 

    let width, height = 500, 500
    Application.Init ()

    let window = new Window ("FSharp IoT Example")
    window.SetDefaultSize (width, height)
    window.DeleteEvent.Add (fun e -> window.Hide(); Application.Quit(); e.RetVal <- true)
    let mutable count = 0
    let button = new Button ("I'm a Raspberry. Click Here!")
    button.Clicked.Add (fun (s) -> count <- count + 1; button.Label <- String.Format("You pressed {0} times",string count))
    window.Add (button)

    window.ShowAll()
    window.Show()
    Application.Run ()
    0
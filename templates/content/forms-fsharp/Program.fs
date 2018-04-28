namespace NewApp

open System
open Xamarin.Forms
open Xamarin.Forms.Platform.GTK

module Program =

[<EntryPoint>]
let main (argv :string[]) = 
    Gtk.Application.Init ()
    Forms.Init ()
    let app = new App ()
    let window = new FormsWindow ()
    window.LoadApplication (app)
    window.Show ()
    Gtk.Application.Run ()
    0
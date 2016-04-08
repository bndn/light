/// Copyright (C) 2016 The Authors.
module AmbientLightTest

open Xunit
open FsUnit.Xunit

let createValidAmbientLight =
    let c = Color.make 0.1 0.2 0.3 // Color
    let i = 0.5                    // intensity

    AmbientLight.make c i

[<Fact>]
let ``make constructs an AmbientLight given a set of valid arguments`` () =
    let al = createValidAmbientLight

    // Check that the ambient light was constructed.
    al |> should be instanceOfType<AmbientLight.AmbientLight>

[<Fact>]
let ``getColor gets the right float values`` () =
    let c = createValidAmbientLight

    // Check that getColor returns the right value.
    AmbientLight.getColor al |> should equal (Color.make 0.1 0.2 0.3)

[<Fact>]
let ``getIntensity gets the right float value`` () =
    let c = createValidAmbientLight

    // Check that getIntensity returns the right value.
    AmbientLight.getIntensity c |> should equal 0.5

[<Fact>]
let ``make for an AmbientLight with a negative intensity fails`` () =
    let c = Color.make 0.1 0.2 0.3 // Color
    let i = -0.1                   // intensity

    // Check that an exception is thrown with a negative intensity value.
    (fun () -> AmbientLight.make c i |> ignore)
    |> should throw typeof<AmbientLight.InvalidIntensityException>

[<Fact>]
let ``make for an AmbientLight with an intensity larger than 1 fails`` () =
    let c = Color.make 0.1 0.2 0.3 // Color
    let i = 1.1                    // intensity

    // Check that an exception is thrown with an intensity value > 1.
    (fun () -> AmbientLight.make c i |> ignore)
    |> should throw typeof<AmbientLight.InvalidIntensityException>

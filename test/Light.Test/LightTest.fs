/// Copyright (C) 2016 The Authors.
module LightTest

open Xunit
open FsUnit.Xunit
open Light

let makeValidAmbientLight =
    let c = Color.make 0.1 0.2 0.3 // Color
    let i = 0.5                    // intensity

    Light.make Ambient c i

let makeValidOmnidirectionalLight =
    let p = Point.make 1.5 2.5 3.5 // Point
    let c = Color.make 0.1 0.2 0.3 // Color
    let i = 0.5                    // intensity

    Light.make (Omni(p)) c i

[<Fact>]
let ``make constructs an AmbientLight given a set of valid arguments`` () =
    let al = makeValidAmbientLight

    // Check that the ambient light was constructed.
    al |> should be instanceOfType<Light>

[<Fact>]
let ``make constructs an OmnidirectionalLight given a set of valid arguments`` () =
    let ol = makeValidOmnidirectionalLight

    // Check that the omnidirectional light was constructed.
    ol |> should be instanceOfType<Light>

[<Fact>]
let ``getVector returns the right Vector for an Ambient Light`` () =
    let al = makeValidAmbientLight
    let hp = Point.make 5.0 6.0 7.0 // Hit point

    // Check that getVector returns the right value.
    Light.getVector hp al |> should equal (Vector.make 0.0 0.0 0.0)

[<Fact>]
let ``getVector returns the right Vector for an Omnidirectional Light`` () =
    let ol = makeValidOmnidirectionalLight
    let hp = Point.make 5.0 6.0 7.0 // Hit point

    // Check that getVector returns the right value.
    Light.getVector hp ol |> should equal (Point.distance (Point.make 5.0 6.0 7.0) (Point.make 1.5 2.5 3.5))

[<Fact>]
let ``getColor gets the right float values for an Ambient Light`` () =
    let al = makeValidAmbientLight

    // Check that getColor returns the right value.
    Light.getColor al |> should equal (Color.make 0.1 0.2 0.3)

[<Fact>]
let ``getColor gets the right float values for an Omnidirectional Light`` () =
    let ol = makeValidOmnidirectionalLight

    // Check that getColor returns the right value.
    Light.getColor ol |> should equal (Color.make 0.1 0.2 0.3)

[<Fact>]
let ``getIntensity gets the right float value for an Ambient Light`` () =
    let al = makeValidAmbientLight

    // Check that getIntensity returns the right value.
    Light.getIntensity al |> should equal 0.5

[<Fact>]
let ``getIntensity gets the right float value for an Omnidirectional Light`` () =
    let ol = makeValidOmnidirectionalLight

    // Check that getIntensity returns the right value.
    Light.getIntensity ol |> should equal 0.5

[<Fact>]
let ``make with a negative intensity fails for an Ambient Light`` () =
    let c = Color.make 0.1 0.2 0.3 // Color
    let i = -0.1                   // intensity

    // Check that an exception is thrown with a negative intensity value.
    (fun () -> Light.make Ambient c i |> ignore) |> shouldFail

[<Fact>]
let ``make with an intensity larger than 1 fails for an Ambient Light`` () =
    let c = Color.make 0.1 0.2 0.3 // Color
    let i = 1.1                    // intensity

    // Check that an exception is thrown with an intensity value > 1.
    (fun () -> Light.make Ambient c i |> ignore) |> shouldFail

[<Fact>]
let ``make with a negative intensity fails for an Omni Light`` () =
    let p = Point.make 1.5 2.5 3.5 // Point
    let c = Color.make 0.1 0.2 0.3 // Color
    let i = -0.1                   // intensity

    // Check that an exception is thrown with a negative intensity value.
    (fun () -> Light.make (Omni(p)) c i |> ignore) |> shouldFail

[<Fact>]
let ``make with an intensity larger than 1 fails for an Omni Light`` () =
    let p = Point.make 1.5 2.5 3.5 // Point
    let c = Color.make 0.1 0.2 0.3 // Color
    let i = 1.1                    // intensity

    // Check that an exception is thrown with an intensity value > 1.
    (fun () -> Light.make (Omni(p)) c i |> ignore) |> shouldFail

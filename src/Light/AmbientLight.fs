/// Copyright (C) 2015 The Authors.
module AmbientLight

open Color

type AmbientLight = AL of Color * float

/// Raised in case of a negative float for intensity or a float > 1
exception InvalidIntensityException

/// <summary>
/// Create an AmbientLight with a Color and an intensity (float).
/// </summary>
/// <param name=c>The Color of the AmbientLight.</param>
/// <param name=i>The intensity of the AmbientLight.</param>
/// <returns>The created AmbientLight.</returns>
let make c i =
    if i < 0. then raise InvalidIntensityException
    if i > 1. then rasie InvalidIntensityException
    AL(c,i)

/// <summary>
/// Get the Color of an AmbientLight.
/// </summary>
/// <param name=al>The AmbientLight whose color is returned.</param>
/// <returns>The Color of the AmbientLight.</returns>
let getColor (AL(color, _)) = color

/// <summary>
/// Get the intensity of an AmbientLight.
/// </summary>
/// <param name=al>The AmbientLight whose intensity is returned.</param>
/// <returns>The intensity of the AmbientLight.</returns>
let getIntensity (AL(_,intensity)) = intensity

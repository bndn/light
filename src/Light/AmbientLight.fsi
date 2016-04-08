/// Copyright (C) 2015 The Authors.
module AmbientLight

open Color

type AmbientLight

/// Raised in case of a negative float for intensity or a float > 1
exception InvalidIntensityException

/// <summary>
/// Create an AmbientLight with a Color and an intensity
/// </summary>
/// <param name=c>The Color of the AmbientLight</param>
/// <param name=i>The intensity of the AmbientLight.</param>
/// <returns>The created AmbientLight.</returns>
val make : c:Color -> i:float -> AmbientLight

/// <summary>
/// Get the Color of an AmbientLight.
/// </summary>
/// <param name=al>The AmbientLight whose color is returned.</param>
/// <returns>The Color of the AmbientLight.</returns>
val getColor : al:AmbientLight -> Color

/// <summary>
/// Get the intensity of an AmbientLight.
/// </summary>
/// <param name=al>The AmbientLight whose intensity is returned.</param>
/// <returns>The intensity of the AmbientLight.</returns>
val getIntensity : al:AmbientLight -> float

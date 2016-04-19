/// Copyright (C) 2015 The Authors.
module Light

open Color
open Point
open Vector

type Direction =
  | Ambient
  | Omni of Point

type Light = L of Direction * Color * float

/// <summary>
/// Create a Light with a Direction, a Color and an intensity.
/// </summary>
/// <param name=d>The Direction of the Light.</param>
/// <param name=c>The Color of the Light.</param>
/// <param name=i>The intensity of the Light.</param>
/// <returns>The created Light.</returns>
let make d c i =
    if i < 0. || i > 1.
    then invalidArg "i" "Should be between 0 and 1"
    L(d, c, i)

/// <summary>
/// Get the Vector between a hit point on a shape and the nearest point of a light source.
/// </summary>
/// <param name=hp>The hit point from which the vector is made.</param>
/// <param name=l>The Light whose point is used.</param>
/// <returns>The Vector between the hit point and the nearest light point.</returns>
let getVector hp = function
  | L(Ambient, c, i) -> Vector.make 0.0 0.0 0.0
  | L(Omni(p), c, i) -> Point.distance hp p

/// <summary>
/// Get the Color of a Light.
/// </summary>
/// <param name=l>The Light whose color is returned.</param>
/// <returns>The Color of the Light.</returns>
let getColor = function L(_, c, i) -> c

/// <summary>
/// Get the intensity of a Light.
/// </summary>
/// <param name=l>The Light whose intensity is returned.</param>
/// <returns>The intensity of the Light.</returns>
let getIntensity = function L(_, _, i) -> i

/// Copyright (C) 2015 The Authors.
module Light

open Color
open Point
open Vector

type Direction =
  | Ambient
  | Omni of Point

type Light

/// <summary>
/// Create a Light with a Direction, a Color and an intensity.
/// </summary>
/// <param name=d>The Direction of the Light.</param>
/// <param name=c>The Color of the Light.</param>
/// <param name=i>The intensity of the Light.</param>
/// <returns>The created Light.</returns>
val make : d:Direction -> c:Color -> i:float -> Light

/// <summary>
/// Get the Vector between a hit point on a shape and the nearest point of a light source.
/// </summary>
/// <param name=hp>The hit point from which the vector is made.</param>
/// <param name=l>The Light whose point is used.</param>
/// <returns>The Vector between the hit point and the nearest light point.</returns>
val getVector : hp:Point -> l:Light -> Vector

/// <summary>
/// Get the Color of a Light.
/// </summary>
/// <param name=l>The Light whose color is returned.</param>
/// <returns>The Color of the Light.</returns>
val getColor : l:Light -> Color

/// <summary>
/// Get the intensity of a Light.
/// </summary>
/// <param name=l>The Light whose intensity is returned.</param>
/// <returns>The intensity of the Light.</returns>
val getIntensity : l:Light -> float

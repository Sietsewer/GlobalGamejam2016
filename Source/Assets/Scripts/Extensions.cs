//using System;
using UnityEngine;

public static class Extensions
{
	public static Vector3 quickScale (this Vector3 a, Vector3 b){
		return new Vector3 (a.x * b.x, a.y * b.y, a.z * b.z);
	}
}


using UnityEngine;

public struct Float2 {
	private float _x, _y;

	public Float2(float x, float y) {
		_x = x;
		_y = y;
	}

	#region Float1Properties
	public float x => _x;
	public float y => _y;
	public static float o => 0f;
	public static float l => 1f;
	#endregion

	#region Float2Properties
	public Float2 xx => new Float2(_x, _x);
	public Float2 xy => new Float2(_x, _y);
	public Float2 xo => new Float2(_x, 0f);
	public Float2 xl => new Float2(_x, 1f);

	public Float2 yx => new Float2(_y, _x);
	public Float2 yy => new Float2(_y, _y);
	public Float2 yo => new Float2(_y, 0f);
	public Float2 yl => new Float2(_y, 1f);

	public Float2 ox => new Float2(0f, _x);
	public Float2 oy => new Float2(0f, _y);
	public static Float2 oo => new Float2(0f, 0f);
	public static Float2 ol => new Float2(0f, 1f);

	public Float2 lx => new Float2(1f, _x);
	public Float2 ly => new Float2(1f, _y);
	public static Float2 lo => new Float2(1f, 0f);
	public static Float2 ll => new Float2(1f, 1f);
	#endregion

	#region Operators
	public static float operator +(Float2 f2) => f2._x + f2._y;
	public static Float2 operator -(Float2 f2) => new Float2(-f2._x, -f2._y);

	public static Float2 operator +(Float2 lhs, Float2 rhs) => new Float2(lhs._x + rhs._x, lhs._y + rhs._y);
	public static Float2 operator -(Float2 lhs, Float2 rhs) => new Float2(lhs._x - rhs._x, lhs._y - rhs._y);
	public static Float2 operator *(Float2 lhs, Float2 rhs) => new Float2(lhs._x * rhs._x, lhs._y * rhs._y);
	public static Float2 operator /(Float2 lhs, Float2 rhs) => new Float2(lhs._x / rhs._x, lhs._y / rhs._y);

	public static Float2 operator +(Float2 lhs, float rhs) => new Float2(lhs._x + rhs, lhs._y + rhs);
	public static Float2 operator +(float lhs, Float2 rhs) => new Float2(lhs + rhs._x, lhs + rhs._y);
	public static Float2 operator -(Float2 lhs, float rhs) => new Float2(lhs._x - rhs, lhs._y - rhs);
	public static Float2 operator -(float lhs, Float2 rhs) => new Float2(lhs - rhs._x, lhs - rhs._y);
	public static Float2 operator *(Float2 lhs, float rhs) => new Float2(lhs._x * rhs, lhs._y * rhs);
	public static Float2 operator *(float lhs, Float2 rhs) => new Float2(lhs * rhs._x, lhs * rhs._y);
	public static Float2 operator /(Float2 lhs, float rhs) => new Float2(lhs._x / rhs, lhs._y / rhs);
	public static Float2 operator /(float lhs, Float2 rhs) => new Float2(lhs / rhs._x, lhs / rhs._y);

	public static implicit operator Vector2(Float2 f2) => new Vector2(f2._x, f2._y);
	#endregion
}
using UnityEngine;

public struct Float3 {
	private float _x, _y, _z;

	public Float3(float x, float y, float z) {
		_x = x;
		_y = y;
		_z = z;
	}

	#region Float1Properties
	public float x => _x;
	public float y => _y;
	public float z => _z;
	public static float o => 0f;
	public static float l => 1f;
	#endregion

	#region Float2Properties
	public Float2 xx => new Float2(_x, _x);
	public Float2 xy => new Float2(_x, _y);
	public Float2 xz => new Float2(_x, _z);
	public Float2 xo => new Float2(_x, 0f);
	public Float2 xl => new Float2(_x, 1f);

	public Float2 yx => new Float2(_y, _x);
	public Float2 yy => new Float2(_y, _y);
	public Float2 yz => new Float2(_y, _z);
	public Float2 yo => new Float2(_y, 0f);
	public Float2 yl => new Float2(_y, 1f);

	public Float2 zx => new Float2(_z, _x);
	public Float2 zy => new Float2(_z, _y);
	public Float2 zz => new Float2(_z, _z);
	public Float2 zo => new Float2(_z, 0f);
	public Float2 zl => new Float2(_z, 1f);

	public Float2 ox => new Float2(0f, _x);
	public Float2 oy => new Float2(0f, _y);
	public Float2 oz => new Float2(0f, _z);
	public static Float2 oo => new Float2(0f, 0f);
	public static Float2 ol => new Float2(0f, 1f);

	public Float2 lx => new Float2(1f, _x);
	public Float2 ly => new Float2(1f, _y);
	public Float2 lz => new Float2(1f, _z);
	public static Float2 lo => new Float2(1f, 0f);
	public static Float2 ll => new Float2(1f, 1f);
	#endregion

	#region Float3Properties
	#region FirstX
	public Float3 xxx => new Float3(_x, _x, _x);
	public Float3 xxy => new Float3(_x, _x, _y);
	public Float3 xxz => new Float3(_x, _x, _z);
	public Float3 xxo => new Float3(_x, _x, 0f);
	public Float3 xxl => new Float3(_x, _x, 1f);

	public Float3 xyx => new Float3(_x, _y, _x);
	public Float3 xyy => new Float3(_x, _y, _y);
	public Float3 xyz => new Float3(_x, _y, _z);
	public Float3 xyo => new Float3(_x, _y, 0f);
	public Float3 xyl => new Float3(_x, _y, 1f);

	public Float3 xzx => new Float3(_x, _z, _x);
	public Float3 xzy => new Float3(_x, _z, _y);
	public Float3 xzz => new Float3(_x, _z, _z);
	public Float3 xzo => new Float3(_x, _z, 0f);
	public Float3 xzl => new Float3(_x, _z, 1f);

	public Float3 xox => new Float3(_x, 0f, _x);
	public Float3 xoy => new Float3(_x, 0f, _y);
	public Float3 xoz => new Float3(_x, 0f, _z);
	public Float3 xoo => new Float3(_x, 0f, 0f);
	public Float3 xol => new Float3(_x, 0f, 1f);

	public Float3 xlx => new Float3(_x, 1f, _x);
	public Float3 xly => new Float3(_x, 1f, _y);
	public Float3 xlz => new Float3(_x, 1f, _z);
	public Float3 xlo => new Float3(_x, 1f, 0f);
	public Float3 xll => new Float3(_x, 1f, 1f);
	#endregion
	#region FirstY
	public Float3 yxx => new Float3(_y, _x, _x);
	public Float3 yxy => new Float3(_y, _x, _y);
	public Float3 yxz => new Float3(_y, _x, _z);
	public Float3 yxo => new Float3(_y, _x, 0f);
	public Float3 yxl => new Float3(_y, _x, 1f);

	public Float3 yyx => new Float3(_y, _y, _x);
	public Float3 yyy => new Float3(_y, _y, _y);
	public Float3 yyz => new Float3(_y, _y, _z);
	public Float3 yyo => new Float3(_y, _y, 0f);
	public Float3 yyl => new Float3(_y, _y, 1f);

	public Float3 yzx => new Float3(_y, _z, _x);
	public Float3 yzy => new Float3(_y, _z, _y);
	public Float3 yzz => new Float3(_y, _z, _z);
	public Float3 yzo => new Float3(_y, _z, 0f);
	public Float3 yzl => new Float3(_y, _z, 1f);

	public Float3 yox => new Float3(_y, 0f, _x);
	public Float3 yoy => new Float3(_y, 0f, _y);
	public Float3 yoz => new Float3(_y, 0f, _z);
	public Float3 yoo => new Float3(_y, 0f, 0f);
	public Float3 yol => new Float3(_y, 0f, 1f);

	public Float3 ylx => new Float3(_y, 1f, _x);
	public Float3 yly => new Float3(_y, 1f, _y);
	public Float3 ylz => new Float3(_y, 1f, _z);
	public Float3 ylo => new Float3(_y, 1f, 0f);
	public Float3 yll => new Float3(_y, 1f, 1f);
	#endregion
	#region FirstZ
	public Float3 zxx => new Float3(_z, _x, _x);
	public Float3 zxy => new Float3(_z, _x, _y);
	public Float3 zxz => new Float3(_z, _x, _z);
	public Float3 zxo => new Float3(_z, _x, 0f);
	public Float3 zxl => new Float3(_z, _x, 1f);

	public Float3 zyx => new Float3(_z, _y, _x);
	public Float3 zyy => new Float3(_z, _y, _y);
	public Float3 zyz => new Float3(_z, _y, _z);
	public Float3 zyo => new Float3(_z, _y, 0f);
	public Float3 zyl => new Float3(_z, _y, 1f);

	public Float3 zzx => new Float3(_z, _z, _x);
	public Float3 zzy => new Float3(_z, _z, _y);
	public Float3 zzz => new Float3(_z, _z, _z);
	public Float3 zzo => new Float3(_z, _z, 0f);
	public Float3 zzl => new Float3(_z, _z, 1f);

	public Float3 zox => new Float3(_z, 0f, _x);
	public Float3 zoy => new Float3(_z, 0f, _y);
	public Float3 zoz => new Float3(_z, 0f, _z);
	public Float3 zoo => new Float3(_z, 0f, 0f);
	public Float3 zol => new Float3(_z, 0f, 1f);

	public Float3 zlx => new Float3(_z, 1f, _x);
	public Float3 zly => new Float3(_z, 1f, _y);
	public Float3 zlz => new Float3(_z, 1f, _z);
	public Float3 zlo => new Float3(_z, 1f, 0f);
	public Float3 zll => new Float3(_z, 1f, 1f);
	#endregion
	#region FirstO
	public Float3 oxx => new Float3(0f, _x, _x);
	public Float3 oxy => new Float3(0f, _x, _y);
	public Float3 oxz => new Float3(0f, _x, _z);
	public Float3 oxo => new Float3(0f, _x, 0f);
	public Float3 oxl => new Float3(0f, _x, 1f);

	public Float3 oyx => new Float3(0f, _y, _x);
	public Float3 oyy => new Float3(0f, _y, _y);
	public Float3 oyz => new Float3(0f, _y, _z);
	public Float3 oyo => new Float3(0f, _y, 0f);
	public Float3 oyl => new Float3(0f, _y, 1f);

	public Float3 ozx => new Float3(0f, _z, _x);
	public Float3 ozy => new Float3(0f, _z, _y);
	public Float3 ozz => new Float3(0f, _z, _z);
	public Float3 ozo => new Float3(0f, _z, 0f);
	public Float3 ozl => new Float3(0f, _z, 1f);

	public Float3 oox => new Float3(0f, 0f, _x);
	public Float3 ooy => new Float3(0f, 0f, _y);
	public Float3 ooz => new Float3(0f, 0f, _z);
	public static Float3 ooo => new Float3(0f, 0f, 0f);
	public static Float3 ool => new Float3(0f, 0f, 1f);

	public Float3 olx => new Float3(0f, 1f, _x);
	public Float3 oly => new Float3(0f, 1f, _y);
	public Float3 olz => new Float3(0f, 1f, _z);
	public static Float3 olo => new Float3(0f, 1f, 0f);
	public static Float3 oll => new Float3(0f, 1f, 1f);
	#endregion
	#region FirstL
	public Float3 lxx => new Float3(1f, _x, _x);
	public Float3 lxy => new Float3(1f, _x, _y);
	public Float3 lxz => new Float3(1f, _x, _z);
	public Float3 lxo => new Float3(1f, _x, 0f);
	public Float3 lxl => new Float3(1f, _x, 1f);

	public Float3 lyx => new Float3(1f, _y, _x);
	public Float3 lyy => new Float3(1f, _y, _y);
	public Float3 lyz => new Float3(1f, _y, _z);
	public Float3 lyo => new Float3(1f, _y, 0f);
	public Float3 lyl => new Float3(1f, _y, 1f);

	public Float3 lzx => new Float3(1f, _z, _x);
	public Float3 lzy => new Float3(1f, _z, _y);
	public Float3 lzz => new Float3(1f, _z, _z);
	public Float3 lzo => new Float3(1f, _z, 0f);
	public Float3 lzl => new Float3(1f, _z, 1f);

	public Float3 lox => new Float3(1f, 0f, _x);
	public Float3 loy => new Float3(1f, 0f, _y);
	public Float3 loz => new Float3(1f, 0f, _z);
	public static Float3 loo => new Float3(1f, 0f, 0f);
	public static Float3 lol => new Float3(1f, 0f, 1f);

	public Float3 llx => new Float3(1f, 1f, _x);
	public Float3 lly => new Float3(1f, 1f, _y);
	public Float3 llz => new Float3(1f, 1f, _z);
	public static Float3 llo => new Float3(1f, 1f, 0f);
	public static Float3 lll => new Float3(1f, 1f, 1f);
	#endregion
	#endregion

	#region Operators
	public static float operator +(Float3 f3) => f3._x + f3._y + f3._z;
	public static Float3 operator -(Float3 f3) => new Float3(-f3._x, -f3._y, -f3._z);

	public static Float3 operator +(Float3 lhs, Float3 rhs) => new Float3(lhs._x + rhs._x, lhs._y + rhs._y, lhs._z + rhs._z);
	public static Float3 operator -(Float3 lhs, Float3 rhs) => new Float3(lhs._x - rhs._x, lhs._y - rhs._y, lhs._z - rhs._z);
	public static Float3 operator *(Float3 lhs, Float3 rhs) => new Float3(lhs._x * rhs._x, lhs._y * rhs._y, lhs._z * rhs._z);
	public static Float3 operator /(Float3 lhs, Float3 rhs) => new Float3(lhs._x / rhs._x, lhs._y / rhs._y, lhs._z / rhs._z);

	public static Float3 operator +(Float3 lhs, float rhs) => new Float3(lhs._x + rhs, lhs._y + rhs, lhs._z + rhs);
	public static Float3 operator +(float lhs, Float3 rhs) => new Float3(lhs + rhs._x, lhs + rhs._y, lhs + rhs._z);
	public static Float3 operator -(Float3 lhs, float rhs) => new Float3(lhs._x - rhs, lhs._y - rhs, lhs._z - rhs);
	public static Float3 operator -(float lhs, Float3 rhs) => new Float3(lhs - rhs._x, lhs - rhs._y, lhs - rhs._z);
	public static Float3 operator *(Float3 lhs, float rhs) => new Float3(lhs._x * rhs, lhs._y * rhs, lhs._z * rhs);
	public static Float3 operator *(float lhs, Float3 rhs) => new Float3(lhs * rhs._x, lhs * rhs._y, lhs * rhs._z);
	public static Float3 operator /(Float3 lhs, float rhs) => new Float3(lhs._x / rhs, lhs._y / rhs, lhs._z / rhs);
	public static Float3 operator /(float lhs, Float3 rhs) => new Float3(lhs / rhs._x, lhs / rhs._y, lhs / rhs._z);

	public static implicit operator Vector3(Float3 f3) => new Vector3(f3._x, f3._y, f3._z);
	#endregion
}
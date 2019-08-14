using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace General {
	public class BitSet : ISendable, ILoadable<BitSet>, ICollection<int>, IEnumerable<int> {
		private const int _index_offset = 5;

		#region Data
		private Dictionary<int, int> _arr;
		private bool _inv;
		#endregion

		#region Constructors
		public BitSet(bool inv = false) {
			_arr = new Dictionary<int, int>();
			_inv = inv;
		}

		public BitSet(IEnumerable<int> arr, bool inv = false) {
			_arr = new Dictionary<int, int>();
			_inv = inv;
			foreach(int i in arr)
				this[i] = inv;
		}

		public BitSet(BitSet bs) {
			_arr = new Dictionary<int, int>(bs._arr.Count);
			foreach(var vp in bs._arr)
				_arr[vp.Key] = vp.Value;
			_inv = bs._inv;
		}
		#endregion

		#region PrivateMethods
		private int GetChunk(int i) {
			if(!_arr.ContainsKey(i))
				return _inv ? -1 : 0;
			return _inv ? ~_arr[i] : _arr[i];
		}

		private BitSet SetChunk(int i, int chunk) {
			if((chunk == 0 && !_inv) || (chunk == -1 && _inv)) {
				_arr.Remove(i);
			} else {
				_arr[i] = _inv ? ~chunk : chunk;
			}
			return this;
		}

		private int GetCount() {
			int ret = 0;
			foreach(var vp in _arr) {
				ret += BitCount((uint)vp.Value);
			}
			return ret;
		}

		private static int BitCount(uint value) {
			uint result = value - ((value >> 1) & 0x55555555U);
			result = (result & 0x33333333U) + ((result >> 2) & 0x33333333U);
			return (int)(unchecked(((result + (result >> 4)) & 0xF0F0F0FU) * 0x1010101U) >> 24);
		}

		private static IEnumerable<int> Enumerate(BitSet b) {
			foreach(var chunk in b._arr) {
				for(int i = 0; i < 32; i++) {
					int tmp = chunk.Value >> i;
					if(tmp == 0)
						break;
					if((tmp & 1) != 0)
						yield return (chunk.Key << _index_offset) + i;
				}
			}
		}

		private static BitSet And(BitSet lhs, BitSet rhs, bool invl = false, bool invr = false, bool invo = false) {
			bool linv = (lhs._inv ^ invl), rinv = (rhs._inv ^ invr), oinv = (linv && rinv);
			BitSet ret = new BitSet(oinv);
			lhs._inv = linv;
			rhs._inv = rinv;
			foreach(int key in lhs._arr.Keys) {
				if(rhs._arr.ContainsKey(key))
					ret.SetChunk(key, lhs.GetChunk(key) & rhs.GetChunk(key));
				else if(rhs._inv)
					ret.SetChunk(key, lhs.GetChunk(key));
			}
			foreach(int key in rhs._arr.Keys) {
				if(lhs._inv && !lhs._arr.ContainsKey(key))
					ret.SetChunk(key, rhs.GetChunk(key));
			}
			lhs._inv = linv ^ invl;
			rhs._inv = rinv ^ invr;
			ret._inv = oinv ^ invo;
			return ret;
		}
		#endregion

		#region Operators
		public static BitSet operator !(BitSet os) => os.copy;
		public static BitSet operator ~(BitSet os) => new BitSet(os) { _inv = !os._inv };
		public static BitSet operator &(BitSet lhs, BitSet rhs) => And(lhs, rhs);   //intersection
		public static BitSet operator |(BitSet lhs, BitSet rhs) => And(lhs, rhs, true, true, true);  //union
		public static BitSet operator +(BitSet lhs, BitSet rhs) => lhs | rhs;       //union
		public static BitSet operator -(BitSet lhs, BitSet rhs) => And(lhs, rhs, false, true);      //difference
		public static BitSet operator +(BitSet lhs, int rhs) => (!lhs).AddValue(rhs);
		public static BitSet operator -(BitSet lhs, int rhs) => (!lhs).RemoveValue(rhs);

		//if inverted will return values excluded instead of included
		public static implicit operator List<int>(BitSet os) => new List<int>(os);
		#endregion

		#region Properties
		public bool this[int i] {
			get => HasValue(i);
			set { if(value) AddValue(i); else RemoveValue(i); }
		}

		public BitSet copy => new BitSet(this);

		public int Count => GetCount();

		public bool IsReadOnly => false;
		#endregion

		#region InnateMethods
		public bool HasValue(int i) => (GetChunk(i >> _index_offset) & (1 << (i & 0x1F))) != 0;

		public BitSet AddValue(int i) => SetChunk(i >> _index_offset, GetChunk(i >> _index_offset) | (1 << (i & 0x1F)));

		public BitSet RemoveValue(int i) => SetChunk(i >> _index_offset, GetChunk(i >> _index_offset) & ~(1 << (i & 0x1F)));

		public BitSet AddRange(IEnumerable<int> range) {
			foreach(int i in range)
				AddValue(i);
			return this;
		}

		public BitSet RemoveRange(IEnumerable<int> range) {
			foreach(int i in range)
				RemoveValue(i);
			return this;
		}

		public BitSet SetRange(int start, int length, bool set = true) {
			int sidx = start >> _index_offset;
			int eidx = (start + length) >> _index_offset;
			for(int cidx = sidx; cidx <= eidx; cidx++) {
				int chunk = -1;
				if(cidx == sidx)
					chunk &= (-1 << (start & 0x1F));
				if(cidx == eidx)
					chunk &= ~(-1 << ((start + length) & 0x1F));
				if(set)
					chunk |= GetChunk(cidx);
				else
					chunk = GetChunk(cidx) & ~chunk;
				SetChunk(cidx, chunk);
			}
			return this;
		}

		public void Clear() {
			_arr.Clear();
			_inv = false;
		}
		#endregion

		#region InheritedMethods
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		public IEnumerator<int> GetEnumerator() => Enumerate(this).GetEnumerator();

		public void Add(int item) => AddValue(item);
		public bool Contains(int item) => HasValue(item);
		public void CopyTo(int[] array, int arrayIndex) {
			foreach(int i in this)
				array[arrayIndex++] = i;
		}
		public bool Remove(int item) {
			if(!HasValue(item))
				return false;
			RemoveValue(item);
			return true;
		}

		public BitSet Load(BinaryReader br) {
			int l = br.ReadInt32();
			_arr = new Dictionary<int, int>(l);
			for(int i = 0; i < l; i++)
				_arr[br.ReadInt32()] = br.ReadInt32();
			_inv = br.ReadBoolean();
			return this;
		}

		public void ToSend(BinaryWriter bw) {
			bw.Write(_arr.Count);
			foreach(var vp in _arr) {
				bw.Write(vp.Key);
				bw.Write(vp.Value);
			}
			bw.Write(_inv);
		}
		#endregion
	}
}
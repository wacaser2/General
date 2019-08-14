using System;
using System.Collections.Generic;
using System.Linq;

namespace General {
	public static class IEnumerableExtensions {
		public static IEnumerable<T> Loop<T>(this IEnumerable<T> source, int maxIterations = 10000) {
			int iteration = 0;
			while(iteration++ < maxIterations) {
				foreach(T item in source)
					yield return item;
			}
		}

		public static IEnumerable<int> Indices<T>(this IEnumerable<T> source) where T : IIndexed => source.Select(t => t.idx);

		public static IEnumerable<T> SkipFirstMatch<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
			bool seen = false;
			foreach(T item in source) {
				if(seen || !(seen = predicate(item)))
					yield return item;
			}
		}

		public static IEnumerable<T> WhenEnd<T>(this IEnumerable<T> source, Action action) {
			foreach(T item in source)
				yield return item;
			action?.Invoke();
		}

		public static IEnumerable<T> When<T>(this IEnumerable<T> source, Func<T, bool> predicate, Action<T> action) {
			foreach(T item in source) {
				if(predicate(item))
					action?.Invoke(item);
				yield return item;
			}
		}
	}
}
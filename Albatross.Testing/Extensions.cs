using System.Collections.Generic;

namespace Albatross.Testing {
	public static class Extensions {
		public static IEnumerable<object[]> ConvertToTheory<T>(this IEnumerable<T> source) where T : notnull {
			foreach (var item in source) {
				yield return new object[] { item };
			}
		}
		
		public static string NormalizeLineEnding(this string text) {
			if (string.IsNullOrEmpty(text)) return text;
			return text.Replace("\r\n", "\n");
		}
	}
}

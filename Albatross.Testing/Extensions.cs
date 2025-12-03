using System.Collections.Generic;
using Xunit;

namespace Albatross.Testing {
	public static class Extensions {
		public static IEnumerable<object[]> ConvertToTheory<T>(this IEnumerable<T> source) where T : notnull {
			foreach (var item in source) {
				yield return new object[] { item };
			}
		}
		
		/// <summary>
		/// Remove carriage return and the trailing line ending
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string? NormalizeLineEnding(this string? text) {
			if (string.IsNullOrEmpty(text)) { return text; }
			return text.Replace("\r", "").TrimEnd('\n');
		}

		/// <summary>
		/// compare 2 string without carriage return or line feed
		/// </summary>
		/// <param name="expected"></param>
		/// <param name="actual"></param>
		public static void EqualsIgnoringLineEndings(this string? expected, string? actual) {
			if (!string.IsNullOrEmpty(expected)) {
				expected = expected.Replace("\r", "").Replace("\n", "");
			}
			if(!string.IsNullOrEmpty(actual)) {
				actual = actual.Replace("\r", "").Replace("\n", "");
			}
			Assert.Equal(expected, actual);
		}
	}
}

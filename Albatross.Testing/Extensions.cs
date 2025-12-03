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
		public static string NormalizeLineEnding(this string? text) {
			if (string.IsNullOrEmpty(text)) return text;
			return text.Replace("\r", "").TrimEnd('\n');
		}

		public static void EqualIgnoringLineEndings(this string? expected, string? actual) {
			expected = expected.NormalizeLineEnding();
			actual = actual.NormalizeLineEnding();
			Assert.Equal(expected, actual);
		}
	}
}



using System.Collections.Generic;
using System.Linq;

namespace Katas
{
	public class WordWrap
	{
		public string Wrap(string s, int length)
		{
			var words = Split_into_words(s);
			var wordsAllShorterThanLength = Split_too_long_words(words, length);
			var lines = Build_lines(wordsAllShorterThanLength, length, new List<string>());
			return Assemble_lines(lines);
		}

		private static IList<string> Split_into_words(string s)
		{
			return s.Split(' ');
		}

		private static IList<string> Split_too_long_words(IList<string> wordList, int length)
		{
			if (wordList.All(x => x.Length <= length))
			{
				return wordList;
			}
			var result = new List<string>();
			foreach (var word in wordList)
			{
				if (word.Length > length)
				{
					result.Add(word.Substring(0, length));
					result.Add(word.Substring(length));
				}
				else
				{
					result.Add(word);
				}
			}
			return Split_too_long_words(result, length);
		}

		private static IList<string> Build_lines(IList<string> words, int length, IList<string> lines)
		{
			if (words.Count == 0) return lines;
			if (words.Count == 1)
			{
				lines.Add(words[0]);
				return lines;
			}
			var line = words[0];
			var wordsIndex = 1;
			var lineFull = false;
			while (!lineFull && wordsIndex < words.Count)
			{
				if (line.Length + 1 + words[wordsIndex].Length > length)
				{
					line += '\n';
					lineFull = true;
				}
				else
				{
					line += ' ' + words[wordsIndex++];
				}
			}
			lines.Add(line);
			return Build_lines(words.Skip(wordsIndex).ToList(), length, lines);
		}

		private static string Assemble_lines(IEnumerable<string> lines)
		{
			return lines.Aggregate("", (current, item) => current + item);
		}
	}
}

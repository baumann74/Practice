
using Katas;

namespace KatasTest.WordWrapTest
{
	using FluentAssertions;
	using NUnit.Framework;
	using System.Collections.Generic;
	using System.Reflection;

	[TestFixture]
	public class WordWrapTests
	{
		[TestCase("This is a story", 5, "This\nis a\nstory")]
		[TestCase("line1 l ine2", 7, "line1 l\nine2")]
		[TestCase("Abekattemand er en god mand", 4, "Abek\natte\nmand\ner\nen\ngod\nmand")]
		public void TestWrap(string input, int length, string output)
		{
			// arrange
			var sut = new WordWrap();

			// act
			sut.Wrap(input, length).Should().Be(output);
		}

		[Test]
		public void Split_into_words()
		{
			// arrange
			var mi = typeof(WordWrap).GetMethod("Split_into_words", BindingFlags.NonPublic | BindingFlags.Static);
			var sut = new WordWrap();

			// act
			var result = mi.Invoke(sut, new object[] { "This is a story" }) as IList<string>;

			// assert
			result.Should().BeEquivalentTo(new[] {"This", "is", "a", "story"});
		}

		[Test]
		public void Split_long_words()
		{
			// arrange
			var mi = typeof(WordWrap).GetMethod("Split_too_long_words", BindingFlags.NonPublic | BindingFlags.Static);
			var sut = new WordWrap();

			// act
			var result = mi.Invoke(sut, new object[] { new List<string> { "123456789", "abc", "1234", "12345" }, 4 }) as IList<string>;

			// assert
			result.Should().BeEquivalentTo(new[] { "1234", "5678", "9", "abc", "1234", "1234", "5" });
		}

		[Test]
		public void Build_lines()
		{
			// arrange
			var mi = typeof(WordWrap).GetMethod("Build_lines", BindingFlags.NonPublic | BindingFlags.Static);
			var sut = new WordWrap();

			// act
			var result = mi.Invoke(sut, new object[] { new List<string> { "This", "is", "a", "dog" }, 4, new List<string>() }) as IList<string>;

			// assert
			result.Should().BeEquivalentTo(new List<string> { "This\n", "is a\n", "dog" });
		}

		[Test]
		public void Build_lines_One_word_on_each_line()
		{
			// arrange
			var mi = typeof(WordWrap).GetMethod("Build_lines", BindingFlags.NonPublic | BindingFlags.Static);
			var sut = new WordWrap();

			// act
			var result = mi.Invoke(sut, new object[] { new List<string> { "This", "house", "has", "many", "doors" }, 3, new List<string>() }) as IList<string>;

			// assert
			result.Should().BeEquivalentTo(new List<string> { "This\n", "house\n", "has\n", "many\n", "doors" });
		}

		[Test]
		public void Build_lines_All_words_on_one_line()
		{
			// arrange
			var mi = typeof(WordWrap).GetMethod("Build_lines", BindingFlags.NonPublic | BindingFlags.Static);
			var sut = new WordWrap();

			// act
			var result = mi.Invoke(sut, new object[] { new List<string> { "This", "house", "has", "many", "doors" }, 100, new List<string>() }) as IList<string>;

			// assert
			result.Should().BeEquivalentTo(new List<string> { "This house has many doors" });
		}

		[Test]
		public void Build_lines_One_word()
		{
			// arrange
			var mi = typeof(WordWrap).GetMethod("Build_lines", BindingFlags.NonPublic | BindingFlags.Static);
			var sut = new WordWrap();

			// act
			var result = mi.Invoke(sut, new object[] { new List<string> { "This", }, 5, new List<string>() }) as IList<string>;

			// assert
			result.Should().BeEquivalentTo(new List<string> { "This" });
		}

		[Test]
		public void Assemble_lines()
		{
			// arrange
			var mi = typeof(WordWrap).GetMethod("Assemble_lines", BindingFlags.NonPublic | BindingFlags.Static);
			var sut = new WordWrap();

			// act
			var result = mi.Invoke(sut, new object[] { new List<string> { "Foo\n", "bar\n", "Noop" } }) as string;

			// assert
			result.Should().BeEquivalentTo("Foo\nbar\nNoop" );
		}
	}
}

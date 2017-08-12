namespace Katas
{
	public class BottlesSong
	{
		public static string Song()
		{
			const string newParagraph = "\r\n" + "\r\n";
			var result = "";
			for (var n = 99; n >= 3; n--)
			{
				result = result + Verse(n) + newParagraph;
			}
			return result + Verse2() + newParagraph + Verse1() + newParagraph + VerseEmpty();
		}

		public static string Verse(int n)
		{
			return $@"{n} bottles of beer on the wall, {n} bottles of beer.
Take one down and pass it around, {n - 1} bottles of beer on the wall.";
		}

		private static string Verse2()
		{
			return @"2 bottles of beer on the wall, 2 bottles of beer.
Take one down and pass it around, 1 bottle of beer on the wall.";
		}


		private static string Verse1()
		{
			return @"1 bottle of beer on the wall, 1 bottle of beer.
Take it down and pass it around, no more bottles of beer on the wall.";
		}

		private static string VerseEmpty()
		{
			return @"No more bottles of beer on the wall, no more bottles of beer.
Go to the store and buy some more, 99 bottles of beer on the wall.";
		}
	}
}

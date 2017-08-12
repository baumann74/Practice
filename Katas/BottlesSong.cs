namespace Katas
{
	public class BottlesSong
	{
		public static string Song()
		{
			var result = "";
			for (var n = 99; n >= 3; n--)
			{
				result = result + Verse(n);
			}
			return result + Verse2() + Verse1() + VerseEmpty();
		}

		public static string Verse(int n)
		{
			return $"{n} bottles of beer on the wall, {n} bottles of beer.\r\nTake one down and pass it around," +
			       $" {n - 1} bottles of beer on the wall.\r\n\r\n";
		}

		private static string Verse2()
		{
			return "2 bottles of beer on the wall, 2 bottles of beer.\r\nTake one down and pass it around, 1 bottle of beer on the wall.\r\n\r\n";
		}

		private static string Verse1()
		{
			return "1 bottle of beer on the wall, 1 bottle of beer.\r\nTake it down and pass it around, no more bottles of beer on the wall.\r\n\r\n";
		}

		private static string VerseEmpty()
		{
			return "No more bottles of beer on the wall, no more bottles of beer.\r\nGo to the store and buy some more, 99 bottles of beer on the wall.";
		}
	}
}

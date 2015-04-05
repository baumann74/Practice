
namespace ProjectEuler.Test
{
	using NUnit.Framework;

	[TestFixture]
	class ProblemsTests
	{
		[Test]
		public void Largest_palindrome_product()
		{
			Assert.AreEqual(906609, Problems.Largest_palindrome_product());
		}
	}
}

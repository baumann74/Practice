using Microsoft.VisualStudio.TestTools.UnitTesting;
using Misc;

namespace MiscTest
{
	[TestClass]
	public class LargestPuddleTest
	{
		[TestMethod]
		public void Calculate()
		{
			var su = new LargestPuddle();
			Assert.AreEqual(100, su.Calculate(new [] { 10, 20, 80, 70, 60, 90, 40, 30, 40, 70 }));
		}
	}
}

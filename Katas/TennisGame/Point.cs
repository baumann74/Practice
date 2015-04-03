
namespace Katas.TennisGame
{
	public interface IPoint
	{
		IPoint Won();

		IPoint Lost();

		bool IsGamePoint();
	}

	//		public class RegularPoint : Point
	//		{
	//			private string asString;
	//	
	//			public RegularPoint(string asString, string nextAsString)
	//			{
	//				this.asString = asString;
	//			}
	//	
	//			public string AsString()
	//			{
	//				return asString;
	//			}
	//	
	//			public Point Won()
	//			{
	//				throw new System.NotImplementedException();
	//			}
	//	
	//			public Point Lost()
	//			{
	//				throw new System.NotImplementedException();
	//			}
	//	
	//			public bool IsGamePoint()
	//			{
	//				throw new System.NotImplementedException();
	//			}
	//		}

	public class PointLove : IPoint
	{
		public IPoint Won()
		{
			return new PointFifteen();
		}

		public IPoint Lost()
		{
			return this;
		}

		public bool IsGamePoint()
		{
			return false;
		}

		public override string ToString()
		{
			return "15";
		}
	}

	public class PointFifteen : IPoint
	{
		public IPoint Won()
		{
			return new PointThirty();
		}

		public IPoint Lost()
		{
			return this;
		}

		public bool IsGamePoint()
		{
			return false;
		}

		public override string ToString()
		{
			return "30";
		}
	}

	public class PointThirty : IPoint
	{
		public IPoint Won()
		{
			return new PointFourty();
		}

		public IPoint Lost()
		{
			return this;
		}

		public bool IsGamePoint()
		{
			return false;
		}

		public override string ToString()
		{
			return "30";
		}
	}

	public class PointFourty : IPoint
	{
		public IPoint Won()
		{
			return new PointAdvantage();
		}

		public IPoint Lost()
		{
			return this;
		}

		public bool IsGamePoint()
		{
			return true;
		}

		public override string ToString()
		{
			throw new System.NotImplementedException();
		}
	}

	public class PointAdvantage : IPoint
	{
		public IPoint Won()
		{
			throw new System.NotImplementedException();
		}

		public IPoint Lost()
		{
			throw new System.NotImplementedException();
		}

		public bool IsGamePoint()
		{
			throw new System.NotImplementedException();
		}

		public override string ToString()
		{
			throw new System.NotImplementedException();
		}
	}
}

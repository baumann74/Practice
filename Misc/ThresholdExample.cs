
namespace Misc
{
	// http://dotnetcodr.com/2015/05/21/solid-principles-in-net-revisited-part-9-concentrating-on-enumerations/
	public class ThresholdExample
	{
		public class PerformanceSummary
		{
			public double TotalPassedLoops { get; set; }
			public double TotalFailedLoops { get; set; }
			public double TotalPassedCallsPerMinute { get; set; }
			public double AverageNetworkThroughput { get; set; }
			public double AverageSessionTimePerLoop { get; set; }
			public double AverageResponseTimePerLoop { get; set; }
			public double WebTransactionRate { get; set; }
			public double AverageResponseTimePerPage { get; set; }
			public double TotalHttpCalls { get; set; }
			public double AverageNetworkConnectTime { get; set; }
			public double TotalTransmittedBytes { get; set; }
		}

		public interface IPerformanceEvaluator
		{
			bool Evaluate(PerformanceSummary summary);
		}

		public interface IEvaluationOperator
		{
			bool IsThresholdBroken(double input);
		}

		public class GreaterThanEvaluator : IEvaluationOperator
		{
			private readonly double threshold;

			public GreaterThanEvaluator(double threshold)
			{
				this.threshold = threshold;
			}

			public bool IsThresholdBroken(double input)
			{
				return threshold < input;
			}
		}

		public class LessThanEvaluator : IEvaluationOperator
		{
			private readonly double threshold;

			public LessThanEvaluator(double threshold)
			{
				this.threshold = threshold;
			}

			public bool IsThresholdBroken(double input)
			{
				return threshold > input;
			}
		}

		public class AverageResponseTimeEvaluator : IPerformanceEvaluator
		{
			private readonly IEvaluationOperator evaluator;

			public AverageResponseTimeEvaluator(IEvaluationOperator evaluator)
			{
				this.evaluator = evaluator;
			}

			public bool Evaluate(PerformanceSummary summary)
			{
				return evaluator.IsThresholdBroken(summary.AverageResponseTimePerPage);
			}
		}

		public class UrlCallsPassedPerMinuteEvaluator : IPerformanceEvaluator
		{
			private readonly IEvaluationOperator evaluator;

			public UrlCallsPassedPerMinuteEvaluator(IEvaluationOperator evaluator)
			{
				this.evaluator = evaluator;
			}

			public bool Evaluate(PerformanceSummary summary)
			{
				return evaluator.IsThresholdBroken(summary.TotalPassedCallsPerMinute);
			}
		}
	}
}


namespace Misc
{
	// http://dotnetcodr.com/2015/05/21/solid-principles-in-net-revisited-part-9-concentrating-on-enumerations/
	// Flow: performance summery -> extract metric -> apply operator

	public class ThresholdExampleWithFlowDesign
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

		public class ThresholdEvaluationResult
		{
			public bool ThresholdBroken { get; set; }
		}

		public interface IMetricExtractor
		{
			double Extract(PerformanceSummary summary);
		}

		public class AverageResponseExtractor : IMetricExtractor
		{
			public double Extract(PerformanceSummary summary)
			{
				return summary.AverageResponseTimePerPage;
			}
		}

		public class UrlCallsPassedPerMinuteExtractor : IMetricExtractor
		{
			public double Extract(PerformanceSummary summary)
			{
				return summary.AverageResponseTimePerPage;
			}
		}

		public interface IEvaluationOperator
		{
			bool IsValid(double limit, double input);
		}

		public class GreaterThanEvaluator : IEvaluationOperator
		{

			public bool IsValid(double limit, double input)
			{
				return limit < input;
			}
		}

		public class LessThanEvaluator : IEvaluationOperator
		{

			public bool IsValid(double limit, double input)
			{
				return limit > input;
			}
		}

		public class Threshold
		{
			private readonly double limit;
			private readonly IEvaluationOperator evaluationOperator;
			private readonly IMetricExtractor extractor;

			public Threshold(IEvaluationOperator evaluationOperator, IMetricExtractor extractor, double limit)
			{
				this.evaluationOperator = evaluationOperator;
				this.extractor = extractor;
				this.limit = limit;
			}

			public ThresholdEvaluationResult Evaluate(PerformanceSummary summary)
			{
				var metric = extractor.Extract(summary);
				var isBroken = evaluationOperator.IsValid(limit, metric);

				return new ThresholdEvaluationResult
				{
					ThresholdBroken	 = isBroken
				};
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core.Server
{
	[DataContract]
	public class GetTestStatisticsResult
	{
		[DataMember]
		public double? AverageScore
		{
			get;
			set;
		}

		[DataMember]
		public double PassedPercent
		{
			get;
			set;
		}

		[DataMember]
		public TestStatistics[] TestStatistics
		{
			get;
			set;
		}
	}
}

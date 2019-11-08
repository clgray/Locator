using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core.Server
{
	[DataContract]
	public class TestStatistics
	{
		[DataMember]
		public double Score
		{
			get;
			set;
		}

		[DataMember]
		public int ScoreCount
		{
			get;
			set;
		}
	}
}

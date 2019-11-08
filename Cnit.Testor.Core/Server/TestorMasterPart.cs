using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Cnit.Testor.Core.Server
{
	[DataContract]
	public class TestorMasterPart
	{
		[DataMember(IsRequired = true)]
		public int PartTestId
		{
			get;
			set;
		}

		[DataMember(IsRequired = true)]
		public int QuestionsNumber
		{
			get;
			set;
		}

		[DataMember(IsRequired = true)]
		public string Name
		{
			get;
			set;
		}
	}
}

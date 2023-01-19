using System;
using System.Collections.Generic;

namespace mqttTest.models
{
	public class GameInfo
	{
		private long _RunTime = 0;
		private long _TimeLimit = 0;

		[JsonProperty("inProgress")]
		public bool GameInProgress { get; set; }

		[JsonProperty("runTime")]
		public long RunTime
		{
			get { return _RunTime; }
			set
			{
				_RunTime = value;
			}
		}

		[JsonProperty("timeLimit")]
		public long TimeLimit
		{
			get { return _TimeLimit; }

			set
			{
				List<long> timeLimits = new List<long> { 15 * 60, 60 * 60, 120 * 60, 240 * 60 };
				if (timeLimits.Contains(value)) _TimeLimit = value;
			}
		}

	}
}

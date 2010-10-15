using System;

namespace CHSNS
{
	public class HostEnvironment
	{
		/// <summary>
		/// 服务器启动时间
		/// 重典 http://chsword.cnblogs.com
		/// http://bbs.eice.com.cn
		/// </summary>
		/// <value>The system uptime.</value>
		public String SystemUptime
		{
			get
			{
				int tickCount = System.Environment.TickCount;
				if (tickCount < 0)
				{
					tickCount += 2147483647;
				}
				tickCount /= 1000;
				TimeSpan span = TimeSpan.FromSeconds(tickCount);
				return ((((span.Days + "d ") + span.Hours + "h ") + span.Minutes + "m ") + span.Seconds + "s");
			}
		}
	}
}
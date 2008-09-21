/*
 * Created by 邹健
 * Date: 2007-10-23
 * Time: 13:31
 * 
 * 
 */
using System.Management;
namespace CHSNS
{
	/// <summary>
	/// Description of NetworkCross.
	/// </summary>
	public class NetworkCross{
		/// <summary>
		/// 读取设备
		/// </summary>
		private ManagementClass mc;
		private ManagementObjectCollection moc;
		private ManagementObject disk;
		/// <summary>
		/// 取得设备网卡的MAC地址
		/// </summary>
		public string GetNetCardMacAddress()
		{
			mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
			moc = mc.GetInstances();
			string str = "";
			foreach(ManagementObject mo in moc)
			{
				if((bool)mo["IPEnabled"] == true)
					str = mo["MacAddress"].ToString();
				
			}
			return str;
		}
		/// <summary>
		/// 取得设备硬盘的卷标号
		/// </summary>
		/// <returns>硬盘的卷标号</returns>
		public string GetDiskVolumeSerialNumber()
		{
			mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
			disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
			disk.Get();
			return disk.GetPropertyValue("VolumeSerialNumber").ToString();
		}
		/// <summary>
		/// 获取CPU编号
		/// </summary>
		/// <returns>CPU编号</returns>
		public string GetCpuID(){
			System.Management.ManagementObjectSearcher Wmi =new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_Processor");

			string Uint32="";

			foreach(ManagementObject WmiObj in Wmi.Get()){

				Uint32 = WmiObj["ProcessorId"].ToString();

			}

			return Uint32;
		}
	}
}

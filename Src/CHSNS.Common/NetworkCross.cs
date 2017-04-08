/*
 * Created by 邹健
 * Date: 2007-10-23
 * Time: 13:31
 * 
 * 
 */
using System;

namespace CHSNS.Common
{
    /// <summary>
    /// Description of NetworkCross.
    /// </summary>
    public class NetworkCross
    {
        //private ManagementObject _disk;

        ///// <summary>
        ///// 读取设备
        ///// </summary>
        //private ManagementClass _mc;

        //private ManagementObjectCollection _moc;

        /// <summary>
        /// 取得设备网卡的MAC地址
        /// </summary>
        public string GetNetCardMacAddress()
        {
            throw new NotImplementedException();
            //_mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            //_moc = _mc.GetInstances();
            //string str = "";
            //foreach (ManagementObject mo in _moc.Cast<ManagementObject>().Where(mo => (bool) mo["IPEnabled"]))
            //{
            //    str = mo["MacAddress"].ToString();
            //}
            //return str;
        }

        /// <summary>
        /// 取得设备硬盘的卷标号
        /// </summary>
        /// <returns>硬盘的卷标号</returns>
        public string GetDiskVolumeSerialNumber()
        {
            throw new NotImplementedException();
            //_mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            //_disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            //_disk.Get();
            //return _disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        /// <summary>
        /// 获取CPU编号
        /// </summary>
        /// <returns>CPU编号</returns>
        public string GetCpuId()
        {
            throw new NotImplementedException();
            //var wmi = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

            //string uint32 = "";

            //foreach (ManagementBaseObject wmiObj in wmi.Get())
            //{
            //    uint32 = wmiObj["ProcessorId"].ToString();
            //}

            //return uint32;
        }
    }
}
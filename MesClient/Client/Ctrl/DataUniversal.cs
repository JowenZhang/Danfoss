using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Ctrl
{    
    /// <summary>
    /// 公有的多窗体共享数据类
    /// </summary>
    public class DataUniversal
    {
        /// <summary>
        /// 设备状态枚举值
        /// </summary>
        public enum EqmStatus
        {
            Ill = 0,
            Repair,
            Working
        }

        /// <summary>
        /// 工站编号
        /// </summary>
        public string EqmNo { set; get; }

        /// <summary>
        /// 工站姓名
        /// </summary>
        public string EqmName { set; get; }

        /// <summary>
        /// 员工编号
        /// </summary>
        public string UserNo { set; get; }

        /// <summary>
        /// 序列号
        /// </summary>
        public string SerialNo { set; get; }

        /// <summary>
        /// 设备状态
        /// </summary>
        public EqmStatus EnumEqmStatus { set; get; }

        /// <summary>
        /// 生产单号
        /// </summary>
        public string MpoNo { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Timers;

namespace DataServices
{
    /// <summary>
    /// 数据服务
    /// </summary>
    public partial class DataServices: ServiceBase
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DataServices()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 私有字段，时间触发操作函数
        /// </summary>
        private Bll.AnSyTimeOperate _anSyTimeOperate = new Bll.AnSyTimeOperate();

        /// <summary>
        /// 服务启动
        /// </summary>
        /// <param name="args">启动服务的默认变量</param>
        protected override void OnStart(string[] args)
        {
            _anSyTimeOperate.StartTimer();
        }

        /// <summary>
        /// 服务停止
        /// </summary>
        protected override void OnStop()
        {
            _anSyTimeOperate.StopTimer();
            GC.Collect();
        }
    }
}

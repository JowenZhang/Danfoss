using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Configuration.Install;
using System.ServiceProcess;

namespace MesServiceFrm
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class frmMain : CCWin.Skin_Color
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmMain()
            : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件函数
        /// </summary>
        /// <param name="sender">窗体加载对象</param>
        /// <param name="e">窗体加载事件句柄</param>
        private void frmMusic_Load(object sender, EventArgs e)
        {
            this.picLogo.Image = Image.FromFile(@"dfsLogo.png");
            this.picLogo.Location = new Point(this.Size.Width - this.picLogo.Size.Width - this.CloseBoxSize.Width - this.MiniSize.Width - 5, 7);
            LoadServiceStatus();
        }

        /// <summary>
        /// 加载并设置按钮状态
        /// </summary>
        private void LoadServiceStatus()
        {
            ServiceController serviceCtrl = GetServicesByName("DataServices");
            if (serviceCtrl == null)
            {
                btnSetupAndUnist.Text = "安装服务";
                btnSetupAndUnist.Enabled = true;
                btnStartAndStop.Text = "启动服务";
                btnStartAndStop.Enabled = false;
            }
            else
            {
                btnSetupAndUnist.Text = "卸载服务";
                btnStartAndStop.Enabled = true;
                switch (serviceCtrl.Status)
                {
                    case ServiceControllerStatus.Running:
                        btnStartAndStop.Text = "停止服务";
                        btnSetupAndUnist.Enabled = false;
                        break;
                    case ServiceControllerStatus.StartPending:
                    case ServiceControllerStatus.ContinuePending:
                    case ServiceControllerStatus.PausePending:
                    case ServiceControllerStatus.Paused:

                    case ServiceControllerStatus.StopPending:
                        serviceCtrl.Stop();
                        btnStartAndStop.Text = "启动服务";
                        btnSetupAndUnist.Enabled = true;
                        break;
                    case ServiceControllerStatus.Stopped:
                        btnStartAndStop.Text = "启动服务";
                        btnSetupAndUnist.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 服务安装卸载按钮
        /// </summary>
        /// <param name="sender">按钮对象</param>
        /// <param name="e">按钮事件句柄</param>
        private void btnStartAndUnist_Click(object sender, EventArgs e)
        {
            if (btnSetupAndUnist.Text == "安装服务")
            {
                string[] args = { "DataServices.exe" };
                ServiceController serviceCtrl = GetServicesByName("DataServices");
                if (serviceCtrl == null)//这里的Service1是对应真实项目中的服务名称
                {
                    try
                    {
                        ManagedInstallerClass.InstallHelper(args);  //参数 args 就是你用 InstallUtil.exe 工具安装时的参数。一般就是一个exe的文件名
                        string msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t服务成功安装\n" + "\n";
                        ResultOutPut(msg);
                    }
                    catch (Exception ex)
                    {
                        string msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t服务安装失败\n" + ex.ToString() + "\n";
                        ResultOutPut(msg);
                        return;
                    }
                }
                else
                {
                    string msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t该服务已经存在，禁止重复安装\n" + "\n";
                    ResultOutPut(msg);
                }
                btnStartAndStop.Enabled = true;
                btnSetupAndUnist.Text = "卸载服务";

            }
            else
            {
                string[] args = { "/u", "DataServices.exe" };
                ServiceController serviceCtrl = GetServicesByName("DataServices");
                if (serviceCtrl != null)//这里的Service1是对应真实项目中的服务名称
                {
                    try
                    {
                        ManagedInstallerClass.InstallHelper(args);  //参数 args 就是你用 InstallUtil.exe 工具安装时的参数。一般就是一个exe的文件名
                        string msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t服务成功卸载\n" + "\n";
                        ResultOutPut(msg);
                        btnStartAndStop.Enabled = false;
                        btnSetupAndUnist.Text = "安装服务";
                    }
                    catch (Exception ex)
                    {
                        string msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t服务无法卸载\n" + ex.ToString() + "\n";
                        ResultOutPut(msg);
                        return;
                    }
                }
                else
                {
                    string msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t服务不存在，无法卸载\n" + "\n";
                    ResultOutPut(msg);
                }
            }
        }

        /// <summary>  
        /// 获取指定服务  
        /// </summary>  
        /// <param name="serviceName">服务名</param>  
        /// <returns>对应的服务，若无此服务返回空</returns>  
        private ServiceController GetServicesByName(string svcName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services)
            {
                if (s.ServiceName == svcName)
                {
                    return s;
                }
            }
            return null;
        }

        /// <summary>
        /// 启动和停止按钮事件
        /// </summary>
        /// <param name="sender">按钮对象</param>
        /// <param name="e">按钮事件句柄</param>
        private void btnStartAndStop_Click(object sender, EventArgs e)
        {
            ServiceController serviceCtrl = GetServicesByName("DataServices");
            if (btnStartAndStop.Text == "启动服务")
            {
                try
                {
                    if (serviceCtrl != null)
                    {
                        serviceCtrl.Start();
                        btnSetupAndUnist.Enabled = false;
                        btnStartAndStop.Text = "停止服务";
                        string msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t服务启动成功\n"  + "\n";
                        ResultOutPut(msg);
                    }
                    else
                    {
                        string msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t服务启动失败\n"  + "\n";
                        ResultOutPut(msg);
                    }
                }
                catch (Exception ex)
                {
                    string msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t服务无法启动\n" + ex.ToString() + "\n";
                    ResultOutPut(msg);
                }
            }
            else
            {
                try
                {
                    if (serviceCtrl != null)
                    {
                        serviceCtrl.Stop();
                        btnSetupAndUnist.Enabled = true;
                        btnStartAndStop.Text = "启动服务";
                        string msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t服务停止成功\n"  + "\n";
                        ResultOutPut(msg);
                    }
                    else
                    {
                        string msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t服务停止失败\n" + "\n";
                        ResultOutPut(msg);
                    }
                }
                catch (Exception ex)
                {
                    string msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t服务无法停止\n" + ex.ToString() + "\n";
                    ResultOutPut(msg);
                }
            }
        }

        /// <summary>
        /// 手动获取计划的单击事件函数
        /// </summary>
        /// <param name="sender">手动计划单击按钮</param>
        /// <param name="e">单击按钮事件句柄</param>
        private void btnManuPlan_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(FetchPlan);
        }

        /// <summary>
        /// 多线程控制函数，获取计划
        /// </summary>
        /// <param name="state"></param>
        private void FetchPlan(object state)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Bll.FetchPlanFromGroup fetchData = new Bll.FetchPlanFromGroup();
                fetchData.FetchMpo(state);
                sw.Stop();
                ResultOutPut("成功获取！耗时" + (sw.ElapsedMilliseconds / 1000 / 60).ToString() + "分钟。\n");
            }
            catch (Exception ex)
            {
                string msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t获取失败！\n" + ex.ToString() + "\n";
                ResultOutPut(msg);
            }
        }

        /// <summary>
        /// 过程记录输出到前台
        /// </summary>
        /// <param name="msg"></param>
        private void ResultOutPut(string msg)
        {
            if (txtLogs.InvokeRequired)
            {
                List<object> args = new List<object>();
                args.Add(msg);
                txtLogs.Invoke(new Action<string>(ResultOutPut), new object[] { msg });
            }
            else
            {
                txtLogs.Text += msg;
            }
        }
    }
}

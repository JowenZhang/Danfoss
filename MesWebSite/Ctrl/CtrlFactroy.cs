using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl
{
    /// <summary>
    /// 简单工厂模式：控制层中的工厂类
    /// </summary>
    public class CtrlFactroy
    {
        /// <summary>
        /// 简单工厂模式，返回简单工厂的接口，为对应视图操作的处理
        /// </summary>
        /// <param name="tableName">视图表名</param>
        /// <returns>控制器接口</returns>
        public static ICtrlOperate CreateViewCtrl(string tableName)
        {
            ICtrlOperate ctrl = null;
            switch (tableName)
            {
                case "sysAuthGroup":
                    ctrl=new SysAuthGroupCtrl();
                    break;
                case "sysAuth":
                    ctrl = new SysAuthCtrl();
                    break;
                case "apo":
                    ctrl = new ApoCtrl();
                    break;
                case "apoItem":
                    ctrl = new ApoItemCtrl();
                    break;
                case "sysUser":
                    ctrl = new SysUserCtrl();
                    break;
                case "sysUserAuthGroup":
                    ctrl = new SysUserAuthGroupCtrl();
                    break;
                case "sysGroup":
                    ctrl = new SysGroupCtrl();
                    break;
                case "sysCompany":
                    ctrl = new SysCompanyCtrl();
                    break;
                case "sysFactory":
                    ctrl = new SysFactoryCtrl();
                    break;
                case "sysDept":
                    ctrl = new SysDeptCtrl();
                    break;
                case "sysSetting":
                    ctrl = new SysSettingCtrl();
                    break;
                case "pdmShift":
                    ctrl = new PdmShiftCtrl();
                    break;
                case "pdmWkc":
                    ctrl = new PdmWkcCtrl();
                    break;
                case "pdmEqm":
                    ctrl = new PdmEqmCtrl();
                    break;
                case "pdmWorkshop":
                    ctrl = new PdmWorkshopCtrl();
                    break;
                case "pdmLine":
                    ctrl = new PdmLineCtrl();
                    break;
                case "mesWorker":
                    ctrl = new MesWorkerCtrl();
                    break;
                case "eqmJamCause":
                    ctrl = new EqmJamCauseCtrl();
                    break;
                case "dstblMaintainBasic":
                    ctrl = new DstblMaintainBasicCtrl();
                    break;
                case "eqmJamRecord":
                    ctrl = new EqmJamRecordCtrl();
                    break;
                case "eqmLock":
                    ctrl = new EqmLockCtrl();
                    break;
                case "qcmQuality":
                    ctrl = new QcmQualityCtrl();
                    break;
                case "qcmQaResult":
                    ctrl = new QcmQaResultCtrl();
                    break;
                case "qcmQaCause":
                    ctrl = new QcmQaCauseCtrl();
                    break;
                case "qcmQaRecord":
                    ctrl = new QcmQaRecordCtrl();
                    break;
                case "adn":
                    ctrl = new AdnCtrl();
                    break;
                case "mpo":
                    ctrl = new MpoCtrl();
                    break;
                case "mpoItem":
                    ctrl = new MpoItemCtrl();
                    break;
                case "mesFb":
                    ctrl = new MesFbCtrl();
                    break;
                case "mesFbItem":
                    ctrl = new MesFbItemCtrl();
                    break;
                case "dmsFile":
                    ctrl = new DmsFileCtrl();
                    break;
                case "apoAct":
                    ctrl = new ApoActCtrl();
                    break;
                case "mpoPlan":
                    ctrl = new MpoPlanCtrl();
                    break;
                case "mesFbInfo":
                    ctrl = new MesFbInfoCtrl();
                    break;
                default:
                    break;
            }
            return ctrl;
        }
    }
}

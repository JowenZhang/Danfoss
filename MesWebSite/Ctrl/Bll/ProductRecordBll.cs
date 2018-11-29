using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Ctrl.Bll
{
    /// <summary>
    /// 生产记录业务类
    /// </summary>
    public class ProductRecordBll
    {
        /// <summary>
        /// 获取记录信息及对应配置
        /// </summary>
        /// <param name="serialNo">序列号</param>
        /// <returns>记录信息及配置</returns>
        public List<ModelView.ProductRecordView> GetRecordInfo(string serialNo)
        {
            if (string.IsNullOrEmpty(serialNo))
            {
                return null;
            }
            OrdinaryDataCtrl ordinaryDataCtrl = new OrdinaryDataCtrl();
            DataTable dt = ordinaryDataCtrl.GetProductRecordInfo(serialNo);
            if (dt==null)
            {
                return null;
            }
            if (dt.Rows.Count<=0)
            {
                return null;
            }
            List<DataRow> listSourceRows = dt.AsEnumerable().ToList();

            List<List<ModelView.ProductRecordView>> listAllRes = listSourceRows.Select(ProcessDataRow).ToList();
            List<ModelView.ProductRecordView> listRes = new List<ModelView.ProductRecordView>();
            listAllRes.ForEach(a => listRes.AddRange(a));
            return listRes;
        }

        /// <summary>
        /// 行记录处理为记录信息列表
        /// </summary>
        /// <param name="dataRow">行记录</param>
        /// <returns>记录信息列表</returns>
        private List<ModelView.ProductRecordView> ProcessDataRow(DataRow dataRow)
        {
            List<ModelView.ProductRecordView> listRes = new List<ModelView.ProductRecordView>();
            SysProductRecordSettingCtrl sysProductRecordSettingCtrl = new SysProductRecordSettingCtrl();
            List<Model.TableModel.Sys_product_record_setting> listSettings = null;
            try
            {
                listSettings = sysProductRecordSettingCtrl.GetModelList("status_no='310'");
            }
            catch (Exception)
            {
                listSettings = null;
            }
            if (listSettings == null)
            {
                return null;
            }
            if (listSettings.Count <= 0)
            {
                return null;
            }
            string serialNo = dataRow.Field<string>("serial_no");
            string eqmNo = dataRow.Field<string>("eqm_no");
            string workerName = dataRow.Field<string>("worker_name");
            string crtTime = dataRow.Field<DateTime>("crt_time").ToString("yyyy-MM-dd");
            string itemName = dataRow.Field<string>("information");
            string itemValue = dataRow.Field<string>("information_value");
            Model.TableModel.Sys_product_record_setting setting1=listSettings.Find(a => a.product_record_name == "日期" && a.eqm_no == eqmNo);
            if (setting1!=null)
            {
                ModelView.ProductRecordView model1 = new ModelView.ProductRecordView();
                model1.serial_no = serialNo;
                model1.item_name = "日期";
                model1.item_value = crtTime;
                model1.eqm_no = eqmNo;
                model1.row_index = setting1.row_index;
                model1.col_index = setting1.col_index;
                if (!listRes.Contains(model1))
                {
                    listRes.Add(model1);    
                }
            }
            Model.TableModel.Sys_product_record_setting setting2 = listSettings.Find(a => a.product_record_name == "作业者" && a.eqm_no == eqmNo);
            if (setting2 != null)
            {
                ModelView.ProductRecordView model2 = new ModelView.ProductRecordView();
                model2.serial_no = serialNo;
                model2.item_name = "作业者";
                model2.item_value = workerName;
                model2.eqm_no = eqmNo;
                model2.row_index = setting2.row_index;
                model2.col_index = setting2.col_index;
                if (!listRes.Contains(model2))
                {
                    listRes.Add(model2);
                }
            }
            Model.TableModel.Sys_product_record_setting setting3 = listSettings.Find(a => a.product_record_name == itemName && a.eqm_no == eqmNo);
            if (setting3 != null)
            {
                ModelView.ProductRecordView model3 = new ModelView.ProductRecordView();
                model3.serial_no = serialNo;
                model3.item_name = itemName;
                model3.item_value = itemValue;
                model3.eqm_no = eqmNo;
                model3.row_index = setting3.row_index;
                model3.col_index = setting3.col_index;
                if (!listRes.Contains(model3))
                {
                    listRes.Add(model3);
                }
            }
            return listRes;
        }

        /// <summary>
        /// 将某一序列号的值写入跟踪卡
        /// </summary>
        /// <param name="serialNo">序列号</param>
        /// <param name="tempFullPath">模板全路径</param>
        /// <returns>写入结果</returns>
        public string WriteProductInfoIntoExcel(string serialNo,string tempFullPath,out string destinyfileName)
        {
            if (!System.IO.File.Exists(tempFullPath))
            {
                destinyfileName = string.Empty;
                return "模板文件不存在！";
            }
            string destinyPath = System.IO.Path.GetDirectoryName(tempFullPath) +"\\"+ string.Format(@"序列号{0}_记录跟踪卡",serialNo)+System.IO.Path.GetExtension(tempFullPath);
            destinyfileName = string.Format(@"序列号{0}_记录跟踪卡", serialNo) + System.IO.Path.GetExtension(tempFullPath);
            List<ModelView.ProductRecordView> list=null;
            try
            {
                list = GetRecordInfo(serialNo);
            }
            catch (Exception)
            {
                destinyfileName = string.Empty;
                return "无法获取记录信息！";
            }
            if (list==null)
            {
                destinyfileName = string.Empty;
                return "记录信息不存在！";
            }
            if (list.Count<=0)
            {
                destinyfileName = string.Empty;
                return "记录信息不可为空！";
            }
            ModelView.ProductRecordView model = new ModelView.ProductRecordView();
            model.eqm_no = "EqmNo";
            model.item_name = "Barcode";
            model.item_value = serialNo;
            model.row_index = 1;
            model.col_index = 0;
            list.Add(model);
            List<object> values = list.Select(a => a.item_value).ToList();
            List<int> colIndexs = list.Select(a => a.col_index).ToList();
            List<int> rowIndexs = list.Select(a => a.row_index).ToList();
            System.IO.File.Delete(destinyPath);
            return Common.ExcelHelper.WriteValue2Cell(tempFullPath, destinyPath, "Model", rowIndexs, colIndexs, values).ToLower();
        }
    }
}

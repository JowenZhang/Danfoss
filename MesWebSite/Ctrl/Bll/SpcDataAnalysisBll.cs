using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ctrl.Bll
{
    /// <summary>
    /// SPC数据分析业务类
    /// </summary>
    public class SpcDataAnalysisBll
    {
        /// <summary>
        /// 获取信息列表
        /// </summary>
        /// <param name="eqmNo">工站编号</param>
        /// <param name="information">信息名称</param>
        /// <param name="partNo">信息名称</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>信息集合</returns>
        private List<string> GetInforValueFromDb(string eqmNo, string information, string partNo,DateTime startTime, DateTime endTime)
        {
            if (startTime >= endTime)
            {
                return null;
            }
            if (string.IsNullOrEmpty(eqmNo))
            {
                return null;
            }
            if (string.IsNullOrEmpty(information))
            {
                return null;
            }
            MesFbInfoCtrl mesFbInfoCtrl = new MesFbInfoCtrl();
            try
            {
                return mesFbInfoCtrl.GetList4Spc(eqmNo, information, partNo, startTime, endTime).Select(a => a.information_value).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 字符串集合转换为double集合（点线图纵坐标）
        /// </summary>
        /// <param name="source">源字符串集合</param>
        /// <returns></returns>
        private List<double> ConvertStr2Double(List<string> source)
        {
            return source.Select(a => ConvertStr2Double(a)).ToList();
        }

        /// <summary>
        /// 单值字符串转double
        /// </summary>
        /// <param name="a">要转换的字符串</param>
        /// <returns>deciaml结果值</returns>
        private double ConvertStr2Double(string a)
        {
            double res = 0;
            return double.TryParse(a, out res) ? res : 0;
        }

        /// <summary>
        /// 计算并获取基础的SPC信息变量
        /// </summary>
        /// <param name="source">样本源</param>
        /// <param name="normal">Spc正常值</param>
        /// <param name="toleranceSpc">Spc正常值范围</param>
        /// <param name="basicSpcInfo">传出参数，基本信息对象</param>
        /// <returns>是否获取成功</returns>
        private bool GetBasicParam(List<double> source, double normal,double toleranceSpc,out BasicSpcInfo basicSpcInfo)
        {
            if (source == null)
            {
                basicSpcInfo = null;
                return false;
            }
            if (source.Count <= 0)
            {
                basicSpcInfo = null;
                return false;
            }
            basicSpcInfo = new BasicSpcInfo();
            basicSpcInfo.SampleCount = source.Count;
            basicSpcInfo.SampleMax = source.Max();
            basicSpcInfo.SampleMin = source.Min();
            basicSpcInfo.Wrange = Math.Abs(basicSpcInfo.SampleMax - basicSpcInfo.SampleMin);
            basicSpcInfo.Average = source.Average();
            basicSpcInfo.StandardDeviation = CalculateSD(source, basicSpcInfo.Average, basicSpcInfo.SampleCount);
            basicSpcInfo.Capability = toleranceSpc / 6 / basicSpcInfo.StandardDeviation;
            basicSpcInfo.Centernal = (toleranceSpc / 2 - Math.Abs(normal - basicSpcInfo.Average)) / 3 / basicSpcInfo.StandardDeviation;
            int groupQty = 0;
            groupQty = int.TryParse(Math.Round(Math.Sqrt(basicSpcInfo.SampleCount) + 1, 0, MidpointRounding.AwayFromZero).ToString(), out groupQty) ? groupQty : 0;
            basicSpcInfo.GroupQty = groupQty;
            basicSpcInfo.GroupDistance = (basicSpcInfo.SampleMax - basicSpcInfo.SampleMin) / groupQty * 1.0;
            basicSpcInfo.GroupStartValue = basicSpcInfo.SampleMin - basicSpcInfo.GroupDistance / 2;
            return true;
        }

        /// <summary>
        /// 标准差计算
        /// </summary>
        /// <param name="source">样本</param>
        /// <param name="avg">平均值</param>
        /// <param name="sampleCount">样本数N</param>
        /// <returns>标准差值</returns>
        private double CalculateSD(List<double> source, double avg, int sampleCount)
        {
            double tmpSumSqart = 0;
            foreach (double item in source)
            {
                tmpSumSqart = tmpSumSqart + (item - avg) * (item - avg);
            }
            tmpSumSqart = tmpSumSqart / (sampleCount - 1);
            return Math.Sqrt(tmpSumSqart);
        }

        /// <summary>
        /// 计算每组的分组边界
        /// </summary>
        /// <param name="groupStartValue">分组起始值</param>
        /// <param name="maxValue">样本最大值</param>
        /// <param name="groupDistance"></param>
        /// <returns>每组的分组边界列表</returns>
        private List<BasicSpcInfo.Boundary> CalculateBoundary(double groupStartValue, double maxValue, double groupDistance)
        {
            if (groupDistance<=0)
            {
                return null;
            }
            List<BasicSpcInfo.Boundary> res = new List<BasicSpcInfo.Boundary>();
            double cursor = groupStartValue;
            while (cursor <= maxValue)
            {
                BasicSpcInfo.Boundary boundary = new BasicSpcInfo.Boundary();
                boundary.Min = cursor;
                boundary.Max = cursor + groupDistance;
                cursor = cursor + groupDistance;
                res.Add(boundary);
            }
            return res;
        }

        /// <summary>
        /// 统计样本
        /// </summary>
        /// <param name="sample">样本</param>
        /// <param name="sampleGroupBoundary">样本每组分组边界</param>
        /// <returns></returns>
        private Dictionary<BasicSpcInfo.Boundary, int> StatictisSample(List<double> sample, List<BasicSpcInfo.Boundary> sampleGroupBoundary)
        {
            Dictionary<BasicSpcInfo.Boundary, int> res = new Dictionary<BasicSpcInfo.Boundary, int>();
            sampleGroupBoundary.ForEach(a => {
                int tmp=0;
                sample.ForEach(b => {
                    if (b < a.Max && b > a.Min)
                    {
                        tmp = tmp + 1;
                    }
                });
                res.Add(a, tmp);
            });
            return res;
        }

        /// <summary>
        /// 构造基础计算序列（最终横坐标）
        /// </summary>
        /// <param name="minValue">最小值</param>
        /// <param name="maxValue">最大值</param>
        /// <param name="distance">间距</param>
        /// <returns>基础计算序列</returns>
        private List<double> CreateSpcBasicData(double minValue, double maxValue, double distance)
        {
            List<double> res = new List<double>();
            double cursor = minValue - 3 * distance;
            double max=maxValue+3*distance;
            while (cursor<max)
            {
                double cursorRound = Math.Round(cursor, 2);
                res.Add(cursorRound);
                cursor = cursor + distance;
            }
            return res;
        }

        /// <summary>
        /// 计算基础序列的正态分布概率值（最终返回值纵坐标1）
        /// </summary>
        /// <param name="basicData">基础数据集合</param>
        /// <param name="avg">平均值</param>
        /// <param name="standardDivision">标准差</param>
        /// <param name="sampleCount">样本统计数</param>
        /// <param name="groupDistance">组距</param>
        /// <returns>计算后的结果序列</returns>
        private List<double> CalculateBasicDataNormal(List<double> basicData, double avg, double standardDivision,double groupDistance, int sampleCount)
        {
            List<double> res = new List<double>();
            basicData.ForEach(a => {
                double leftValue = ((a - groupDistance / 2) - avg) / standardDivision;
                double rightValue = ((a + groupDistance / 2) - avg) / standardDivision;
                double value = (Common.StatisticHelper.NormalProbability(rightValue) - Common.StatisticHelper.NormalProbability(leftValue)) * groupDistance;
                res.Add(Math.Round(value,8));
            });
            return res;
        }

        /// <summary>
        /// 统计并构造最终返回每组样本个数集合（最终返回值纵坐标2）
        /// </summary>
        /// <param name="firstStatistic">第一次统计结果</param>
        /// <returns>结果集合</returns>
        private List<int> StatisticSampleCount(Dictionary<BasicSpcInfo.Boundary, int> firstStatistic)
        {
            List<int> res=firstStatistic.Values.ToList();
            res.Insert(0, 0);
            res.Insert(0, 0);
            res.Insert(0, 0);
            res.Add(0);
            res.Add(0);
            res.Add(0);
            return res;
        }

        /// <summary>
        /// 构造样本序列号（点线图横坐标）
        /// </summary>
        /// <param name="sample">样本</param>
        /// <returns>样本序列集合</returns>
        private List<int> CreateSampleIndex(List<double> sample)
        {
            List<int> res = new List<int>();
            int i=1;
            sample.ForEach(a => res.Add(i++));
            return res;
        }

        /// <summary>
        /// 计算Spc
        /// </summary>
        /// <param name="eqmNo">工站编号</param>
        /// <param name="information">要计算的项目</param>
        /// <param name="partNo">型号</param>
        /// <param name="normalValue">该项目的标准值</param>
        /// <param name="tolerance">该项目的容忍度</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>返回Spc统计结果</returns>
        public ModelView.DataAnalysisSpcView CalculateSpc(string eqmNo, string information, string partNo,double normalValue, double tolerance, DateTime startTime, DateTime endTime)
        {
            ModelView.DataAnalysisSpcView res = new ModelView.DataAnalysisSpcView();
            if (startTime >= endTime)
            {
                return null;
            }
            if (string.IsNullOrEmpty(eqmNo))
            {
                return null;
            }
            if (string.IsNullOrEmpty(information))
            {
                return null;
            }
            //获取样本
            List<string> tmpListStr = GetInforValueFromDb(eqmNo, information,partNo, startTime, endTime);
            if (tmpListStr==null)
            {
                return null;
            }
            if (tmpListStr.Count<=0)
            {
                return null;
            }
            List<double> sample = ConvertStr2Double(tmpListStr);
            //样本校验
            if (sample==null)
            {
                return null;
            }
            if (sample.Count<=0)
            {
                return null;
            }
            BasicSpcInfo basicSpcInfo=new BasicSpcInfo();
            //计算基础样本数据
            bool b = GetBasicParam(sample, normalValue, tolerance, out basicSpcInfo);
            if (!b)
            {
                return null;
            }
            res.dotTitle = eqmNo + "-" + information + "分析";
            res.spcTitle = eqmNo + "-" + information + "分析";
            res.avarage = Math.Round(basicSpcInfo.Average,2);
            res.max = Math.Round(basicSpcInfo.SampleMax,2);
            res.min = Math.Round(basicSpcInfo.SampleMin,2);
            res.normal = Math.Round(normalValue,2);
            res.upLimit = Math.Round(normalValue + tolerance / 2,2);
            res.lowerLimit = Math.Round(normalValue - tolerance / 2,2);
            res.yAxisMax = Math.Max(Math.Round(res.max+Math.Abs((res.max-res.min)*0.2),2),Math.Round(res.upLimit+Math.Abs((res.max-res.min)*0.2),2));
            res.yAxisMin = Math.Min(Math.Round(res.min - Math.Abs((res.max - res.min) * 0.2), 2), Math.Round(res.lowerLimit - Math.Abs((res.max - res.min) * 0.2), 2));
            res.dotxAxisData = CreateSampleIndex(sample);
            
            List<double> sampleRound = new List<double>();
            sample.ForEach(a => sampleRound.Add(Math.Round(a, 2)));
            res.dotyAxisData = sampleRound;
            res.spcxAxisData = CreateSpcBasicData(res.min, res.max, basicSpcInfo.GroupDistance);
            res.tips = string.Format("CP:{0}\t\tCPK:{1}",(Math.Round(basicSpcInfo.Capability,2).ToString()),(Math.Round(basicSpcInfo.Centernal,2).ToString()));
            List<BasicSpcInfo.Boundary> sampleGroupBoundary = CalculateBoundary(basicSpcInfo.GroupStartValue, res.max, basicSpcInfo.GroupDistance);
            if (sampleGroupBoundary==null)
            {
                return null;
            }
            if (sampleGroupBoundary.Count<=0)
            {
                return null;
            }
            Dictionary<BasicSpcInfo.Boundary, int> firstStatistic=StatictisSample(sample,sampleGroupBoundary);
            if (firstStatistic==null)
            {
                return null;
            }
                if(firstStatistic.Count<=0)
                {
                    return null;
                }
            res.spcyAxisCountData = StatisticSampleCount(firstStatistic);
            res.spcyAxisCurveData = CalculateBasicDataNormal(res.spcxAxisData, basicSpcInfo.Average, basicSpcInfo.StandardDeviation, basicSpcInfo.GroupDistance, basicSpcInfo.SampleCount);
            return res;
        }
    }
}

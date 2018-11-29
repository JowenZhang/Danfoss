﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 统计学帮助类
    /// </summary>
    public static class StatisticHelper
    {
        /// <summary>
        /// 正态分布函数
        /// </summary>
        /// <param name="x">横坐标</param>
        /// <param name="miu">miu值（标准正态分布0）</param>
        /// <param name="sigma">sigma值（标准正态分布1）</param>
        /// <returns>纵坐标</returns>
        private static double NormDensityFunc(double x, double miu, double sigma) //正态分布概率密度函数μ=0，σ=1
        {
            return (1.0 / (Math.Sqrt(2 * Math.PI) * sigma)) * Math.Exp(-1 * (Math.Pow((x - miu), 2) / (2 * sigma * sigma)));
        }

        /// <summary>
        /// 标准正态分布函数小于x的概率
        /// </summary>
        /// <param name="x">x的值</param>
        /// <returns>小于x的概率，精度10^12次方</returns>
        public static double NormalProbability(double x)
        {
            double x0 = (x >= 0 ? x : -x) / Math.Sqrt(2);
            List<double> A = new List<double>() { 0.0705230784, 0.0422820123, 0.0092705272, 0.0001520143, 0.0002765672, 0.0000430638 };
            double erfSum = 0;
            int i = 1;
            A.ForEach(a =>
            {
                erfSum += a * Math.Pow(x0, i);
                i++;
            });
            double erf = 1 - Math.Pow((1 + erfSum), -16);
            double phi = (x >= 0 ? 0.5 * (1 + erf) : 0.5 * (1 - erf));
            return phi;
        }


        /// <summary>
        /// 标准正态分布函数Phi(x)
        /// </summary>
        /// <param name="x">随机变量</param>
        /// <returns>标准正态分布概率</returns>
        private static double NormDistFunc(double x)
        {
            double x0 = (x >= 0 ? x : -x);
            double[] b = { 0.196854, 0.115194, 0.000344, 0.019527 };
            double erf = 0;
            for (int i = 1; i <= 4; i++)
            {
                erf += b[i - 1] * Math.Pow(x0, i);
            }
            erf = 1 - Math.Pow(1.0 + erf, -4);
            double phi = (x >= 0 ? 0.5 * (1 + erf) : 0.5 * (1 - erf));
            return phi;
        }

        /// <summary>
        /// 标准正态分布函数分位数函数
        /// </summary>
        /// <param name="p">概率</param>
        /// <returns>分位数</returns>
        private static double NormDistributionQuantile(double p)
        {
            Debug.Assert((0 < p) && (p < 1));
            if (p == 0.5)
                return 0;
            double[] b ={0.1570796288E1,   0.3706987906E-1,
              -0.8364353589E-3, -0.2250947176E-3,
                0.6841218299E-5,  0.5824238515E-5,
              -0.1045274970E-5,  0.8360937017E-7,
              -0.3231081277E-8,  0.3657763036E-10,
                0.6936233982E-12};
            double alpha = 0;
            if ((0 < p) && (p < 0.5))
                alpha = p;
            else if ((0.5 < p) && (p < 1))
                alpha = 1 - p;
            double y = -Math.Log(4 * alpha * (1 - alpha));
            double u = 0;
#if USE_TODA_FORMULA
  //Toda近似公式，最大误差1.2e-8
  for (int i = 0; i < b.Length; i++)
  {
    u += b[i] * Math.Pow(y, i);
  }
  u = Math.Sqrt(y * u);
#else
            //山内近似公式，最大误差4.9e-4
            u = Math.Sqrt(y * (2.0611786 - 5.7262204 / (y + 11.640595)));
#endif
            double up = 0;
            if ((0 < p) && (p < 0.5))
                up = -u;
            else if ((0.5 < p) && (p < 1))
                up = u;
            return up;
        }

        /// <summary>
        /// 标准正态分布概率密度函数
        /// </summary>
        /// <param name="x">随机变量</param>
        /// <returns>概率密度</returns>
        private static double NormDensityFunc(double x)
        {
            return Math.Exp(-x * x * 0.5) / Math.Sqrt(2 * Math.PI);
        }
    }
}

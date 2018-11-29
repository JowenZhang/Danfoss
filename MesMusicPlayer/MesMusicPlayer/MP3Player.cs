using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace MesMusicPlayer
{  
    /// <summary>
    /// MP3音乐播放器
    /// </summary>
    public class MP3Player   
    {
        /// <summary>
        /// 私有构造函数
        /// </summary>
        private MP3Player() { }

        /// <summary>
        /// 私有单例字段
        /// </summary>
        private static MP3Player _mp3Player = null;

        /// <summary>
        /// 线程同步标识
        /// </summary>
        private static readonly object _locker = new object();


        /// <summary>
        /// 类的单例创建函数
        /// </summary>
        /// <returns>创建类的构造函数</returns>
        public static MP3Player CreateInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (_mp3Player == null)
            {
                lock (_locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (_mp3Player == null)
                    {
                        _mp3Player = new MP3Player();
                    }
                }
            }
            return _mp3Player;
        }


        #region MyRegion
        /// <summary>
        /// 导入Win32媒体播放api
        /// </summary>
        /// <param name="command">MCI命令字符串</param>
        /// <param name="returnString">存放反馈信息的缓冲区</param>
        /// <param name="returnSize">缓冲区的长度</param>
        /// <param name="hwndCallback">回调窗口的句柄，一般为NULL</param>
        /// <returns>若成功则返回0，否则返回错误码</returns>
        [DllImport("winmm.dll")]
        private static extern long mciSendString(
            string command,      //MCI命令字符串
            string returnString, //存放反馈信息的缓冲区
            int returnSize,      //缓冲区的长度
            IntPtr hwndCallback  //回调窗口的句柄，一般为NULL
            );                   //若成功则返回0，否则返回错误码。

        /// <summary>
        /// 播放媒体文件
        /// </summary>
        /// <param name="file">媒体文件全路径</param>
        private void PlayWait(string file)
        {
            /*
             * open device_name type device_type alias device_alias  打开设备
             * device_name　 　　　要使用的设备名，通常是文件名。
             * type device_type　　设备类型，例如mpegvideo或waveaudio，可省略。
             * alias device_alias　设备别名，指定后可在其他命令中代替设备名。
             */
            mciSendString(string.Format("open \"{0}\" type mpegvideo alias media", file), null, 0, IntPtr.Zero);

            /*
             * play device_alias from pos1 to pos2 wait repeat  开始设备播放
             * 若省略from则从当前磁道开始播放。
             * 若省略to则播放到结束。
             * 若指明wait则等到播放完毕命令才返回。即指明wait会产生线程阻塞，直到播放完毕
             * 若指明repeat则会不停的重复播放。
             * 若同时指明wait和repeat则命令不会返回，本线程产生堵塞，通常会引起程序失去响应。
             */
            mciSendString("play media wait", null, 0, IntPtr.Zero);

            /*
             * close　　　 关闭设备
             */
            mciSendString("close media", null, 0, IntPtr.Zero);

        }

        /// <summary>
        /// 获取音乐时长
        /// </summary>
        /// <returns></returns>
        public int GetTimeLong()
        {
            string durLength = "";
            durLength = durLength.PadLeft(128, Convert.ToChar(" "));
            mciSendString("status media length", durLength, durLength.Length, IntPtr.Zero);
            durLength = durLength.Trim();
            if (durLength == "") return 0;
            return (int)(Convert.ToDouble(durLength));
        }

        /// <summary>
        /// 循环播放媒体文件
        /// </summary> 
        /// <param name="file">媒体文件全路径</param>
        private void PlayRepeat(string file)
        {
            mciSendString(string.Format("open \"{0}\" type mpegvideo alias media", file), null, 0, IntPtr.Zero);
            mciSendString("play media repeat", null, 0, IntPtr.Zero);
        }

        /// <summary>
        /// 私有线程
        /// </summary>
        private Thread thread;

        /// <summary>
        /// 播放音频文件
        /// </summary>
        /// <param name="file">音频文件路径</param>
        /// <param name="times">播放次数，0：循环播放 大于0：按指定次数播放</param>
        public void Play(string file, int times)
        {
            //用线程主要是为了解决在播放的时候指定wait时产生线程阻塞,从而导致界面假死的现象
            thread = new Thread(() =>
            {
                if (times == 0)
                {
                    PlayRepeat(file);
                }
                else if (times > 0)
                {
                    for (int i = 0; i < times; i++)
                    {
                        PlayWait(file);
                    }
                }
            });
            //线程必须为单线程
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 结束播放的线程
        /// </summary>
        public void Exit()
        {
            if (thread != null)
            {
                try
                {
                    thread.Abort();
                }
                catch { }
                thread = null;
            }
        }
        #endregion
    }   
} 
using DotNetCoreConfiguration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogMan
{
    /*
Copyright (C)  2019 Jiang Ming Feng
Github: https://github.com/mfjiang
Contact: hamlet.jiang@live.com
License:  https://github.com/mfjiang/GoGoGo/blob/master/LICENSE

这一程序库是自由软件，您可以遵照自由软件基金会出版的 GNU General Public License （以下简称 GNU GPL v3）条款来修改和重新发布这一程序库，或者用许可证的第二版，或者 (根据您的选择) 用任何更新的版本。

发布这一程序库的目的是希望它有用，但没有任何担保。甚至没有适合特定目的而隐含的担保。更详细的情况请参阅 GNU GPL v3条款。
您应该已经和程序库一起收到一份 GNU GPL v3内容的副本。如果还没有，写信给：
Free Software Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

This library is free software, you can modify and republish this program in accordance with the terms of the GNU Lesser General Public License published by the Free Software Foundation, or use the second version of the license, or (depending on your choice) Use any updated version.

The purpose of publishing this library is to make it useful, but without any guarantee. There are no guarantees that are implied for a specific purpose. For more details, please refer to the GNU Lesser General Public License.

You should have received a copy of the GNU Lesser General Public License along with the library. If not, write to:
Free Software Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.
*/

    /// <summary>
    /// 表示简易日志输出器
    /// </summary>
    public static class Loger
    {
        #region 静态字段
        private static string m_LogName;
        private static string m_LogSuffix;
        private static string m_LogPath;
        private static LogLevel m_LogLevel;
        private static int m_AutoCleanDays_Cfg;
        private static int m_AutoCleanDays_Code;
        #endregion

        static Loger()
        {
            m_LogName = "LogMan";
            m_LogSuffix = ".log";
            m_LogPath = @"C:\LogMan\";
            m_LogLevel = LogLevel.Unknown;
            //此值为-1说明没有配置，按m_AutoCleanDays_Code的值执行
            m_AutoCleanDays_Cfg = -1;

            try
            {
                if (!String.IsNullOrEmpty(ConfigurationManager.GetAppConfig("LogManPath")))
                {
                    m_LogPath = ConfigurationManager.GetAppConfig("LogManPath");
                }

                if (!Directory.Exists(m_LogPath))
                {
                    Directory.CreateDirectory(m_LogPath);
                }

                if (!String.IsNullOrEmpty(ConfigurationManager.GetAppConfig("LogManLevel")))
                {
                    m_LogLevel = (LogLevel)Enum.Parse(typeof(LogLevel), ConfigurationManager.GetAppConfig("LogManLevel"));
                }

                if (!String.IsNullOrEmpty(ConfigurationManager.GetAppConfig("AutoCleanDays")))
                {
                    int.TryParse(ConfigurationManager.GetAppConfig("AutoCleanDays"), out m_AutoCleanDays_Cfg);
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }

        /// <summary>
        /// 初始化日志配置
        /// </summary>
        /// <param name="logName">日志名</param>
        /// <param name="logSuffix">日志后缀</param>
        /// <param name="logPath">日志路径</param>
        /// <param name="autoCleanDays">自动清理天数</param>
        public static void InitLog(string logName = null, string logSuffix = null, string logPath = null, int autoCleanDays = 0)
        {
            if (!String.IsNullOrEmpty(logName))
            {
                m_LogName = logName;
            }

            if (!String.IsNullOrEmpty(logSuffix))
            {
                m_LogSuffix = logSuffix;
            }

            if (!String.IsNullOrEmpty(logPath))
            {
                m_LogPath = logPath;
            }

            m_AutoCleanDays_Code = autoCleanDays;
        }

        /// <summary>
        /// 输出消息日志 LogLevel = Info
        /// </summary>
        /// <param name="ot">要记录的类型</param>
        /// <param name="message">消息</param>
        /// <param name="ex">异常</param>
        public static void Info(Type ot, string message, Exception ex = null)
        {
            //从类型获取日志配置
            IEnumerable<object> ie = ot.GetCustomAttributes(typeof(LogAttribute), true);
            if (ie != null && ie.Count() > 0)
            {
                foreach (Attribute ca in ie)
                {
                    LogAttribute lma = (LogAttribute)ca;
                    //配置文件没有明确配置日志级别，使用代码中定义的默认级别
                    if (m_LogLevel == LogLevel.Unknown)
                    {
                        if (lma.LogLevel == LogLevel.Info)
                        {
                            InitLog(lma.LogName, lma.FileSuffix, null, lma.AutoCleanDays);
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine(String.Format("====== {0} {1} {2} ======", ot.FullName, Enum.GetName(typeof(LogLevel), LogLevel.Info), DateTime.Now));
                            if (!String.IsNullOrEmpty(message))
                            {
                                sb.AppendLine(message);
                            }

                            if (ex != null)
                            {
                                sb.AppendLine(ex.ToString());
                            }

                            WriteLogFile(sb);
                            break;
                        }
                    }
                    else
                    {
                        //使用配置中的日志级别
                        if (m_LogLevel == LogLevel.Info)
                        {
                            InitLog(lma.LogName, lma.FileSuffix, null, lma.AutoCleanDays);
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine(String.Format("====== {0} {1} {2} ======", ot.FullName, Enum.GetName(typeof(LogLevel), LogLevel.Info), DateTime.Now));
                            if (!String.IsNullOrEmpty(message))
                            {
                                sb.AppendLine(message);
                            }

                            if (ex != null)
                            {
                                sb.AppendLine(ex.ToString());
                            }

                            WriteLogFile(sb);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 输出警告日志 LogLevel = Info,Warn
        /// </summary>
        /// <param name="obj">要记录的类型</param>
        /// <param name="message">消息</param>
        /// <param name="ex">异常</param>
        public static void Warn(Type ot, string message, Exception ex = null)
        {
            //从类型获取日志配置
            IEnumerable<object> ie = ot.GetCustomAttributes(typeof(LogAttribute), true);
            if (ie != null && ie.Count() > 0)
            {
                foreach (object ca in ie)
                {
                    LogAttribute lma = (LogAttribute)ca;
                    //配置文件没有明确配置日志级别，使用代码中定义的默认级别
                    if (m_LogLevel == LogLevel.Unknown)
                    {
                        if (lma.LogLevel <= LogLevel.Warn && lma.LogLevel > LogLevel.None)
                        {
                            InitLog(lma.LogName, lma.FileSuffix, null, lma.AutoCleanDays);
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine(String.Format("====== {0} {1} {2} ======", ot.FullName, Enum.GetName(typeof(LogLevel), LogLevel.Warn), DateTime.Now));
                            if (!String.IsNullOrEmpty(message))
                            {
                                sb.AppendLine(message);
                            }

                            if (ex != null)
                            {
                                sb.AppendLine(ex.ToString());
                            }

                            WriteLogFile(sb);
                            break;
                        }
                    }
                    else
                    {
                        //使用配置中的日志级别
                        if (m_LogLevel <= LogLevel.Warn && m_LogLevel > LogLevel.None)
                        {
                            InitLog(lma.LogName, lma.FileSuffix, null, lma.AutoCleanDays);
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine(String.Format("====== {0} {1} {2} ======", ot.FullName, Enum.GetName(typeof(LogLevel), LogLevel.Warn), DateTime.Now));
                            if (!String.IsNullOrEmpty(message))
                            {
                                sb.AppendLine(message);
                            }

                            if (ex != null)
                            {
                                sb.AppendLine(ex.ToString());
                            }

                            WriteLogFile(sb);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 输出一般异常日志 LogLevel = Info,Warn,Error
        /// </summary>
        /// <param name="obj">要记录的类型</param>
        /// <param name="message">消息</param>
        /// <param name="ex">异常</param>
        public static void Error(Type ot, string message, Exception ex = null)
        {
            //从类型获取日志配置
            IEnumerable<object> ie = ot.GetCustomAttributes(typeof(LogAttribute), true);
            if (ie != null && ie.Count() > 0)
            {
                foreach (object ca in ie)
                {
                    LogAttribute lma = (LogAttribute)ca;
                    //配置文件没有明确配置日志级别，使用代码中定义的默认级别
                    if (m_LogLevel == LogLevel.Unknown)
                    {
                        if (lma.LogLevel <= LogLevel.Error && lma.LogLevel > LogLevel.None)
                        {
                            InitLog(lma.LogName, lma.FileSuffix, null, lma.AutoCleanDays);
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine(String.Format("====== {0} {1} {2} ======", ot.FullName, Enum.GetName(typeof(LogLevel), LogLevel.Error), DateTime.Now));
                            if (!String.IsNullOrEmpty(message))
                            {
                                sb.AppendLine(message);
                            }

                            if (ex != null)
                            {
                                sb.AppendLine(ex.ToString());
                            }

                            WriteLogFile(sb);
                            break;
                        }
                    }
                    else
                    {
                        //使用配置中的日志级别
                        if (m_LogLevel <= LogLevel.Error && m_LogLevel > LogLevel.None)
                        {
                            InitLog(lma.LogName, lma.FileSuffix, null, lma.AutoCleanDays);
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine(String.Format("====== {0} {1} {2} ======", ot.FullName, Enum.GetName(typeof(LogLevel), LogLevel.Error), DateTime.Now));
                            if (!String.IsNullOrEmpty(message))
                            {
                                sb.AppendLine(message);
                            }

                            if (ex != null)
                            {
                                sb.AppendLine(ex.ToString());
                            }

                            WriteLogFile(sb);
                            break;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// 输出致命异常日志 LogLevel = Info,Warn,Error,Fatal
        /// </summary>
        /// <param name="ot">要记录的类型</param>
        /// <param name="message">消息</param>
        /// <param name="ex">异常</param>
        public static void Fatal(Type ot, string message, Exception ex = null)
        {
            List<LogLevel> scope = new List<LogLevel>() { LogLevel.Info, LogLevel.Warn, LogLevel.Error, LogLevel.Fatal };
            //从类型获取日志配置
            IEnumerable<object> ie = ot.GetCustomAttributes(typeof(LogAttribute), true);
            if (ie != null && ie.Count() > 0)
            {
                foreach (object ca in ie)
                {
                    LogAttribute lma = (LogAttribute)ca;
                    //配置文件没有明确配置日志级别，使用代码中定义的默认级别
                    if (m_LogLevel == LogLevel.Unknown)
                    {
                        if (lma.LogLevel <= LogLevel.Fatal && lma.LogLevel > LogLevel.None)
                        {
                            InitLog(lma.LogName, lma.FileSuffix, null, lma.AutoCleanDays);
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine(String.Format("======= {0} {1} {2} ======", ot.FullName, Enum.GetName(typeof(LogLevel), LogLevel.Fatal), DateTime.Now));
                            if (!String.IsNullOrEmpty(message))
                            {
                                sb.AppendLine(message);
                            }

                            if (ex != null)
                            {
                                sb.AppendLine(ex.Source);
                                sb.AppendLine(ex.ToString());
                                sb.AppendLine(ex.StackTrace);
                                if (ex.TargetSite != null)
                                {
                                    sb.AppendLine(ex.TargetSite.ToString());
                                }
                            }

                            WriteLogFile(sb);
                            break;
                        }
                    }
                    else
                    {
                        //使用配置中的日志级别
                        if (m_LogLevel <= LogLevel.Fatal && m_LogLevel > LogLevel.None)
                        {
                            InitLog(lma.LogName, lma.FileSuffix, null, lma.AutoCleanDays);
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine(String.Format("======= {0} {1} {2} ======", ot.FullName, Enum.GetName(typeof(LogLevel), LogLevel.Fatal), DateTime.Now));
                            if (!String.IsNullOrEmpty(message))
                            {
                                sb.AppendLine(message);
                            }

                            if (ex != null)
                            {
                                sb.AppendLine(ex.Source);
                                sb.AppendLine(ex.ToString());
                                sb.AppendLine(ex.StackTrace);
                                if (ex.TargetSite != null)
                                {
                                    sb.AppendLine(ex.TargetSite.ToString());
                                }
                            }

                            WriteLogFile(sb);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 写日志到文件
        /// </summary>
        /// <param name="log"></param>
        private static void WriteLogFile(StringBuilder log)
        {
            string dateField = DateTime.Now.ToString("yyyy-MM-dd");
            int pid = Process.GetCurrentProcess().Id;
            string logFileName = String.Format("{0}-{1}-pid{2}{3}", m_LogName, dateField, pid, m_LogSuffix);

            try
            {
                object locker = new object();

                lock (locker)
                {
                    //FileStream logFile = File.Open(m_LogPath + "\\" + logFileName, FileMode.Append);这个写法导致linux上多了\
                    DirectoryInfo logdir = new DirectoryInfo(m_LogPath);
                    //FileStream logFile = File.Open(logdir.FullName + @"\" + logFileName, FileMode.Append);
                    FileStream logFile = File.Open(logdir.FullName + logFileName, FileMode.Append);
                    //检查文件大小，每个日志文件不大于5MB (5242880 byte)   
                    if (logFile.Length < 5242880)
                    {
                        if (log != null)
                        {
                            byte[] logData = Encoding.UTF8.GetBytes(log.ToString());
                            MemoryStream logStream = new MemoryStream(logData);
                            for (int i = 0; i < logData.Length; i++)
                            {
                                logFile.Write(logData, i, 1);
                            }
                        }
                    }
                    else
                    {
                        logFile.Flush();
                        logFile.Close();

                        int partitionedLogFileNumber = 1;
                        //把当天日志拆成多个，每个不大于5MB
                        WriteLogFile(log, partitionedLogFileNumber);
                    }

                    logFile.Flush();
                    logFile.Close();

                }

                //23点左右清理文件
                if (DateTime.Now.Hour == 23)
                {
                    CleanFiles();
                }

            }
            catch (Exception ex)
            {
                ;
            }
        }

        /// <summary>
        /// 把当天日志拆成多个，每个不大于5MB
        /// </summary>
        /// <param name="log"></param>
        /// <param name="partitionedLogFileNumber">每次递归加1</param>
        private static void WriteLogFile(StringBuilder log, int partitionedLogFileNumber)
        {
            string dateField = DateTime.Now.ToString("yyyy-MM-dd");
            int pid = Process.GetCurrentProcess().Id;
            string logFileName = String.Format("{0}-{1}-pid{2}-part{3}{4}", m_LogName, dateField, pid, partitionedLogFileNumber, m_LogSuffix);

            try
            {
                object locker = new object();

                lock (locker)
                {

                    //FileStream logFile = File.Open(m_LogPath + "\\" + logFileName, FileMode.Append);这个写法导致linux上多了\
                    DirectoryInfo logdir = new DirectoryInfo(m_LogPath);
                    //FileStream logFile = File.Open(logdir.FullName + @"\" + logFileName, FileMode.Append);
                    FileStream logFile = File.Open(logdir.FullName + logFileName, FileMode.Append);
                    //检查文件大小，每个日志文件不大于5MB (5242880 byte)   
                    if (logFile.Length < 5242880)
                    {
                        if (log != null)
                        {
                            byte[] logData = Encoding.UTF8.GetBytes(log.ToString());
                            MemoryStream logStream = new MemoryStream(logData);
                            for (int i = 0; i < logData.Length; i++)
                            {
                                logFile.Write(logData, i, 1);
                            }
                        }
                    }
                    else
                    {
                        logFile.Flush();
                        logFile.Close();
                        //递归处理，每次日志编号加1
                        WriteLogFile(log, partitionedLogFileNumber + 1);
                    }

                    logFile.Flush();
                    logFile.Close();

                }

                //23点左右清理文件
                if (DateTime.Now.Hour == 23)
                {
                    CleanFiles();
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }

        /// <summary>
        /// 清理过时日志文件
        /// </summary>
        private static void CleanFiles()
        {
            int days = m_AutoCleanDays_Code;
            if (m_AutoCleanDays_Cfg > -1)
            {
                days = m_AutoCleanDays_Cfg;
            }

            //0值表示不清理
            if (days > 0)
            {
                object locker = new object();
                lock (locker)
                {
                    try
                    {
                        string[] files = Directory.GetFiles(m_LogPath, "*" + m_LogSuffix);
                        //仅余1个日志时不清理
                        if (files.Length > 1)
                        {
                            for (int i = 1; i < files.Length; i++)
                            {
                                FileInfo f = new FileInfo(files[i]);
                                if ((DateTime.Now - f.CreationTime) >= new TimeSpan(days, 0, 0, 0))
                                {
                                    f.Delete();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
    }
}

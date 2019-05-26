using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DotNetCoreConfiguration
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
    /// 实现.net core环境的配置文件操作方法，以替代.net framework 中的同名类
    /// 默认使用当前目录下的appsettings.json文件
    /// </summary>
    public static class ConfigurationManager
    {
        #region 私有字段
        private static IConfigurationBuilder m_ConfigBuilder;
        private static IConfigurationRoot m_ConfigRoot;
        #endregion

        /// <summary>
        /// 获取JsonConfig对象
        /// </summary>
        public static IConfigurationRoot JsonConfig { get { return m_ConfigRoot; } }

        static ConfigurationManager()
        {
            string path = Directory.GetCurrentDirectory();

            if (!File.Exists(path + "\\appsettings.json"))
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string loc = assembly.Location;
                FileInfo ff = new FileInfo(loc);
                path = ff.DirectoryName;
            }

            m_ConfigBuilder = new ConfigurationBuilder().SetBasePath(path).AddJsonFile("appsettings.json");
            m_ConfigRoot = m_ConfigBuilder.Build();
        }

        /// <summary>
        ///以实体的形式读取AppSettings节点下的值
        /// </summary>
        public static AppSettings GetAppConfig()
        {
            AppSettings cfg = new AppSettings();

            m_ConfigRoot.GetSection("AppSettings").Bind(cfg);

            return cfg;
        }

        /// <summary>
        /// 读取AppSettings节点下的指定KEY的值
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns></returns>
        public static string GetAppConfig(string key)
        {
            string cfg = String.Empty;

            cfg = m_ConfigRoot.GetSection("AppSettings").GetValue<string>(key);

            return cfg;
        }

        /// <summary>
        /// 以实体的形式读取MySqlClusterSettings节点下的值
        /// </summary>
        /// <returns></returns>
        public static MySqlClusterSettings GetMySqlClusterSettings()
        {
            MySqlClusterSettings cfg = new MySqlClusterSettings();
            var ie = m_ConfigRoot.GetSection("MySqlClusterSettings:Nodes").GetChildren().GetEnumerator();
            int i = 0;
            while (ie.MoveNext())
            {
                string path = ie.Current.Path + ":MySqlNode";
                MySqlNode node = new MySqlNode();
                m_ConfigRoot.GetSection(path).Bind(node);
                cfg.Nodes.Add(node);
                i += 1;
            }
            return cfg;
        }

        /// <summary>
        /// 指定节点和键名取值
        /// </summary>
        /// <param name="sectionName">节点</param>
        /// <param name="key">键名</param>
        /// <returns></returns>
        public static string GetValue(string sectionName, string key)
        {
            string cfg = String.Empty;

            var section = m_ConfigRoot.GetSection(sectionName);
            if (section != null)
            {
                cfg = section.GetValue<string>(key);
            }
            return cfg;
        }
    }
}

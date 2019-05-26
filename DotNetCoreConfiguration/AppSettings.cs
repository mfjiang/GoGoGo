using System;
using System.Collections.Generic;
using System.Text;

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
    /// 对应appsettings.json中的AppSettings节
    /// </summary>
    public class AppSettings
    {
        public AppSettings() { }

        /// <summary>
        /// 日志路径
        /// </summary>
        public string LogManPath { get; set; }

        /// <summary>
        /// Linux日志路径
        /// </summary>
        public string LogManPathLinux { get; set; }

        /// <summary>
        /// 游服登录握手地址
        /// </summary>
        public string GameServerLoginUri { get; set; }

        /// <summary>
        /// Redis连接串
        /// </summary>
        public string RedisConn { get; set; }

        /// <summary>
        /// 用户中心数据库名称
        /// </summary>
        public string OAuthCenterDBName { get; set; }

        /// <summary>
        /// 游戏日志数据库名称
        /// </summary>
        public string GamePlayDataDBName { get; set; }

        /// <summary>
        /// 游戏系统数据库名称
        /// </summary>
        public string GameSystemDataDBName { get; set; }

        /// <summary>
        /// 文件中心数据库名称
        /// </summary>
        public string FileCenterDBName { get; set; }

        /// <summary>
        /// 分布式ID生成库名称
        /// </summary>
        public string DistributedIDDBName { get; set; }

        /// <summary>
        /// 是否启用短信接口
        /// </summary>
        public bool SMS_Enabled { get; set; } = false;

        /// <summary>
        /// 短信接口账号
        /// </summary>
        public string SMS_Account { get; set; }

        /// <summary>
        /// 短信接口账号密码
        /// </summary>
        public string SMS_PWD { get; set; }

        /// <summary>
        /// 短信接口地址(?之前)
        /// </summary>
        public string SMS_Uri { get; set; }

        /// <summary>
        /// 短信前置标题
        /// </summary>
        public string SMS_Tittle { get; set; }

        /// <summary>
        /// 返回短信配置实体
        /// </summary>
        /// <returns></returns>
        public SMSConfig GetSMSConfig()
        {
            return new SMSConfig()
            {
                Account = this.SMS_Account,
                Uri = this.SMS_Uri,
                Enabled = this.SMS_Enabled,
                PWD = this.SMS_PWD,
                Tittle = this.SMS_Tittle
            };
        }
    }
}

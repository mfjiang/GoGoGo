using System;
using System.Text;
using Gogogo.IF;
using Gogogo.IF.Entity;

namespace Gogogo.Entity
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

    [Serializable]
    public class UseCase:IUseCase
    {
        public ulong id { get; set; }
        public ulong product_id { get; set; }
        public ulong module_id { get; set; }
        public ulong creator_id { get; set; }
        public ulong last_editor_id { get; set; }
        public string test_path { get; set; }
        public string remark { get; set; }
        public string paramas { get; set; }
        public string expected_results { get; set; }
        public string tested_results { get; set; }
        public bool quality_pass { get; set; }
        public int state { get; set; }
        public DateTime created { get; set; }
    }
}

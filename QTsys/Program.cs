using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
namespace QTsys
{
    class WinSendMsg
    {
        public static bool IsSampleProduct;
        public static bool IsMeterialReduce;
        public static bool IsProductPlanRun;
        public static int row;
        public static string Oid;
    }

    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /// 

        

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }


    }
}

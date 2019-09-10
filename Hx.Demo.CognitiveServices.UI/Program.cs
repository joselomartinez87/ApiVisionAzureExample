using Hx.Demo.CognitiveServices.Client;
using Hx.Demo.CognitiveServices.Common;
using Hx.Demo.CognitiveServices.Logic;
using StructureMap;
using System;
using System.Windows.Forms;

namespace Hx.Demo.CognitiveServices.UI
{
    static class Program
    {
        private static Container container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmDemo());

            Bootstrap();
            Application.Run(container.GetInstance<FrmDemo>());
        }

        private static void Bootstrap()
        {
            container = new Container();

            container.Configure(c =>
            {
                c.AddRegistry<ClientRegistry>();
                c.AddRegistry<LogicRegistry>();
                c.AddRegistry<CommonRegistry>();
            });
        }
    }
}

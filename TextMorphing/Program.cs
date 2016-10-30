using System;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using YoutubeWallpaper;

namespace TextMorphing
{
    static class Program
    {
        private static Dictionary<string, Assembly> dict = new Dictionary<string, Assembly>();

        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            LoadLib("Libs.SharpDX.Desktop.dll");
            LoadLib("Libs.SharpDX.Direct2D1.dll");
            LoadLib("Libs.SharpDX.Direct3D11.dll");
            LoadLib("Libs.SharpDX.dll");
            LoadLib("Libs.SharpDX.DXGI.dll");
            LoadLib("Libs.SharpDX.Mathematics.dll");
            try
            {
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    WinApi.SetProcessDPIAware();
                }
            }
            catch (EntryPointNotFoundException)
            {
                // OS가 해당 API를 지원하지 않으므로 무시.
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm l = new LoginForm();
            l.Show();
            //SurfaceWindow s = new SurfaceWindow();
            //s.Show();
            Application.Run();
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (dict.ContainsKey(args.Name))
            {
                var assm = dict[args.Name];
                dict.Remove(args.Name);

                return assm;
            }

            return null;
        }

        static void LoadLib(string path)
        {
            var cAssm = Assembly.GetExecutingAssembly();
            var appName = cAssm.GetName().Name;

            Assembly libAssm;
            byte[] bin;

            using (var s = cAssm.GetManifestResourceStream($"{appName}.{path}"))
            {
                if (s != null)
                {
                    bin = new byte[s.Length];
                    s.Read(bin, 0, (int)s.Length);

                    libAssm = Assembly.Load(bin);

                    dict[libAssm.FullName] = libAssm;
                }
            }
        }
    }
}

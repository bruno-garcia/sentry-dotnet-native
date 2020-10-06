using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.InteropServices;
using SentryNative;


namespace SentryNativeTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private SentryBridge Sentry { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Sentry = new SentryBridge("https://80aed643f81249d4bed3e30687b310ab@o447951.ingest.sentry.io/5428537");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Sentry.Dispose();
        }
    }

    public static unsafe partial class Methods
    {
        [DllImport("crashtest", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rust_crash_test", ExactSpelling = true)]
        public static extern void rust_crash_test();
    }
}

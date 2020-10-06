using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;

namespace SentryNative
{
    public class SentryBridge : IDisposable
    {
        private bool disposedValue;

        public SentryBridge(String dsn)
        {
            unsafe
            {
                sentry_options_s* options = Methods.sentry_options_new();
                sbyte* dsn_ptr = (sbyte*)Marshal.StringToHGlobalAnsi(dsn).ToPointer();
                Methods.sentry_options_set_dsn(options, dsn_ptr);
                Methods.sentry_init(options);
                //Methods.sentry_options_free(options);
                var logger = "custom";
                var message = "Testing, it works!";
                sentry_value_u msg = Methods.sentry_value_new_message_event(
                    sentry_level_e.SENTRY_LEVEL_INFO,
                    (sbyte*)Marshal.StringToHGlobalAnsi(logger).ToPointer(), 
                    (sbyte*)Marshal.StringToHGlobalAnsi(message).ToPointer()
                );
                Methods.sentry_capture_event(msg);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                Methods.sentry_shutdown();
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~SentryBridge()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

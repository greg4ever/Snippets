using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Snippets.Basics
{
    public sealed class X : IDisposable
    {
        private bool _disposed;
        private FileStream _resourceUnmanaged;
        private SafeHandle _resourceManaged;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_resourceManaged != null)
                        _resourceManaged.Dispose();
                }

                if (_resourceUnmanaged != null)
                    _resourceUnmanaged.Dispose();

                _disposed = true;
            }
        }

        ~X()
        {
            Dispose(false);
        }
    }

    public class Y : IDisposable
    {
        private bool _disposed;
        private FileStream _resourceUnmanaged;
        private SafeHandle _resourceManaged;

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_resourceManaged != null)
                        _resourceManaged.Dispose();
                }

                if (_resourceUnmanaged != null)
                    _resourceUnmanaged.Dispose();

                _disposed = true;
            }
        }

        ~Y()
        {
            Dispose(false);
        }
    }

    public class Z : Y
    {
        private bool _disposed;

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {

                }

                _disposed = true;
            }

            base.Dispose();
        }

        ~Z()
        {
            Dispose(false);
        }
    }
}
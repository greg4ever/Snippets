using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SnippetsTest.Basics
{
    // To handle several calls to Dispose
    // we could add disposed boolean or even raise ObjectDisposedException
    public sealed class A : IDisposable
    {
        private SafeHandle _resource;

        public void Dispose()
        {
            if (_resource != null)
                _resource.Dispose();
        }
    }

    public class B : IDisposable
    {
        private bool _disposed; // I think if the class is abstract, we don't need this
        private SafeHandle _resource;

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
                    if (_resource != null)
                        _resource.Dispose();
                }

                _disposed = true;
            }
        }
    }

    public class C : B
    {
        private bool _disposed;
        private SafeHandle _resource;

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_resource != null)
                        _resource.Dispose();
                }

                _disposed = true;
            }

            base.Dispose();
        }
    }
}

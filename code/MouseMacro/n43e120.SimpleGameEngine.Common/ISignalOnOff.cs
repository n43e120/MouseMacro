using System;
using System.Threading;

namespace n43e120.SimpleGameEngine
{
    public interface ISignalOnOff
    {
        void Start();
        void Stop();
    }
    public abstract class LoopingOnNewThreadSignalWorker : IDisposable, ISignalOnOff
    {
        protected EventWaitHandle _signal;
        public virtual EventWaitHandle Signal => _signal;
        protected Thread _t;
        public virtual Thread Thread => _t;
        protected abstract void Work();
        protected virtual void ThreadStart_Looper()
        {
            do
            {
                _signal.WaitOne();
                Work();
            } while (true);
        }
        public virtual ThreadStart ThreadStart => ThreadStart_Looper;
        protected virtual void InitializeEventWaitHandle()
        {
            _signal = new AutoResetEvent(false);
        }
        protected virtual void InitializeThread()
        {
            _t = new Thread(this.ThreadStart);
        }
        protected virtual void Initialize()
        {
            InitializeEventWaitHandle();
            InitializeThread();
        }
        protected virtual void Cleanup()
        {
            _t?.Abort();
            _signal?.Dispose();
        }
        /// <summary>
        /// StartWorkerThread
        /// </summary>
        public virtual void Activate()
        {
            _t.Start();
        }
        public virtual void Start()
        {
            _signal.Set();
        }
        public virtual void Stop()
        {
            _signal.Reset();
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    Cleanup();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ThreadWork_PullMouseDown() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
    public class InterruptableLoopingOnNewThreadSignalWorker : LoopingOnNewThreadSignalWorker
    {
        public InterruptableLoopingOnNewThreadSignalWorker()
        {
            this.Initialize();
            this.Activate();
        }

        protected override void Work()
        {
            throw new NotImplementedException();
        }

        protected override void ThreadStart_Looper()
        {
            do
            {
                try
                {
                    do
                    {
                        _signal.WaitOne();
                        Work();
                    } while (true);
                }
                catch (ThreadInterruptedException)
                {

                }
                //catch (Exception)
                //{
                //    throw;
                //}
            } while (true);
        }
        public override void Stop()
        {
            this.Thread.Interrupt();
        }
        public virtual void Restart()
        {
            Stop();
            Start();
        }
    }
}

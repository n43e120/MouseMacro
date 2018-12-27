using SharpDX.DirectInput;
using System;
using System.Threading;
using n43e120.SimpleGameEngine;

namespace n43e120.SimpleGameEngine.SharpDX
{
    public abstract class Subsystem_Input : LoopingOnNewThreadSignalWorker
    {
        protected Device _dev;
        protected void Initialize(Device d)
        {
            base.Initialize();

            _dev = d;
            if (_dev != null)
            {
                _dev.SetCooperativeLevel(IntPtr.Zero, //keyboard.SetCooperativeLevel((this as Form).Handle,
                    CooperativeLevel.Background |
                    CooperativeLevel.NonExclusive);
                _dev.SetNotification(this.Signal);
                //_dev.Acquire();

                //_dev.Poll(); //keyboard and mouse donot need poll
                //_devstate = _dev.GetCurrentState();
                //_dev.Unacquire();
            }
        }
        protected override void Cleanup()
        {
            _dev?.Dispose();

            base.Cleanup();
        }
        public override void Start()
        {
            _dev.Acquire();
        }
        public override void Stop()
        {
            _dev.Unacquire();
        }
    }
    public sealed class Subsystem_Input_Keyboard : Subsystem_Input
    {
        public Subsystem_Input_Keyboard(DirectInput di)
        {
            var k = new Keyboard(di);
            base.Initialize(k);
        }

        public event EventHandler<KeyboardState> KeyboardChanged;
        private KeyboardState _devstate;
        protected override void Work()
        {
            var k = _dev as Keyboard;
            k.Poll();
            try
            {
                k.GetCurrentState(ref _devstate);
            }
            catch (NullReferenceException)
            {
                _devstate = k.GetCurrentState();
            }
            KeyboardChanged?.Invoke(this, _devstate);
        }
        protected override void Cleanup()
        {
            KeyboardChanged = null;
            _devstate = null;

            base.Cleanup();
        }
    }
    public sealed class Subsystem_Input_Mouse : Subsystem_Input
    {
        public Subsystem_Input_Mouse(DirectInput di)
        {
            var k = new Mouse(di);
            base.Initialize(k);
        }

        public event EventHandler<MouseState> MouseChanged;
        private MouseState _devstate;
        protected override void Work()
        {
            var k = _dev as Mouse;
            k.Poll();
            try
            {
                k.GetCurrentState(ref _devstate);
            }
            catch (NullReferenceException)
            {
                _devstate = k.GetCurrentState();
            }
            MouseChanged?.Invoke(this, _devstate);
        }
        protected override void Cleanup()
        {
            MouseChanged = null;
            _devstate = null;

            base.Cleanup();
        }
    }
    //public class Subsystem_Input_Keyboard : IDisposable, IOnOff
    //{
    //    private Keyboard _Keyboard;
    //    private KeyboardState _Keyboardstate;
    //    private EventWaitHandle _hKeyboardChange;
    //    private Thread _threadKeyboardChange;
    //    public event EventHandler<KeyboardState> KeyboardChanged;
    //    protected void OnKeyboardChanged()
    //    {
    //        try
    //        {
    //            do
    //            {
    //                _hKeyboardChange.WaitOne();
    //                _Keyboard.GetCurrentState(ref _Keyboardstate);
    //                KeyboardChanged?.Invoke(this, _Keyboardstate);
    //            } while (true);
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //    }
    //    public Subsystem_Input_Keyboard(SharpDX.DirectInput.DirectInput di)
    //    {
    //        _hKeyboardChange = new AutoResetEvent(false);
    //        _threadKeyboardChange = new Thread(OnKeyboardChanged);

    //        _Keyboard = new Keyboard(di);
    //        if (_Keyboard != null)
    //        {
    //            _Keyboard.SetCooperativeLevel(IntPtr.Zero, //keyboard.SetCooperativeLevel((this as Form).Handle,
    //                CooperativeLevel.Background |
    //                CooperativeLevel.NonExclusive);
    //            _Keyboard.SetNotification(_hKeyboardChange);
    //            _Keyboard.Acquire();

    //            //_Keyboard.Poll(); //keyboard and mouse donot need poll
    //            _Keyboardstate = _Keyboard.GetCurrentState();

    //            _Keyboard.Unacquire();
    //        }
    //    }
    //    public void TurnOn()
    //    {
    //        _Keyboard.Acquire();
    //        switch (this._threadKeyboardChange.ThreadState)
    //        {
    //            case ThreadState.Unstarted:
    //                this._threadKeyboardChange.Start();
    //                break;
    //        }
    //    }
    //    public void TurnOff()
    //    {
    //        _Keyboard.Unacquire();
    //    }
    //    void Cleanup()
    //    {
    //        TurnOff();

    //        _threadKeyboardChange?.Abort();
    //        _hKeyboardChange?.Dispose();
    //        KeyboardChanged = null;
    //        _Keyboard?.Dispose();
    //    }
    //    #region IDisposable Support
    //    private bool disposedValue = false; // To detect redundant calls

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!disposedValue)
    //        {
    //            if (disposing)
    //            {
    //                // TODO: dispose managed state (managed objects).
    //                Cleanup();
    //            }

    //            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
    //            // TODO: set large fields to null.

    //            disposedValue = true;
    //        }
    //    }

    //    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    //    // ~ThreadWork_PullMouseDown() {
    //    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //    //   Dispose(false);
    //    // }

    //    // This code added to correctly implement the disposable pattern.
    //    public void Dispose()
    //    {
    //        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //        Dispose(true);
    //        // TODO: uncomment the following line if the finalizer is overridden above.
    //        // GC.SuppressFinalize(this);
    //    }
    //    #endregion
    //}

    //public class Subsystem_Input_Mouse : IDisposable, IOnOff
    //{
    //    private Mouse _Mouse;
    //    private MouseState _Mousestate;
    //    private EventWaitHandle _hMouseChange;
    //    private Thread _threadMouseChange;
    //    public event EventHandler<MouseState> MouseChanged;
    //    protected void OnMouseChanged()
    //    {
    //        try
    //        {
    //            do
    //            {
    //                _hMouseChange.WaitOne();
    //                _Mouse.GetCurrentState(ref _Mousestate);
    //                MouseChanged?.Invoke(this, _Mousestate);
    //            } while (true);
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //    }
    //    public Subsystem_Input_Mouse(SharpDX.DirectInput.DirectInput di)
    //    {
    //        _hMouseChange = new AutoResetEvent(false);
    //        _threadMouseChange = new Thread(OnMouseChanged);

    //        _Mouse = new Mouse(di);
    //        if (_Mouse != null)
    //        {
    //            _Mouse.SetCooperativeLevel(IntPtr.Zero, //keyboard.SetCooperativeLevel((this as Form).Handle,
    //                CooperativeLevel.Background |
    //                CooperativeLevel.NonExclusive);
    //            _Mouse.SetNotification(_hMouseChange);
    //            _Mouse.Acquire();

    //            //_Mouse.Poll(); //keyboard and mouse donot need poll
    //            _Mousestate = _Mouse.GetCurrentState();

    //            _Mouse.Unacquire();
    //        }
    //    }
    //    public void TurnOn()
    //    {
    //        _Mouse.Acquire();
    //        switch (this._threadMouseChange.ThreadState)
    //        {
    //            case ThreadState.Unstarted:
    //                this._threadMouseChange.Start();
    //                break;
    //        }
    //    }
    //    public void TurnOff()
    //    {
    //        _Mouse.Unacquire();
    //    }
    //    void Cleanup()
    //    {
    //        TurnOff();

    //        _threadMouseChange?.Abort();
    //        _hMouseChange?.Dispose();
    //        MouseChanged = null;
    //        _Mouse?.Dispose();
    //    }
    //    #region IDisposable Support
    //    private bool disposedValue = false; // To detect redundant calls

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!disposedValue)
    //        {
    //            if (disposing)
    //            {
    //                // TODO: dispose managed state (managed objects).
    //                Cleanup();
    //            }

    //            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
    //            // TODO: set large fields to null.

    //            disposedValue = true;
    //        }
    //    }

    //    // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    //    // ~ThreadWork_PullMouseDown() {
    //    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //    //   Dispose(false);
    //    // }

    //    // This code added to correctly implement the disposable pattern.
    //    public void Dispose()
    //    {
    //        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
    //        Dispose(true);
    //        // TODO: uncomment the following line if the finalizer is overridden above.
    //        // GC.SuppressFinalize(this);
    //    }
    //    #endregion
    //}

    public abstract class SimpleGameEngineForSharpDX : LoopingOnNewThreadSignalWorker
    {
        protected DirectInput di;
        protected Subsystem_Input_Keyboard _subsysKeyboard;
        public Subsystem_Input_Keyboard Keyboard => _subsysKeyboard;

        protected Subsystem_Input_Mouse _subsysMouse;
        public Subsystem_Input_Mouse Mouse => _subsysMouse;

        protected override void Initialize()
        {
            base.Initialize();

            di = new DirectInput();
            _subsysKeyboard = new Subsystem_Input_Keyboard(di);
            _subsysMouse = new Subsystem_Input_Mouse(di);
        }
        protected override void Cleanup()
        {
            _subsysKeyboard?.Dispose();
            _subsysKeyboard = null;

            _subsysMouse?.Dispose();
            _subsysMouse = null;

            di?.Dispose();
            di = null;

            base.Cleanup();
        }
        public override void Start()
        {
            _subsysKeyboard?.Start();
            _subsysMouse?.Start();

            base.Start();
        }
        public override void Stop()
        {
            base.Stop();

            _subsysKeyboard?.Stop();
            _subsysMouse?.Stop();
        }
        public override void Activate()
        {
            _subsysKeyboard.Activate();
            _subsysMouse.Activate();

            base.Activate();
        }
    }
}

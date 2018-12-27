using System;
using System.Collections.Generic;
using System.Text;
using n43e120.Interop.WinAPI;

namespace n43e120.SimpleGameEngine.Common
{
    public delegate void WndProc(IntPtr MSG);
    public class MessageDispatcher
    {

        public event WndProc evMessage;
        protected void Broadcast(IntPtr msg)
        {
            this.evMessage?.Invoke(msg);
        }
        public void ClearAllSubscribers()
        {
            this.evMessage = null;
        }
    }
    public interface IMessageReceptor
    {
        void WndProc(IntPtr msg);
    }
}

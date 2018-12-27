using n43e120.SimpleGameEngine;
using System;

namespace n43e120.MouseMacro
{
    public class Actor : InterruptableLoopingOnNewThreadSignalWorker
    {
        protected Action action1;
        public virtual Action Action
        {
            get { return action1; }
            set { action1 = value; }
        }
        protected override void Work()
        {
            action1?.Invoke();
        }
    }
}

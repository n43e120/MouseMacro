using n43e120.SimpleGameEngineViaSharpDX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace WinFormMouseMarco
{
    public sealed class MyGame : SimpleGameEngineForSharpDX
    {
        public MyGame()
        {
            Initialize();

        }
        //protected override void InitializeEventWaitHandle()
        //{
        //    _signal = new ManualResetEvent(false);
        //}
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void DoWork()
        {
            throw new NotImplementedException();
        }
    }
    public class MouseRunner : DoWorkOnLoopSignal_Interruptable
    {
        protected Action action1;
        public virtual Action Action
        {
            get { return action1; }
            set { action1 = value; }
        }
        protected override void DoWork()
        {
            action1.Invoke();
        }
    }
    public class TextSpeaker : DoWorkOnLoopSignal_Interruptable
    {
        public static void TTSspeak(string text)
        {
            using (var ss = new System.Speech.Synthesis.SpeechSynthesizer())
            {
                ss.SelectVoiceByHints(System.Speech.Synthesis.VoiceGender.Female, System.Speech.Synthesis.VoiceAge.Adult, 0, System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                //var pr = ss.SpeakAsync(text);
                //Task.Run(() =>
                //{
                //    do
                //    {
                //        Application.DoEvents();
                //        System.Threading.Thread.Sleep(1000);
                //    } while (!pr.IsCompleted);
                //}).Wait();
                ss.Speak(text);
            }
        }

        public string script;
        protected override void DoWork()
        {
            TTSspeak(script);
        }
    }
}

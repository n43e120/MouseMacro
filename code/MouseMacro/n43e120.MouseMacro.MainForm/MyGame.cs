using n43e120.SimpleGameEngine;

namespace n43e120.MouseMacro
{
    public class TextSpeaker : InterruptableLoopingOnNewThreadSignalWorker
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
        protected override void Work()
        {
            TTSspeak(script);
        }
    }
}
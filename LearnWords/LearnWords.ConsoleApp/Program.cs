using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Globalization;

namespace LearnWords.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize a new instance of the SpeechSynthesizer.  
            var synth = new SpeechSynthesizer();

            var voices = synth.GetInstalledVoices();

            foreach(var culture in voices.Select(x => x.VoiceInfo.Culture).Distinct())
            {
                Console.WriteLine(culture.EnglishName);

                foreach(var voice in voices.Where(x => x.VoiceInfo.Culture.Equals(culture)))
                {
                    Console.WriteLine("\t" + voice.VoiceInfo.Name);
                }
            }

            // Configure the audio output.   
            synth.SetOutputToDefaultAudioDevice();
            synth.SelectVoice("Microsoft Irina Desktop");

            // Speak a string.  
            synth.Speak("Образ");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace MaduMänguLoomine
{
    
    class Sound
    {
        private IWavePlayer player = new WaveOutEvent();
        private AudioFileReader currentFile;
        private string pathToMedia;
        public Sound(string pathToResources)
        {
            pathToMedia = pathToResources;
        }
        
        public void Play(string filePath)
        {
            Stop(); 
            currentFile = new AudioFileReader(filePath);
            player.Init(currentFile);
            player.Volume = 0.3f;
            player.Play();
        }
        
        public void PlayGameOver()
        {
            Play("../../../death.mp3");
        }
        
        public void PlayEat()
        {
            Play("../../../poedanie.mp3");
        }
        
        public void Stop() 
        {
            if (player.PlaybackState == PlaybackState.Playing)
            {
                player.Stop();
                currentFile?.Dispose(); 
                currentFile = null; 
            }
        }
    }
}
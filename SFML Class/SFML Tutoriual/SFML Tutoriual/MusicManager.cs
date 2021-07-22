using SFML.Audio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SFML_Tutoriual
{
    class MusicManager
    {
        private readonly string defaultMusic = "Audio" + Path.DirectorySeparatorChar + "Music" + Path.DirectorySeparatorChar + "Music1.ogg";
        private readonly string battleMusic = "Audio" + Path.DirectorySeparatorChar + "Music" + Path.DirectorySeparatorChar + "Music2.ogg";

        private const int battleMusicIndex = 1;

        private static MusicManager instance;

        public static MusicManager GetInstance()
        {
            if (instance == null)
            {
                instance = new MusicManager();
            }
            return instance;
        }
        private List<Music> music;
        private int currentSong;
        private MusicManager()
        {
            music = new List<Music>();
            currentSong = 0;
            Music m = new Music(defaultMusic);
            m.Loop = true;
            Music m2 = new Music(battleMusic);
            m2.Loop = true;
            music.Add(m);
            music.Add(m2);
            SetVolume(10);
        }

        public void SetVolume(int newVolume)
        {
            for (int i = 0; i < music.Count; i++)
            {
                music[i].Volume = newVolume;
            }
        }

        public void Stop()
        {
            music[currentSong].Stop();
        }
        public void Pause()
        {
            music[currentSong].Pause();
        }
        public void Play()
        {
            music[currentSong].Play();
        }

        public void Skip() 
        {
            music[currentSong].Stop();
            currentSong++;
            if (currentSong > music.Count)
            {
                currentSong = 0;
            }
            music[currentSong].Play();
        }

        public void SetBattleMusic()
        {
            music[currentSong].Stop();
            currentSong = battleMusicIndex;
            music[currentSong].Play();
        }


    }
}

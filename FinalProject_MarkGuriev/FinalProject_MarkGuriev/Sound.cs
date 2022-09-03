using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace FinalProject_MarkGuriev
{
    class Sound
    {
        public SoundPlayer start = new SoundPlayer("Sound/Start.wav");

        public SoundPlayer coin = new SoundPlayer("Sound/Coin.wav");

        public SoundPlayer foot = new SoundPlayer("Sound/Foot.wav");

        public SoundPlayer oof = new SoundPlayer("Sound/Oof.wav");

        public SoundPlayer fbi = new SoundPlayer("Sound/fbi.wav");

        //public SoundPlayer souz = new SoundPlayer("Sound/Souz.wav");

        public SoundPlayer theme = new SoundPlayer("Sound/Theme.wav");

        public SoundPlayer pass = new SoundPlayer("Sound/Pass.wav");

        public SoundPlayer fail = new SoundPlayer("Sound/Fail.wav");

        public SoundPlayer loss = new SoundPlayer("Sound/Loss.wav");

    }
}

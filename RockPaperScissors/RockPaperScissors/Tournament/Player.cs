﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockPaperScissors.Tournament
{
    //The representation of a player.
    public class Player
    {
        public string _name;
        public string _play;

        public Player(string name, string play) {
            _name = name;
            _play = play;
        }


        public string getName()
        {
            return _name;
        }


        public string getPlay()
        {
            return _play;
        }

        
    }
}

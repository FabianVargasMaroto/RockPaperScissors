using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RockPaperScissors.Tournament
{
    public class Tournament
    {
        private TournamentNode _tournament;
        private Player _winner;
        private Player _secondPlace;





        public Tournament(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                 Stack list = new Stack();
                while (sr.Peek() >= 0) 
                {
                    String line = sr.ReadLine();
                    line.Trim();
                    if (line.Equals("["))
                    { 
                        TournamentNode node = new TournamentNode();
                        list.Push(node);
                    }
                    else if (line.Equals("]") || line.Equals("],"))
                    {
                        TournamentNode right = (TournamentNode) list.Pop();
                        TournamentNode left = (TournamentNode) list.Pop();
                        TournamentNode node = (TournamentNode)list.Pop();
                        node.setSons(left, right);
                        list.Push(node);
                    }
                    else
                    {
                      string[] args =  line.Split('"');
                      Player left = new Player(args[1], args[3]);
                      Player right = new Player(args[5], args[7]);
                      TournamentNode node = new TournamentNode(left, right);
                      list.Push(node);
                    }
                }

                _tournament = (TournamentNode)list.Pop();

            }

        }

        public void  setFinalists()
        {
            Player leftFinalist = _tournament.winnerTournament(_tournament.getLeftNode());
            Player rightFinalist = _tournament.winnerTournament(_tournament.getRightNode());
        if (_tournament.leftwins(leftFinalist.getPlay(), rightFinalist.getPlay()))
        {
            _winner = leftFinalist;
            _secondPlace = rightFinalist;
        }
        else
        {
            _winner = rightFinalist;
            _secondPlace = leftFinalist;
        }
        }


    }
}
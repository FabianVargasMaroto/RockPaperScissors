using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RockPaperScissors.Tournament
{
    public class Championship
    {
        /* The championship is the representation of a championship*/
        private TournamentNode _tournament;
        public Player _winner;
        public Player _secondPlace;




        /*Constructor that recieves the path of a .txt file to obtain the winner and second place of the tournament specified in 
          the file.  */
        public Championship(string path)
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
                      Player left = new Player(args[1].Trim().ToUpper(), args[3].Trim().ToUpper());
                      Player right = new Player(args[5].Trim().ToUpper(), args[7].Trim().ToUpper());
                      TournamentNode node = new TournamentNode(left, right);
                      list.Push(node);
                    }
                }

                _tournament = (TournamentNode)list.Pop();

            }

        }


        public Championship()
        { 
        }


        public void setNodes(string match)
        {
            string[] args = match.Split('"');
            Player left = new Player(args[1], args[3]);
            Player right = new Player(args[5], args[7]);
            TournamentNode node = new TournamentNode(left, right);
            _winner = node.winnerTournament(node);
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


        public string getWinners(int ptsfp, int ptssp)
        {
            return _winner._name + " won " + ptsfp.ToString() + " points using " + _winner._play + ", " + _secondPlace._name + " won " + ptssp.ToString() + " points using " + _secondPlace._play; 
        }




        public int[] getpointsperwin() { 
        int[] resul = new int[]{3,1};
        return  resul;
        }

    }
}
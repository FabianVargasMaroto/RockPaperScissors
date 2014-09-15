using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScissors.Tournament
{
    public class TournamentNode
    {
        private TournamentNode _leftNode;
        private TournamentNode _rightNode;
        private Player _player;

        public TournamentNode() { 
        
        }

        public TournamentNode(Player left, Player right)
        {
            _leftNode = new TournamentNode(left);
            _rightNode = new TournamentNode(right);
        }

        public TournamentNode(Player player)
        {
            _player = player;
        }



        public TournamentNode getLeftNode()
        {
            return _leftNode;
        }

        public TournamentNode getRightNode()
        {
            return _rightNode;
        }


        public Player winnerTournament(TournamentNode actualNode)
        {
            if (actualNode.isSon())
                return actualNode._player;
            else
                return winnerTournamentAux(actualNode._leftNode, actualNode._rightNode)._player;
        }

       private TournamentNode winnerTournamentAux(TournamentNode tournamentNodeleft, TournamentNode tournamentNoderight)
        {
            if (tournamentNodeleft.isSon())
                return winnerMatch(tournamentNodeleft, tournamentNoderight);
            else
            {
                TournamentNode leftwinner = winnerTournamentAux(tournamentNodeleft._leftNode, tournamentNodeleft._rightNode);
                TournamentNode rightwinner = winnerTournamentAux(tournamentNoderight._leftNode, tournamentNoderight._rightNode);
                return winnerTournamentAux(leftwinner, rightwinner);
            }
        }


        private TournamentNode winnerMatch(TournamentNode left, TournamentNode right)
        {
            char playLeft = left._player.getPlay();
            char playRight = right._player.getPlay();
          
            if (leftwins(playLeft, playRight))
                return left;
            else
                return right;

        }




        public bool leftwins(char playLeft, char playRight)
        {
            //P beats R, R beats S, S beats P
            //if it's a tie, left wins
            if (playLeft.Equals(playRight)
                || (playLeft.Equals('S') && playRight.Equals('P'))
                || (playLeft.Equals('P') && playRight.Equals('R'))
                || (playLeft.Equals('R') && playRight.Equals('S')))
                return true;
            else
                return false;

        }


        private bool isSon() {
            bool _result = false;
            if (_leftNode == null && _rightNode == null)
                _result = true;

            return _result;
        }

        internal void setSons(TournamentNode left, TournamentNode right)
        {
            _leftNode = left;
            _rightNode = right;
        }
    }
}
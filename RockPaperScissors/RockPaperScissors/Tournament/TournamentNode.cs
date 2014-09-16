using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScissors.Tournament
{
    //The Node of the tree representation of the list used for getting the matches
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

        //Recursive method for obtaining the winner of a tournament.
        //if you call this method with a tournament Node, you can obtain the winner of that Node in specific.
        public Player winnerTournament(TournamentNode actualNode)
        {
            if (actualNode.isSon())
                return actualNode._player;
            else
                return winnerTournamentAux(actualNode._leftNode, actualNode._rightNode)._player;
        }
        //Auxiliar method of winnerTournament used for the recursion of the method in both Nodes of the tree
       private TournamentNode winnerTournamentAux(TournamentNode tournamentNodeleft, TournamentNode tournamentNoderight)
        {
           //end statement, when the Nodes are Sons
            if (tournamentNodeleft.isSon())
                return winnerMatch(tournamentNodeleft, tournamentNoderight);
            else
            {
                //Obtains the winner of the games in the left and right Nodes and obtains the champion
                TournamentNode leftwinner = winnerTournamentAux(tournamentNodeleft._leftNode, tournamentNodeleft._rightNode);
                TournamentNode rightwinner = winnerTournamentAux(tournamentNoderight._leftNode, tournamentNoderight._rightNode);
                return winnerTournamentAux(leftwinner, rightwinner);
            }
        }

        //Method that retrieves the winner of a single match.
        //the nodes that recieves most be sons
        private TournamentNode winnerMatch(TournamentNode left, TournamentNode right)
        {
            string playLeft = left._player.getPlay();
            string playRight = right._player.getPlay();
          
            if (leftwins(playLeft, playRight))
                return left;
            else
                return right;

        }



        //Method that returns a True if the left Node is winner 
        public bool leftwins(string playLeft, string playRight)
        {
            //P beats R, R beats S, S beats P
            //if it's a tie, left wins
            if (playLeft.Equals(playRight)
                || (playLeft.Equals("S") && playRight.Equals("P"))
                || (playLeft.Equals("P") && playRight.Equals("R"))
                || (playLeft.Equals("R") && playRight.Equals("S")))
                return true;
            else
                return false;

        }

        //Boolean Method that returns true if the actual Node is a son.
        private bool isSon() {
            bool _result = false;
            if (_leftNode == null && _rightNode == null)
                _result = true;

            return _result;
        }


        //Set of the Left and Right Nodes.
        internal void setSons(TournamentNode left, TournamentNode right)
        {
            _leftNode = left;
            _rightNode = right;
        }
    }
}
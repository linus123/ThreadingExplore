using System;
using System.Collections.Generic;

namespace ThreadingExplore.Core.TicTacToe
{
    public class Player
    {
        private readonly TicTacToeCellValue _playerCellValue;
        private readonly TicTacToeCellValue _opposingCellValue;

        public Player(
            TicTacToeCellValue playerCellValue)
        {
            _playerCellValue = playerCellValue;

            if (_playerCellValue == TicTacToeCellValue.X)
                _opposingCellValue = TicTacToeCellValue.O;
            else
                _opposingCellValue = TicTacToeCellValue.X;
        }

        delegate bool Move(TicTacToeBoard board);

        public void MakeNextMove(
            TicTacToeBoard board)
        {
            var possibleMoves = CreatePossibleMoves();

            foreach (var possibleMove in possibleMoves)
            {
                var madeMove = possibleMove(board);

                if (madeMove)
                    return;
            }

            throw new Exception("Could not make another move.");
        }

        private List<Move> CreatePossibleMoves()
        {
            var moves = new List<Move>();

            moves.Add(BlockHorizontal);
            moves.Add(BlockVertical);
            moves.Add(BlockBackToFrontDiagonal);
            moves.Add(BlockFrontToBackDiagonal);
            moves.Add(NextBlankSpace);

            return moves;
        }

        private bool BlockVertical(
            TicTacToeBoard board)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (board.GetCellValue(x, AddWithAdjust(y, 1)) == _opposingCellValue
                        && board.GetCellValue(x, AddWithAdjust(y, 2)) == _opposingCellValue)
                    {
                        board.SetCellValue(x, AddWithAdjust(y, 0), _playerCellValue);
                        return true;
                    }
                }
            }

            return false;
        }

        private bool BlockHorizontal(
            TicTacToeBoard board)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (board.GetCellValue(AddWithAdjust(x, 1), y) == _opposingCellValue
                        && board.GetCellValue(AddWithAdjust(x, 2), y) == _opposingCellValue)
                    {
                        board.SetCellValue(AddWithAdjust(x, 0), y, _playerCellValue);
                        return true;
                    }
                }
            }

            return false;
        }

        private bool BlockBackToFrontDiagonal(
            TicTacToeBoard board)
        {
            for (int n = 0; n < 3; n++)
            {
                if (board.GetCellValue(AddWithAdjust(n, 0), AddWithAdjust(n, 0)) == _opposingCellValue
                    && board.GetCellValue(AddWithAdjust(n, 1), AddWithAdjust(n, 1)) == _opposingCellValue)
                {
                    board.SetCellValue(AddWithAdjust(n, 2), AddWithAdjust(n, 2), _playerCellValue);
                    return true;
                }
            }

            return false;
        }

        private bool BlockFrontToBackDiagonal(
            TicTacToeBoard board)
        {
            if (board.GetCellValue(2, 0) == _opposingCellValue
                && board.GetCellValue(1, 1) == _opposingCellValue)
            {
                board.SetCellValue(0, 2, _playerCellValue);
                return true;
            }

            if (board.GetCellValue(2, 0) == _opposingCellValue
                && board.GetCellValue(0, 2) == _opposingCellValue)
            {
                board.SetCellValue(1, 1, _playerCellValue);
                return true;
            }

            if (board.GetCellValue(0, 2) == _opposingCellValue
                && board.GetCellValue(1, 1) == _opposingCellValue)
            {
                board.SetCellValue(2, 0, _playerCellValue);
                return true;
            }

            return false;
        }

        private bool NextBlankSpace(
            TicTacToeBoard board)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (board.GetCellValue(x, y) == TicTacToeCellValue.Blank)
                        board.SetCellValue(x, y, _playerCellValue);

                    return true;
                }
            }

            return false;
        }

        private int AddWithAdjust(int x, int addVal)
        {
            var n1 = x + addVal;

            if (n1 >= 3)
                n1 = n1 - 3;

            return n1;
        }

    }
}
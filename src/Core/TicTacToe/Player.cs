using System;
using System.Collections.Generic;

namespace ThreadingExplore.Core.TicTacToe
{
    public class Player
    {
        private readonly TicTacToeCellValue _playerCellValue;
        private readonly TicTacToeCellValue _opposingCellValue;

        public static int[,] AllCombos = new int[,]
        {
            {0, 1, 2},
            {1, 2, 0},
            {2, 0, 1},
        };

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
            moves.Add(BlockBackSlashDiagonal);
            moves.Add(BlockFrontSlashDiagonal);
            moves.Add(SetFirstBlankSpace);

            return moves;
        }

        private bool BlockVertical(
            TicTacToeBoard board)
        {
            for (int x = 0; x < 3; x++)
            {
                var verticalCells = board.GetVerticalCells(x);

                var madeBlock = MakeBlockOnCells(verticalCells, board);

                if (madeBlock)
                    return true;
            }

            return false;
        }

        private bool BlockHorizontal(
            TicTacToeBoard board)
        {
            for (int y = 0; y < 3; y++)
            {
                var horizontalCells = board.GetHorizontalCells(y);

                var madeBlock = MakeBlockOnCells(horizontalCells, board);

                if (madeBlock)
                    return true;
            }

            return false;
        }

        private bool BlockBackSlashDiagonal(
            TicTacToeBoard board)
        {
            var backSlashDiagonalCells = board.GetBackSlashDiagonalCells();

            var madeBlock = MakeBlockOnCells(backSlashDiagonalCells, board);

            if (madeBlock)
                return true;

            return false;
        }

        private bool BlockFrontSlashDiagonal(
            TicTacToeBoard board)
        {
            var frontSlashDiagonalCells = board.GetFrontSlashDiagonalCells();

            var madeBlock = MakeBlockOnCells(frontSlashDiagonalCells, board);

            if (madeBlock)
                return true;

            return false;
        }

        private bool MakeBlockOnCells(
            CellValueWithLocation[] cells,
            TicTacToeBoard board)
        {
            for (int n = 0; n < 3; n++)
            {
                if (cells[AllCombos[n, 0]].IsBlank
                    && cells[AllCombos[n, 1]].CellValue == _opposingCellValue
                    && cells[AllCombos[n, 2]].CellValue == _opposingCellValue)
                {
                    board.SetCellValue(
                        cells[AllCombos[n, 0]],
                        _playerCellValue);

                    return true;
                }
            }

            return false;
        }

        private bool SetFirstBlankSpace(
            TicTacToeBoard board)
        {
            var allLocations = TicTacToeBoard.GetAllLocations();

            foreach (var location in allLocations)
            {
                if (board.IsCellBlank(location))
                {
                    board.SetCellValue(location, _playerCellValue);
                    return true;
                }
            }

            return false;
        }
    }
}
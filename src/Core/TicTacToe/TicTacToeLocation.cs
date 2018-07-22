﻿namespace ThreadingExplore.Core.TicTacToe
{
    public class TicTacToeLocation : ILocation
    {
        public TicTacToeLocation(
            int x,
            int y)
        {
            Y = y;
            X = x;
        }

        public int X { get; }
        public int Y { get; }
    }
}
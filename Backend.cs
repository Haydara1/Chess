namespace Chess;

public static class Piece
{
    public const int None = 0;
    public const int King = 1;
    public const int Queen = 2;
    public const int Bishop = 3;
    public const int Knight = 4;
    public const int Rook = 5;
    public const int Pawn = 6;

    public const int White = 8;
    public const int Black = 16;
}

public class Board
{
    public int[] Square;

    public Board()
    {
        Square = new int[64];
    }
}

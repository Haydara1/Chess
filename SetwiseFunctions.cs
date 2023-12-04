namespace Chess;

internal static class SetwiseFunctions
{
    //Constants:
    public const UInt64 empty = 0;

    //Ranks
    public static Dictionary<char, UInt64> rank = new()
    {
        { '8', 0b_00000000_00000000_00000000_00000000_00000000_00000000_00000000_11111111 },
        { '7', 0b_00000000_00000000_00000000_00000000_00000000_00000000_11111111_00000000 },
        { '6', 0b_00000000_00000000_00000000_00000000_00000000_11111111_00000000_00000000 },
        { '5', 0b_00000000_00000000_00000000_00000000_11111111_00000000_00000000_00000000 },
        { '4', 0b_00000000_00000000_00000000_11111111_00000000_00000000_00000000_00000000 },
        { '3', 0b_00000000_00000000_11111111_00000000_00000000_00000000_00000000_00000000 },
        { '2', 0b_00000000_11111111_00000000_00000000_00000000_00000000_00000000_00000000 },
        { '1', 0b_11111111_00000000_00000000_00000000_00000000_00000000_00000000_00000000 },
    };

    //Files
    public static Dictionary<char, UInt64> file = new()
    {
        { '1', 0b_10000000_10000000_10000000_10000000_10000000_10000000_10000000_10000000 },
        { '2', 0b_01000000_01000000_01000000_01000000_01000000_01000000_01000000_01000000 },
        { '3', 0b_00100000_00100000_00100000_00100000_00100000_00100000_00100000_00100000 },
        { '4', 0b_00010000_00010000_00010000_00010000_00010000_00010000_00010000_00010000 },
        { '5', 0b_00001000_00001000_00001000_00001000_00001000_00001000_00001000_00001000 },
        { '6', 0b_00000100_00000100_00000100_00000100_00000100_00000100_00000100_00000100 },
        { '7', 0b_00000010_00000010_00000010_00000010_00000010_00000010_00000010_00000010 },
        { '8', 0b_00000001_00000001_00000001_00000001_00000001_00000001_00000001_00000001 },
    };

    // Shifts the bits one position to the north.
    public static UInt64 NorthOne(UInt64 x)
        => x << 8;

    // Shifts the bits one position to the south.
    public static UInt64 SouthOne(UInt64 x) 
        => x >> 8;

    // Shifts the bits one position to the west.
    public static UInt64 WestOne(UInt64 x)
        => x << 1;

    // Shifts the bits one position to the east.
    public static UInt64 EastOne(UInt64 x)
        => x >> 1;

    // Gets the empty squares, doesn't work if the position wasn't updated.
    public static UInt64 GetEmptySquares()
        => ~Board.board;

    // Gets the occupied squares, doesn't work if the position wasn't updated.
    public static UInt64 GetOccupiedSquares()
        => Board.board;
}

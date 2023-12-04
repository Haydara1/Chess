namespace Chess;

// https://www.chessprogramming.org/Classical_Approach

// Logic explanation: 
// 1. Take the ray attack from each direction.
// 2. Intersect the attack with occupied pieces.
// 3. Bitscan to the LSB or the MSB depending on the direction.
// 4. Exclusif or the attack and the attack of the same direction from the result of the bitscann.


using static SetwiseFunctions;

internal class RooksFunctions
{
    static private UInt64 NorthMovements(UInt64 rook)
    {
        // The variable for all the movements
        UInt64 movements = 0;

        // Assign movements to the north direction until the end of the board
        for(int i = 0; i < 8; i++)
            movements |= rook << (i * 8);

        UInt64 blocker = movements & GetOccupiedSquares();

        // Checks if there is a blocker
        if (blocker != 0)
            return 0; // temporarly

        return movements;
    }

    static private UInt64 SouthMovements(UInt64 rook)
    {
        UInt64 movements = 0;

        for (int i = 0; i < 8; i++)
            movements |= rook >> (i * 8);

        return movements;
    }

    static private UInt64 EastMovements(UInt64 rook)
    {
        UInt64 movements = 0;

        for (int i = 0; i < 8; i++)
            movements |= rook << i;

        return movements;
    }

    static private UInt64 WestMovements(UInt64 rook)
    {
        UInt64 movements = 0;

        for (int i = 0; i < 8; i++)
            movements |= rook >> i;

        return movements;
    }

    static public UInt64 GetRookMovements(UInt64 rook)
        => 0;
}

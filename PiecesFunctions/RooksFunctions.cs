namespace Chess;

// https://www.chessprogramming.org/Classical_Approach

// Logic explanation: 
// 1. Take the ray attack from each direction.
// 2. Intersect the attack with occupied pieces.
// 3. Bitscan to the LSB or the MSB depending on the direction.
// 4. Exclusif or the attack and the attack of the same direction from the result of the bitscan.

using static SetwiseFunctions;

internal class RooksFunctions
{
    static private UInt64 NorthMovements(UInt64 rook)
    {
        // The variable for all the movements
        UInt64 movements = 0;

        // Assign movements to the north direction until the end of the board
        for(int i = 1; i < 8; i++)
            movements |= rook << (i * 8);
       
        return movements;
    }

    static private UInt64 SouthMovements(UInt64 rook)
    {
        UInt64 movements = 0;

        for (int i = 1; i < 8; i++)
            movements |= rook >> (i * 8);

        return movements;
    }

    static private UInt64 EastMovements(UInt64 rook)
    {
        UInt64 movements = 0;

        for (int i = 1; i < 8; i++)
            movements |= rook << i;

        return movements & getRank(rook);
    }

    static private UInt64 WestMovements(UInt64 rook)
    {
        UInt64 movements = 0;

        for (int i = 1; i < 8; i++)
            movements |= rook >> i;

        return movements & getRank(rook);
    }

    static private UInt64 getRank(UInt64 x)
    {
       int pow = (int)Math.Log2(x);
       pow = ((int)pow / 8) * 8;
        
       return (ulong)(Math.Pow(2, pow) + Math.Pow(2, pow + 1) + Math.Pow(2, pow + 2)
            + Math.Pow(2, pow + 3) + Math.Pow(2, pow + 4) + Math.Pow(2, pow + 5) 
            + Math.Pow(2, pow + 6) + Math.Pow(2, pow + 7));
    }

    static public UInt64 GetRookMovements(UInt64 rook)
    {
        UInt64 NMovements = NorthMovements(rook);
        UInt64 SMovements = SouthMovements(rook);
        UInt64 WMovements = WestMovements(rook);
        UInt64 EMovements = EastMovements(rook);

        UInt64 NBlocker = NMovements & GetOccupiedSquares();
        UInt64 SBlocker = SMovements & GetOccupiedSquares();
        UInt64 WBlocker = WMovements & GetOccupiedSquares();
        UInt64 EBlocker = EMovements & GetOccupiedSquares();

        
        NMovements ^= NorthMovements(GetLSB(NBlocker)) | NBlocker;
        SMovements ^= SouthMovements(GetMSB(SBlocker)) | SBlocker;
        WMovements ^= WestMovements(GetMSB(WBlocker))  | WBlocker;
        EMovements ^= EastMovements(GetLSB(EBlocker))  | EBlocker;

        // Add the blockers from the opposing color
        UInt64 Blockers = GetLSB(NBlocker) | GetMSB(SBlocker) | GetMSB(WBlocker) | GetLSB(EBlocker);
        Blockers &= Convert.ToBoolean(Program.turn) ? Board.WhitePieces : Board.BlackPieces;

        return NMovements | SMovements | WMovements | EMovements | Blockers;
    }
}

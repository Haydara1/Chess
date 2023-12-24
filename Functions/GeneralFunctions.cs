namespace Chess.Functions;

using static Board;

internal class GeneralFunctions
{
    // Is not going to be used currently
    public static UInt64 GetOppClrPossAttacks()
    {
        UInt64 PossMovements = 0;

        // Get the opposing color
        int color = Program.turn == 1 ? 0 : 6;

        // Get the possible movements for all the pieces in this color (Should change the code when the pinned pieces are implemented)
        PossMovements |= KnightsFunctions.GetKnightMovements(piecesBB[color + Knights - 1]);
        PossMovements |= BishopsFunctions.GetBishopsMovements(piecesBB[color + Bishops - 1]);
        PossMovements |= RooksFunctions.GetRookMovements(piecesBB[color + Rooks - 1]);
        PossMovements |= QueensFunctions.GetQueenMovements(piecesBB[color + Knights - 1]);
        PossMovements |= KingsFunctions.GetAllKingMovements(piecesBB[color + King - 1]);

        return PossMovements;
    }

    public static UInt64 TurnOffAttackedBits(UInt64 pos)
    {
        UInt64 result = 0;
        List<UInt64> bits = DisolveBits(pos);

        foreach (UInt64 bit in bits)
        {
            if(SquareAttackedBy.isSquareAttacked(bit, Program.turn == 0 ? (short)1 : (short)0)) 
                continue;
            result |= bit;
        }

        return result;
    }

    public static List<UInt64> DisolveBits(UInt64 pos)
    {
        List<UInt64> bits = new();

        while(Convert.ToBoolean(pos)) // iterate until zero
        {
            UInt64 bit = pos ^ (pos & (pos - 1)); // gets only on bit
            bits.Add(bit);
            pos ^= bit;
        }

        return bits;
    }
}
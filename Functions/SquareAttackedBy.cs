namespace Chess.Functions;

using System.Security.Principal;
using static Board;

internal class SquareAttackedBy
{
    // Returns true if the given square is attacked by a piece from the opposing side
    static public bool isSquareAttacked(UInt64 sq, short side)
    {
        // Take the colour
        int color = side == 0 ? 0 : 6;

        // Check for knights
        if ((KnightsFunctions.GetKnightMovements(piecesBB[color + Knights - 1]) & sq) != 0)
            return true;

        // Check for bishops
        if ((BishopsFunctions.GetBishopsMovements(piecesBB[color + Bishops - 1]) & sq) != 0)
            return true;

        // Check for rooks
        if ((RooksFunctions.GetRookMovements(piecesBB[color + Rooks - 1]) & sq) != 0)
            return true;

        // Check for queens
        if ((QueensFunctions.GetQueenMovements(piecesBB[color + Queen - 1]) & sq) != 0)
            return true;

        // Lastly check for pawns
        if (side == 0)
        {
            if ((PawnsFunctions.wEat(piecesBB[color + Pawns - 1]) & sq) != 0)
                return true;
        }
        else
            if ((PawnsFunctions.bEat(piecesBB[color + Pawns - 1]) & sq) != 0)
                return true;

        return false;
    }
}

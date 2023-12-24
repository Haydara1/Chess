namespace Chess;

using Chess.Functions;

// https://www.chessprogramming.org/King_Pattern

using static SetwiseFunctions;

internal class KingsFunctions
{
    // Returns the legal movements of a king
    public static UInt64 GetKingMovements(UInt64 king)
    {
        UInt64 attacks = EastOne(king) | WestOne(king);
        king |= attacks;
        attacks |= NorthOne(king) | SouthOne(king);

        attacks = GeneralFunctions.TurnOffAttackedBits(attacks);

        return attacks & (GetEmptySquares() | (Convert.ToBoolean(Program.turn) 
            ? Board.WhitePieces : Board.BlackPieces)); 
    }

    // Returns the possible movements of a king
    public static UInt64 GetAllKingMovements(UInt64 king)
    {
        UInt64 attacks = EastOne(king) | WestOne(king);
        king |= attacks;
        attacks |= NorthOne(king) | SouthOne(king);
        return attacks;
    }

}

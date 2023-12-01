namespace Chess;

using static SetwiseFunctions;

internal class KingsFunctions
{
    // Returns the possible movements of a king
    public static UInt64 GetKingMovements(UInt64 king)
    {
        UInt64 attacks = EastOne(king) | WestOne(king);
        king |= attacks;
        attacks |= NorthOne(king) | SouthOne(king);
        return attacks & GetEmptySquares();
    }
}

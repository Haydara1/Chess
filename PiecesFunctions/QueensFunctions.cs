namespace Chess;

internal class QueensFunctions
{
    // queen = rook + bishop
    static public UInt64 GetQueenMovements(UInt64 queen)
        => RooksFunctions.GetRookMovements(queen) 
         | BishopsFunctions.GetBishopsMovements(queen);
}

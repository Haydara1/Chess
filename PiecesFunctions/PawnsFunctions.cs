namespace Chess;

using static SetwiseFunctions;

internal class PawnsFunctions
{
    #region Pawns pushes:

    #region White:
    // Push one square for white pawns
    static public UInt64 wSinglePush(UInt64 pawns)
        => NorthOne(pawns) & GetEmptySquares(); 
    //Gets the square in the north of pawns, intersected with empty squares.

    // Push two squares for white pawns
    static public UInt64 wDoublePush(UInt64 pawns)
        => NorthOne(NorthOne(pawns)) & GetEmptySquares() & rank4;
    //Gets the square in the north of pawns, intersected with empty squares in the fourth rank.

    #endregion

    #region Black:
    // Push one square for black pawns
    static public UInt64 bSinglePush(UInt64 pawns)
        => SouthOne(pawns) & GetEmptySquares();

    // Push two squares for black pawns
    static public UInt64 bDoublePush(UInt64 pawns)
        => SouthOne(SouthOne(pawns)) & GetEmptySquares() & rank5;

    #endregion

    #endregion
}

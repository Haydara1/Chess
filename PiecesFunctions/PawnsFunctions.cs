namespace Chess;

using static SetwiseFunctions;

internal class PawnsFunctions
{
    #region Pawns pushes

    #region White
    // Push one square for white pawns
    static public UInt64 wSinglePush(UInt64 pawns)
        => NorthOne(pawns) & GetEmptySquares(); 
    //Gets the square in the north of pawns, intersected with empty squares.

    // Push two squares for white pawns
    static public UInt64 wDoublePush(UInt64 pawns)
        => NorthOne(NorthOne(pawns)) & GetEmptySquares() & rank['5'];
    //Gets the square in the north of pawns, intersected with empty squares in the fourth rank.

    #endregion

    #region Black
    // Push one square for black pawns
    static public UInt64 bSinglePush(UInt64 pawns)
        => SouthOne(pawns) & GetEmptySquares();

    // Push two squares for black pawns
    static public UInt64 bDoublePush(UInt64 pawns)
        => SouthOne(SouthOne(pawns)) & GetEmptySquares() & rank['4'];

    #endregion

    #endregion

    #region Pawns able to push

    #region White

    // Gets the white pawns that are able to push
    static public UInt64 wAbleToPush(UInt64 pawns, UInt64 empty)
        => SouthOne(empty) & pawns;
    

     // Gets the white pawns that are able to double push
    static public UInt64 wAbleToDoublePush(UInt64 pawns, UInt64 empty)
        => wAbleToPush(pawns, SouthOne(empty & rank['5']) & empty);

    #endregion

    #region Black

    // Gets the black pawns that are able to push
    static public UInt64 bAbleToPush(UInt64 pawns, UInt64 empty)
        => NorthOne(empty) & pawns;

    // Gets the black pawns that are able to double push
    static public UInt64 bAbleToDoublePush(UInt64 pawns, UInt64 empty)
        => bAbleToPush(pawns, NorthOne(empty & rank['4']) & empty);

    #endregion

    #endregion

    #region Clean results

    // Gets all possible movements for all white pawns
    static public UInt64 GetWPawnsMovement(UInt64 wpawns)
        => wSinglePush(wAbleToPush(wpawns, GetEmptySquares())) | wDoublePush(wAbleToDoublePush(wpawns, GetEmptySquares()));

    // Gets all possible movements for the white pawn in the file 'index'
    static public UInt64 GetWPawnsMovement(UInt64 wpawns, char index)
        => (wSinglePush(wAbleToPush(wpawns, GetEmptySquares())) | wDoublePush(wAbleToDoublePush(wpawns, GetEmptySquares()))) & file[index];

    // Gets all possible movements for all white pawns
    static public UInt64 GetBPawnsMovement(UInt64 bpawns)
        => bSinglePush(bAbleToPush(bpawns, GetEmptySquares())) | bDoublePush(bAbleToDoublePush(bpawns, GetEmptySquares()));

    // Gets all possible movements for the black pawn in the file 'index'
    static public UInt64 GetBPawnsMovement(UInt64 bpawns, char index)
        => (bSinglePush(bAbleToPush(bpawns, GetEmptySquares())) | bDoublePush(bAbleToDoublePush(bpawns, GetEmptySquares()))) & file[index];

    #endregion
}

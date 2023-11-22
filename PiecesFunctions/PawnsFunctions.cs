namespace Chess;

using static SetwiseFunctions;

internal class PawnsFunctions
{
    // Push one square for white pawns
    static public UInt64 wSinglePush(UInt64 pawns)
        => NorthOne(pawns) & empty;

    // Push two squares for white pawns
    static public UInt64 wDoublePush(UInt64 pawns)
    {
        return 0;
    }
}

namespace Chess;

using static SetwiseFunctions;

internal class KnightsFunctions
{
    // Knight movements
    private static UInt64 NoNoEa(UInt64 knight)
        => (knight << 0) & (0);

    private static UInt64 NoNoWe(UInt64 knight)
        => (knight << 0) & (0);

    private static UInt64 SoSoEa(UInt64 knight)
        => (knight << 0) & (0);

    private static UInt64 SoSoWe(UInt64 knight)
        => (knight << 0) & (0);

    private static UInt64 EaEaNo(UInt64 knight)
        => (knight << 0) & (0);

    private static UInt64 EaEaSo(UInt64 knight)
        => (knight << 0) & (0);

    private static UInt64 WeWeNo(UInt64 knight)
        => (knight << 0) & (0);

    private static UInt64 WeWeSo(UInt64 knight)
        => (knight << 0) & (0);

    // Group them all in this function
    public static UInt64 GetKnightMovements(UInt64 knight)
        => (NoNoEa(knight) | NoNoWe(knight) |
            SoSoEa(knight) | SoSoWe(knight) |
            EaEaNo(knight) | EaEaSo(knight) |
            WeWeNo(knight) | WeWeSo(knight) )
        & GetEmptySquares();
    
}

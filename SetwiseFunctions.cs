namespace Chess;

internal static class SetwiseFunctions
{
    // Constants:
    public static UInt64 empty = 0;

    // Shifts the bits one position to the north.
    public static UInt64 NorthOne(UInt64 x)
        => x << 8;

    // Shifts the bits one position to the south.
    public static UInt64 SouthOne(UInt64 x) 
        => x >> 8;
}

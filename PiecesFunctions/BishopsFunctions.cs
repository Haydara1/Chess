namespace Chess;

using static SetwiseFunctions;

internal class BishopsFunctions
{
    static private UInt64 NorthWestMovements(UInt64 bishop)
    {
        UInt64 movements = 0;

        int max = 8 - GetFile(bishop);

        for (int i = 1; i <= max; i++)
            movements |= bishop << (i * 9);

        return movements;
    }

    static private UInt64 NorthEastMovements(UInt64 bishop)
    {
        UInt64 movements = 0;

        int max = GetFile(bishop);

        for (int i = 1; i < max; i++)
            movements |= bishop << (i * 7);

        return movements;
    }

    static private UInt64 SouthWestMovements(UInt64 bishop)
    {
        UInt64 movements = 0;

        int max = GetFile(bishop);

        for (int i = 1; i < max; i++)
            movements |= bishop >> (i * 9);

        return movements;
    }

    static private UInt64 SouthEastMovements(UInt64 bishop)
    {
        UInt64 movements = 0;

        int max = 8 - GetFile(bishop);

        for (int i = 1; i <= max; i++)
            movements |= bishop >> (i * 7);

        return movements;
    }

    static private int GetFile(UInt64 x)
        =>(int)Math.Log2(x) % 8 + 1;


    static public UInt64 GetBishopsMovements(UInt64 bishop)
    {
        UInt64 NEMovements = NorthEastMovements(bishop);
        UInt64 SEMovements = SouthEastMovements(bishop);
        UInt64 NWMovements = NorthWestMovements(bishop);
        UInt64 SWMovements = SouthWestMovements(bishop);

        UInt64 NEBlocker = NEMovements & GetOccupiedSquares();
        UInt64 SEBlocker = SEMovements & GetOccupiedSquares();
        UInt64 NWBlocker = NWMovements & GetOccupiedSquares();
        UInt64 SWBlocker = SWMovements & GetOccupiedSquares();

        
        NEMovements ^= NorthEastMovements(GetLSB(NEBlocker)) | NEBlocker;
        SEMovements ^= SouthEastMovements(GetMSB(SEBlocker)) | SEBlocker;
        NWMovements ^= NorthWestMovements(GetLSB(NWBlocker)) | NWBlocker;
        SWMovements ^= SouthWestMovements(GetMSB(SWBlocker)) | SWBlocker;

        return NWMovements | NEMovements | SWMovements| SEMovements;
    }
}

namespace Chess;

// https://www.chessprogramming.org/Knight_Pattern

//          noNoWe noNoEa
//            +17  +15
//             |     |
//noWeWe  +10 __|     |__+6  noEaEa
//              \   /
//               >0<
//           __ /   \ __
//soWeWe -6   |     |   -10  soEaEa
//             |     |
//            -15  -17
//          soSoWe soSoEa

using static SetwiseFunctions;

internal class KnightsFunctions
{
    // Knight movements
    private static UInt64 NoNoEa(UInt64 knight)
        => (knight & ~(rank['1'] | rank['2'] | file['8'])) << 15;

    private static UInt64 NoNoWe(UInt64 knight)
        => (knight & ~(rank['1'] | rank['2'] | file['1'])) << 17;

    private static UInt64 SoSoEa(UInt64 knight)
        => (knight & ~(rank['7'] | rank['8'] | file['8'])) >> 17;

    private static UInt64 SoSoWe(UInt64 knight)
        => (knight & ~(rank['7'] | rank['8'] | file['1'])) >> 15;

    private static UInt64 EaEaNo(UInt64 knight)
        => (knight & ~(rank['1'] | file['7'] | file['8'])) << 6;

    private static UInt64 EaEaSo(UInt64 knight)
        => (knight & ~(rank['8'] | file['7'] | file['8'])) >> 10;

    private static UInt64 WeWeNo(UInt64 knight)
        => (knight & ~(rank['1'] | file['1'] | file['2'])) << 10;

    private static UInt64 WeWeSo(UInt64 knight)
        => (knight & ~(rank['8'] | file['1'] | file['2'])) >> 6;

    // Group them all in this function
    public static UInt64 GetKnightMovements(UInt64 knight)
        => (NoNoEa(knight) | NoNoWe(knight) |
            SoSoEa(knight) | SoSoWe(knight) |
            EaEaNo(knight) | EaEaSo(knight) |
            WeWeNo(knight) | WeWeSo(knight) )
        & GetEmptySquares();
    
}

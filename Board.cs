// https://www.chessprogramming.org/Bitboard_Board-Definition

namespace Chess;

// This class has the logic to represent the board and the pieces, as well as methods.
internal class Board
{
    #region old code
    ////Keeps some often used redundant union sets like white and black pieces, occupancy or their complement, the empty squares.

    //UInt64[] pieceBB = new UInt64[14];
    //UInt64 emptyBB;

    //// Defining each piece group as a bitboard

    //UInt64 WhitePawns;
    //UInt64 WhiteKnights;
    //UInt64 WhiteBishops;
    //UInt64 WhiteRooks;
    //UInt64 WhiteQueens;
    //UInt64 WhiteKing;

    //UInt64 BlackPawns;
    //UInt64 BlackKnights;
    //UInt64 BlackBishops;
    //UInt64 BlackRooks;
    //UInt64 BlackQueens;
    //UInt64 BlackKing;

    #endregion

    // ---> Here we can dense the board to avoid repetitions:

    public static UInt64[] piecesBB = new UInt64[12];

    // Calculations on the enum, to be ignored: 
    // wp: 1, wn : 2, wb : 3, wr : 4, wq : 5, wk : 6     } -1 for the index
    // bp: 7, bn : 8, bb : 9, br : 10, bq : 11, bk : 12  } -1 for the index

    internal static int White = 0;
    internal static int Black = 6;
    internal static int Pawns = 1;
    internal static int Knights = 2;
    internal static int Bishops = 3;
    internal static int Rooks = 4;
    internal static int Queen = 5;
    internal static int King = 6;


    // Initializing the array: (A piece on the square is represented by 1)
    static void InitializePiecesBB()
    {
        piecesBB[White + Pawns]   = 0b_00000000_00000000_00000000_00000000_00000000_00000000_11111111_00000000;
        piecesBB[White + Knights] = 0b_00000000_00000000_00000000_00000000_00000000_00000000_00000000_01000010;
        piecesBB[White + Bishops] = 0b_00000000_00000000_00000000_00000000_00000000_00000000_00000000_00100100;
        piecesBB[White + Rooks]   = 0b_00000000_00000000_00000000_00000000_00000000_00000000_00000000_10000001;
        piecesBB[White + Queen]   = 0b_00000000_00000000_00000000_00000000_00000000_00000000_00000000_00001000;
        piecesBB[White + King]    = 0b_00000000_00000000_00000000_00000000_00000000_00000000_00000000_00010000; 
        piecesBB[Black + Pawns]   = 0b_00000000_11111111_00000000_00000000_00000000_00000000_00000000_00000000;
        piecesBB[Black + Knights] = 0b_01000010_00000000_00000000_00000000_00000000_00000000_00000000_00000000;
        piecesBB[Black + Bishops] = 0b_00100100_00000000_00000000_00000000_00000000_00000000_00000000_00000000;
        piecesBB[Black + Rooks]   = 0b_10000001_00000000_00000000_00000000_00000000_00000000_00000000_00000000;
        piecesBB[Black + Queen]   = 0b_00010000_00000000_00000000_00000000_00000000_00000000_00000000_00000000;
        piecesBB[Black + King]    = 0b_00001000_00000000_00000000_00000000_00000000_00000000_00000000_00000000;

    }

}

// https://www.chessprogramming.org/Bitboard_Board-Definition

using System;

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

    // ---> Here we can densify the board to avoid repetitions:

    public static UInt64[] piecesBB = new UInt64[12];

    // Calculations on the enum, to be ignored: 
    // wp: 1, wn : 2, wb : 3, wr : 4, wq : 5, wk : 6     } -1 for the index
    // bp: 7, bn : 8, bb : 9, br : 10, bq : 11, bk : 12  } -1 for the index

    internal static short White = 0;
    internal static short Black = 6;
    internal static short Pawns = 1;
    internal static short Knights = 2;
    internal static short Bishops = 3;
    internal static short Rooks = 4;
    internal static short Queen = 5;
    internal static short King = 6;

    internal static UInt64 board = 0; // Keeps tracking the position of all the pieces.
    internal static UInt64 WhitePieces = 0; // Keeps tracking the position of all the white pieces.
    internal static UInt64 BlackPieces = 0; // Keeps tracking the position of all the black pieces.

    // Track the board with an array too:
    internal static int[] MailboxBoard = new int[]
    {
        Black + Rooks, Black + Knights, Black + Bishops, Black + Queen, Black + King, Black + Bishops, Black + Knights, Black + Rooks,
        Black + Pawns, Black + Pawns, Black + Pawns, Black + Pawns, Black + Pawns, Black + Pawns, Black + Pawns, Black + Pawns,
        0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0,
        White + Pawns, White + Pawns, White + Pawns, White + Pawns, White + Pawns, White + Pawns, White + Pawns, White + Pawns,
        White + Rooks, White + Knights, White + Bishops, White + Queen, White + King, White + Bishops, White + Knights, White + Rooks,
    };


    // Initializing the array: (A piece on the square is represented by 1)
    public static void InitPieces()
    {
        piecesBB[White + Pawns   - 1]   = 0b_00000000_00000000_00000000_00000000_00000000_00000000_11111111_00000000;
        piecesBB[White + Knights - 1]   = 0b_00000000_00000000_00000000_00000000_00000000_00000000_00000000_01000010;
        piecesBB[White + Bishops - 1]   = 0b_00000000_00000000_00000000_00000000_00010000_00000000_00000000_00100100;
        piecesBB[White + Rooks   - 1]   = 0b_00000000_00000000_00000000_00000000_00000000_00000000_00000000_10000001;
        piecesBB[White + Queen   - 1]   = 0b_00000000_00000000_00000000_00000000_00000000_00000000_00000000_00010000;
        piecesBB[White + King    - 1]   = 0b_00000000_00000000_00000000_00000000_00000000_00000000_00000000_00001000; 
        piecesBB[Black + Pawns   - 1]   = 0b_00000000_11111111_00000000_00000000_00000000_00000000_00000000_00000000;
        piecesBB[Black + Knights - 1]   = 0b_01000010_00000000_00000000_00000000_00000000_00000000_00000000_00000000;
        piecesBB[Black + Bishops - 1]   = 0b_00100100_00000000_00000000_00000000_00000000_00000000_00000000_00000000;
        piecesBB[Black + Rooks   - 1]   = 0b_10000001_00000000_00000000_00000000_00000000_00000000_00000000_00000000;
        piecesBB[Black + Queen   - 1]   = 0b_00010000_00000000_00000000_00000000_00000000_00000000_00000000_00000000;
        piecesBB[Black + King    - 1]   = 0b_00001000_00000000_00000000_00000000_00000000_00000000_00000000_00000000;

        UpdatePosition();
    }

    public static UInt64[] GetPiecesBB()
        => piecesBB;    

    //Updates the position of all the pieces.
    public static void UpdatePosition()
    {
        board = 0;

        UpdateBlackPosition();
        UpdateWhitePosition();

        board |= BlackPieces | WhitePieces;
    }

    // Updates the position of all the black pieces.
    private static void UpdateBlackPosition()
    {
        BlackPieces = 0;

        BlackPieces |= piecesBB[Black + Pawns  - 1]
                    | piecesBB[Black + Knights - 1]
                    | piecesBB[Black + Bishops - 1]
                    | piecesBB[Black + Rooks   - 1]
                    | piecesBB[Black + Queen   - 1]
                    | piecesBB[Black + King    - 1];
    }

    // Updates the position of all the white pieces.
    private static void UpdateWhitePosition()
    {
        WhitePieces = 0;

        WhitePieces |= piecesBB[White + Pawns   - 1]
                     | piecesBB[White + Knights - 1]
                     | piecesBB[White + Bishops - 1]
                     | piecesBB[White + Rooks   - 1]
                     | piecesBB[White + Queen   - 1]
                     | piecesBB[White + King    - 1];
    }

    public static UInt64 GetPossibleMoves(UInt64 piece, int index)
    {
        switch (index)
        {
            // White pawn
            case 1:
                return PawnsFunctions.GetWPawnsMovement(piece);
            
            // White knight
            case 2:
                return KnightsFunctions.GetKnightMovements(piece);

            // White Bishop
            case 3:
                return BishopsFunctions.GetBishopsMovements(piece);

            // White Rook
            case 4: 
                return RooksFunctions.GetRookMovements(piece);

            // White Queen
            case 5:
                return QueensFunctions.GetQueenMovements(piece);

            // White king
            case 6:
                return KingsFunctions.GetKingMovements(piece);

            // Black pawn
            case 7:
                return PawnsFunctions.GetBPawnsMovement(piece);

            // Black knight
            case 8:
                return KnightsFunctions.GetKnightMovements(piece);

            // Black Bishop
            case 9:
                return BishopsFunctions.GetBishopsMovements(piece);

            // Black Rook
            case 10:
                return RooksFunctions.GetRookMovements(piece);

            // Black Queen
            case 11:
                return QueensFunctions.GetQueenMovements(piece);

            // Black king
            case 12:
                return KingsFunctions.GetKingMovements(piece);

            default:
                break;
        }

        return 0;
    }

    public static void UpdatePiecePosition(UInt64 Pos, UInt64 LastPos, int index)
    {
        // Update piece bitboard
        piecesBB[index - 1] |= Pos;
        piecesBB[index - 1] &= ~LastPos;
        
        // Update position for all the board IMPORTANT
        UpdatePosition();
    }

}

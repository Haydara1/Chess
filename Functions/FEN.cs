namespace Chess.Functions;

using System.Linq;

internal class FEN
{
    void FenDisplay(Board board, string fen)
    {
        int index = 63;

        for (int i = 0; i < fen.Length; i++)
        {
            char c = fen[i];
            if (Char.IsNumber(c))
            { 
                index -= c;
                continue;
            }

            if (Char.IsLetter(c))
            {
                board.Square[index] = LetterToPiece(c);
            }
        }
    }

    int LetterToPiece(char c)
    {
        int piece = 0;

        // !! Might cause a problem for color, should revise this line of code.
        switch (Char.ToLower(c))
        {
            case 'k': piece = Piece.King; break;
            case 'q': piece = Piece.Queen; break;
            case 'n': piece = Piece.Knight; break;
            case 'b': piece = Piece.Bishop; break;
            case 'r': piece = Piece.Rook; break;
            case 'p': piece = Piece.Pawn; break;
        }

        return piece | (Char.IsUpper(c) ? Piece.White : Piece.Black);
    }
}

namespace Chess;

// This file contains the UI and the logic to display the board.

using Raylib_cs;
using System.Numerics;
using static Board;

internal class Program
{ 
    // Colors.
    static Color Green = Raylib.ColorFromNormalized(new Vector4(0.467f, 0.600f, 0.329f, 1f));
    static Color White = Raylib.ColorFromNormalized(new Vector4(0.914f, 0.929f, 0.800f, 1f));
    static Color Gray  = Raylib.ColorFromNormalized(new Vector4(0.216f, 0.212f, 0.204f, 0.5f));
    static Color Background  = Raylib.ColorFromNormalized(new Vector4(0.216f, 0.212f, 0.204f, 1f));
    static Color Black = Color.BLACK;

    // Making the starting position as a variable to gain the ability to shift the board
    static int starting_pos_x = 25;
    static int starting_pos_y = 25;

    // The width of the square
    static int width = 100;
    static int ratio = width / 100;

    // Repeated vairables
    readonly static char on  = '1';
    readonly static char off = '0';

    static Texture2D[] textures = new Texture2D[12];

    // The variable to display the possible movements
    static UInt64 PossibleMovements = 0;

    // Track the last pressed position and piece
    static UInt64 LastPos = 0;
    static int LastPiece = 0;
    static int LastIndex = 0;

    // 0: white's turn, 1: black's turn
    static short turn = 0;

    static void Main()
    {
        Raylib.InitWindow(1080, 920, "Chess");
        Board.InitPieces(); // Initializes the position.

        Console.Title = "Chess console";
        
        //Textures loading
        textures[0]  = Raylib.LoadTexture("C:\\Users\\hayda\\source\\repos\\Chess\\Pieces\\WP.png");
        textures[1]  = Raylib.LoadTexture("C:\\Users\\hayda\\source\\repos\\Chess\\Pieces\\BP.png");
        textures[2]  = Raylib.LoadTexture("C:\\Users\\hayda\\source\\repos\\Chess\\Pieces\\WN.png");
        textures[3]  = Raylib.LoadTexture("C:\\Users\\hayda\\source\\repos\\Chess\\Pieces\\BN.png");
        textures[4]  = Raylib.LoadTexture("C:\\Users\\hayda\\source\\repos\\Chess\\Pieces\\WB.png");
        textures[5]  = Raylib.LoadTexture("C:\\Users\\hayda\\source\\repos\\Chess\\Pieces\\BB.png");
        textures[6]  = Raylib.LoadTexture("C:\\Users\\hayda\\source\\repos\\Chess\\Pieces\\WR.png");
        textures[7]  = Raylib.LoadTexture("C:\\Users\\hayda\\source\\repos\\Chess\\Pieces\\BR.png");
        textures[8]  = Raylib.LoadTexture("C:\\Users\\hayda\\source\\repos\\Chess\\Pieces\\WQ.png");
        textures[9]  = Raylib.LoadTexture("C:\\Users\\hayda\\source\\repos\\Chess\\Pieces\\BQ.png");
        textures[10] = Raylib.LoadTexture("C:\\Users\\hayda\\source\\repos\\Chess\\Pieces\\WK.png");
        textures[11] = Raylib.LoadTexture("C:\\Users\\hayda\\source\\repos\\Chess\\Pieces\\BK.png");

        Console.Clear();

        // Main loop
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Background);

            // Drawing functions
            DrawChessBoard();
            DrawPieces();
            DrawPossibleMovements();

            if (Raylib.IsMouseButtonPressed(0))
                MouseButtonPressed();
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_EQUAL))
                UpdateWidth(10);
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_MINUS))
                UpdateWidth(-10);

            Raylib.EndDrawing();
        }

        // Unloading textures
        foreach(Texture2D texture in textures)
            Raylib.UnloadTexture(texture);

        Raylib.CloseWindow();

        Console.Clear();
        Console.WriteLine("Thanks for playing");
        
    }

    static void DrawChessBoard()
    {
        // Drawing the outline of the board.
        // Using two lines to make the outline look thicker.
        Raylib.DrawRectangleLines(starting_pos_x - 2, starting_pos_y - 2, 8 * width + 4, 8 * width + 4, Black);
        Raylib.DrawRectangleLines(starting_pos_x - 1, starting_pos_y - 1, 8 * width + 2, 8 * width + 2, Black);

        // Drawing the board.
        Raylib.DrawRectangle(starting_pos_x, starting_pos_y, width * 8, width * 8, Green);
        for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
                if ((i + j) % 2 == 0)
                    Raylib.DrawRectangle(starting_pos_x + i * width, starting_pos_y + j * width, width, width, White);

        // Drawing the ranks numbers.
        Raylib.DrawText("8", starting_pos_x + (4 * ratio), starting_pos_y + (4 * ratio),             12 * ratio, Green);
        Raylib.DrawText("7", starting_pos_x + (4 * ratio), starting_pos_y + (4 * ratio) + width,     12 * ratio, White);
        Raylib.DrawText("6", starting_pos_x + (4 * ratio), starting_pos_y + (4 * ratio) + width * 2, 12 * ratio, Green);
        Raylib.DrawText("5", starting_pos_x + (4 * ratio), starting_pos_y + (4 * ratio) + width * 3, 12 * ratio, White);
        Raylib.DrawText("4", starting_pos_x + (4 * ratio), starting_pos_y + (4 * ratio) + width * 4, 12 * ratio, Green);
        Raylib.DrawText("3", starting_pos_x + (4 * ratio), starting_pos_y + (4 * ratio) + width * 5, 12 * ratio, White);
        Raylib.DrawText("2", starting_pos_x + (4 * ratio), starting_pos_y + (4 * ratio) + width * 6, 12 * ratio, Green);
        Raylib.DrawText("1", starting_pos_x + (4 * ratio), starting_pos_y + (4 * ratio) + width * 7, 12 * ratio, White);

        // Drawing the files letters.
        Raylib.DrawText("a", starting_pos_x + (80 * ratio),             starting_pos_y + width * 7 + (85 * ratio), 12 * ratio, White);
        Raylib.DrawText("b", starting_pos_x + (80 * ratio) + width ,    starting_pos_y + width * 7 + (85 * ratio), 12 * ratio, Green);
        Raylib.DrawText("c", starting_pos_x + (80 * ratio) + width * 2, starting_pos_y + width * 7 + (85 * ratio), 12 * ratio, White);
        Raylib.DrawText("d", starting_pos_x + (80 * ratio) + width * 3, starting_pos_y + width * 7 + (85 * ratio), 12 * ratio, Green);
        Raylib.DrawText("e", starting_pos_x + (80 * ratio) + width * 4, starting_pos_y + width * 7 + (85 * ratio), 12 * ratio, White);
        Raylib.DrawText("f", starting_pos_x + (80 * ratio) + width * 5, starting_pos_y + width * 7 + (85 * ratio), 12 * ratio, Green);
        Raylib.DrawText("g", starting_pos_x + (80 * ratio) + width * 6, starting_pos_y + width * 7 + (85 * ratio), 12 * ratio, White);
        Raylib.DrawText("h", starting_pos_x + (80 * ratio) + width * 7, starting_pos_y + width * 7 + (85 * ratio), 12 * ratio, Green);
    }

    static void DrawPieces()
    {
        UInt64[] pieces = Board.GetPiecesBB();

        //Get pieces bitboards
        string WPawns   = CvrtString(pieces[Board.White + Board.Pawns - 1]); 
        string BPawns   = CvrtString(pieces[Board.Black + Board.Pawns - 1]);
                                                                                                              
        string WKnight  = CvrtString(pieces[Board.White + Board.Knights - 1]);
        string BKnight  = CvrtString(pieces[Board.Black + Board.Knights - 1]);
                                                                                                              
        string WBishops = CvrtString(pieces[Board.White + Board.Bishops - 1]);
        string BBishops = CvrtString(pieces[Board.Black + Board.Bishops - 1]);
                                                                                                               
        string WRooks   = CvrtString(pieces[Board.White + Board.Rooks - 1]);
        string BRooks   = CvrtString(pieces[Board.Black + Board.Rooks - 1]);
                                                                                                               
        string WQueen   = CvrtString(pieces[Board.White + Board.Queen - 1]);
        string BQueen   = CvrtString(pieces[Board.Black + Board.Queen - 1]);
                                                                                                               
        string WKing    = CvrtString(pieces[Board.White + Board.King - 1]);
        string BKing    = CvrtString(pieces[Board.Black + Board.King - 1]);


        // Display the pieces depending on the bits
        for (int i = 0; i < 64; i++)
        {
            //Repeated variables
            int div = i / 8;
            int mod = i % 8;

            float rotation = 0f;
            float scale = 0.3f * ratio;

            Color color = Color.WHITE;

            //Pawns
            if (WPawns[i] == on)
                Raylib.DrawTextureEx(textures[0], new(starting_pos_x + mod * width - (17 * ratio), 
                    starting_pos_y + div * width + (10 * ratio)), rotation, scale, color);
            else if (BPawns[i] == on)
                Raylib.DrawTextureEx(textures[1], new(starting_pos_x + mod * width - (17 * ratio), 
                    starting_pos_y + div * width), rotation, scale, color);

            //Knights
            else if (WKnight[i] == on)
                Raylib.DrawTextureEx(textures[2], new(starting_pos_x + mod * width - (10 * ratio), 
                    starting_pos_y + div * width + (10 * ratio)), rotation, scale, color);
            else if (BKnight[i] == on)
                Raylib.DrawTextureEx(textures[3], new(starting_pos_x + mod * width - (10 * ratio), 
                    starting_pos_y + div * width), rotation, scale, color);

            //Bishops
            else if (WBishops[i] == on)
                Raylib.DrawTextureEx(textures[4], new(starting_pos_x + mod * width, 
                    starting_pos_y + div * width + (10 * ratio)), rotation, scale, color);
            else if (BBishops[i] == on)
                Raylib.DrawTextureEx(textures[5], new(starting_pos_x + mod * width, 
                    starting_pos_y + div * width), rotation, scale, color);

            //Rooks
            else if (WRooks[i] == on)
                Raylib.DrawTextureEx(textures[6], new(starting_pos_x + mod * width - (10 * ratio), 
                    starting_pos_y + div * width + (10 * ratio)), rotation, scale, color);
            else if (BRooks[i] == on)
                Raylib.DrawTextureEx(textures[7], new(starting_pos_x + mod * width - (10 * ratio), 
                    starting_pos_y + div * width), rotation, scale, color);

            //Queens
            else if (WQueen[i] == on)
                Raylib.DrawTextureEx(textures[8], new(starting_pos_x + mod * width + (6 * ratio), 
                    starting_pos_y + div * width + (10 * ratio)), rotation, scale, color);
            else if (BQueen[i] == on)
                Raylib.DrawTextureEx(textures[9], new(starting_pos_x + mod * width + (6 * ratio), 
                    starting_pos_y + div * width), rotation, scale, color);

            //Kings
            else if (WKing[i] == on)
                Raylib.DrawTextureEx(textures[10], new(starting_pos_x + mod * width + (10 * ratio), 
                    starting_pos_y + div * width + (10 * ratio)), rotation, scale, color);
            else if (BKing[i] == on)
                Raylib.DrawTextureEx(textures[11], new(starting_pos_x + mod * width + (10 * ratio), 
                    starting_pos_y + div * width), rotation, scale, color);
        }

        // Convert UInt64 to a string of bits
        static string CvrtString(UInt64 piece)
            => Convert.ToString((long)piece, toBase: 2).PadLeft(64, off);
    }

    static void DrawPossibleMovements()
    {
        if (PossibleMovements == 0)
            return;

        string possible_movements = Convert.ToString((long)PossibleMovements, toBase: 2).PadLeft(64, off);

        // Display them as circles
        for (int i = 0; i < 64; i++)
            if (possible_movements[i] == on)
                Raylib.DrawCircle(starting_pos_x + (i % 8) * width + width / 2,
                                  starting_pos_y + (i / 8) * width + width / 2,
                                  20, Gray);
    }

    static void MouseButtonPressed()
    {
        Vector2 MousePos = Raylib.GetMousePosition();

        // Check whether the mouse is in the board
        if (!(MousePos.X >= starting_pos_x &&
            MousePos.X <= starting_pos_x + 8 * width &&
            MousePos.Y >= starting_pos_y &&
            MousePos.Y <= starting_pos_y + 8 * width))
            return;

        // Normalize the vector
        MousePos.X = Convert.ToInt32(Math.Floor((MousePos.X - starting_pos_x) / width));
        MousePos.Y = Convert.ToInt32(Math.Floor((MousePos.Y - starting_pos_y) / width));

        // Get the piece index
        int index = MailboxBoard[(int)MousePos.Y * 8 + (int)MousePos.X];

        // Get the piece position in binary
        UInt64 PiecePos = SetwiseFunctions.rank[Convert.ToString((int)MousePos.Y + 1)[0]] 
                        & SetwiseFunctions.file[Convert.ToString((int)MousePos.X + 1)[0]];

        // Check if the pressed square has a possible movement for the last pressed piece.
        if ((PossibleMovements & PiecePos) != 0)
        {
            MovePiece(PiecePos, LastPiece, (int)MousePos.Y * 8 + (int)MousePos.X);
            PossibleMovements = 0;
            return;
        }

        // Checks if this color should be played
        if (turn == 0)
            PiecePos &= Board.WhitePieces;
        else
            PiecePos &= Board.BlackPieces;

        LastIndex = (int)MousePos.Y * 8 + (int)MousePos.X;
        LastPos = PiecePos;
        LastPiece = index;

        PossibleMovements = GetPossibleMoves(PiecePos, index);
    }

    static void UpdateWidth(int number)
    {
        width += number;
        ratio = width / 100;
    }

    static void MovePiece(UInt64 pos, int piece_index, int index)
    {   
        // Update the mailbox array
        MailboxBoard[index] = piece_index;
        MailboxBoard[LastIndex] = 0;

        // Update the bitboards
        UpdatePiecePosition(pos, LastPos, piece_index);

        // Update the turn
        turn ^= 1;
    }
}
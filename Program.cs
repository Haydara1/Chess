namespace Chess;

using Raylib_cs;
using System.Numerics;
using static Board;

internal class Program
{ 
    // Colors.
    static Color Green = Raylib.ColorFromNormalized(new Vector4(0.467f, 0.600f, 0.329f, 1f));
    static Color White = Raylib.ColorFromNormalized(new Vector4(0.914f, 0.929f, 0.800f, 1f));
    static Color Black = Color.BLACK;

    static Texture2D[] textures = new Texture2D[12];

    static void Main()
    {
        Raylib.InitWindow(1080, 920, "Chess");
        Board.InitPieces(); // Initializes the position.

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

        // Main loop
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            DrawChessBoard();
            DrawPieces();

            Raylib.EndDrawing();
        }

        // Unloading textures
        foreach(Texture2D texture in textures)
            Raylib.UnloadTexture(texture);

        Raylib.CloseWindow();
    }

    static void DrawChessBoard()
    {
        // Making the starting position as a variable to gain the ability to shift the board
        int starting_pos_x = 25;
        int starting_pos_y = 25;

        // The width of the square
        int width = 100;

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
        Raylib.DrawText("1", starting_pos_x + (4 * width / 100), starting_pos_y + (4 * width / 100),             12 * width / 100, Green);
        Raylib.DrawText("2", starting_pos_x + (4 * width / 100), starting_pos_y + (4 * width / 100) + width,     12 * width / 100, White);
        Raylib.DrawText("3", starting_pos_x + (4 * width / 100), starting_pos_y + (4 * width / 100) + width * 2, 12 * width / 100, Green);
        Raylib.DrawText("4", starting_pos_x + (4 * width / 100), starting_pos_y + (4 * width / 100) + width * 3, 12 * width / 100, White);
        Raylib.DrawText("5", starting_pos_x + (4 * width / 100), starting_pos_y + (4 * width / 100) + width * 4, 12 * width / 100, Green);
        Raylib.DrawText("6", starting_pos_x + (4 * width / 100), starting_pos_y + (4 * width / 100) + width * 5, 12 * width / 100, White);
        Raylib.DrawText("7", starting_pos_x + (4 * width / 100), starting_pos_y + (4 * width / 100) + width * 6, 12 * width / 100, Green);
        Raylib.DrawText("8", starting_pos_x + (4 * width / 100), starting_pos_y + (4 * width / 100) + width * 7, 12 * width / 100, White);

        // Drawing the files letters.
        Raylib.DrawText("a", starting_pos_x + (80 * width / 100),             starting_pos_y + width * 7 + (85 * width / 100), 12 * width / 100, White);
        Raylib.DrawText("b", starting_pos_x + (80 * width / 100) + width ,    starting_pos_y + width * 7 + (85 * width / 100), 12 * width / 100, Green);
        Raylib.DrawText("c", starting_pos_x + (80 * width / 100) + width * 2, starting_pos_y + width * 7 + (85 * width / 100), 12 * width / 100, White);
        Raylib.DrawText("d", starting_pos_x + (80 * width / 100) + width * 3, starting_pos_y + width * 7 + (85 * width / 100), 12 * width / 100, Green);
        Raylib.DrawText("e", starting_pos_x + (80 * width / 100) + width * 4, starting_pos_y + width * 7 + (85 * width / 100), 12 * width / 100, White);
        Raylib.DrawText("f", starting_pos_x + (80 * width / 100) + width * 5, starting_pos_y + width * 7 + (85 * width / 100), 12 * width / 100, Green);
        Raylib.DrawText("g", starting_pos_x + (80 * width / 100) + width * 6, starting_pos_y + width * 7 + (85 * width / 100), 12 * width / 100, White);
        Raylib.DrawText("h", starting_pos_x + (80 * width / 100) + width * 7, starting_pos_y + width * 7 + (85 * width / 100), 12 * width / 100, Green);
    }

    static void DrawPieces()
    {
        UInt64[] pieces = Board.GetPiecesBB();

        //Get pieces bitboards
        string WPawns   = Convert.ToString((long)pieces[Board.White + Board.Pawns - 1], toBase: 2).PadLeft(64, '0'); 
        string BPawns   = Convert.ToString((long)pieces[Board.Black + Board.Pawns - 1], toBase: 2).PadLeft(64, '0');

        string WKnight  = Convert.ToString((long)pieces[Board.White + Board.Knights - 1], toBase: 2).PadLeft(64, '0');
        string BKnight  = Convert.ToString((long)pieces[Board.Black + Board.Knights - 1], toBase: 2).PadLeft(64, '0');
                                          
        string WBishops = Convert.ToString((long)pieces[Board.White + Board.Bishops - 1], toBase: 2).PadLeft(64, '0');
        string BBishops = Convert.ToString((long)pieces[Board.Black + Board.Bishops - 1], toBase: 2).PadLeft(64, '0');
                                                                                   
        string WRooks   = Convert.ToString((long)pieces[Board.White + Board.Rooks - 1],   toBase: 2).PadLeft(64, '0');
        string BRooks   = Convert.ToString((long)pieces[Board.Black + Board.Rooks - 1],   toBase: 2).PadLeft(64, '0');
                                          
        string WQueen   = Convert.ToString((long)pieces[Board.White + Board.Queen - 1],   toBase: 2).PadLeft(64, '0');
        string BQueen   = Convert.ToString((long)pieces[Board.Black + Board.Queen - 1],   toBase: 2).PadLeft(64, '0');
                                          
        string WKing    = Convert.ToString((long)pieces[Board.White + Board.King - 1],    toBase: 2).PadLeft(64, '0');
        string BKing    = Convert.ToString((long)pieces[Board.Black + Board.King - 1],    toBase: 2).PadLeft(64, '0');


        // Display the pieces depending on the bits
        for (int i = 0; i < 64; i++)
        {
            if (WPawns[i] == '1')
                Raylib.DrawTextureEx(textures[0], new(25 + (i % 8) * 100, 25 + (i / 8) * 100), 0f, 0.3f, Color.WHITE);
            else if (BPawns[i] == '1')
                Raylib.DrawTextureEx(textures[1], new(25 + (i % 8) * 100, 25 + (i / 8) * 100), 0f, 0.3f, Color.WHITE);

            else if (WKnight[i] == '1')
                Raylib.DrawTextureEx(textures[2], new(25 + (i % 8) * 100, 25 + (i / 8) * 100), 0f, 0.3f, Color.WHITE);
            else if (BKnight[i] == '1')
                Raylib.DrawTextureEx(textures[3], new(25 + (i % 8) * 100, 25 + (i / 8) * 100), 0f, 0.3f, Color.WHITE);

            else if (WBishops[i] == '1')
                Raylib.DrawTextureEx(textures[4], new(25 + (i % 8) * 100, 25 + (i / 8) * 100), 0f, 0.3f, Color.WHITE);
            else if (BBishops[i] == '1')
                Raylib.DrawTextureEx(textures[5], new(25 + (i % 8) * 100, 25 + (i / 8) * 100), 0f, 0.3f, Color.WHITE);

            else if (WRooks[i] == '1')
                Raylib.DrawTextureEx(textures[6], new(25 + (i % 8) * 100, 25 + (i / 8) * 100), 0f, 0.3f, Color.WHITE);
            else if (BRooks[i] == '1')
                Raylib.DrawTextureEx(textures[7], new(25 + (i % 8) * 100, 25 + (i / 8) * 100), 0f, 0.3f, Color.WHITE);

            else if (WQueen[i] == '1')
                Raylib.DrawTextureEx(textures[8], new(25 + (i % 8) * 100, 25 + (i / 8) * 100), 0f, 0.3f, Color.WHITE);
            else if (BQueen[i] == '1')
                Raylib.DrawTextureEx(textures[9], new(25 + (i % 8) * 100, 25 + (i / 8) * 100), 0f, 0.3f, Color.WHITE);

            else if (WKing[i] == '1')
                Raylib.DrawTextureEx(textures[10], new(25 + (i % 8) * 100, 25 + (i / 8) * 100), 0f, 0.3f, Color.WHITE);
            else if (BKing[i] == '1')
                Raylib.DrawTextureEx(textures[11], new(25 + (i % 8) * 100, 25 + (i / 8) * 100), 0f, 0.3f, Color.WHITE);
        }

    }
}
namespace Chess;

using Raylib_cs;

internal class Program
{
    // Colors.
    static Color Green = Raylib.ColorFromNormalized(new System.Numerics.Vector4(0.467f, 0.600f, 0.329f, 1f));
    static Color White = Raylib.ColorFromNormalized(new System.Numerics.Vector4(0.914f, 0.929f, 0.800f, 1f));
    static Color Black = Color.BLACK;

    static void Main()
    {
        Raylib.InitWindow(1080, 920, "Chess");

        // Main loop
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            DrawChessBoard();

            Raylib.EndDrawing();
        }

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
}
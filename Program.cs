namespace Chess;

using Raylib_cs;

internal class Program
{
    static void Main(string[] args)
    {
        Raylib.InitWindow(1080, 920, "Chess");

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
        Raylib.DrawRectangleLines(starting_pos_x - 2, starting_pos_y - 2, 8 * width + 4, 8 * width + 4, Color.BLACK);
        Raylib.DrawRectangleLines(starting_pos_x - 1, starting_pos_y - 1, 8 * width + 2, 8 * width + 2, Color.BLACK);

        // Drawing the board.
        Raylib.DrawRectangle(starting_pos_x, starting_pos_y, width * 8, width * 8, Color.BEIGE);
        for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
                if ((i + j) % 2 == 0)
                    Raylib.DrawRectangle(starting_pos_x + i * width, starting_pos_y + j * width, width, width, Color.LIME);
    }
}
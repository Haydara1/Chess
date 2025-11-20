using Raylib_cs;

namespace Chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = 720;
            int height = 720;

            Raylib.InitWindow(width, height, "Chess");

            // Game loop
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                bool color = false;

                // Draw chess board
                for (int i = 0; i < 8; i++)
                {
                    color = !color;
                    for (int j = 0; j < 8; j++)
                    {
                        Raylib.DrawRectangle(i * 40, j * 40, 40, 40, 
                            color ? Color.Black : Color.Red);
                        color = !color;
                    }
                }

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}

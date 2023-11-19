namespace Chess;

using Raylib_cs;

internal class Program
{
    static void Main(string[] args)
    {
        Raylib.InitWindow(800, 480, "Chess");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
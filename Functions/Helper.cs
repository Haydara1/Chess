namespace Chess.Functions;

internal class Helper
{
    static public void Print(UInt64 Position)
        => Console.WriteLine(Convert.ToString((long)Position, 2).PadLeft(64, '0'));

    static public void Print(string text, UInt64 Position)
        => Console.WriteLine(text + ": " + Convert.ToString((long)Position).PadLeft(64, '0'));
}

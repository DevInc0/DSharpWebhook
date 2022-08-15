using System.Globalization;

namespace DSharpWebhook.Discord.Colors
{
    public struct Color
    {
        public byte R;

        public byte G;

        public byte B;

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Color(int value)
        {
            var hex = value.ToString("X6");

            R = (byte)TryParseHexToDec(hex.Substring(0, 2));
            G = (byte)TryParseHexToDec(hex.Substring(2, 2));
            B = (byte)TryParseHexToDec(hex.Substring(4, 2));
        }

        public string Hex => $"{R:X2}{G:X2}{B:X2}";

        public int Value => TryParseHexToDec(Hex);

        private static int TryParseHexToDec(string hex) => int.TryParse(hex, NumberStyles.HexNumber, default, out var dec) ? dec : default;
    }
}

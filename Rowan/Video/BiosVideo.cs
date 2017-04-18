namespace Rowan.Video
{
    public static unsafe class BiosVideo
    {
        public const int Width = 80, Height = 25;
        private static int _row, _column;
        private static VgaColour _foreground, _background;

        public static void Init()
        {
            ClearScreen();
            SetColors(VgaColour.White, VgaColour.Black);
        }

        public static void ClearScreen()
        {
            for (int i = 0; i < Width*Height*2; i++)
                *(byte*) (0xb8000 + i) = 0;
            _row = 0;
            _column = 0;
        }

        public static void SetColors(VgaColour foreground, VgaColour background)
        {
            _foreground = foreground;
            _background = background;
        }

        //TODO: Replace
        public static void Print(int val)
        {
            int numCount = 1;
            int temp = val;
            while (temp > 9)
            {
                numCount++;
                temp = temp/10;
            }
            for (int i = 0; i < numCount; i++)
            {
                int d = (val/Pow(10, numCount - 1 - i))%10;
                Print((char) (48 + d));
            }
        }

        //TODO: Replace
        private static int Pow(int a, int b)
        {
            int val = 1;
            for (int i = 0; i < b; i++)
            {
                val *= a;
            }
            return val;
        }

        public static void Print(char c)
        {
            if (c == '\n')
            {
                _column = 0;
                _row++;
            }
            else
            {
                WriteAt(_column, _row, c, _foreground, _background);
                _column++;
            }

            if (_column >= Width)
            {
                _column = 0;
                _row++;
            }
            if (_row >= Height)
            {
                int diff = _row - Height + 1;
                Scroll(diff);
                _row = Height - 1;
            }
        }

        public static void Scroll(int by)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    int pos = y*Width + x;
                    if (y < Height - by)
                    {
                        int opos = (y + by)*Width + x;
                        *(byte*) (0xb8000 + pos*2) = *(byte*) (0xb8000 + opos*2);
                        *(byte*) (0xb8000 + pos*2 + 1) = *(byte*) (0xb8000 + opos*2 + 1);
                    }
                    else
                    {
                        *(byte*) (0xb8000 + pos*2) = 0;
                        *(byte*) (0xb8000 + pos*2 + 1) = 0;
                    }
                }
            }
        }

        public static void WriteAt(int pos, char c, VgaColour fore, VgaColour back)
        {
            *(byte*) (0xb8000 + pos*2) = (byte) c;
            *(byte*) (0xb8000 + pos*2 + 1) = (byte) ((int) fore | ((int) back << 4));
        }

        public static void WriteAt(int x, int y, char c, VgaColour fore, VgaColour back)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Width)
                return;
            int pos = _row*Width + _column;
            *(byte*) (0xb8000 + pos*2) = (byte) c;
            *(byte*) (0xb8000 + pos*2 + 1) = (byte) ((int) fore | ((int) back << 4));
        }
    }
}
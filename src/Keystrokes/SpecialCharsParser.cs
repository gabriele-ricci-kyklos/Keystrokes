namespace Keystrokes
{
    internal static class SpecialCharsParser
    {
        internal static bool TryParseKey(Keys key, out char? c)
        {
            bool parsed = true;
            c = null;

            switch (key)
            {
                case Keys.Space:
                    c = ' ';
                    break;
                case Keys.Tab:
                    c = '\t';
                    break;
                case Keys.Enter:
                    c = '\n';
                    break;
                case Keys.OemPeriod:
                    c = '.';
                    break;
                case Keys.Oemcomma:
                    c = ',';
                    break;
                case Keys.Oemtilde:
                    c = '@';
                    break;
                case Keys.OemMinus:
                    c = '_';
                    break;
                case Keys.D1:
                    c = '1';
                    break;
                case Keys.D2:
                    c = '2';
                    break;
                case Keys.D3:
                    c = '3';
                    break;
                case Keys.D4:
                    c = '4';
                    break;
                case Keys.D5:
                    c = '5';
                    break;
                case Keys.D6:
                    c = '6';
                    break;
                case Keys.D7:
                    c = '7';
                    break;
                case Keys.D8:
                    c = '8';
                    break;
                case Keys.D9:
                    c = '9';
                    break;
                case Keys.D0:
                    c = '0';
                    break;
                case Keys.LButton:
                case Keys.RButton:
                case Keys.MButton:
                case Keys.ShiftKey:
                case Keys.Shift:
                case Keys.RShiftKey:
                case Keys.LShiftKey:
                case Keys.Menu:
                case Keys.LMenu:
                case Keys.RMenu:
                case Keys.Control:
                case Keys.ControlKey:
                case Keys.LControlKey:
                case Keys.RControlKey:
                    break;
                default:
                    parsed = false;
                    break;
            }

            return parsed;
        }
    }
}

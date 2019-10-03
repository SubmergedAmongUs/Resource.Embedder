using System;
using System.Globalization;

namespace SingleFileConsole
{
    public static class Program
    {
        static void Main(string[] args)
        {
            // test localizations
            Assert("en", "Hello world!");

            // fallback to english
            Assert("pl", "Hello world!");

            Assert("fr", "Bonjour le monde!");

            Assert("de", "Hallo Welt!");
            // fallback to de
            Assert("de-AT", "Hallo Welt!");

            Assert("de-DE", "Hallo, Welt!");
        }

        private static void Assert(string culture, string expected)
        {
            SwitchCulture(culture);

            if (Translations.Text != expected)
            {
                Console.WriteLine($"Got '{Translations.Text}' but expected '{expected}'");
                Environment.Exit(-1);
            }
            Console.WriteLine($"Got (expected) '{Translations.Text}' for culture {culture}");
        }

        private static void SwitchCulture(string culture)
        {
            if (string.IsNullOrEmpty(culture))
            {
                CultureInfo.DefaultThreadCurrentCulture = null;
                CultureInfo.DefaultThreadCurrentUICulture = null;
                return;
            }
            CultureInfo ci;
            try
            {
                ci = new CultureInfo(culture);
            }
            catch (CultureNotFoundException)
            {
                ci = null;
            }
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;
        }
    }
}

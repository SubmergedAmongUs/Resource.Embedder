using LocalizeHelper;

namespace CoreLibraryWithTranslations
{
    public class LibraryTranslationHelper
    {
        public string GetLanguage(string culture, bool changeCulture)
        {
            if (changeCulture)
                Localize.SwitchLocale(culture);

            return Translation.Language;
        }
    }
}

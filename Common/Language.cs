using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Animation_Editor.Common {
    public static class Language {

        #region DLLImport INI

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString", CharSet = CharSet.Unicode)]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        private static string GetIniValue(string section, string key, string fileName) {
            int chars = 1000;
            StringBuilder buffer = new StringBuilder(chars);

            string sDefault = "";
            if (GetPrivateProfileString(section, key, sDefault, buffer, chars, fileName) != 0) {
                return buffer.ToString();
            }
            else {
                int err = Marshal.GetLastWin32Error();
                return null;
            }
        }

        private static bool WriteIniValue(string section, string key, string value, string fileName) {
            return WritePrivateProfileString(section, key, value, fileName);
        }

        #endregion

        /// <summary>
        /// Altera ou obtém o idioma atual.
        /// </summary>
        public static string CurrentLanguage { get; set; }

        public static string MessageTitle { get; set; }
        public static string MessageText { get; set; }
        public static string FrameText { get; set; }
        public static string FrameCount { get; set; }
        public static string WidthText { get; set; }
        public static string HeightText { get; set; }
        public static string ClipAreaText { get; set; }

        public static string MoveUpText { get; set; }
        public static string MoveDownText { get; set; }

        public static string MouseText { get; set; }

        const string ConfigSection = "LANGUAGE";
        const string ConfigFile = "Config.ini";
            
        public static string GetConfigString(string key) {
            return GetIniValue(ConfigSection, key, $"./{ConfigFile}");
        }

        public static void WriteConfig(string key, string value) {
            WriteIniValue(ConfigSection, key, value, $"./{ConfigFile}");
        }

        /// <summary>
        /// Obtém o texto de determinado idioma.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetLanguageText(string section, string key) {
            return GetIniValue(section, key, $"./Language/{CurrentLanguage}.ini");
        }

        /// <summary>
        /// Obtém a lista de idiomas.
        /// </summary>
        /// <returns></returns>
        public static string[] GetLanguages() {
            var languageCount = Convert.ToInt32(GetConfigString("MaxLanguage"));
            string[] languages = new string[languageCount + 1];

            for (var n = 0; n <= languageCount; n++) {
                languages[n] = GetConfigString($"Language_{n}");
            }

            return languages;
        }
    }
}
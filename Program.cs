using System;
using System.Windows.Forms;

namespace Animation_Editor {
    static class Program {
        /// <summary>
        /// Formulário principal.
        /// </summary>
        public static FormMain MainForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            
            MainForm = new FormMain();
            MainForm.InitializeEngine();

            Application.Idle += new EventHandler(MainForm.OnApplicationIdle);
            Application.Run(MainForm);
        }
    }
}

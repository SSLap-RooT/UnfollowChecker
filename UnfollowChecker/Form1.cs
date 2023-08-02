using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace UnfollowChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeChromium();
        }
        private void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load("https://www.instagram.com/accounts/login/");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string javascriptCode = ReadJavascriptCodeFromFile("code.txt");
            chromiumWebBrowser1.ExecuteScriptAsync(javascriptCode);

        }
        private string ReadJavascriptCodeFromFile(string fileName)
        {
            try
            {
                // "code.txt" dosyasının içeriğini okuyup dize olarak döndür
                string filePath = Path.Combine(Application.StartupPath, fileName);
                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                // Hata durumlarını ele almak için burada uygun işlemler yapın
                // Örneğin: Hata mesajını göstermek veya boş bir dize döndürmek gibi
                return string.Empty;
            }
        }
        private void chromiumWebBrowser1_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            
        }
    }
}

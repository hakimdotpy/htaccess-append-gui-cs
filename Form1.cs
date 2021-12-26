using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using CryptSharp;

namespace WindowsFormsApp3
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private static Random random = new Random();
        
        public static string RandomString(int laenge)
        {
            string Buchstaben = "abcdefghijklmnopqrstuvxyz";
            return new string(Enumerable.Repeat(Buchstaben, laenge)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            var Benutzername = guna2TextBox1.Text;
            var Pfad = guna2TextBox3.Text;
            var Passwort = RandomString(5);
            guna2TextBox2.Text = Passwort;
            string cryptedPassword = Crypter.MD5.Crypt(Passwort, new CrypterOptions()
             {
                { CrypterOption.Variant, MD5CrypterVariant.Apache }
             });
            var Output = Benutzername + ";" + cryptedPassword + Environment.NewLine;
            File.AppendAllText(Pfad, Output);
        }
        }
    }

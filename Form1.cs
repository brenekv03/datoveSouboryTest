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

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           listBox1.Items.Clear();
            StreamReader sr = new StreamReader("cisla.txt");
            FileStream fs = new FileStream("cisla.dat",FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs);
            while(!sr.EndOfStream) 
            {
                string cislo = sr.ReadLine();
                bw.Write(cislo);
            }
           // bw.Close();
            sr.Close();
            fs.Seek(0, SeekOrigin.Begin);
            BinaryReader br = new BinaryReader(fs);
            while(br.BaseStream.Position< br.BaseStream.Length) 
            {
                string cislo = br.ReadString();
                listBox1.Items.Add(cislo);
            }
            br.Close();
            fs.Close();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("cisla.dat", FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fs);
            int poziceCisla3 = 0;
            string cisloPred="";
            while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
            {
                string cislo = binaryReader.ReadString();
                if (cislo == "3")
                {
                    poziceCisla3 = int.Parse(binaryReader.BaseStream.Position.ToString());
                    fs.Seek(-4, SeekOrigin.Current);
                    cisloPred = binaryReader.ReadString();
                    fs.Seek(+4, SeekOrigin.Current);

                }
            }
            MessageBox.Show((poziceCisla3/2).ToString()+"\nČíslo před 3: "+cisloPred);
        }
    }
}

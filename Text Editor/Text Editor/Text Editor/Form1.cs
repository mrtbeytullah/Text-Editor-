using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Linkedin: mrtbeytullah
namespace Text_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("verdana", 15, FontStyle.Bold);
            comboBox1.Text="verdana";
            comboBox2.Text = "15";
            comboBox3.Text = "Bold";
           

            foreach (FontFamily family in FontFamily.Families)
            {
                comboBox1.Items.Add(family.Name);
            }

            for (int index = 6; index < 25; ++index)
                comboBox2.Items.Add(index);

            comboBox3.Items.Add(FontStyle.Regular);
            comboBox3.Items.Add(FontStyle.Underline);
            comboBox3.Items.Add(FontStyle.Italic);
            comboBox3.Items.Add(FontStyle.Bold);

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Dosya sec |*.rtf";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            richTextBox1.LoadFile(openFileDialog.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Dosya sec |*.rtf";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            richTextBox1.SaveFile(saveFileDialog.FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text.Length>0)
            {
                richTextBox1.Undo();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
                richTextBox1.Redo();
         
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(Convert.ToString(comboBox1.SelectedItem), richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, (float)Convert.ToInt32(comboBox2.SelectedItem), richTextBox1.SelectionFont.Style);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.Name, richTextBox1.SelectionFont.Size, (FontStyle)Enum.Parse(typeof(FontStyle), Convert.ToString(comboBox3.SelectedItem), true));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog renk = new ColorDialog();
            renk.ShowDialog();
            richTextBox1.SelectionColor = renk.Color;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ColorDialog arka_renk = new ColorDialog();
            arka_renk.ShowDialog();
            richTextBox1.BackColor = arka_renk.Color;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionCharOffset = -3;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionCharOffset = +3;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string aranacak_metin = textBox1.Text;
            int start = 0;
            int end = richTextBox1.Text.LastIndexOf(aranacak_metin);
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = Color.White;
            while (start < end)
            {
                richTextBox1.Find(aranacak_metin, start, richTextBox1.TextLength, RichTextBoxFinds.MatchCase);

                richTextBox1.SelectionBackColor = Color.Yellow;

                start = richTextBox1.Text.IndexOf(aranacak_metin, start) + 1;
            }
        }

     
    }
}

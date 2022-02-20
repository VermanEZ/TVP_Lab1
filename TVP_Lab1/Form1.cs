namespace TVP_Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            using (var file = File.Open("EnRuDict.dat", FileMode.OpenOrCreate))
                using (StreamReader sr = new StreamReader(file))
                    richTextBox1.Text = sr.ReadToEnd();
            using (var file = File.Open("RuEnDict.dat", FileMode.OpenOrCreate))
                using (StreamReader sr = new StreamReader(file))
                    richTextBox2.Text = sr.ReadToEnd();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program is used for adding new words to dictionary", "Dictionary Enlarger by Nikita Kudinov (3821Б1ПР1)");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text))
            {
                using (StreamWriter sw = new StreamWriter("EnRuDict.dat", append: true))
                    sw.WriteLine(textBox1.Text.Trim() + " " + textBox2.Text.Trim());

                using (StreamReader sr = new StreamReader("EnRuDict.dat"))
                    richTextBox1.Text = sr.ReadToEnd();
                
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox3.Text) && !String.IsNullOrWhiteSpace(textBox4.Text))
            {
                using (StreamWriter sw = new StreamWriter("RuEnDict.dat", append: true))
                    sw.WriteLine(textBox3.Text.Trim() + " " + textBox4.Text.Trim());
                
                using (StreamReader sr = new StreamReader("RuEnDict.dat"))
                    richTextBox2.Text = sr.ReadToEnd();
                
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }
    }
}
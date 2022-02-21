namespace TVP_Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Creating and reading files
            using (var file = File.Open("EnRuDict.dat", FileMode.OpenOrCreate))
                using (StreamReader sr = new StreamReader(file))
                    richTextBox1.Text = sr.ReadToEnd();
            using (var file = File.Open("RuEnDict.dat", FileMode.OpenOrCreate))
                using (StreamReader sr = new StreamReader(file))
                    richTextBox2.Text = sr.ReadToEnd();
            // Enable the buttons based on text length
            button3.Enabled = richTextBox1.Text.Length != 0;
            button4.Enabled = richTextBox2.Text.Length != 0;
        }
        // Menu Events
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program is used for adding new words to dictionary", "Dictionary Enlarger by Nikita Kudinov (3821Б1ПР1)");
        }
        // Adding Buttons Events 
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
        // Deleting Buttons Events
        private void button3_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines("EnRuDict.dat");
            var lines_without_last = lines.Take(lines.Length - 1).ToArray();
            richTextBox1.Text = String.Join("\n", lines_without_last);
            File.WriteAllLines("EnRuDict.dat", lines_without_last);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines("RuEnDict.dat");
            var lines_without_last = lines.Take(lines.Length - 1).ToArray();
            richTextBox2.Text = String.Join("\n", lines_without_last);
            File.WriteAllLines("RuEnDict.dat", lines_without_last);
        }
        // Textbox Events
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = !String.IsNullOrWhiteSpace(textBox3.Text) && !String.IsNullOrWhiteSpace(textBox4.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = !String.IsNullOrWhiteSpace(textBox3.Text) && !String.IsNullOrWhiteSpace(textBox4.Text);
        }
        // Dictionary Events
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = richTextBox1.Text.Length != 0;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            button4.Enabled = richTextBox2.Text.Length != 0;
        }

    }
}
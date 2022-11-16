using lab2proektirovaniePletnyakov.EntityFramework;
using lab2proektirovaniePletnyakov.EntityFramework.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2proektirovaniePletnyakov
{
    public partial class Form1 : Form
    {
        lab2proektirovaniePletnyakov.EntityFramework.ApplicationContext db;
        string filtr = null;
        public Form1()
        {
            InitializeComponent();
            db = new lab2proektirovaniePletnyakov.EntityFramework.ApplicationContext();
            dataGridView1.DataSource = db.Students.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student student = new Student() {Name=textBoxName.Text,PhoneNumber=textBoxPhoneNumber.Text,Address=textBoxAddress.Text,Surname=textBoxSurname.Text};
            db.Students.Add(student);
            db.SaveChanges();
            if (filtr==null) dataGridView1.DataSource = db.Students.ToList();
            else dataGridView1.DataSource = db.Students.Where(s => s.Name == filtr).ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            filtr = textBoxFiltr.Text;
            dataGridView1.DataSource = db.Students.Where(s=>s.Name==filtr).ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            filtr = null;
            dataGridView1.DataSource = db.Students.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Students.FromSqlRaw("GetStudentById {0}", textBox1.Text).ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Students.FromSqlRaw("GetStudentByName {0}", textBox2.Text).ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

        }
    }
}

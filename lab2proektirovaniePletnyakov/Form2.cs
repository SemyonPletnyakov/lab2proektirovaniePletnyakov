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
    public partial class Form2 : Form
    {
        lab2proektirovaniePletnyakov.EntityFramework.ApplicationContext db;
        public Form2()
        {
            InitializeComponent();
            db = new lab2proektirovaniePletnyakov.EntityFramework.ApplicationContext();
            dataGridView1.DataSource = db.Subjects.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Subject subject = new Subject() { Name = textBox1.Text };
            db.Subjects.Add(subject);
            db.SaveChanges();
            dataGridView1.DataSource = db.Subjects.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Subjects.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Subjects.FromSqlRaw("GetSubjectByName {0}", textBox2.Text).ToList();
        }
    }
}

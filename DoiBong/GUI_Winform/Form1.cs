using BLL;
using Entities;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI_Winform
{
    public partial class Form1 : Form
    {
        private BindingSource binding;
        private CauThuBLL dbcauthu;
        private DoiBongBLL dbdoibong;
        public Form1()
        {
            InitializeComponent();
            binding = new BindingSource();
            dbcauthu = new CauThuBLL();
            dbdoibong = new DoiBongBLL();
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            LoadDataCombo();

        }
        private void LoadDataCombo()
        {
            comboBox1.Items.Clear();
            comboBox1.DataSource = null;
            comboBox1.DataSource = dbdoibong.GetAllDoiBong();
            comboBox1.DisplayMember = "tendoibong";
            comboBox1.ValueMember = "madoibong";

        }
        private void LoadDataGridView(int id)
        {
            binding.DataSource = dbcauthu.GetAllCauThu().Where(x => x.iddoibong == id).ToList();
            dataGridView1.DataSource = binding;
            BindingToTextBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadDataGridView((int)(comboBox1.SelectedValue));
        }
        private void BindingToTextBox()
        {
            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", binding, "macauthu");
            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("Text", binding, "email");
            textBox3.DataBindings.Clear();
            textBox3.DataBindings.Add("Text", binding, "iddoibong");
            textBox4.DataBindings.Clear();
            textBox4.DataBindings.Add("Text", binding, "tencauthu");
            textBox5.DataBindings.Clear();
            textBox5.DataBindings.Add("Text", binding, "sodt");

        }
        private void AddCauThu(eCauThu e)
        {
            dbcauthu.AddCauThu(e);
        }
        private void UpdateCauThu(eCauThu e)
        {
            dbcauthu.UpdateCauThu(e);
        }
        private void DeleteCauThu(int id)
        {
            dbcauthu.DeleteCauThu(id);
        }
        private void FormatForm()
        {
            LoadDataGridView((int)comboBox1.SelectedValue);
            button3.Text = "Thêm";
            button4.Text = "Lưu";
            button5.Text = "Cập nhật";
            button6.Text = "Xóa";
        }
        private void ClearText()
        {
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox5.DataBindings.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        private eCauThu GetCauThuByText()
        {
            return new eCauThu { email = textBox2.Text.ToString(), sodt = textBox5.Text.ToString(), tencauthu = textBox4.Text.ToString(), iddoibong = Int32.Parse(textBox3.Text.ToString()) };
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ClearText();
            button4.Text = "Lưu Thêm";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(button4.Text=="Lưu Thêm")
            {
                AddCauThu(GetCauThuByText());
                FormatForm();
            }
            else if(button4.Text=="Lưu Cập Nhật")
            {
                UpdateCauThu(GetCauThuByText());
                FormatForm();
            }
            else
            {
                FormatForm();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.Text = "Lưu Cập Nhật";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text.ToString().Equals(""))
                return;
            DeleteCauThu(Int32.Parse(textBox1.Text.ToString()));
            FormatForm();
        }
    }
}

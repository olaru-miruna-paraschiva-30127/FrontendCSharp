using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        EmployeeService employeeService;
        List<Employee> employeeList;
        public Form1()
        {
            InitializeComponent();
            employeeService = new EmployeeService();
            employeeService.createConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var employeeList = employeeService.GetEmployees(textBox1.Text);

            comboBox1.DataSource = employeeList;
            comboBox1.DisplayMember = "name";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var employeeList = employeeService.GetManagers(textBox1.Text);

            comboBox2.DataSource = employeeList;
            comboBox2.DisplayMember = "name";

        }
    }
}

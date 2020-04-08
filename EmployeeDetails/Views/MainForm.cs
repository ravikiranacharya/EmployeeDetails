using EmployeeDetails.Controllers;
using EmployeeDetails.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeDetails.Views
{
    public partial class MainForm : Form
    {
        private EmployeeRepository employeeRepository;
        private List<Employee> employees;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Initialize();
            PopulateData();
        }

        /* Initializing the repository */
        private void Initialize()
        {
            employeeRepository = new EmployeeRepository();
            FetchData();
        }

        /* This should run on a separate thread if the data grows big */
        private void FetchData()
        {
            employees = employeeRepository.GetData();
        }

        /* Handling the filter popup dialog */
        private void Button1_Click(object sender, EventArgs e)
        {
            Filter filter = new Filter();
            var dialogResult = filter.ShowDialog();
            if (dialogResult == DialogResult.Cancel) { return; }

            if (String.IsNullOrEmpty(filter.value))
            {
                MessageBox.Show("Value is required to filter data", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FilterData(filter.property, filter.value);
        }

        /* Populating data */
        private void PopulateData()
        {
            var bindingList = new BindingList<Employee>(this.employees);
            var bindingSource = new BindingSource(bindingList, null);

            /* This is because if we are on a separate thread for fetching data,
             * we will not be able to access the UI thread */
            BeginInvoke(new MethodInvoker(delegate
            {
                employeeDataGridView.DataSource = bindingSource;
            }));
        }

        /* Method to filter data
         * Beauty is that we can add more properties and filter logic without 
         * changing anything in this class
         **/ 
        private void FilterData(int property, String value)
        {
            try
            {
                this.employees = employeeRepository.GetFilteredData(property, value);
                PopulateData();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

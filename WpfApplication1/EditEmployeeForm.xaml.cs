//Project:  Assignment 2
//Author: Andrew Hewitson
//Date: Jan 29, 2019
//
//Edit Employee Form. Allows editing of employee table in SQL database.

using DataAccess;
using System.Linq;
using System.Windows;

namespace WpfAppClient
{

    /// <summary>
    /// Interaction logic for EditEmployeeForm.xaml
    /// </summary>
    public partial class EditEmployeeForm : Window
    {

        private int EmployeeID;

        public EditEmployeeForm()
        {
            InitializeComponent();
        }

        //starts UI and populates it with current EmployeeID.  Default is 0 for none.  
        public void Run()
        {
            InitializeComponent();
            var _context = new AdventureWorksLTContext();
            var query = from c in _context.Employee where c.EmployeeID == EmployeeID select c;
            this.DataContext = query.FirstOrDefault();
        }

        //starts UI and populates it with a selected EmployeeID. 
        public void GetEmployeeByID(int id)
        {
            EmployeeID = id;
            InitializeComponent();
            var _context = new AdventureWorksLTContext();
            var query = from c in _context.Employee where c.EmployeeID == id select c;
            this.DataContext = query.FirstOrDefault();
            Show();
        }

        //saves changes and closes UI screen.
        private void SaveClose_Button_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeID == 0)
            {
                NewEmployee();
            }
            else
            {
                UpdateEmployeeById(EmployeeID);              
            }
            Close();
        }

        //saves changes but UI remains active.
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeID == 0)
            {
                NewEmployee();
            }
            else
            {
                UpdateEmployeeById(EmployeeID);
            }
        }

        //deletes selected employee from database.
        private void Delete_Button1_Click(object sender, RoutedEventArgs e)
        {
            DeleteEmployee(EmployeeID);
        }

        //reloads page with original information from the last save.
        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            Run();
        }

        //creates new employee and saves it to databse from input from user.
        private void NewEmployee()
        {
            using (var _context = new AdventureWorksLTContext())
            {
                Employee employee = new Employee();
                employee.FirstName = FirstNameTextBox.Text;
                employee.LastName = LastNameTextBox.Text;
                employee.Prefix = PrefixComboBox.Text;
                employee.HomePhone = HomePhoneTextBox.Text;
                employee.MobilePhone = MobilePhoneTextBox.Text;
                employee.Skype = SkypeTextBox.Text;
                employee.PhotoPath = ImageTextBox.Text;
                employee.Address = AddressTextBox.Text;
                _context.Employee.Add(employee);
                _context.SaveChanges();
            }
        }

        //updates employee information in database on selected employee
        private void UpdateEmployeeById(int id)
        {
            using (var _context = new AdventureWorksLTContext())
            {
                Employee employee = _context.Employee.FirstOrDefault(c => c.EmployeeID == id);
                employee.FirstName = FirstNameTextBox.Text;
                employee.LastName = LastNameTextBox.Text;
                employee.Prefix = PrefixComboBox.Text;
                employee.HomePhone = HomePhoneTextBox.Text;
                employee.MobilePhone = MobilePhoneTextBox.Text;
                employee.Skype = SkypeTextBox.Text;
                employee.PhotoPath = ImageTextBox.Text;
                employee.Address = AddressTextBox.Text;
           
                _context.SaveChanges();
            }
        }

        //deletes selected employee from database
        private void DeleteEmployee(int id)
        {
            try
            {
                using (var _context = new AdventureWorksLTContext())
                {
                    var employee = _context.Employee.Where(s => s.EmployeeID == id).First();
                    _context.Employee.Remove(employee);
                    _context.SaveChanges();
                    Run();
                }
            }
            catch
            {
                MessageBox.Show("Please try again.");
            }
        }
    }
}

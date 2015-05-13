using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalInformationAPP
{
    public partial class PersonalInfoUI : Form
    {
        public PersonalInfoUI()
        {
            InitializeComponent();
        }

        string connectionString = @"SERVER = PC-301-26\SQLEXPRESS ;DATABASE= PersonalInfoDB; Integrated Security = true";
        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string age = ageTextBox.Text;
            string sex = sexTextBox.Text;
            string address = addressTextBox.Text;
            string email = emailTextBox.Text;
            string mobile = mobileTextBox.Text;

            isNameExis

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO PersonalInformationTable VALUES('"+name+"', '"+age+"','"+sex+"','"+mobile+"','"+email+"','"+address+"')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();

            int roweffect = command.ExecuteNonQuery();
            connection.Close();

        }

        List<Student> studentList = new List<Student>(); 
        private void PersonalInfoUI_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM PersonalInformationTable";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            

            while (reader.Read())
            {
                Student students = new Student();

                students.Id = int.Parse(reader["ID"].ToString());
                students.name = reader["name"].ToString();
                students.age = reader["age"].ToString();
                students.sex = reader["sex"].ToString();
                students.mobile = reader["mobile"].ToString();
                students.email = reader["email"].ToString();
                students.address = reader["address"].ToString();

                studentList.Add(students);
            }

            foreach (var student in studentList)
            {
                ListViewItem item = new ListViewItem(student.Id.ToString());
                item.SubItems.Add(student.name);
                item.SubItems.Add(student.age);
                item.SubItems.Add(student.sex);
                item.SubItems.Add(student.mobile);
                item.SubItems.Add(student.email);
                item.SubItems.Add(student.address);

                studentListView.Items.Add(item);
            }


        }


    }
}

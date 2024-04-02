using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnShowData2_Click(object sender, RoutedEventArgs e)
        {
            this.dgv1.ItemsSource = null;
           var conn1 = new SqlConnection("Server=DESKTOP-83DF732\\SQL2K19ENT;Database=test_db;User Id=sa;Password=1234;");
            var sqlcmd1 = new SqlCommand();
            sqlcmd1.Connection = conn1;
            sqlcmd1.CommandType = CommandType.Text;
            sqlcmd1.CommandText = "select * from studentInfo;";
            var sqladp1 = new SqlDataAdapter(sqlcmd1);
            var ds1 = new DataSet();
            sqladp1.Fill(ds1);
            this.dgv1.ItemsSource = ds1.Tables[0].DefaultView;
        }

        private void btnShowData_Click(object sender, RoutedEventArgs e)
        {
            this.dgv1.ItemsSource = null;
            var conn1 = new SqlConnection("Server=DESKTOP-83DF732\\SQL2K19ENT;Database=test_db;User Id=sa;Password=1234;");
            var sqlcmd1 = new SqlCommand();
            sqlcmd1.Connection = conn1;
            sqlcmd1.CommandType = CommandType.StoredProcedure;
            //sqlcmd1.CommandText = "[dbo].[basic] @PROCID1='select_rec'";
            sqlcmd1.CommandText = "[dbo].[basic]";
            var parm1 = new SqlParameter("@PROCID1", "select_rec");
            sqlcmd1.Parameters.Add(parm1);

            var sqladp1 = new SqlDataAdapter(sqlcmd1);
            var ds1 = new DataSet();
            sqladp1.Fill(ds1);
            this.dgv1.ItemsSource = ds1.Tables[0].DefaultView;
        }


        private void Submit_Insert_Click(object sender, RoutedEventArgs e)
        {
            string id = txtDataInsertID.Text;
            string name = txtDataInsertName.Text;
            string email = txtDataInsertEmail.Text;
            DateTime dob = dpDateInsert.SelectedDate ?? DateTime.MinValue;

            var conn1 = new SqlConnection("Server=DESKTOP-83DF732\\SQL2K19ENT;Database=test_db;User Id=sa;Password=1234;");
            var sqlcmd1 = new SqlCommand();
            sqlcmd1.Connection = conn1;
            sqlcmd1.CommandType = CommandType.StoredProcedure;
            //sqlcmd1.CommandText = "[dbo].[basic] @PROCID1='select_rec'";
            sqlcmd1.CommandText = "[dbo].[basic]";

            var parm1 = new SqlParameter("@PROCID1", "insert_record");
            var parmv1 = new SqlParameter("@var1", id);
            var parmv2 = new SqlParameter("@var2", name);
            var parmv3 = new SqlParameter("@var3", email);
            var parmv4 = new SqlParameter("@var4", dob);

            sqlcmd1.Parameters.Add(parm1);
            sqlcmd1.Parameters.Add(parmv1);
            sqlcmd1.Parameters.Add(parmv2);
            sqlcmd1.Parameters.Add(parmv3);
            sqlcmd1.Parameters.Add(parmv4);
            
            conn1.Open();
            sqlcmd1.ExecuteNonQuery();
            conn1.Close();


            txtOutput.Text = $" Data Input Successful for \n {id} - {name} - {email} -{dob}";
            txtOutput.Visibility = Visibility.Visible;

        }

        private void Submit_Update_Click(object sender, RoutedEventArgs e)
        {
            string id = txtDataUpdateID.Text;
            string name = txtDataUpdateName.Text;
            string email = txtDataUpdateEmail.Text;
            DateTime dob = dpDateUpdate.SelectedDate ?? DateTime.MinValue;

            var conn1 = new SqlConnection("Server=DESKTOP-83DF732\\SQL2K19ENT;Database=test_db;User Id=sa;Password=1234;");
            var sqlcmd1 = new SqlCommand();
            sqlcmd1.Connection = conn1;
            sqlcmd1.CommandType = CommandType.StoredProcedure;
            //sqlcmd1.CommandText = "[dbo].[basic] @PROCID1='select_rec'";
            sqlcmd1.CommandText = "[dbo].[basic]";

            var parm1 = new SqlParameter("@PROCID1", "update_rec");
            var parmv1 = new SqlParameter("@var1", id);
            var parmv2 = new SqlParameter("@var2", name);
            var parmv3 = new SqlParameter("@var3", email);
            var parmv4 = new SqlParameter("@var4", dob);

            sqlcmd1.Parameters.Add(parm1);
            sqlcmd1.Parameters.Add(parmv1);
            sqlcmd1.Parameters.Add(parmv2);
            sqlcmd1.Parameters.Add(parmv3);
            sqlcmd1.Parameters.Add(parmv4);

            conn1.Open();
            sqlcmd1.ExecuteNonQuery();
            conn1.Close();


            txtOutput.Text = $" Data Update Successful for \n {id} - {name} - {email} -{dob}";
            txtOutput.Visibility = Visibility.Visible;

        }

        private void Submit_Delete_Click(object sender, RoutedEventArgs e)
        {

            string id = txtDataDeleteID.Text;

            var conn1 = new SqlConnection("Server=DESKTOP-83DF732\\SQL2K19ENT;Database=test_db;User Id=sa;Password=1234;");
            var sqlcmd1 = new SqlCommand();
            sqlcmd1.Connection = conn1;
            sqlcmd1.CommandType = CommandType.StoredProcedure;
            //sqlcmd1.CommandText = "[dbo].[basic] @PROCID1='select_rec'";
            sqlcmd1.CommandText = "[dbo].[basic]";
            var parm1 = new SqlParameter("@PROCID1", "delete_rec");
            var parmv1 = new SqlParameter("@var1", id);

            sqlcmd1.Parameters.Add(parm1);
            sqlcmd1.Parameters.Add(parmv1);
            conn1.Open();
            sqlcmd1.ExecuteNonQuery();
            conn1.Close();

            txtOutput.Text = $" Data delete Successful for id: \n {id}";
            txtOutput.Visibility = Visibility.Visible;

        }

    }
}
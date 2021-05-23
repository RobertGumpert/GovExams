using pt.Source.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pt
{
    public partial class Loader : Form
    {
        private UserDao userDAO;


        public Loader()
        {
            InitializeComponent();
        
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\VKR\\GovExams\\ProgrammingTech\\pt\\pt\\Data";
                openFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    userDAO = new UserDao(filePath);

                    var res = userDAO.GetEmailContainsSymbol();
                    
                }
            }
        }
    }
}

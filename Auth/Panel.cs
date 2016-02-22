using System;
using System.Collections.Generic;


using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Common.Network;
using Common.Utility;
using Common.Packet;
using Common.Database;
using Common.Model;

namespace Auth
{
    public partial class Panel : Form
    {
        public Panel()
        {
            InitializeComponent();
            
        }

      
      
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlDatabaseConnection.Initialize("127.0.0.1", "3306", "MuOnline", "root", "");
            Account player = DatabaseOperations.GetObject<Account>(1);

            DatabaseOperations.SaveObject(player);
        }
    }
}

using System;
using System.Collections.Generic;

using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using Common.Network;
using Common.Utility;
namespace Database
{
    public partial class Panel : Form
    {
        public Panel()
        {
            InitializeComponent();
            ff.Listen("databasesend");
          
            ff.MessageRecived += (e) => StringByte( e.data,e.pipeName);
        }
        public void StringByte(byte[] hh,string g)
        {
            try { 
            byte[] gg = Miscellaneous.TrimNullByteInDataArray(hh);
            string bb = TypeConverter.ByteArrayToString(gg);
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate { richTextBox1.AppendText(bb); }));
                return;
            }
           
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        NetworkPipeServer ff = new NetworkPipeServer();
        NetworkPipeClient gg = new NetworkPipeClient();
        private void button1_Click(object sender, EventArgs e)
        {
            string hh ="hujciw cyce";
            richTextBox1.AppendText(hh);
        }
    }
}

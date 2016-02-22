using System;
using System.Collections.Generic;

using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;


using Common.Packet;
using Common.Utility;
using Common.Database;
using Common.Model;
namespace Game
{
    public partial class Panel : Form
    {

       private GameCore gameCore;
       private Logger logger;
        public Panel()
        {
            InitializeComponent();
            this.Text = Define.GetTitle();
           
            Logger.LoggerSend += ( e) => AppendTextRichTextBox(e.log, e.color);
            gameCore = new GameCore();
           
        }
        public void AppendTextRichTextBox(string text, Color color)
        {
              if( text.Equals(string.Empty))
              {
                  return;
              }
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>richTextBox1.SelectionStart = richTextBox1.TextLength));
                this.Invoke(new Action(() => richTextBox1.SelectionLength = 0));
                this.Invoke(new Action(() => richTextBox1.SelectionColor = color));
                this.Invoke(new Action(() => richTextBox1.AppendText(text+"\r\n")));
                this.Invoke(new Action(() => richTextBox1.SelectionColor = richTextBox1.ForeColor));
            }
            else 
            {
                //richTextBox1.SelectionStart = richTextBox1.TextLength;
                richTextBox1.SelectionLength = 0;
                richTextBox1.SelectionColor = color;
                richTextBox1.AppendText(text + "\r\n");
                richTextBox1.SelectionColor = richTextBox1.ForeColor;
            }

        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameCore.StartGame();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameCore.StopGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseOperations.CreateNewPlayer("fff", 32, 2);
        }
       
      
    }
    
}

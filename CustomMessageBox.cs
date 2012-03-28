using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snippet
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        public string Title { get; set; }
        public string Message { get; set; }

        private void CustomMessageBox_Load(object sender, EventArgs e)
        {
            txtMessage.Text = Message;
            
            // Disable selection
            txtMessage.SelectionStart = 0;
            txtMessage.SelectionLength = 0;  

            this.Text = Title;
        }
    }
}

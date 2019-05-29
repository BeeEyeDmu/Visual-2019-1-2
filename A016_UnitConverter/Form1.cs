using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A016_UnitConverter
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void btnConvert_Click(object sender, EventArgs e)
    {
      if(txtCm.Text != "")
      {
        txtInch.Text 
          = (double.Parse(txtCm.Text) * 0.3937).ToString();
        txtYard.Text
          = (double.Parse(txtCm.Text) * 0.0109).ToString();
        txtFeet.Text
          = (double.Parse(txtCm.Text) * 0.0328).ToString();
      }
      // ...
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      txtCm.Text = "";
      txtFeet.Text = "";
      txtInch.Text = "";
      txtYard.Text = "";
    }
  }
}

namespace A016_UnitConverter
{
  partial class Form1
  {
    /// <summary>
    /// 필수 디자이너 변수입니다.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 사용 중인 모든 리소스를 정리합니다.
    /// </summary>
    /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form 디자이너에서 생성한 코드

    /// <summary>
    /// 디자이너 지원에 필요한 메서드입니다. 
    /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.txtInch = new System.Windows.Forms.TextBox();
      this.txtCm = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtYard = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtFeet = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.btnClear = new System.Windows.Forms.Button();
      this.btnConvert = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(43, 28);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(29, 12);
      this.label1.TabIndex = 0;
      this.label1.Text = "인치";
      // 
      // txtInch
      // 
      this.txtInch.Location = new System.Drawing.Point(122, 25);
      this.txtInch.Name = "txtInch";
      this.txtInch.Size = new System.Drawing.Size(100, 21);
      this.txtInch.TabIndex = 1;
      // 
      // txtCm
      // 
      this.txtCm.Location = new System.Drawing.Point(122, 61);
      this.txtCm.Name = "txtCm";
      this.txtCm.Size = new System.Drawing.Size(100, 21);
      this.txtCm.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(43, 64);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(53, 12);
      this.label2.TabIndex = 2;
      this.label2.Text = "센티미터";
      // 
      // txtYard
      // 
      this.txtYard.Location = new System.Drawing.Point(122, 97);
      this.txtYard.Name = "txtYard";
      this.txtYard.Size = new System.Drawing.Size(100, 21);
      this.txtYard.TabIndex = 5;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(43, 100);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(29, 12);
      this.label3.TabIndex = 4;
      this.label3.Text = "야드";
      // 
      // txtFeet
      // 
      this.txtFeet.Location = new System.Drawing.Point(122, 133);
      this.txtFeet.Name = "txtFeet";
      this.txtFeet.Size = new System.Drawing.Size(100, 21);
      this.txtFeet.TabIndex = 7;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(43, 136);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(29, 12);
      this.label4.TabIndex = 6;
      this.label4.Text = "피트";
      // 
      // btnClear
      // 
      this.btnClear.Location = new System.Drawing.Point(45, 178);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(75, 23);
      this.btnClear.TabIndex = 8;
      this.btnClear.Text = "Clear";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // btnConvert
      // 
      this.btnConvert.Location = new System.Drawing.Point(147, 178);
      this.btnConvert.Name = "btnConvert";
      this.btnConvert.Size = new System.Drawing.Size(75, 23);
      this.btnConvert.TabIndex = 9;
      this.btnConvert.Text = "변환";
      this.btnConvert.UseVisualStyleBackColor = true;
      this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(245, 227);
      this.Controls.Add(this.btnConvert);
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.txtFeet);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtYard);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtCm);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtInch);
      this.Controls.Add(this.label1);
      this.Name = "Form1";
      this.Text = "단위변환기";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtInch;
    private System.Windows.Forms.TextBox txtCm;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtYard;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtFeet;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.Button btnConvert;
  }
}


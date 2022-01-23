namespace parseXML_DayZ
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnPARSE = new System.Windows.Forms.Button();
            this.txtOUTPUT = new System.Windows.Forms.TextBox();
            this.btnCLEAR = new System.Windows.Forms.Button();
            this.cbALLUNIQUEENTRIES = new System.Windows.Forms.ComboBox();
            this.btnVIEWINFO = new System.Windows.Forms.Button();
            this.btnGENSPECIFIC = new System.Windows.Forms.Button();
            this.btnALLTHETHINGS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbALLUNIQUEMAPENTRIES = new System.Windows.Forms.ComboBox();
            this.btnVIEWCITYINFO = new System.Windows.Forms.Button();
            this.txtRADIUS = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnPARSE
            // 
            resources.ApplyResources(this.btnPARSE, "btnPARSE");
            this.btnPARSE.Name = "btnPARSE";
            this.btnPARSE.UseVisualStyleBackColor = true;
            this.btnPARSE.Click += new System.EventHandler(this.btnPARSE_Click);
            // 
            // txtOUTPUT
            // 
            resources.ApplyResources(this.txtOUTPUT, "txtOUTPUT");
            this.txtOUTPUT.Name = "txtOUTPUT";
            this.txtOUTPUT.ReadOnly = true;
            // 
            // btnCLEAR
            // 
            resources.ApplyResources(this.btnCLEAR, "btnCLEAR");
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.UseVisualStyleBackColor = true;
            this.btnCLEAR.Click += new System.EventHandler(this.btnCLEAR_Click);
            // 
            // cbALLUNIQUEENTRIES
            // 
            this.cbALLUNIQUEENTRIES.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbALLUNIQUEENTRIES.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbALLUNIQUEENTRIES.FormattingEnabled = true;
            resources.ApplyResources(this.cbALLUNIQUEENTRIES, "cbALLUNIQUEENTRIES");
            this.cbALLUNIQUEENTRIES.Name = "cbALLUNIQUEENTRIES";
            // 
            // btnVIEWINFO
            // 
            resources.ApplyResources(this.btnVIEWINFO, "btnVIEWINFO");
            this.btnVIEWINFO.Name = "btnVIEWINFO";
            this.btnVIEWINFO.UseVisualStyleBackColor = true;
            this.btnVIEWINFO.Click += new System.EventHandler(this.btnVIEWINFO_Click);
            // 
            // btnGENSPECIFIC
            // 
            resources.ApplyResources(this.btnGENSPECIFIC, "btnGENSPECIFIC");
            this.btnGENSPECIFIC.Name = "btnGENSPECIFIC";
            this.btnGENSPECIFIC.UseVisualStyleBackColor = true;
            this.btnGENSPECIFIC.Click += new System.EventHandler(this.btnGENSPECIFIC_Click);
            // 
            // btnALLTHETHINGS
            // 
            resources.ApplyResources(this.btnALLTHETHINGS, "btnALLTHETHINGS");
            this.btnALLTHETHINGS.Name = "btnALLTHETHINGS";
            this.btnALLTHETHINGS.UseVisualStyleBackColor = true;
            this.btnALLTHETHINGS.Click += new System.EventHandler(this.btnALLTHETHINGS_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbALLUNIQUEMAPENTRIES
            // 
            this.cbALLUNIQUEMAPENTRIES.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbALLUNIQUEMAPENTRIES.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbALLUNIQUEMAPENTRIES.FormattingEnabled = true;
            resources.ApplyResources(this.cbALLUNIQUEMAPENTRIES, "cbALLUNIQUEMAPENTRIES");
            this.cbALLUNIQUEMAPENTRIES.Name = "cbALLUNIQUEMAPENTRIES";
            // 
            // btnVIEWCITYINFO
            // 
            resources.ApplyResources(this.btnVIEWCITYINFO, "btnVIEWCITYINFO");
            this.btnVIEWCITYINFO.Name = "btnVIEWCITYINFO";
            this.btnVIEWCITYINFO.UseVisualStyleBackColor = true;
            this.btnVIEWCITYINFO.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnVIEWCITYINFO_MouseClick);
            // 
            // txtRADIUS
            // 
            resources.ApplyResources(this.txtRADIUS, "txtRADIUS");
            this.txtRADIUS.Name = "txtRADIUS";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtRADIUS);
            this.Controls.Add(this.btnVIEWCITYINFO);
            this.Controls.Add(this.cbALLUNIQUEMAPENTRIES);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnALLTHETHINGS);
            this.Controls.Add(this.btnGENSPECIFIC);
            this.Controls.Add(this.btnVIEWINFO);
            this.Controls.Add(this.cbALLUNIQUEENTRIES);
            this.Controls.Add(this.btnCLEAR);
            this.Controls.Add(this.txtOUTPUT);
            this.Controls.Add(this.btnPARSE);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnPARSE;
        private TextBox txtOUTPUT;
        private Button button1;
        private Button btnCLEAR;
        private ComboBox cbALLUNIQUEENTRIES;
        private Button btnVIEWINFO;
        private Button btnGENSPECIFIC;
        private Button btnALLTHETHINGS;
        private Label label1;
        private ComboBox cbALLUNIQUEMAPENTRIES;
        private Button btnVIEWCITYINFO;
        private TextBox txtRADIUS;
    }
}
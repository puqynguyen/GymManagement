namespace GUI
{
    partial class FormCusClass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvListClass = new System.Windows.Forms.DataGridView();
            this.LABEL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListClass)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(59, 85);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(16, 16);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Name:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(59, 69);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 16);
            this.lblId.TabIndex = 9;
            this.lblId.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(735, 63);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 46);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvListClass
            // 
            this.dgvListClass.AllowUserToAddRows = false;
            this.dgvListClass.AllowUserToDeleteRows = false;
            this.dgvListClass.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListClass.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListClass.Location = new System.Drawing.Point(0, 120);
            this.dgvListClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListClass.Name = "dgvListClass";
            this.dgvListClass.ReadOnly = true;
            this.dgvListClass.RowHeadersVisible = false;
            this.dgvListClass.RowHeadersWidth = 51;
            this.dgvListClass.RowTemplate.Height = 24;
            this.dgvListClass.Size = new System.Drawing.Size(844, 278);
            this.dgvListClass.TabIndex = 5;
            this.dgvListClass.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListClass_CellContentClick);
            // 
            // LABEL
            // 
            this.LABEL.AutoSize = true;
            this.LABEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL.Location = new System.Drawing.Point(12, 5);
            this.LABEL.Name = "LABEL";
            this.LABEL.Size = new System.Drawing.Size(407, 32);
            this.LABEL.TabIndex = 4;
            this.LABEL.Text = "ADD CUSTOMER TO CLASS";
            // 
            // FormCusClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 398);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvListClass);
            this.Controls.Add(this.LABEL);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormCusClass";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormCusClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListClass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvListClass;
        private System.Windows.Forms.Label LABEL;
    }
}
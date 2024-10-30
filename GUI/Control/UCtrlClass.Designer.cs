namespace GUI.Control
{
    partial class UCtrlClass
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRemoveCustomer = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactInfor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveInstructor = new System.Windows.Forms.Button();
            this.dgvInstructor = new System.Windows.Forms.DataGridView();
            this.InstructorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstructorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Certifications = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstructorGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddInstructor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckFull = new System.Windows.Forms.CheckBox();
            this.dgvClass = new System.Windows.Forms.DataGridView();
            this.ClassId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enrollment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblInstructorId = new System.Windows.Forms.Label();
            this.lblInstructorName = new System.Windows.Forms.Label();
            this.lblCertifications = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstructor)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClass)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 310);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1072, 346);
            this.panel3.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblContact);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustomerName);
            this.splitContainer1.Panel1.Controls.Add(this.lblCustomerId);
            this.splitContainer1.Panel1.Controls.Add(this.btnRemoveCustomer);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddCustomer);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dgvCustomer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblCertifications);
            this.splitContainer1.Panel2.Controls.Add(this.btnRemoveInstructor);
            this.splitContainer1.Panel2.Controls.Add(this.lblInstructorName);
            this.splitContainer1.Panel2.Controls.Add(this.lblInstructorId);
            this.splitContainer1.Panel2.Controls.Add(this.dgvInstructor);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddInstructor);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.splitContainer1.Size = new System.Drawing.Size(1072, 346);
            this.splitContainer1.SplitterDistance = 525;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnRemoveCustomer
            // 
            this.btnRemoveCustomer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRemoveCustomer.Location = new System.Drawing.Point(403, 50);
            this.btnRemoveCustomer.Name = "btnRemoveCustomer";
            this.btnRemoveCustomer.Size = new System.Drawing.Size(105, 27);
            this.btnRemoveCustomer.TabIndex = 5;
            this.btnRemoveCustomer.Text = "Remove";
            this.btnRemoveCustomer.UseVisualStyleBackColor = true;
            this.btnRemoveCustomer.Click += new System.EventHandler(this.btnRemoveCustomer_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Enabled = false;
            this.btnAddCustomer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddCustomer.Location = new System.Drawing.Point(403, 17);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(105, 27);
            this.btnAddCustomer.TabIndex = 4;
            this.btnAddCustomer.Text = "Add";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(15, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Contact";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID";
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToAddRows = false;
            this.dgvCustomer.AllowUserToDeleteRows = false;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerId,
            this.CustomerName,
            this.ContactInfor,
            this.CustomerAge,
            this.CustomerGender});
            this.dgvCustomer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCustomer.Location = new System.Drawing.Point(0, 96);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.ReadOnly = true;
            this.dgvCustomer.RowHeadersVisible = false;
            this.dgvCustomer.RowHeadersWidth = 51;
            this.dgvCustomer.RowTemplate.Height = 24;
            this.dgvCustomer.Size = new System.Drawing.Size(525, 250);
            this.dgvCustomer.TabIndex = 0;
            this.dgvCustomer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellContentClick);
            // 
            // CustomerId
            // 
            this.CustomerId.HeaderText = "ID";
            this.CustomerId.MinimumWidth = 6;
            this.CustomerId.Name = "CustomerId";
            this.CustomerId.ReadOnly = true;
            this.CustomerId.Width = 50;
            // 
            // CustomerName
            // 
            this.CustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CustomerName.HeaderText = "Name";
            this.CustomerName.MinimumWidth = 6;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // ContactInfor
            // 
            this.ContactInfor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ContactInfor.HeaderText = "Contact Information";
            this.ContactInfor.MinimumWidth = 6;
            this.ContactInfor.Name = "ContactInfor";
            this.ContactInfor.ReadOnly = true;
            // 
            // CustomerAge
            // 
            this.CustomerAge.HeaderText = "Age";
            this.CustomerAge.MinimumWidth = 6;
            this.CustomerAge.Name = "CustomerAge";
            this.CustomerAge.ReadOnly = true;
            this.CustomerAge.Width = 50;
            // 
            // CustomerGender
            // 
            this.CustomerGender.HeaderText = "Gender";
            this.CustomerGender.MinimumWidth = 6;
            this.CustomerGender.Name = "CustomerGender";
            this.CustomerGender.ReadOnly = true;
            this.CustomerGender.Width = 75;
            // 
            // btnRemoveInstructor
            // 
            this.btnRemoveInstructor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRemoveInstructor.Location = new System.Drawing.Point(411, 50);
            this.btnRemoveInstructor.Name = "btnRemoveInstructor";
            this.btnRemoveInstructor.Size = new System.Drawing.Size(105, 27);
            this.btnRemoveInstructor.TabIndex = 5;
            this.btnRemoveInstructor.Text = "Remove";
            this.btnRemoveInstructor.UseVisualStyleBackColor = true;
            this.btnRemoveInstructor.Click += new System.EventHandler(this.btnRemoveInstructor_Click);
            // 
            // dgvInstructor
            // 
            this.dgvInstructor.AllowUserToAddRows = false;
            this.dgvInstructor.AllowUserToDeleteRows = false;
            this.dgvInstructor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInstructor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InstructorId,
            this.InstructorName,
            this.Certifications,
            this.InstructorGender});
            this.dgvInstructor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvInstructor.Location = new System.Drawing.Point(0, 96);
            this.dgvInstructor.Name = "dgvInstructor";
            this.dgvInstructor.ReadOnly = true;
            this.dgvInstructor.RowHeadersVisible = false;
            this.dgvInstructor.RowHeadersWidth = 51;
            this.dgvInstructor.RowTemplate.Height = 24;
            this.dgvInstructor.Size = new System.Drawing.Size(543, 250);
            this.dgvInstructor.TabIndex = 0;
            this.dgvInstructor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInstructor_CellContentClick);
            // 
            // InstructorId
            // 
            this.InstructorId.HeaderText = "ID";
            this.InstructorId.MinimumWidth = 6;
            this.InstructorId.Name = "InstructorId";
            this.InstructorId.ReadOnly = true;
            this.InstructorId.Width = 50;
            // 
            // InstructorName
            // 
            this.InstructorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InstructorName.HeaderText = "Name";
            this.InstructorName.MinimumWidth = 6;
            this.InstructorName.Name = "InstructorName";
            this.InstructorName.ReadOnly = true;
            // 
            // Certifications
            // 
            this.Certifications.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Certifications.HeaderText = "Certifications";
            this.Certifications.MinimumWidth = 6;
            this.Certifications.Name = "Certifications";
            this.Certifications.ReadOnly = true;
            // 
            // InstructorGender
            // 
            this.InstructorGender.HeaderText = "Gender";
            this.InstructorGender.MinimumWidth = 6;
            this.InstructorGender.Name = "InstructorGender";
            this.InstructorGender.ReadOnly = true;
            this.InstructorGender.Width = 75;
            // 
            // btnAddInstructor
            // 
            this.btnAddInstructor.Enabled = false;
            this.btnAddInstructor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddInstructor.Location = new System.Drawing.Point(411, 17);
            this.btnAddInstructor.Name = "btnAddInstructor";
            this.btnAddInstructor.Size = new System.Drawing.Size(105, 27);
            this.btnAddInstructor.TabIndex = 4;
            this.btnAddInstructor.Text = "Add";
            this.btnAddInstructor.UseVisualStyleBackColor = true;
            this.btnAddInstructor.Click += new System.EventHandler(this.btnAddInstructor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(23, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Certifications";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(23, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(23, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "ID";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.ckFull);
            this.panel1.Controls.Add(this.dgvClass);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1072, 304);
            this.panel1.TabIndex = 1;
            // 
            // ckFull
            // 
            this.ckFull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckFull.AutoSize = true;
            this.ckFull.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ckFull.Location = new System.Drawing.Point(1019, 3);
            this.ckFull.Name = "ckFull";
            this.ckFull.Size = new System.Drawing.Size(50, 20);
            this.ckFull.TabIndex = 1;
            this.ckFull.Text = "Full";
            this.ckFull.UseVisualStyleBackColor = true;
            this.ckFull.CheckedChanged += new System.EventHandler(this.ckFull_CheckedChanged);
            // 
            // dgvClass
            // 
            this.dgvClass.AllowUserToAddRows = false;
            this.dgvClass.AllowUserToDeleteRows = false;
            this.dgvClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClass.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClassId,
            this.ClassName,
            this.Description,
            this.Enrollment,
            this.Status});
            this.dgvClass.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvClass.Location = new System.Drawing.Point(0, 29);
            this.dgvClass.Name = "dgvClass";
            this.dgvClass.ReadOnly = true;
            this.dgvClass.RowHeadersVisible = false;
            this.dgvClass.RowHeadersWidth = 51;
            this.dgvClass.RowTemplate.Height = 24;
            this.dgvClass.Size = new System.Drawing.Size(1072, 275);
            this.dgvClass.TabIndex = 0;
            this.dgvClass.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClass_CellContentClick);
            // 
            // ClassId
            // 
            this.ClassId.HeaderText = "ID";
            this.ClassId.MinimumWidth = 6;
            this.ClassId.Name = "ClassId";
            this.ClassId.ReadOnly = true;
            this.ClassId.Width = 50;
            // 
            // ClassName
            // 
            this.ClassName.HeaderText = "Class Name";
            this.ClassName.MinimumWidth = 6;
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            this.ClassName.Width = 200;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Enrollment
            // 
            this.Enrollment.HeaderText = "Enrollment";
            this.Enrollment.MinimumWidth = 6;
            this.Enrollment.Name = "Enrollment";
            this.Enrollment.ReadOnly = true;
            this.Enrollment.Width = 125;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 125;
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCustomerId.Location = new System.Drawing.Point(83, 17);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(16, 16);
            this.lblCustomerId.TabIndex = 6;
            this.lblCustomerId.Text = "...";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCustomerName.Location = new System.Drawing.Point(83, 45);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(16, 16);
            this.lblCustomerName.TabIndex = 7;
            this.lblCustomerName.Text = "...";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblContact.Location = new System.Drawing.Point(83, 73);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(16, 16);
            this.lblContact.TabIndex = 7;
            this.lblContact.Text = "...";
            // 
            // lblInstructorId
            // 
            this.lblInstructorId.AutoSize = true;
            this.lblInstructorId.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblInstructorId.Location = new System.Drawing.Point(114, 17);
            this.lblInstructorId.Name = "lblInstructorId";
            this.lblInstructorId.Size = new System.Drawing.Size(16, 16);
            this.lblInstructorId.TabIndex = 6;
            this.lblInstructorId.Text = "...";
            // 
            // lblInstructorName
            // 
            this.lblInstructorName.AutoSize = true;
            this.lblInstructorName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblInstructorName.Location = new System.Drawing.Point(114, 45);
            this.lblInstructorName.Name = "lblInstructorName";
            this.lblInstructorName.Size = new System.Drawing.Size(16, 16);
            this.lblInstructorName.TabIndex = 7;
            this.lblInstructorName.Text = "...";
            // 
            // lblCertifications
            // 
            this.lblCertifications.AutoSize = true;
            this.lblCertifications.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCertifications.Location = new System.Drawing.Point(114, 73);
            this.lblCertifications.Name = "lblCertifications";
            this.lblCertifications.Size = new System.Drawing.Size(16, 16);
            this.lblCertifications.TabIndex = 7;
            this.lblCertifications.Text = "...";
            // 
            // UCtrlClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "UCtrlClass";
            this.Size = new System.Drawing.Size(1072, 656);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstructor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvClass;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.DataGridView dgvInstructor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Enrollment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button btnRemoveCustomer;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemoveInstructor;
        private System.Windows.Forms.Button btnAddInstructor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactInfor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstructorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstructorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Certifications;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstructorGender;
        private System.Windows.Forms.CheckBox ckFull;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.Label lblCertifications;
        private System.Windows.Forms.Label lblInstructorName;
        private System.Windows.Forms.Label lblInstructorId;
    }
}

namespace ADO.NET_FinalTask
{
    partial class Form1
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
            this.dataGridCustomers = new System.Windows.Forms.DataGridView();
            this.buttonSaveChanges = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridCustomers
            // 
            this.dataGridCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCustomers.Location = new System.Drawing.Point(12, 12);
            this.dataGridCustomers.Name = "dataGridCustomers";
            this.dataGridCustomers.RowHeadersWidth = 51;
            this.dataGridCustomers.RowTemplate.Height = 24;
            this.dataGridCustomers.Size = new System.Drawing.Size(1157, 499);
            this.dataGridCustomers.TabIndex = 0;
            this.dataGridCustomers.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCustomers_CellEndEdit);
            this.dataGridCustomers.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewCustomers_CellValidating);
            this.dataGridCustomers.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewCustomers_EditingControlShowing);
            // 
            // buttonSaveChanges
            // 
            this.buttonSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveChanges.Location = new System.Drawing.Point(306, 520);
            this.buttonSaveChanges.Name = "buttonSaveChanges";
            this.buttonSaveChanges.Size = new System.Drawing.Size(185, 49);
            this.buttonSaveChanges.TabIndex = 1;
            this.buttonSaveChanges.Text = "Save changes";
            this.buttonSaveChanges.UseVisualStyleBackColor = true;
            this.buttonSaveChanges.Click += new System.EventHandler(this.buttonSaveChanges_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(609, 520);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(175, 49);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 581);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSaveChanges);
            this.Controls.Add(this.dataGridCustomers);
            this.Name = "Form1";
            this.Text = "Customers";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridCustomers;
        private System.Windows.Forms.Button buttonSaveChanges;
        private System.Windows.Forms.Button buttonDelete;
    }
}
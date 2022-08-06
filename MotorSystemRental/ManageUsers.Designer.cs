
namespace MotorSystemRental
{
    partial class ManageUsers
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
            this.btnRfresh = new System.Windows.Forms.Button();
            this.btnActivateDeActivate = new System.Windows.Forms.Button();
            this.btnResetPass = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gvUserListing = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserListing)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRfresh
            // 
            this.btnRfresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRfresh.Location = new System.Drawing.Point(27, 13);
            this.btnRfresh.Name = "btnRfresh";
            this.btnRfresh.Size = new System.Drawing.Size(73, 37);
            this.btnRfresh.TabIndex = 21;
            this.btnRfresh.Text = "Refresh";
            this.btnRfresh.UseVisualStyleBackColor = true;
            this.btnRfresh.Click += new System.EventHandler(this.btnRfresh_Click);
            // 
            // btnActivateDeActivate
            // 
            this.btnActivateDeActivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivateDeActivate.Location = new System.Drawing.Point(317, 251);
            this.btnActivateDeActivate.Name = "btnActivateDeActivate";
            this.btnActivateDeActivate.Size = new System.Drawing.Size(149, 37);
            this.btnActivateDeActivate.TabIndex = 20;
            this.btnActivateDeActivate.Text = "DeActivate/Activate";
            this.btnActivateDeActivate.UseVisualStyleBackColor = true;
            this.btnActivateDeActivate.Click += new System.EventHandler(this.btnActivateDeActivate_Click);
            // 
            // btnResetPass
            // 
            this.btnResetPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPass.Location = new System.Drawing.Point(173, 251);
            this.btnResetPass.Name = "btnResetPass";
            this.btnResetPass.Size = new System.Drawing.Size(117, 37);
            this.btnResetPass.TabIndex = 19;
            this.btnResetPass.Text = "Reset Password";
            this.btnResetPass.UseVisualStyleBackColor = true;
            this.btnResetPass.Click += new System.EventHandler(this.btnResetPass_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.Location = new System.Drawing.Point(27, 251);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(117, 37);
            this.btnAddUser.TabIndex = 18;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(156, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(164, 25);
            this.lblTitle.TabIndex = 17;
            this.lblTitle.Text = "Manage Users";
            // 
            // gvUserListing
            // 
            this.gvUserListing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvUserListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUserListing.Location = new System.Drawing.Point(27, 56);
            this.gvUserListing.Name = "gvUserListing";
            this.gvUserListing.Size = new System.Drawing.Size(439, 189);
            this.gvUserListing.TabIndex = 16;
            // 
            // ManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 300);
            this.Controls.Add(this.btnRfresh);
            this.Controls.Add(this.btnActivateDeActivate);
            this.Controls.Add(this.btnResetPass);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gvUserListing);
            this.Name = "ManageUsers";
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.ManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvUserListing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRfresh;
        private System.Windows.Forms.Button btnActivateDeActivate;
        private System.Windows.Forms.Button btnResetPass;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView gvUserListing;
    }
}
﻿namespace CanadaHousing.Views
{
    partial class formLoadData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLoadData));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnGrabData = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkAvoidSaveDataOnDisc = new System.Windows.Forms.CheckBox();
            this.chkUpdateDatabase = new System.Windows.Forms.CheckBox();
            this.btnStopProcess = new System.Windows.Forms.Button();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(434, 54);
            this.panel2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Download the data from each property";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(68)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 51);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Crawler";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(36, 179);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(364, 85);
            this.txtLog.TabIndex = 5;
            // 
            // btnGrabData
            // 
            this.btnGrabData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(68)))), ((int)(((byte)(55)))));
            this.btnGrabData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(68)))), ((int)(((byte)(55)))));
            this.btnGrabData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(68)))), ((int)(((byte)(55)))));
            this.btnGrabData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(68)))), ((int)(((byte)(55)))));
            this.btnGrabData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabData.ForeColor = System.Drawing.Color.White;
            this.btnGrabData.Location = new System.Drawing.Point(316, 334);
            this.btnGrabData.Name = "btnGrabData";
            this.btnGrabData.Size = new System.Drawing.Size(84, 23);
            this.btnGrabData.TabIndex = 4;
            this.btnGrabData.Text = "Start";
            this.btnGrabData.UseVisualStyleBackColor = false;
            this.btnGrabData.Click += new System.EventHandler(this.btnGrabData_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(36, 122);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(364, 27);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblCurrent);
            this.panel3.Controls.Add(this.chkUpdateDatabase);
            this.panel3.Controls.Add(this.chkAvoidSaveDataOnDisc);
            this.panel3.Controls.Add(this.txtLog);
            this.panel3.Controls.Add(this.btnStopProcess);
            this.panel3.Controls.Add(this.btnGrabData);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(434, 369);
            this.panel3.TabIndex = 10;
            // 
            // chkAvoidSaveDataOnDisc
            // 
            this.chkAvoidSaveDataOnDisc.AutoSize = true;
            this.chkAvoidSaveDataOnDisc.Location = new System.Drawing.Point(36, 271);
            this.chkAvoidSaveDataOnDisc.Name = "chkAvoidSaveDataOnDisc";
            this.chkAvoidSaveDataOnDisc.Size = new System.Drawing.Size(145, 17);
            this.chkAvoidSaveDataOnDisc.TabIndex = 6;
            this.chkAvoidSaveDataOnDisc.Text = "Do not save data on disc";
            this.chkAvoidSaveDataOnDisc.UseVisualStyleBackColor = true;
            // 
            // chkUpdateDatabase
            // 
            this.chkUpdateDatabase.AutoSize = true;
            this.chkUpdateDatabase.Checked = true;
            this.chkUpdateDatabase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdateDatabase.Location = new System.Drawing.Point(36, 294);
            this.chkUpdateDatabase.Name = "chkUpdateDatabase";
            this.chkUpdateDatabase.Size = new System.Drawing.Size(184, 17);
            this.chkUpdateDatabase.TabIndex = 6;
            this.chkUpdateDatabase.Text = "Update database while download";
            this.chkUpdateDatabase.UseVisualStyleBackColor = true;
            // 
            // btnStopProcess
            // 
            this.btnStopProcess.BackColor = System.Drawing.Color.White;
            this.btnStopProcess.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(68)))), ((int)(((byte)(55)))));
            this.btnStopProcess.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(68)))), ((int)(((byte)(55)))));
            this.btnStopProcess.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(68)))), ((int)(((byte)(55)))));
            this.btnStopProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopProcess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(68)))), ((int)(((byte)(55)))));
            this.btnStopProcess.Location = new System.Drawing.Point(226, 334);
            this.btnStopProcess.Name = "btnStopProcess";
            this.btnStopProcess.Size = new System.Drawing.Size(84, 23);
            this.btnStopProcess.TabIndex = 4;
            this.btnStopProcess.Text = "Stop";
            this.btnStopProcess.UseVisualStyleBackColor = false;
            this.btnStopProcess.Visible = false;
            this.btnStopProcess.Click += new System.EventHandler(this.btnStopProcess_Click);
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(36, 156);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(53, 13);
            this.lblCurrent.TabIndex = 7;
            this.lblCurrent.Text = "Current: 0";
            // 
            // formLoadData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 369);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formLoadData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Crawler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formLoadData_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnGrabData;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkUpdateDatabase;
        private System.Windows.Forms.CheckBox chkAvoidSaveDataOnDisc;
        private System.Windows.Forms.Button btnStopProcess;
        private System.Windows.Forms.Label lblCurrent;
    }
}
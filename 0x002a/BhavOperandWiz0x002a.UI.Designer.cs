namespace whse.BhavOperandWizards.Wiz0x002a
{
    partial class UI
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.checkCopyMaterials = new System.Windows.Forms.CheckBox();
            this.checkMoveInSim = new System.Windows.Forms.CheckBox();
            this.lblLocalOrSlot = new System.Windows.Forms.Label();
            this.textLocalOrSlot = new System.Windows.Forms.TextBox();
            this.checkTemps = new System.Windows.Forms.CheckBox();
            this.checkMyTempToken = new System.Windows.Forms.CheckBox();
            this.checkPassT0ToMain = new System.Windows.Forms.CheckBox();
            this.checkFailIfTileNonEmpty = new System.Windows.Forms.CheckBox();
            this.checkNidInSO = new System.Windows.Forms.CheckBox();
            this.comboCreateHow = new System.Windows.Forms.ComboBox();
            this.lblCreateHow = new System.Windows.Forms.Label();
            this.comboCreateWhere = new System.Windows.Forms.ComboBox();
            this.lblCreateWhere = new System.Windows.Forms.Label();
            this.lblGuid = new System.Windows.Forms.Label();
            this.textGUID = new System.Windows.Forms.TextBox();
            this.lblCreateWhat = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.checkCopyMaterials);
            this.panelMain.Controls.Add(this.checkMoveInSim);
            this.panelMain.Controls.Add(this.lblLocalOrSlot);
            this.panelMain.Controls.Add(this.textLocalOrSlot);
            this.panelMain.Controls.Add(this.checkTemps);
            this.panelMain.Controls.Add(this.checkMyTempToken);
            this.panelMain.Controls.Add(this.checkPassT0ToMain);
            this.panelMain.Controls.Add(this.checkFailIfTileNonEmpty);
            this.panelMain.Controls.Add(this.checkNidInSO);
            this.panelMain.Controls.Add(this.comboCreateHow);
            this.panelMain.Controls.Add(this.lblCreateHow);
            this.panelMain.Controls.Add(this.comboCreateWhere);
            this.panelMain.Controls.Add(this.lblCreateWhere);
            this.panelMain.Controls.Add(this.lblGuid);
            this.panelMain.Controls.Add(this.textGUID);
            this.panelMain.Controls.Add(this.lblCreateWhat);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(400, 200);
            this.panelMain.TabIndex = 0;
            // 
            // checkCopyMaterials
            // 
            this.checkCopyMaterials.AutoSize = true;
            this.checkCopyMaterials.Location = new System.Drawing.Point(164, 169);
            this.checkCopyMaterials.Name = "checkCopyMaterials";
            this.checkCopyMaterials.Size = new System.Drawing.Size(182, 17);
            this.checkCopyMaterials.TabIndex = 15;
            this.checkCopyMaterials.Text = "Copy Materials From Object in T5";
            this.checkCopyMaterials.UseVisualStyleBackColor = true;
            // 
            // checkMoveInSim
            // 
            this.checkMoveInSim.AutoSize = true;
            this.checkMoveInSim.Location = new System.Drawing.Point(16, 169);
            this.checkMoveInSim.Name = "checkMoveInSim";
            this.checkMoveInSim.Size = new System.Drawing.Size(120, 17);
            this.checkMoveInSim.TabIndex = 14;
            this.checkMoveInSim.Text = "Move In A New Sim";
            this.checkMoveInSim.UseVisualStyleBackColor = true;
            // 
            // lblLocalOrSlot
            // 
            this.lblLocalOrSlot.AutoSize = true;
            this.lblLocalOrSlot.Location = new System.Drawing.Point(259, 91);
            this.lblLocalOrSlot.Name = "lblLocalOrSlot";
            this.lblLocalOrSlot.Size = new System.Drawing.Size(62, 13);
            this.lblLocalOrSlot.TabIndex = 13;
            this.lblLocalOrSlot.Text = "Local / Slot";
            // 
            // textLocalOrSlot
            // 
            this.textLocalOrSlot.Location = new System.Drawing.Point(327, 89);
            this.textLocalOrSlot.Name = "textLocalOrSlot";
            this.textLocalOrSlot.Size = new System.Drawing.Size(28, 20);
            this.textLocalOrSlot.TabIndex = 12;
            this.textLocalOrSlot.Validating += new System.ComponentModel.CancelEventHandler(this.OnLocalValidating);
            this.textLocalOrSlot.Validated += new System.EventHandler(this.OnLocalValidated);
            // 
            // checkTemps
            // 
            this.checkTemps.AutoSize = true;
            this.checkTemps.Location = new System.Drawing.Point(86, 54);
            this.checkTemps.Name = "checkTemps";
            this.checkTemps.Size = new System.Drawing.Size(72, 17);
            this.checkTemps.TabIndex = 11;
            this.checkTemps.Text = "Use T0/1";
            this.checkTemps.UseVisualStyleBackColor = true;
            this.checkTemps.CheckedChanged += new System.EventHandler(this.OnUseT0Changed);
            // 
            // checkMyTempToken
            // 
            this.checkMyTempToken.AutoSize = true;
            this.checkMyTempToken.Location = new System.Drawing.Point(164, 55);
            this.checkMyTempToken.Name = "checkMyTempToken";
            this.checkMyTempToken.Size = new System.Drawing.Size(126, 17);
            this.checkMyTempToken.TabIndex = 10;
            this.checkMyTempToken.Text = "Use My Temp Token";
            this.checkMyTempToken.UseVisualStyleBackColor = true;
            this.checkMyTempToken.CheckedChanged += new System.EventHandler(this.OnUseMyTokenChanged);
            // 
            // checkPassT0ToMain
            // 
            this.checkPassT0ToMain.AutoSize = true;
            this.checkPassT0ToMain.Location = new System.Drawing.Point(262, 132);
            this.checkPassT0ToMain.Name = "checkPassT0ToMain";
            this.checkPassT0ToMain.Size = new System.Drawing.Size(103, 17);
            this.checkPassT0ToMain.TabIndex = 9;
            this.checkPassT0ToMain.Text = "Pass T0 to Main";
            this.checkPassT0ToMain.UseVisualStyleBackColor = true;
            // 
            // checkFailIfTileNonEmpty
            // 
            this.checkFailIfTileNonEmpty.AutoSize = true;
            this.checkFailIfTileNonEmpty.Location = new System.Drawing.Point(262, 14);
            this.checkFailIfTileNonEmpty.Name = "checkFailIfTileNonEmpty";
            this.checkFailIfTileNonEmpty.Size = new System.Drawing.Size(118, 17);
            this.checkFailIfTileNonEmpty.TabIndex = 8;
            this.checkFailIfTileNonEmpty.Text = "Fail if tile isn\'t empty";
            this.checkFailIfTileNonEmpty.UseVisualStyleBackColor = true;
            // 
            // checkNidInSO
            // 
            this.checkNidInSO.AutoSize = true;
            this.checkNidInSO.Location = new System.Drawing.Point(296, 54);
            this.checkNidInSO.Name = "checkNidInSO";
            this.checkNidInSO.Size = new System.Drawing.Size(96, 17);
            this.checkNidInSO.TabIndex = 7;
            this.checkNidInSO.Text = "Use NID in SO";
            this.checkNidInSO.UseVisualStyleBackColor = true;
            this.checkNidInSO.CheckedChanged += new System.EventHandler(this.OnUseNidChanged);
            // 
            // comboCreateHow
            // 
            this.comboCreateHow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCreateHow.FormattingEnabled = true;
            this.comboCreateHow.Items.AddRange(new object[] {
            "Normally",
            "Do Not Duplicate",
            "Transfer SO to new"});
            this.comboCreateHow.Location = new System.Drawing.Point(86, 128);
            this.comboCreateHow.Name = "comboCreateHow";
            this.comboCreateHow.Size = new System.Drawing.Size(167, 21);
            this.comboCreateHow.TabIndex = 6;
            // 
            // lblCreateHow
            // 
            this.lblCreateHow.AutoSize = true;
            this.lblCreateHow.Location = new System.Drawing.Point(13, 131);
            this.lblCreateHow.Name = "lblCreateHow";
            this.lblCreateHow.Size = new System.Drawing.Size(63, 13);
            this.lblCreateHow.TabIndex = 5;
            this.lblCreateHow.Text = "Create How";
            // 
            // comboCreateWhere
            // 
            this.comboCreateWhere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCreateWhere.FormattingEnabled = true;
            this.comboCreateWhere.Items.AddRange(new object[] {
            "In Front of Me",
            "On Top of Me",
            "In My Hand",
            "In Front of SO",
            "In SO\'s Slot op9",
            "Underneath Me",
            "Out-of-World",
            "Below Object in Param 0",
            "Below Object in Local op6",
            "Next to Me in dir of Object in Local op6",
            "In User Defined Slot of Object in Temp 0"});
            this.comboCreateWhere.Location = new System.Drawing.Point(86, 88);
            this.comboCreateWhere.Name = "comboCreateWhere";
            this.comboCreateWhere.Size = new System.Drawing.Size(167, 21);
            this.comboCreateWhere.TabIndex = 4;
            this.comboCreateWhere.SelectedIndexChanged += new System.EventHandler(this.OnCreateWhereChanged);
            // 
            // lblCreateWhere
            // 
            this.lblCreateWhere.AutoSize = true;
            this.lblCreateWhere.Location = new System.Drawing.Point(13, 91);
            this.lblCreateWhere.Name = "lblCreateWhere";
            this.lblCreateWhere.Size = new System.Drawing.Size(73, 13);
            this.lblCreateWhere.TabIndex = 3;
            this.lblCreateWhere.Text = "Create Where";
            // 
            // lblGuid
            // 
            this.lblGuid.AutoSize = true;
            this.lblGuid.Location = new System.Drawing.Point(83, 34);
            this.lblGuid.Name = "lblGuid";
            this.lblGuid.Size = new System.Drawing.Size(118, 13);
            this.lblGuid.TabIndex = 2;
            this.lblGuid.Text = "GUID {guid} (\"{name}\")";
            // 
            // textGUID
            // 
            this.textGUID.Location = new System.Drawing.Point(86, 11);
            this.textGUID.Name = "textGUID";
            this.textGUID.Size = new System.Drawing.Size(167, 20);
            this.textGUID.TabIndex = 1;
            this.textGUID.TextChanged += new System.EventHandler(this.OnGuidChanged);
            this.textGUID.Validating += new System.ComponentModel.CancelEventHandler(this.OnGuidValidating);
            this.textGUID.Validated += new System.EventHandler(this.OnGuidValidated);
            // 
            // lblCreateWhat
            // 
            this.lblCreateWhat.AutoSize = true;
            this.lblCreateWhat.Location = new System.Drawing.Point(13, 14);
            this.lblCreateWhat.Name = "lblCreateWhat";
            this.lblCreateWhat.Size = new System.Drawing.Size(67, 13);
            this.lblCreateWhat.TabIndex = 0;
            this.lblCreateWhat.Text = "Create What";
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "UI";
            this.Size = new System.Drawing.Size(400, 200);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblGuid;
        private System.Windows.Forms.TextBox textGUID;
        private System.Windows.Forms.Label lblCreateWhat;
        private System.Windows.Forms.ComboBox comboCreateWhere;
        private System.Windows.Forms.Label lblCreateWhere;
        private System.Windows.Forms.CheckBox checkFailIfTileNonEmpty;
        private System.Windows.Forms.CheckBox checkNidInSO;
        private System.Windows.Forms.ComboBox comboCreateHow;
        private System.Windows.Forms.Label lblCreateHow;
        private System.Windows.Forms.CheckBox checkTemps;
        private System.Windows.Forms.CheckBox checkMyTempToken;
        private System.Windows.Forms.CheckBox checkPassT0ToMain;
        private System.Windows.Forms.CheckBox checkCopyMaterials;
        private System.Windows.Forms.CheckBox checkMoveInSim;
        private System.Windows.Forms.Label lblLocalOrSlot;
        private System.Windows.Forms.TextBox textLocalOrSlot;
    }
}

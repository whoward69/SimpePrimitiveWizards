using SimPe.PackedFiles.Wrapper;
using System;
using System.ComponentModel;
using System.Windows.Forms;

/*
 * 0x002A - Create New Object Instance (CNOI)
 * 
 * See https://modthesims.info/wiki.php?title=0x002A
 */
namespace whse.BhavOperandWizards.Wiz0x002a
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        private Instruction inst;

        private bool internalchg;

        public UI()
        {
            InitializeComponent();
        }

        public Panel WizPanel => this.panelMain;

        public void Execute(Instruction inst)
        {
            this.inst = inst;
            wrappedByteArray operands = inst.Operands;
            wrappedByteArray reserved1 = inst.Reserved1;

            internalchg = true;

            // Operands 0 thru 3, the GUID
            SetGUID((byte[])operands, 0, textGUID, lblGuid);

            // Operand 4, where to create the object
            comboCreateWhere.SelectedIndex = operands[4];

            // Operand 5, bit flags
            comboCreateHow.SelectedIndex = (operands[5] & 0x03);
            Boolset boolset5 = (Boolset)operands[5];
            checkNidInSO.Checked = boolset5[2];
            checkFailIfTileNonEmpty.Checked = boolset5[3];
            checkPassT0ToMain.Checked = boolset5[4];
            checkMyTempToken.Checked = boolset5[6];
            checkTemps.Checked = boolset5[7];

            // Operands 6 and 9, local variable used when op4 is 0x08 or 0x09 or slot used when op4 is 0x04
            if (operands[4] == 0x04)
            {
                textLocalOrSlot.Text = reserved1[1].ToString();
            }
            else
            {
                textLocalOrSlot.Text = operands[6].ToString();
            }

            // Operands 7 thru 8 appear to be unused

            // Operand 10, bit flags
            Boolset boolset10 = (Boolset)reserved1[2];
            checkMoveInSim.Checked = boolset10[0];
            checkCopyMaterials.Checked = boolset10[1];

            // Operands 11 thru 15 appear to be unused

            internalchg = false;

            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                // Operands 0 thru 3
                uint uint32 = Convert.ToUInt32(this.textGUID.Text, 16);
                operands[0] = (byte)(uint32 & (uint)byte.MaxValue);
                operands[1] = (byte)(uint32 >> 8 & (uint)byte.MaxValue);
                operands[2] = (byte)(uint32 >> 16 & (uint)byte.MaxValue);
                operands[3] = (byte)(uint32 >> 24 & (uint)byte.MaxValue);

                // Operand 4
                operands[4] = (byte)comboCreateWhere.SelectedIndex;

                // Operand 5
                Boolset boolset5 = (Boolset)operands[5];
                boolset5[0] = (comboCreateHow.SelectedIndex == 1);
                boolset5[1] = (comboCreateHow.SelectedIndex == 2);
                boolset5[2] = checkNidInSO.Checked;
                boolset5[3] = checkFailIfTileNonEmpty.Checked;
                boolset5[4] = checkPassT0ToMain.Checked;
                boolset5[6] = checkMyTempToken.Checked;
                boolset5[7] = checkTemps.Checked;
                operands[5] = (byte)boolset5;

                // Operand 6 or 9
                if (operands[4] == 0x08 || operands[4] == 0x09)
                {
                    operands[6] = (byte)UInt16.Parse(textLocalOrSlot.Text);
                }
                else if (operands[4] == 0x04)
                {
                    reserved1[1] = (byte)UInt16.Parse(textLocalOrSlot.Text);
                }

                // Operands 7 thru 8 appear to be unused

                // Operand 10
                Boolset boolset10 = (Boolset)reserved1[2];
                boolset10[0] = checkMoveInSim.Checked;
                boolset10[1] = checkCopyMaterials.Checked;
                reserved1[2] = (byte)boolset10;

                // Operands 11 thru 15 appear to be unused
            }

            return inst;
        }

        private void UpdatePanelState()
        {
            textGUID.Enabled = lblGuid.Visible = !(checkTemps.Checked || checkMyTempToken.Checked || checkNidInSO.Checked);

            lblLocalOrSlot.Visible = textLocalOrSlot.Visible = (comboCreateWhere.SelectedIndex == 4 || comboCreateWhere.SelectedIndex == 8 || comboCreateWhere.SelectedIndex == 9);
        }

        private bool Hex32_IsValid(object sender)
        {
            try
            {
                int uint32 = (int)Convert.ToUInt32(((Control)sender).Text, 16);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private bool Hex8_IsValid(object sender)
        {
            try
            {
                int uint16 = (int)Convert.ToUInt16(((Control)sender).Text, 16);

                return (uint16 <= 0xFF);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SetGUID(byte[] o, int sub, TextBox textBox, Label label) => this.SetGUID((uint)((int)o[sub] | (int)o[sub + 1] << 8 | (int)o[sub + 2] << 16 | (int)o[sub + 3] << 24), textBox, label);

        private void SetGUID(uint guid, TextBox textBox, Label label)
        {
            if (textBox != null) textBox.Text = "0x" + SimPe.Helper.HexString(guid);
            if (label != null) label.Text = pjse.BhavWiz.FormatGUID(true, guid);
        }

        private void OnGuidChanged(object sender, EventArgs e)
        {
            if (!Hex32_IsValid(sender)) return;

            this.SetGUID(Convert.ToUInt32(((Control)sender).Text, 16), null, lblGuid);
        }

        private void OnGuidValidating(object sender, CancelEventArgs e)
        {
            if (Hex32_IsValid(sender)) return;

            bool internalchg = this.internalchg;
            this.internalchg = true;

            e.Cancel = true;
            ((Control)sender).Text = "0x" + SimPe.Helper.HexString((int)inst.Operands[0] | (int)inst.Operands[1] << 8 | (int)inst.Operands[2] << 16 | (int)inst.Operands[3] << 24);
            ((TextBoxBase)sender).SelectAll();

            this.internalchg = internalchg;
        }

        private void OnGuidValidated(object sender, EventArgs e)
        {
            bool internalchg = this.internalchg;
            this.internalchg = true;

            ((Control)sender).Text = "0x" + SimPe.Helper.HexString(Convert.ToUInt32(((Control)sender).Text, 16));
            ((TextBoxBase)sender).SelectAll();

            this.internalchg = internalchg;
        }

        private void OnLocalValidating(object sender, CancelEventArgs e)
        {
            if (Hex8_IsValid(sender)) return;

            bool internalchg = this.internalchg;
            this.internalchg = true;

            e.Cancel = true;
            byte operand = (comboCreateWhere.SelectedIndex == 0x04) ? inst.Reserved1[1] : inst.Operands[6];
            ((Control)sender).Text = "0x" + SimPe.Helper.HexString(operand);
            ((TextBoxBase)sender).SelectAll();

            this.internalchg = internalchg;
        }

        private void OnLocalValidated(object sender, EventArgs e)
        {
            bool internalchg = this.internalchg;
            this.internalchg = true;

            ((Control)sender).Text = "0x" + SimPe.Helper.HexString((byte)Convert.ToUInt16(((Control)sender).Text, 16));
            ((TextBoxBase)sender).SelectAll();

            this.internalchg = internalchg;
        }

        private void OnCreateWhereChanged(object sender, EventArgs e)
        {
            if (comboCreateWhere.SelectedIndex == 0x08 || comboCreateWhere.SelectedIndex == 0x09)
            {
                textLocalOrSlot.Text = inst.Operands[6].ToString();
            }
            else if (comboCreateWhere.SelectedIndex == 0x04)
            {
                textLocalOrSlot.Text = inst.Reserved1[1].ToString();
            }

            UpdatePanelState();
        }

        private void OnUseT0Changed(object sender, EventArgs e)
        {
            if (checkTemps.Checked)
            {
                checkMyTempToken.Checked = checkNidInSO.Checked = false;
            }

            UpdatePanelState();
        }

        private void OnUseMyTokenChanged(object sender, EventArgs e)
        {
            if (checkMyTempToken.Checked)
            {
                checkTemps.Checked = checkNidInSO.Checked = false;
            }

            UpdatePanelState();
        }

        private void OnUseNidChanged(object sender, EventArgs e)
        {
            if (checkNidInSO.Checked)
            {
                checkMyTempToken.Checked = checkTemps.Checked = false;
            }

            UpdatePanelState();
        }
    }
}

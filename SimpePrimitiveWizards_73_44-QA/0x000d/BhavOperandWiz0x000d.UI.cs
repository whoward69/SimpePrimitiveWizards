/*
 * SimpePrimitiveWizards - additional primitive wizards for SimPe
 *                       - see https://www.picknmixmods.com/Sims2/Notes/SimpePrimitiveWizards/SimpePrimitiveWizards.html
 *
 * William Howard - 2023-2023
 *
 * Permission granted to use this code in any way, except to claim it as your own or sell it
 *
 * NOTE: Code should not be "using Simpe;" or "using pjse;" but fully qualifying classes in those high level namespaces
 *
 */

using pjse.BhavOperandWizards;
using SimPe.PackedFiles.Wrapper;
using System;
using System.Windows.Forms;

/*
 * 0x000D - Push Interaction
 * 
 * See https://modthesims.info/wiki.php?title=0x000D
 */
namespace whse.PrimitiveWizards.Wiz0x000d
{
    public partial class UI : UserControl, pjse.iBhavOperandWizForm
    {
        // private Instruction inst;

        private DataOwnerControl doIntObject, doIntNumber, doIntVariable, doIconObject, doIconIndex, doLinking, doReturning;

        private bool internalchg;

        public UI()
        {
            InitializeComponent();
        }

        public Panel WizPanel => this.panelMain;

        public void Execute(Instruction inst)
        {
            //this.inst = inst;

            wrappedByteArray operands = inst.Operands;
            wrappedByteArray reserved1 = inst.Reserved1;

            Boolset boolset3 = new Boolset(operands[OperandConstants.Operand3]);
            Boolset boolset14 = new Boolset(reserved1[OperandConstants.Operand14]);

            internalchg = true;

            comboIntObject.SelectedIndex = (boolset3[OperandConstants.Bit2] ? 1 : 0);
            doIntObject = WizardHelpers.CreateDataControl(inst, textIntObject, checkDecimal, operands[OperandConstants.Operand1]);

            comboIntNumber.SelectedIndex = (boolset14[OperandConstants.Bit2] ? 2 : (boolset3[OperandConstants.Bit5] ? 1 : 0));
            doIntNumber = WizardHelpers.CreateDataControl(inst, textIntNumber, checkDecimal, operands[OperandConstants.Operand0]);
            doIntVariable = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner1, comboDataPicker1, textDataValue1, checkDecimal, checkAttrPicker, toolTip, operands[OperandConstants.Operand5], operands[OperandConstants.Operand6], operands[OperandConstants.Operand7]);

            WizardHelpers.ComboSelectIndex(comboPriority, (operands[OperandConstants.Operand2] & 0x03));

            comboIconObject.SelectedIndex = (boolset3[OperandConstants.Bit1] ? 1 : (boolset14[OperandConstants.Bit3] ? 2 : 0));
            doIconObject = WizardHelpers.CreateDataControl(inst, textIconObject, checkDecimal, operands[OperandConstants.Operand4]);

            comboIconIndex.SelectedIndex = (boolset14[OperandConstants.Bit4] ? 1 : 0);
            doIconIndex = WizardHelpers.CreateDataControl(inst, textIconIndex, checkDecimal, reserved1[OperandConstants.Operand15]);

            checkCallerParams.Checked = boolset14[OperandConstants.Bit1];
            checkUseName.Checked = boolset3[OperandConstants.Bit4];
            checkRunCheckTree.Checked = boolset3[OperandConstants.Bit6];

            checkLinking.Checked = boolset3[OperandConstants.Bit7];
            doLinking = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner2, comboDataPicker2, textDataValue2, checkDecimal, checkAttrPicker, toolTip, reserved1[OperandConstants.Operand8], reserved1[OperandConstants.Operand9], reserved1[OperandConstants.Operand10]);

            checkReturning.Checked = boolset3[OperandConstants.Bit8];
            doReturning = WizardHelpers.CreateDataOwnerControl(inst, comboDataOwner3, comboDataPicker3, textDataValue3, checkDecimal, checkAttrPicker, toolTip, reserved1[OperandConstants.Operand11], reserved1[OperandConstants.Operand12], reserved1[OperandConstants.Operand13]);

            internalchg = false;

            UpdatePanelState();
        }

        public Instruction Write(Instruction inst)
        {
            if (inst != null)
            {
                wrappedByteArray operands = inst.Operands;
                wrappedByteArray reserved1 = inst.Reserved1;

                operands[OperandConstants.Operand0] = (byte)doIntNumber.Value;

                operands[OperandConstants.Operand1] = (byte)doIntObject.Value;

                operands[OperandConstants.Operand2] = (byte)comboPriority.SelectedIndex;

                Boolset boolset3 = new Boolset(operands[OperandConstants.Operand3]);
                boolset3[OperandConstants.Bit1] = (comboIconObject.SelectedIndex == 1);
                boolset3[OperandConstants.Bit2] = (comboIntObject.SelectedIndex == 1);
                // Bit 3 is unused
                boolset3[OperandConstants.Bit4] = checkUseName.Checked;
                boolset3[OperandConstants.Bit5] = (comboIntNumber.SelectedIndex == 1);
                boolset3[OperandConstants.Bit6] = checkRunCheckTree.Checked;
                boolset3[OperandConstants.Bit7] = checkLinking.Checked;
                boolset3[OperandConstants.Bit8] = checkReturning.Checked;
                operands[OperandConstants.Operand3] = boolset3;

                operands[OperandConstants.Operand4] = (byte)doIconObject.Value;

                operands[OperandConstants.Operand5] = doIntVariable.DataOwner;
                operands[OperandConstants.Operand6] = (byte)doIntVariable.Value;
                operands[OperandConstants.Operand7] = (byte)(doIntVariable.Value >> 8);

                reserved1[OperandConstants.Operand8] = doLinking.DataOwner;
                reserved1[OperandConstants.Operand9] = (byte)doLinking.Value;
                reserved1[OperandConstants.Operand10] = (byte)(doLinking.Value >> 8);

                reserved1[OperandConstants.Operand11] = doReturning.DataOwner;
                reserved1[OperandConstants.Operand12] = (byte)doReturning.Value;
                reserved1[OperandConstants.Operand13] = (byte)(doReturning.Value >> 8);

                Boolset boolset14 = new Boolset(reserved1[OperandConstants.Operand14]);
                boolset14[OperandConstants.Bit1] = checkCallerParams.Checked;
                boolset14[OperandConstants.Bit2] = (comboIntNumber.SelectedIndex == 2);
                boolset14[OperandConstants.Bit3] = (comboIconObject.SelectedIndex == 2);
                boolset14[OperandConstants.Bit4] = (comboIconIndex.SelectedIndex == 1);
                reserved1[OperandConstants.Operand14] = boolset14;

                reserved1[OperandConstants.Operand15] = (byte)doIconIndex.Value;
            }

            return inst;
        }

        private void UpdatePanelState()
        {
            textIntNumber.Visible = (comboIntNumber.SelectedIndex == 0);

            panelDataOwner1.Visible = (comboIntNumber.SelectedIndex == 1);

            textIconObject.Visible = (comboIconObject.SelectedIndex == 1);

            textIconIndex.Visible = (comboIconIndex.SelectedIndex == 0);

            panelDataOwner2.Visible = checkLinking.Checked;

            panelDataOwner3.Visible = checkReturning.Checked;
        }

        private void OnControlChanged(object sender, EventArgs e)
        {
            if (internalchg) return;

            UpdatePanelState();
        }
    }
}

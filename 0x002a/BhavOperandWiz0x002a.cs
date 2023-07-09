using SimPe.PackedFiles.Wrapper;
using whse.BhavOperandWizards.Wiz0x002a;

namespace whse.BhavOperandWizards
{
    public class BhavOperandWiz0x002a : pjse.ABhavOperandWiz
    {
        public BhavOperandWiz0x002a(Instruction i) : base(i)
        {
            this.myForm = new UI();
        }

        public override void Dispose()
        {
            if (this.myForm != null)
            {
                // Clean up as necessary

                this.myForm = null;
            }
        }
    }
}

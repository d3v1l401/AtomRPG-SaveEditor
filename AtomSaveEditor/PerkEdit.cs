using AtomSaveEditor.Atom.PlayerSave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtomSaveEditor
{
    public partial class PerkEdit : Form
    {
        public void LoadPerks(List<string> _perks)
        {
            this.PerkList.Items.Clear();
            foreach (var perk in _perks)
                this.PerkList.Items.Add(perk);
        }

        public List<string> GetPerks()
        {
            List<string> _perks = new List<string>();
            foreach (string item in this.PerkList.Items)
                if (!_perks.Contains(item))
                    _perks.Add(item);

            return _perks;
        }
        private Main _mainMenu;
        public PerkEdit(Main _refToMain)
        {
            InitializeComponent();
            this._mainMenu = _refToMain;
        }

        private void PerkEdit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.PerkList.Items.Remove(this.PerkList.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.PerkList.Items.Add(this.addablePerk.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this._mainMenu.GetCurrentChar().Stats.Perks = this.GetPerks();
            this.Hide();
        }
    }
}

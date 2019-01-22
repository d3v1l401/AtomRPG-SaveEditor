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
    public partial class SkillEdit : Form
    {
        public void LoadSkills(Skills _skills) {
            this.smallgunsCounter.Value = _skills.SmallGuns;
            this.biggunsCounter.Value = _skills.BigGuns;
            this.automfireCounter.Value = _skills.AutomaticFirearms;
            this.unarmedCounter.Value = _skills.Unarmed;
            this.meleeCounter.Value = _skills.MeleeWeapons;
            this.throwingCounter.Value = _skills.Throwing;
            this.firstaidCounter.Value = _skills.FirstAid;
            this.craftingCounter.Value = _skills.Crafting;
            this.sneakCounter.Value = _skills.Sneak;
            this.lockpickCounter.Value = _skills.Lockpick;
            this.stealCounter.Value = _skills.Steal;
            this.attentionCounter.Value = _skills.Alertness;
            this.scienceCounter.Value = _skills.Science;
            this.speechCounter.Value = _skills.Speech;
            this.barterCounter.Value = _skills.Barter;
            this.gamblingCounter.Value = _skills.Gambling;
            this.survivalCounter.Value = _skills.Outdoorsman;
        }

        public Skills GetNewSkillsTree()
        {
            Skills _skills = new Skills();

            _skills.SmallGuns = (long)this.smallgunsCounter.Value;
            _skills.BigGuns = (long)this.biggunsCounter.Value;
            _skills.AutomaticFirearms = (long)this.automfireCounter.Value;
            _skills.Unarmed = (long)this.unarmedCounter.Value;
            _skills.MeleeWeapons = (long)this.meleeCounter.Value;
            _skills.Throwing = (long)this.throwingCounter.Value;
            _skills.FirstAid = (long)this.firstaidCounter.Value;
            _skills.Crafting = (long)this.craftingCounter.Value;
            _skills.Sneak = (long)this.sneakCounter.Value;
            _skills.Lockpick = (long)this.lockpickCounter.Value;
            _skills.Steal = (long)this.stealCounter.Value;
            _skills.Alertness = (long)this.attentionCounter.Value;
            _skills.Science = (long)this.scienceCounter.Value;
            _skills.Speech = (long)this.speechCounter.Value;
            _skills.Barter = (long)this.barterCounter.Value;
            _skills.Gambling = (long)this.gamblingCounter.Value;
            _skills.Outdoorsman = (long)this.survivalCounter.Value;

            return _skills;
        }

        private Main _mainMenu;
        public SkillEdit(Main _refToMain)
        {
            this._mainMenu = _refToMain;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._mainMenu.GetCurrentChar().Stats.Skills = this.GetNewSkillsTree();
            this.Hide();
        }

        private void smallgunsCounter_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

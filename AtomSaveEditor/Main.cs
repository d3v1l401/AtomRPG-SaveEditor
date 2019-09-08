using AtomSaveEditor.Atom;
using AtomSaveEditor.Atom.PlayerSave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtomSaveEditor
{
    public partial class Main : Form
    {
        // https://stackoverflow.com/questions/4494290/detect-the-location-of-appdata-locallow
        // Thomas Levesque's
        string GetKnownFolderPath(Guid knownFolderId)
        {
            IntPtr pszPath = IntPtr.Zero;
            try {
                int hr = SHGetKnownFolderPath(knownFolderId, 0, IntPtr.Zero, out pszPath);
                if (hr >= 0)
                    return Marshal.PtrToStringAuto(pszPath);
                throw Marshal.GetExceptionForHR(hr);
            } finally {
                if (pszPath != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(pszPath);
            }
        }

        [DllImport("shell32.dll")]
        static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken, out IntPtr pszPath);

        public Main()
        {
            InitializeComponent();
        }

        private static string           _currentFilePath    = string.Empty;
        private static readonly Guid    _localLowId         = new Guid("A520A1A4-1780-4FF6-BD18-167343C5AF16");
        private static readonly string  _saveSubFolder      = "\\AtomTeam\\Atom";

        private SaveHandler             _sh                 = null;

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog _ofd = new OpenFileDialog();
            _ofd.Filter = "Save File|*.as";
            _ofd.Title = "Select Save File";
            _ofd.CheckFileExists = true;
            _ofd.InitialDirectory = GetKnownFolderPath(_localLowId) + _saveSubFolder;

            if (_ofd.ShowDialog() == DialogResult.OK) {
                _currentFilePath = _ofd.FileName;

                this._sh = new SaveHandler(_currentFilePath);
                this.savePicture.LoadAsync(this._sh.GetScreenshot());
                this.biographyLabel.Text = this._sh._stateSave.PlayerBio;
                this.playerNameLabel.Text = this._sh._stateSave.PlayerName;

                this.comboBox1.Items.Clear();
                foreach (var character in this._sh._playerSave) {
                    this.comboBox1.Items.Add(character.Name);
                }

                this.comboBox1.SelectedItem = this.comboBox1.Items[0];
                statusBase.Hide();
                this.OverviewPanel.Show();
            }
        }
        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
	        var newSaveBuffer = _sh.Pack();
	        var dialogResult = MessageBox.Show("Do you want to replace the save file?", "Replace save file",
		        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

	        if (dialogResult == DialogResult.Yes)
	        {
		        File.Delete(_currentFilePath);
		        File.WriteAllBytes(_currentFilePath, newSaveBuffer);
	        }
	        else if (dialogResult == DialogResult.No)
	        {
		        File.WriteAllBytes(_currentFilePath + "_modded.as", newSaveBuffer);
	        }

	        MessageBox.Show("Save file successfully overwritten.", "Operation complete", MessageBoxButtons.OK,
		        MessageBoxIcon.Information);
		}

        SkillEdit _skEdit = null;
        PerkEdit _pEdit = null;
        PlayerSave _selectedCharacter = null;

        public PlayerSave GetCurrentChar() {
            return this._selectedCharacter;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            foreach (var character in this._sh._playerSave)
                if (character.Name.Equals(this.comboBox1.SelectedItem.ToString()))
                    _selectedCharacter = character;

            if (_selectedCharacter != null) {
                this.charNameText.Text = _selectedCharacter.Name;
                this.modelSelect.Text = _selectedCharacter.Proto;
                this.apCounter.Value = _selectedCharacter.Ap;
                this.relationshipCounter.Value = _selectedCharacter.Relationship;

                this.levelCounter.Value = _selectedCharacter.Stats.Level;
                this.expCounter.Value = _selectedCharacter.Stats.Xp;
                this.strenghtCounter.Value = _selectedCharacter.Stats.Strength;
                this.agilityCounter.Value = _selectedCharacter.Stats.Agility;
                this.percepCounter.Value = _selectedCharacter.Stats.Perception;
                this.enduranceCounter.Value = _selectedCharacter.Stats.Endurance;
                this.charismaCounter.Value = _selectedCharacter.Stats.Charisma;
                this.intelCounter.Value = _selectedCharacter.Stats.Intelligence;
                this.luckCounter.Value = _selectedCharacter.Stats.Luck;

                this._skEdit = new SkillEdit(this);
                this._skEdit.LoadSkills(this._selectedCharacter.Stats.Skills);

                this._pEdit = new PerkEdit(this);
                this._pEdit.LoadPerks(this._selectedCharacter.Stats.Perks);

                this.skinSelector.Text = this._selectedCharacter.Skin;
                this.beardSelector.Text = this._selectedCharacter.Beard;
                this.hairSelector.Text = this._selectedCharacter.Hair;
                this.hairColorSelector.Text = this._selectedCharacter.HairColor;

                this.headSelector.Text = this._selectedCharacter.Cap.Proto;
                this.headSkinSelector.Text = this._selectedCharacter.Cap.Skin;
                
                this.bagSelector.Text = this._selectedCharacter.Rucksack.Proto;
                this.bagSkinSelector.Text = this._selectedCharacter.Rucksack.Skin;

                this.faceSelector.Text = this._selectedCharacter.HeadMask.Proto;
                this.faceSkinSelector.Text = this._selectedCharacter.HeadMask.Skin;

                this.item1Selector.Text = this._selectedCharacter.Item1.Proto;
                this.item1SkinSelector.Text = this._selectedCharacter.Item1.Skin;
                if (this._selectedCharacter.Item1.Ammo != null) {
                    this.item1AmmoSelector.Text = this._selectedCharacter.Item1.Ammo.Proto;
                    this.item1AmmoCount.Value = this._selectedCharacter.Item1.Ammo.Count;
                }

                this.item2Selector.Text = this._selectedCharacter.Item2.Proto;
                this.item2SkinSelector.Text = this._selectedCharacter.Item2.Skin;
                if (this._selectedCharacter.Item2.Ammo != null)
                {
                    this.item2AmmoSelector.Text = this._selectedCharacter.Item2.Ammo.Proto;
                    this.item2AmmoCount.Value = this._selectedCharacter.Item2.Ammo.Count;
                }


                this.keywordsList.Items.Clear();
                // I only added most interesting ones I could find in my save files, but there should be a lot more.
                this.keywordsList.Items.Add("CULT_CODE1: " + this._selectedCharacter.Keywords.CultCode1);
                this.keywordsList.Items.Add("CULT_CODE2: " + this._selectedCharacter.Keywords.CultCode2);
                this.keywordsList.Items.Add("PIN_VILLAGE_BUNKER_SAFE: " + this._selectedCharacter.Keywords.PinVillageBunkerSafe);

            } else {
                MessageBox.Show("No character selected has been found in the save file.", "No character found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void strenghtCounter_ValueChanged(object sender, EventArgs e)
        {
            _selectedCharacter.Stats.Strength = (long)this.strenghtCounter.Value;
        }

        private void percepCounter_ValueChanged(object sender, EventArgs e)
        {
            _selectedCharacter.Stats.Perception = (long)this.percepCounter.Value;
        }

        private void enduranceCounter_ValueChanged(object sender, EventArgs e)
        {
            _selectedCharacter.Stats.Endurance = (long)this.enduranceCounter.Value;
        }

        private void charismaCounter_ValueChanged(object sender, EventArgs e)
        {
            _selectedCharacter.Stats.Charisma = (long)this.charismaCounter.Value;
        }

        private void intelCounter_ValueChanged(object sender, EventArgs e)
        {
            _selectedCharacter.Stats.Intelligence = (long)this.intelCounter.Value;
        }

        private void agilityCounter_ValueChanged(object sender, EventArgs e)
        {
            _selectedCharacter.Stats.Agility = (long)this.agilityCounter.Value;
        }

        private void luckCounter_ValueChanged(object sender, EventArgs e)
        {
            _selectedCharacter.Stats.Luck = (long)this.luckCounter.Value;
        }

        private void levelCounter_ValueChanged(object sender, EventArgs e)
        {
            _selectedCharacter.Stats.Level = (long)this.levelCounter.Value;
        }

        private void expCounter_ValueChanged(object sender, EventArgs e)
        {
            _selectedCharacter.Stats.Xp = (long)this.expCounter.Value;
        }

        private void apCounter_ValueChanged(object sender, EventArgs e)
        {
            _selectedCharacter.Ap = (long)this.apCounter.Value;
        }

        private void relationshipCounter_ValueChanged(object sender, EventArgs e)
        {
            _selectedCharacter.Relationship = (long)this.relationshipCounter.Value;
        }

        private void modelSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCharacter.Proto = this.modelSelect.SelectedItem.ToString();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            OverviewPanel.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._skEdit.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._pEdit.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void keywordsList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void skinSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.Skin = this.skinSelector.Text;
        }

        private void hairSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.Hair = this.hairSelector.Text;
        }

        private void beardSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.Beard = this.beardSelector.Text;
        }

        private void hairColorSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.HairColor = this.hairColorSelector.Text;
        }

        private void bagSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.Rucksack.Proto = this.bagSelector.Text;
        }

        private void bagSkinSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.Rucksack.Skin = this.bagSkinSelector.Text;
        }

        private void faceSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.HeadMask.Proto = this.faceSelector.Text;

        }

        private void faceSkinSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.HeadMask.Skin = this.faceSkinSelector.Text;
        }

        private void headSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.Cap.Proto = this.headSelector.Text;
        }

        private void headSkinSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.Cap.Skin = this.headSkinSelector.Text;
        }

        private void item1Selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.Item1.Proto = this.item1Selector.Text;
        }

        private void item1SkinSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.Item1.Skin = this.item1SkinSelector.Text;
        }

        private void item1AmmoSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.Item1.Ammo.Proto = this.item1AmmoSelector.Text;
        }

        private void item1AmmoCount_ValueChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.Item1.Ammo.Count = (long)this.item1AmmoCount.Value;
        }

        private void item2Selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.Item2.Proto = this.item2Selector.Text;
        }

        private void item2SkinSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.Item2.Skin = this.item2SkinSelector.Text;
        }

        private void item2AmmoSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.Item2.Ammo.Proto = this.item2AmmoSelector.Text;
        }

        private void item2AmmoCount_ValueChanged(object sender, EventArgs e)
        {
            this._selectedCharacter.Item2.Ammo.Count = (long)this.item2AmmoCount.Value;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
        
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomSaveEditor.Atom
{
    class SaveHandler
    {
        private static readonly string _editPath = "atomedit";
        private static string _pathBase = string.Empty;

        // Contains a list of playing characters.
        public List<PlayerSave.PlayerSave> _playerSave { get; set; }
        // Contains generic states of entities.
        public GeneralSave.Save        _stateSave { get; set; }

        private byte[] _readFileContent(string _pathToFile) {
            var _handle = File.OpenRead(_pathToFile);
            if (_handle == null)
                return null;

            byte[] _outBuffer = new byte[_handle.Length];
            _handle.Read(_outBuffer, 0, (int)_handle.Length);
            _handle.Close();

            return _outBuffer;
        }
        public string GetScreenshot() {
            return _pathBase + Database.SelectFile(Database.SAVE_SELECTOR.SAVE_PICTURE);
        }
        public SaveHandler(string _pathToFile) {
            _pathBase = Path.GetTempPath() + _editPath;
            ZIPHelper.DecompressToDirectory(_pathToFile, _pathBase);

            _playerSave = PlayerSave.PlayerSave.FromJson(File.ReadAllText(_pathBase + Database.SelectFile(Database.SAVE_SELECTOR.SAVE_PLAYER)));
            _stateSave  = GeneralSave.Save.FromJson(File.ReadAllText(_pathBase + Database.SelectFile(Database.SAVE_SELECTOR.SAVE_STATE)));
            
        }

        public GeneralSave.Stats ConvertAsGS(PlayerSave.Stats pss) {
            GeneralSave.Stats _gssn = new GeneralSave.Stats();


            _gssn.Agility = pss.Agility;
            _gssn.Strength = pss.Strength;
            _gssn.Luck = pss.Luck;
            _gssn.Perks = pss.Perks.ToArray();

            _gssn.Skills = new GeneralSave.Skills();
            _gssn.Skills.SmallGuns = pss.Skills.SmallGuns;
            _gssn.Skills.AutomaticFirearms = pss.Skills.AutomaticFirearms;
            _gssn.Skills.Unarmed = pss.Skills.Unarmed;
            _gssn.Skills.BigGuns = pss.Skills.BigGuns;
            _gssn.Skills.MeleeWeapons = pss.Skills.MeleeWeapons;
            _gssn.Skills.Throwing = pss.Skills.Throwing;
            _gssn.Skills.FirstAid = pss.Skills.FirstAid;
            _gssn.Skills.Crafting = pss.Skills.Crafting;
            _gssn.Skills.Sneak = pss.Skills.Sneak;
            _gssn.Skills.Lockpick = pss.Skills.Lockpick;
            _gssn.Skills.Steal = pss.Skills.Steal;
            _gssn.Skills.Alertness = pss.Skills.Alertness;
            _gssn.Skills.Science = pss.Skills.Science;
            _gssn.Skills.Speech = pss.Skills.Speech;
            _gssn.Skills.Barter = pss.Skills.Barter;
            _gssn.Skills.Gambling = pss.Skills.Gambling;
            _gssn.Skills.Outdoorsman = pss.Skills.Outdoorsman;
            _gssn.FreeStatPoints = pss.FreeStatPoints;
            _gssn.FreeSkillPoints = pss.FreeSkillPoints;
            _gssn.Intelligence = pss.Intelligence;
            _gssn.Level = pss.Level;
            _gssn.Xp = pss.Xp;
            _gssn.Perception = pss.Perception;
            _gssn.Endurance = pss.Endurance;
            _gssn.Charisma = pss.Charisma;
            _gssn.FreeSpecPoints = pss.FreeSpecPoints;
            _gssn.SpecLevel = pss.SpecLevel;

            return _gssn;
        }

        public byte[] Pack() {
            File.Delete(_pathBase + Database.SelectFile(Database.SAVE_SELECTOR.SAVE_STATE));
            File.Delete(_pathBase + Database.SelectFile(Database.SAVE_SELECTOR.SAVE_PLAYER));

            // Ugly hotfix...but if the player changes the character name it's a problem...
            foreach (var character in this._playerSave)
                if (character.Name.Equals("Player")) {
                    this._stateSave.Stats = this.ConvertAsGS(character.Stats);
                    break;
                }

            File.WriteAllBytes(_pathBase + Database.SelectFile(Database.SAVE_SELECTOR.SAVE_STATE), GeneralSave.Serialize.ToJson(this._stateSave).ToArray().Select(character => (byte)character).ToArray());
            File.WriteAllBytes(_pathBase + Database.SelectFile(Database.SAVE_SELECTOR.SAVE_PLAYER), PlayerSave.Serialize.ToJson(this._playerSave).ToArray().Select(character => (byte)character).ToArray());

            return ZIPHelper.CompressDirectory(_pathBase);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomSaveEditor.Atom
{
    class Database
    {
        public enum SAVE_SELECTOR {
            SAVE_PLAYER = 0,
            SAVE_STATE = 1,
            SAVE_PICTURE = 2,
            SAVE_WORLD = 3
        }

        public static readonly string[] _persistentSaveFiles = {
            "player.dat",
            "save.dat",
            "Screenshot.png",
            "WorldMap.dat"
        };

        public static string SelectFile(SAVE_SELECTOR _selector) {
            if ((int)_selector > _persistentSaveFiles.Length || (int)_selector < 0)
                return "null";

            return "\\" + _persistentSaveFiles[(int)_selector];
        }
    }
}

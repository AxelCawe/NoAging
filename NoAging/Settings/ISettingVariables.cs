using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoAging.Settings
{
    internal interface ISettingVariables
    {
        bool IsPlayerAgeCapped { get; set; }
        int PlayerAgeCap { get; set; }

        bool IsPlayerSpouseCapped { get; set; }
        int PlayerSpouseAgeCap { get; set; }

        bool IsPlayerClanMembersCapped { get; set; }
        int PlayerClanMembersAgeCap { get; set; }

        bool ApplyPatchForMultipleSpouses { get; set; }
        int PlayerSecondarySpousesAgeCap { get; set; }
    }
}

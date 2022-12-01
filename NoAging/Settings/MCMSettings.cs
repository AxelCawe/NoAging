using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoAging.Settings
{
    internal class MCMSettings : AttributeGlobalSettings<MCMSettings>, ISettingVariables
    {
        public override string Id => "NoAgingSettings";

        public override string DisplayName => "No Aging";

        public override string FolderName => "NoAging";

        public override string FormatType => "xml";

        [SettingPropertyBool("{=player_settings}Player Character Age Cap", Order = 0, RequireRestart = false, HintText = "{=cap_player_age_desc}Whether the player character's age should be capped. If ticked, character will not grow order than the given age.", IsToggle = true)]
        [SettingPropertyGroup("{=player_settings}Player Character Age Cap", GroupOrder = 0)]
        public bool IsPlayerAgeCapped { get; set; } = false;

        [SettingPropertyInteger("{=cap_player_age_value}Player Age To Cap", minValue: GlobalModSettings.minAge, maxValue: GlobalModSettings.maxAge, valueFormat: "0 years old", Order = 1, HintText = "{=cap_player_age_value_desc}The age that the player character cannot exceed.", RequireRestart = false)]
        [SettingPropertyGroup("{=player_settings}Player Character Age Cap", GroupOrder = 0)]
        public int PlayerAgeCap { get; set; } = 20;

        [SettingPropertyBool("{=player_spouse_settings}Player Spouse Age Cap", Order = 0, RequireRestart = false, HintText = "{=cap_player_spouse_age_desc}Whether the player character's spouse age should be capped. If ticked, character's spouse will not grow order than the given age.", IsToggle = true)]
        [SettingPropertyGroup("{=player_spouse_settings}Player Spouse Age Cap", GroupOrder = 1)]
        public bool IsPlayerSpouseCapped { get; set; } = false;
        [SettingPropertyInteger("{=cap_player_spouse_age_value}Player Spouse Age To Cap", minValue: GlobalModSettings.minAge, maxValue: GlobalModSettings.maxAge, valueFormat: "0 years old", Order = 1, HintText = "{=cap_player_spouse_age_value_desc}The age that the player character's spouse cannot exceed.", RequireRestart = false)]
        [SettingPropertyGroup("{=player_spouse_settings}Player Spouse Age Cap", GroupOrder = 1)]
        public int PlayerSpouseAgeCap { get; set; } = 20;

        [SettingPropertyBool("{=player_clan_settings}Player Clan Members Age Cap", Order = 0, RequireRestart = false, HintText = "{=cap_player_clan_age_desc}Whether the player clan's characters age should be capped. If ticked, player clan's characters will not grow order than the given age.", IsToggle = true)]
        [SettingPropertyGroup("{=player_clan_settings}Player Clan Members Age Cap", GroupOrder = 2)]
        public bool IsPlayerClanMembersCapped { get; set; } = false;
        [SettingPropertyInteger("{=cap_player_clan_age_value}Player Clan Members Age To Cap", minValue: GlobalModSettings.minAge, maxValue: GlobalModSettings.maxAge, valueFormat: "0 years old", Order = 1, HintText = "{=cap_player_clan_age_value_desc}The age that the player clan's characters cannot exceed.", RequireRestart = false)]
        [SettingPropertyGroup("{=player_clan_settings}Player Clan Members Age Cap", GroupOrder = 2)]
        public int PlayerClanMembersAgeCap { get; set; } = 20;


        [SettingPropertyBool("{=player_secondary_spouses_settings}Apply Patch for Multiple Spouses", Order = 0, RequireRestart = false, HintText = "{=cap_secondary_spouses_age_desc}Applies a patch for mods that multiple spouses. If ticked, all \"secondary\" spouses will be patched with an age cap.", IsToggle = true)]
        [SettingPropertyGroup("{=player_secondary_spouses_settings}Apply Patch for Multiple Spouses", GroupOrder = 3)]
        public bool ApplyPatchForMultipleSpouses { get; set; } = false;

        [SettingPropertyInteger("{=cap_secondary_spouses_age_value}Secondary Spouses' Age To Cap", minValue: GlobalModSettings.minAge, maxValue: GlobalModSettings.maxAge, valueFormat: "0 years old", Order = 1, HintText = "{=cap_secondary_spouses_age_value_desc}The age that the secondary spouses cannot exceed.", RequireRestart = false)]
        [SettingPropertyGroup("{=player_secondary_spouses_settings}Apply Patch for Multiple Spouses", GroupOrder = 3)]
        public int PlayerSecondarySpousesAgeCap { get; set; } = 20;

    }
}

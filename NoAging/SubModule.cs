using HarmonyLib;
using MCM.Abstractions.Base.Global;
using NoAging.Settings;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.MountAndBlade;

namespace NoAging
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarter)
        {
            base.OnGameStart(game, gameStarter);
            
            MCMSettings mainSettings = GlobalSettings<MCMSettings>.Instance;
            CampaignEvents.DailyTickEvent.AddNonSerializedListener((object)this, new Action(() =>
            {
                // For Player Character
                if (mainSettings.IsPlayerAgeCapped)
                {
                    var targetAge = mainSettings.PlayerAgeCap;
                    if (Hero.MainHero.Age > targetAge + 1f)
                    {
                        var birthday = CampaignTime.Now - CampaignTime.Years(targetAge);
                        Hero.MainHero.SetBirthDay(birthday);
                       
                    }
                }

                // For Spouse
                if (mainSettings.IsPlayerSpouseCapped)
                {
                    var targetAge = mainSettings.PlayerSpouseAgeCap;
                    if (Hero.MainHero.Spouse != null && !Hero.MainHero.Spouse.IsDead && Hero.MainHero.Spouse.Age > targetAge + 1)
                    {
                        var birthday = CampaignTime.Now - CampaignTime.Years(targetAge);
                        Hero.MainHero.Spouse.SetBirthDay(birthday);
                    }
                }

                // For clan members
                if (mainSettings.IsPlayerClanMembersCapped && Clan.PlayerClan != null)
                {
                    var targetAge = mainSettings.PlayerClanMembersAgeCap;
                    foreach (var hero in Clan.PlayerClan.Heroes)
                    {
                        if (hero != Hero.MainHero.Spouse && !hero.IsDead && hero.Age > targetAge + 1)
                        {
                            bool isExSpouse = false;
                            foreach (var exHero in Hero.MainHero.ExSpouses)
                            {
                                if (exHero == hero)
                                {
                                    isExSpouse = true; break;
                                }
                            }
                            if (!isExSpouse)
                            {
                                var birthday = CampaignTime.Now - CampaignTime.Years(targetAge);
                                hero.SetBirthDay(birthday);
                            }
                            
                        }
                        
                    }
                }

                if (mainSettings.ApplyPatchForMultipleSpouses && Hero.MainHero.ExSpouses.Count > 0) 
                {
                    var targetAge = mainSettings.PlayerSecondarySpousesAgeCap;
                    foreach (var hero in Hero.MainHero.ExSpouses)
                    {
                        if (!hero.IsDead && hero.Age > targetAge + 1)
                        {
                            var birthday = CampaignTime.Now - CampaignTime.Years(targetAge);
                            hero.SetBirthDay(birthday);
                        }

                    }
                }



            }));
            
        }
    }
}
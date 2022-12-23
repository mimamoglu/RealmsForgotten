// Decompiled with JetBrains decompiler
// Type: RealmsForgotten.RFCharacterCreationContent
// Assembly: RealmsForgotten, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B26E324A-F09C-4542-BFFC-02D91686071A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\RF_Core\bin\Win64_Shipping_Client\RealmsForgotten.dll

using Helpers;
using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.GameState;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace RealmsForgotten
{
  public class RFCharacterCreationContent : SandboxCharacterCreationContent
  {
    protected new readonly Dictionary<string, Vec2> _startingPoints = new Dictionary<string, Vec2>()
    {
      {
        "empire",
        new Vec2(296.03f, 646.27f)
      },
      {
        "sturgia",
        new Vec2(697.85f, 721.67f)
      },
      {
        "aserai",
        new Vec2(642.16f, 240.77f)
      },
      {
        "battania",
        new Vec2(446.58f, 460.19f)
      },
      {
        "khuzait",
        new Vec2(43.49f, 733.3f)
      },
      {
        "vlandia",
        new Vec2(667.2f, 442.22f)
      }
    };
    private const string Athas = "<BodyProperties version=\"4\" age=\"22.23\" weight=\"0.0448\" build=\"0.6065\"  key=\"003FB40FCE001016AF9E6DFC6B0756871FF2FD9D8031BB1327CCC0244CAB9C060069160306EC96D8000000000000000000000000000000000000000010CC1004\"  />";
    private const string Nasoria = "<BodyProperties version=\"4\" age=\"40\" weight=\"0.8288\" build=\"0.4213\"  key=\"001EAC0B80000004FFC53FE76E83CCEA36A3EC6D8174DF4070129ADF3E13E54B0366C6350684B8A7000000000000000000000000000000000000000026CC7002\"  />";
    private const string AllKhuur = "<BodyProperties version=\"4\" age=\"22.49\" weight=\"0.9599\" build=\"0.3611\"  key=\"001EF80D8000200AB8708BB6CDC85229D3698B3ABDFE344CD22D3DD5388988680355E6350596723B0000000000000000000000000000000000000000609C1005\"  />";
    private const string Elvean = "<BodyProperties version=\"4\" age=\"22.49\" weight=\"0.0262\" build=\"0.5108\"  key=\"00000400000000038788080F07757777F0F887F8F88008888E068A89808D80060078060307883F10000000000000000000000000000000000000000052F47145\"  />";
    private const string Human = "<BodyProperties version=\"4\" age=\"22.35\" weight=\"0.5417\" build=\"0.5231\"  key=\"000DF00FC00033CD8771188F38770F8801F188778888888888888888546AF0F90088860308888888000000000000000000000000000000000000000043044144\"  />";
    private const string Undead = "<BodyProperties version=\"4\" age=\"40\" weight=\"0.2978\" build=\"0.9522\"  key=\"000004001900178D18E0788057F760886F8707E84EA8E18174414A490D1100E803BE46350BA7B7A50000000000000000000000000000000000000000016430C6\"  />";

    public override TextObject ReviewPageDescription => new TextObject("{=W6pKpEoT}You prepare to set off for a grand adventure! Here is your character. Continue if you are ready, or go back to make changes.");

    public override IEnumerable<Type> CharacterCreationStages
    {
      get
      {
        yield return typeof (CharacterCreationCultureStage);
        yield return typeof (CharacterCreationFaceGeneratorStage);
        yield return typeof (CharacterCreationGenericStage);
        yield return typeof (CharacterCreationBannerEditorStage);
        yield return typeof (CharacterCreationClanNamingStage);
        yield return typeof (CharacterCreationReviewStage);
        yield return typeof (CharacterCreationOptionsStage);
      }
    }

    protected override void OnCultureSelected()
    {
      this.SelectedTitleType = 1;
      this.SelectedParentType = 0;
      TextObject clanNameforPlayer = FactionHelper.GenerateClanNameforPlayer();
      Clan.PlayerClan.ChangeClanName(clanNameforPlayer, clanNameforPlayer);
      CharacterObject playerCharacter = CharacterObject.PlayerCharacter;
      string keyValue = (string) null;
      switch (playerCharacter.Culture.StringId)
      {
        case "aserai":
          keyValue = "<BodyProperties version=\"4\" age=\"22.23\" weight=\"0.0448\" build=\"0.6065\"  key=\"003FB40FCE001016AF9E6DFC6B0756871FF2FD9D8031BB1327CCC0244CAB9C060069160306EC96D8000000000000000000000000000000000000000010CC1004\"  />";
          break;
        case "vlandia":
          keyValue = "<BodyProperties version=\"4\" age=\"40\" weight=\"0.8288\" build=\"0.4213\"  key=\"001EAC0B80000004FFC53FE76E83CCEA36A3EC6D8174DF4070129ADF3E13E54B0366C6350684B8A7000000000000000000000000000000000000000026CC7002\"  />";
          break;
        case "battania":
          keyValue = "<BodyProperties version=\"4\" age=\"22.49\" weight=\"0.0262\" build=\"0.5108\"  key=\"00000400000000038788080F07757777F0F887F8F88008888E068A89808D80060078060307883F10000000000000000000000000000000000000000052F47145\"  />";
          break;
        case "sturgia":
          keyValue = "<BodyProperties version=\"4\" age=\"40\" weight=\"0.2978\" build=\"0.9522\"  key=\"000004001900178D18E0788057F760886F8707E84EA8E18174414A490D1100E803BE46350BA7B7A50000000000000000000000000000000000000000016430C6\"  />";
          break;
        case "empire":
          keyValue = "<BodyProperties version=\"4\" age=\"22.35\" weight=\"0.5417\" build=\"0.5231\"  key=\"000DF00FC00033CD8771188F38770F8801F188778888888888888888546AF0F90088860308888888000000000000000000000000000000000000000043044144\"  />";
          break;
        case "khuzait":
          keyValue = "<BodyProperties version=\"4\" age=\"22.49\" weight=\"0.9599\" build=\"0.3611\"  key=\"001EF80D8000200AB8708BB6CDC85229D3698B3ABDFE344CD22D3DD5388988680355E6350596723B0000000000000000000000000000000000000000609C1005\"  />";
          break;
      }
      BodyProperties bodyProperties;
      BodyProperties.FromString(keyValue, out bodyProperties);
      playerCharacter.UpdatePlayerCharacterBodyProperties(bodyProperties, playerCharacter.Race, playerCharacter.IsFemale);
    }

    public override int GetSelectedParentType() => this.SelectedParentType;

    public override void OnCharacterCreationFinalized()
    {
      Vec2 vec2;
      if (this._startingPoints.TryGetValue(CharacterObject.PlayerCharacter.Culture.StringId, out vec2))
      {
        MobileParty.MainParty.Position2D = vec2;
      }
      else
      {
        MobileParty.MainParty.Position2D = Campaign.Current.DefaultStartingPosition;
        Debug.FailedAssert("Selected culture is not in the dictionary!", "C:\\Develop\\mb3\\Source\\Bannerlord\\TaleWorlds.CampaignSystem\\CharacterCreationContent\\RFCharacterCreationContent.cs", nameof (OnCharacterCreationFinalized), 125);
      }
      if (GameStateManager.Current.ActiveState is MapState activeState)
      {
        activeState.Handler.ResetCamera(true, true);
        activeState.Handler.TeleportCameraToMainParty();
      }
      this.SetHeroAge((float) this._startingAge);
    }

    protected override void OnInitialized(CharacterCreation characterCreation)
    {
      this.AddParentsMenu(characterCreation);
      this.AddChildhoodMenu(characterCreation);
      this.AddEducationMenu(characterCreation);
      this.AddYouthMenu(characterCreation);
      this.AddAdulthoodMenu(characterCreation);
      this.AddAgeSelectionMenu(characterCreation);
    }

    protected new void AddParentsMenu(CharacterCreation characterCreation)
    {
      CharacterCreationMenu menu = new CharacterCreationMenu(new TextObject("{=b4lDDcli}Family"), new TextObject("{=XgFU1pCx}You were born into a family of..."), new CharacterCreationOnInit(((SandboxCharacterCreationContent) this).ParentsOnInit));
      CharacterCreationCategory creationCategory1 = menu.AddMenuCategory(new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).EmpireParentsOnCondition));
      List<SkillObject> effectedSkills1 = new List<SkillObject>()
      {
        DefaultSkills.Riding,
        DefaultSkills.Polearm
      };
      CharacterAttribute vigor1 = DefaultCharacterAttributes.Vigor;
      creationCategory1.AddCategoryOption(new TextObject("Direct Descendants of the first people."), effectedSkills1, vigor1, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition) null, new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).EmpireLandlordsRetainerOnConsequence), new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).EmpireLandlordsRetainerOnApply), new TextObject("{=ivKl4mV2}Descending from the ruler´s bloodline of the First People - the ancestors that made the pilgrimage to Aeurth - your father was a leader among his village and the cousin of the King of his Realm. He rode with the lord´s cavalry, fighting as an armored lancer."));
      List<SkillObject> effectedSkills2 = new List<SkillObject>()
      {
        DefaultSkills.Trade,
        DefaultSkills.Charm
      };
      CharacterAttribute social1 = DefaultCharacterAttributes.Social;
      creationCategory1.AddCategoryOption(new TextObject("{=651FhzdR}Urban merchants"), effectedSkills2, social1, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition) null, new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).EmpireMerchantOnConsequence), new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).EmpireMerchantOnApply), new TextObject("{=FQntPChs}Your family were merchants in one of the main cities of the Kingdoms of Man. They sometimes organized caravans to nearby towns, and discussed issues in the town council."));
      List<SkillObject> effectedSkills3 = new List<SkillObject>()
      {
        DefaultSkills.Athletics,
        DefaultSkills.Polearm
      };
      CharacterAttribute endurance1 = DefaultCharacterAttributes.Endurance;
      creationCategory1.AddCategoryOption(new TextObject("Free Farmers"), effectedSkills3, endurance1, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition) null, new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).EmpireFreeholderOnConsequence), new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).EmpireFreeholderOnApply), new TextObject("{=09z8Q08f}Your family were small farmers with just enough land to feed themselves and make a small profit. People like them were the pillars of the realm rural economy, as well as the backbone of the levy."));
      List<SkillObject> effectedSkills4 = new List<SkillObject>()
      {
        DefaultSkills.Crafting,
        DefaultSkills.Crossbow
      };
      CharacterAttribute intelligence1 = DefaultCharacterAttributes.Intelligence;
      creationCategory1.AddCategoryOption(new TextObject("{=v48N6h1t}Urban artisans"), effectedSkills4, intelligence1, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition) null, new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).EmpireArtisanOnConsequence), new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).EmpireArtisanOnApply), new TextObject("{=ZKynvffv}Your family owned their own workshop in a city, making goods from raw materials brought in from the countryside. Your father played an active if minor role in the town council, and also served in the militia."));
      List<SkillObject> effectedSkills5 = new List<SkillObject>()
      {
        DefaultSkills.Scouting,
        DefaultSkills.Bow
      };
      CharacterAttribute control1 = DefaultCharacterAttributes.Control;
      creationCategory1.AddCategoryOption(new TextObject("Forestcaretakers"), effectedSkills5, control1, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition) null, new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).EmpireWoodsmanOnConsequence), new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).EmpireWoodsmanOnApply), new TextObject("Your family lived in a village, but did not own their own land. Instead, your father supplemented paid jobs with long trips in the woods, hunting and trapping, always keeping a wary eye for the lord's game wardens."));
      List<SkillObject> effectedSkills6 = new List<SkillObject>()
      {
        DefaultSkills.Roguery,
        DefaultSkills.Throwing
      };
      CharacterAttribute cunning1 = DefaultCharacterAttributes.Cunning;
      creationCategory1.AddCategoryOption(new TextObject("{=aEke8dSb}Urban vagabonds"), effectedSkills6, cunning1, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition) null, new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).EmpireVagabondOnConsequence), new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).EmpireVagabondOnApply), new TextObject("{=Jvf6K7TZ}Your family numbered among the many poor migrants living in the slums that grow up outside the walls of cities, making whatever money they could from a variety of odd jobs. Sometimes they did service for one of the many criminal gangs, and you had an early look at the dark side of life."));
      CharacterCreationCategory creationCategory2 = menu.AddMenuCategory(new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).VlandianParentsOnCondition));
      List<SkillObject> effectedSkills7 = new List<SkillObject>()
      {
        DefaultSkills.Riding,
        DefaultSkills.Polearm
      };
      CharacterAttribute social2 = DefaultCharacterAttributes.Social;
      creationCategory2.AddCategoryOption(new TextObject("Retainers of the Qairth"), effectedSkills7, social2, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition) null, new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).VlandiaBaronsRetainerOnConsequence), new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).VlandiaBaronsRetainerOnApply), new TextObject("Your father was a bailiff for a local Qairth. He looked after his Qairth's estates, resolved disputes in the village, and helped train the village levy. He rode with the Qairth's cavalry, fighting as an armored knight."));
      List<SkillObject> effectedSkills8 = new List<SkillObject>()
      {
        DefaultSkills.Trade,
        DefaultSkills.Charm
      };
      CharacterAttribute intelligence2 = DefaultCharacterAttributes.Intelligence;
      creationCategory2.AddCategoryOption(new TextObject("Guildmerchants"), effectedSkills8, intelligence2, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition) null, new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).VlandiaMerchantOnConsequence), new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).VlandiaMerchantOnApply), new TextObject("{=qNZFkxJb}Your family were merchants in one of the main cities of the kingdom. They organized caravans to nearby towns and were active in the local merchant's guild."));
      List<SkillObject> effectedSkills9 = new List<SkillObject>()
      {
        DefaultSkills.Polearm,
        DefaultSkills.Crossbow
      };
      CharacterAttribute endurance2 = DefaultCharacterAttributes.Endurance;
      creationCategory2.AddCategoryOption(new TextObject("Aldenari"), effectedSkills9, endurance2, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition) null, new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).VlandiaYeomanOnConsequence), new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).VlandiaYeomanOnApply), new TextObject("{=BLZ4mdhb}Your family were small farmers with just enough land to feed themselves and make a small profit. People like them were the pillars of the kingdom's economy, as well as the backbone of the levy."));
      List<SkillObject> effectedSkills10 = new List<SkillObject>()
      {
        DefaultSkills.Crafting,
        DefaultSkills.TwoHanded
      };
      CharacterAttribute vigor2 = DefaultCharacterAttributes.Vigor;
      creationCategory2.AddCategoryOption(new TextObject("{=p2KIhGbE}Urban blacksmith"), effectedSkills10, vigor2, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition) null, new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).VlandiaBlacksmithOnConsequence), new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).VlandiaBlacksmithOnApply), new TextObject("{=btsMpRcA}Your family owned a smithy in a city. Your father played an active if minor role in the town council, and also served in the militia."));
      List<SkillObject> effectedSkills11 = new List<SkillObject>()
      {
        DefaultSkills.Scouting,
        DefaultSkills.Crossbow
      };
      CharacterAttribute control2 = DefaultCharacterAttributes.Control;
      creationCategory2.AddCategoryOption(new TextObject("{=YcnK0Thk}Hunters"), effectedSkills11, control2, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition) null, new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).VlandiaHunterOnConsequence), new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).VlandiaHunterOnApply), new TextObject("{=yRFSzSDZ}Your family lived in a village, but did not own their own land. Instead, your father supplemented paid jobs with long trips in the woods, hunting and trapping, always keeping a wary eye for the lord's game wardens."));
      List<SkillObject> effectedSkills12 = new List<SkillObject>()
      {
        DefaultSkills.Roguery,
        DefaultSkills.Crossbow
      };
      CharacterAttribute cunning2 = DefaultCharacterAttributes.Cunning;
      creationCategory2.AddCategoryOption(new TextObject("{=ipQP6aVi}Mercenaries"), effectedSkills12, cunning2, this.FocusToAdd, this.SkillLevelToAdd, this.AttributeLevelToAdd, (CharacterCreationOnCondition) null, new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).VlandiaMercenaryOnConsequence), new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).VlandiaMercenaryOnApply), new TextObject("Your father joined one of the East many mercenary companies, composed of men who got such a taste for war in their clan's service that they never took well to peace. Their crossbowmen were much valued across the world. Your mother was a camp follower, taking you along in the wake of bloody campaigns."));
      CharacterCreationCategory creationCategory3 = menu.AddMenuCategory(new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).SturgianParentsOnCondition));
      CharacterCreationCategory creationCategory4 = creationCategory3;
      TextObject text1 = new TextObject("Servants of the Undead");
      List<SkillObject> effectedSkills13 = new List<SkillObject>();
      effectedSkills13.Add(DefaultSkills.Riding);
      effectedSkills13.Add(DefaultSkills.TwoHanded);
      CharacterAttribute social3 = DefaultCharacterAttributes.Social;
      int focusToAdd1 = this.FocusToAdd;
      int skillLevelToAdd1 = this.SkillLevelToAdd;
      int attributeLevelToAdd1 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect1 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).SturgiaBoyarsCompanionOnConsequence);
      CharacterCreationApplyFinalEffects onApply1 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).SturgiaBoyarsCompanionOnApply);
      TextObject descriptionText1 = new TextObject("Your family served the Undead.");
      creationCategory4.AddCategoryOption(text1, effectedSkills13, social3, focusToAdd1, skillLevelToAdd1, attributeLevelToAdd1, (CharacterCreationOnCondition) null, onSelect1, onApply1, descriptionText1);
      CharacterCreationCategory creationCategory5 = creationCategory3;
      TextObject text2 = new TextObject("{=HqzVBfpl}Urban traders");
      List<SkillObject> effectedSkills14 = new List<SkillObject>();
      effectedSkills14.Add(DefaultSkills.Trade);
      effectedSkills14.Add(DefaultSkills.Tactics);
      CharacterAttribute cunning3 = DefaultCharacterAttributes.Cunning;
      int focusToAdd2 = this.FocusToAdd;
      int skillLevelToAdd2 = this.SkillLevelToAdd;
      int attributeLevelToAdd2 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect2 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).SturgiaTraderOnConsequence);
      CharacterCreationApplyFinalEffects onApply2 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).SturgiaTraderOnApply);
      TextObject descriptionText2 = new TextObject("Your family were merchants who lived in one of the land's great river ports, organizing the shipment of goods to faraway lands.");
      creationCategory5.AddCategoryOption(text2, effectedSkills14, cunning3, focusToAdd2, skillLevelToAdd2, attributeLevelToAdd2, (CharacterCreationOnCondition) null, onSelect2, onApply2, descriptionText2);
      CharacterCreationCategory creationCategory6 = creationCategory3;
      TextObject text3 = new TextObject("Farmers");
      List<SkillObject> effectedSkills15 = new List<SkillObject>();
      effectedSkills15.Add(DefaultSkills.Athletics);
      effectedSkills15.Add(DefaultSkills.Polearm);
      CharacterAttribute endurance3 = DefaultCharacterAttributes.Endurance;
      int focusToAdd3 = this.FocusToAdd;
      int skillLevelToAdd3 = this.SkillLevelToAdd;
      int attributeLevelToAdd3 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect3 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).SturgiaFreemanOnConsequence);
      CharacterCreationApplyFinalEffects onApply3 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).SturgiaFreemanOnApply);
      TextObject descriptionText3 = new TextObject("{=Mcd3ZyKq}Your family had just enough land to feed themselves and make a small profit. People like them were the pillars of the kingdom's economy, as well as the backbone of the levy.");
      creationCategory6.AddCategoryOption(text3, effectedSkills15, endurance3, focusToAdd3, skillLevelToAdd3, attributeLevelToAdd3, (CharacterCreationOnCondition) null, onSelect3, onApply3, descriptionText3);
      CharacterCreationCategory creationCategory7 = creationCategory3;
      TextObject text4 = new TextObject("{=v48N6h1t}Urban artisans");
      List<SkillObject> effectedSkills16 = new List<SkillObject>();
      effectedSkills16.Add(DefaultSkills.Crafting);
      effectedSkills16.Add(DefaultSkills.OneHanded);
      CharacterAttribute intelligence3 = DefaultCharacterAttributes.Intelligence;
      int focusToAdd4 = this.FocusToAdd;
      int skillLevelToAdd4 = this.SkillLevelToAdd;
      int attributeLevelToAdd4 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect4 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).SturgiaArtisanOnConsequence);
      CharacterCreationApplyFinalEffects onApply4 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).SturgiaArtisanOnApply);
      TextObject descriptionText4 = new TextObject("{=ueCm5y1C}Your family owned their own workshop in a city, making goods from raw materials brought in from the countryside. Your father played an active if minor role in the town council, and also served in the militia.");
      creationCategory7.AddCategoryOption(text4, effectedSkills16, intelligence3, focusToAdd4, skillLevelToAdd4, attributeLevelToAdd4, (CharacterCreationOnCondition) null, onSelect4, onApply4, descriptionText4);
      CharacterCreationCategory creationCategory8 = creationCategory3;
      TextObject text5 = new TextObject("Forestfolk");
      List<SkillObject> effectedSkills17 = new List<SkillObject>();
      effectedSkills17.Add(DefaultSkills.Scouting);
      effectedSkills17.Add(DefaultSkills.Bow);
      CharacterAttribute vigor3 = DefaultCharacterAttributes.Vigor;
      int focusToAdd5 = this.FocusToAdd;
      int skillLevelToAdd5 = this.SkillLevelToAdd;
      int attributeLevelToAdd5 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect5 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).SturgiaHunterOnConsequence);
      CharacterCreationApplyFinalEffects onApply5 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).SturgiaHunterOnApply);
      TextObject descriptionText5 = new TextObject("Your family had no taste for authority of others. They made their living deep in the woods, slashing and burning fields which they tended for a year or two before moving on. They hunted and trapped fox, hare, ermine, and other fur-bearing animals.");
      creationCategory8.AddCategoryOption(text5, effectedSkills17, vigor3, focusToAdd5, skillLevelToAdd5, attributeLevelToAdd5, (CharacterCreationOnCondition) null, onSelect5, onApply5, descriptionText5);
      CharacterCreationCategory creationCategory9 = creationCategory3;
      TextObject text6 = new TextObject("{=TPoK3GSj}Vagabonds");
      List<SkillObject> effectedSkills18 = new List<SkillObject>();
      effectedSkills18.Add(DefaultSkills.Roguery);
      effectedSkills18.Add(DefaultSkills.Throwing);
      CharacterAttribute control3 = DefaultCharacterAttributes.Control;
      int focusToAdd6 = this.FocusToAdd;
      int skillLevelToAdd6 = this.SkillLevelToAdd;
      int attributeLevelToAdd6 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect6 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).SturgiaVagabondOnConsequence);
      CharacterCreationApplyFinalEffects onApply6 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).SturgiaVagabondOnApply);
      TextObject descriptionText6 = new TextObject("{=2SDWhGmQ}Your family numbered among the poor migrants living in the slums that grow up outside the walls of the river cities, making whatever money they could from a variety of odd jobs. Sometimes they did services for one of the region's many criminal gangs.");
      creationCategory9.AddCategoryOption(text6, effectedSkills18, control3, focusToAdd6, skillLevelToAdd6, attributeLevelToAdd6, (CharacterCreationOnCondition) null, onSelect6, onApply6, descriptionText6);
      CharacterCreationCategory creationCategory10 = menu.AddMenuCategory(new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).AseraiParentsOnCondition));
      CharacterCreationCategory creationCategory11 = creationCategory10;
      TextObject text7 = new TextObject("The inner circle of Atha's rulers");
      List<SkillObject> effectedSkills19 = new List<SkillObject>();
      effectedSkills19.Add(DefaultSkills.Riding);
      effectedSkills19.Add(DefaultSkills.Throwing);
      CharacterAttribute endurance4 = DefaultCharacterAttributes.Endurance;
      int focusToAdd7 = this.FocusToAdd;
      int skillLevelToAdd7 = this.SkillLevelToAdd;
      int attributeLevelToAdd7 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect7 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AseraiTribesmanOnConsequence);
      CharacterCreationApplyFinalEffects onApply7 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AseraiTribesmanOnApply);
      TextObject descriptionText7 = new TextObject("You were a family of some importance in the inner circle of Athas.");
      creationCategory11.AddCategoryOption(text7, effectedSkills19, endurance4, focusToAdd7, skillLevelToAdd7, attributeLevelToAdd7, (CharacterCreationOnCondition) null, onSelect7, onApply7, descriptionText7);
      CharacterCreationCategory creationCategory12 = creationCategory10;
      TextObject text8 = new TextObject("{=ngFVgwDD}Warrior-slaves");
      List<SkillObject> effectedSkills20 = new List<SkillObject>();
      effectedSkills20.Add(DefaultSkills.Riding);
      effectedSkills20.Add(DefaultSkills.Polearm);
      CharacterAttribute vigor4 = DefaultCharacterAttributes.Vigor;
      int focusToAdd8 = this.FocusToAdd;
      int skillLevelToAdd8 = this.SkillLevelToAdd;
      int attributeLevelToAdd8 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect8 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AseraiWariorSlaveOnConsequence);
      CharacterCreationApplyFinalEffects onApply8 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AseraiWariorSlaveOnApply);
      TextObject descriptionText8 = new TextObject("{=GsPC2MgU}Your father was part of one of the slave-bodyguards maintained by the rulers. He fought by his master's side with tribe's armored cavalry, and was freed - perhaps for an act of valor, or perhaps he paid for his freedom with his share of the spoils of battle. He then married your mother.");
      creationCategory12.AddCategoryOption(text8, effectedSkills20, vigor4, focusToAdd8, skillLevelToAdd8, attributeLevelToAdd8, (CharacterCreationOnCondition) null, onSelect8, onApply8, descriptionText8);
      CharacterCreationCategory creationCategory13 = creationCategory10;
      TextObject text9 = new TextObject("{=651FhzdR}Urban merchants");
      List<SkillObject> effectedSkills21 = new List<SkillObject>();
      effectedSkills21.Add(DefaultSkills.Trade);
      effectedSkills21.Add(DefaultSkills.Charm);
      CharacterAttribute social4 = DefaultCharacterAttributes.Social;
      int focusToAdd9 = this.FocusToAdd;
      int skillLevelToAdd9 = this.SkillLevelToAdd;
      int attributeLevelToAdd9 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect9 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AseraiMerchantOnConsequence);
      CharacterCreationApplyFinalEffects onApply9 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AseraiMerchantOnApply);
      TextObject descriptionText9 = new TextObject("{=1zXrlaav}Your family were respected traders in an oasis town. They ran caravans across the desert, and were experts in the finer points of negotiating passage through the desert tribes' territories.");
      creationCategory13.AddCategoryOption(text9, effectedSkills21, social4, focusToAdd9, skillLevelToAdd9, attributeLevelToAdd9, (CharacterCreationOnCondition) null, onSelect9, onApply9, descriptionText9);
      CharacterCreationCategory creationCategory14 = creationCategory10;
      TextObject text10 = new TextObject("Slave-farmers");
      List<SkillObject> effectedSkills22 = new List<SkillObject>();
      effectedSkills22.Add(DefaultSkills.Athletics);
      effectedSkills22.Add(DefaultSkills.OneHanded);
      CharacterAttribute endurance5 = DefaultCharacterAttributes.Endurance;
      int focusToAdd10 = this.FocusToAdd;
      int skillLevelToAdd10 = this.SkillLevelToAdd;
      int attributeLevelToAdd10 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect10 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AseraiOasisFarmerOnConsequence);
      CharacterCreationApplyFinalEffects onApply10 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AseraiOasisFarmerOnApply);
      TextObject descriptionText10 = new TextObject("{=5P0KqBAw}Your family tilled the soil in one of the oases of the Kalikhr tribe and tended the palm orchards that produced the desert's famous dates. Your father was a member of the main foot levy of his tribe, fighting with his kinsmen under the emir's banner.");
      creationCategory14.AddCategoryOption(text10, effectedSkills22, endurance5, focusToAdd10, skillLevelToAdd10, attributeLevelToAdd10, (CharacterCreationOnCondition) null, onSelect10, onApply10, descriptionText10);
      CharacterCreationCategory creationCategory15 = creationCategory10;
      TextObject text11 = new TextObject("Free men");
      List<SkillObject> effectedSkills23 = new List<SkillObject>();
      effectedSkills23.Add(DefaultSkills.Scouting);
      effectedSkills23.Add(DefaultSkills.Bow);
      CharacterAttribute cunning4 = DefaultCharacterAttributes.Cunning;
      int focusToAdd11 = this.FocusToAdd;
      int skillLevelToAdd11 = this.SkillLevelToAdd;
      int attributeLevelToAdd11 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect11 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AseraiBedouinOnConsequence);
      CharacterCreationApplyFinalEffects onApply11 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AseraiBedouinOnApply);
      TextObject descriptionText11 = new TextObject("{=PKhcPbBX}Your family were part of a nomadic clan, crisscrossing the wastes between wadi beds and wells to feed their herds of goats and camels on the scraggly scrubs of the Kalikhr.");
      creationCategory15.AddCategoryOption(text11, effectedSkills23, cunning4, focusToAdd11, skillLevelToAdd11, attributeLevelToAdd11, (CharacterCreationOnCondition) null, onSelect11, onApply11, descriptionText11);
      CharacterCreationCategory creationCategory16 = creationCategory10;
      TextObject text12 = new TextObject("Urban Orfans");
      List<SkillObject> effectedSkills24 = new List<SkillObject>();
      effectedSkills24.Add(DefaultSkills.Roguery);
      effectedSkills24.Add(DefaultSkills.Polearm);
      CharacterAttribute control4 = DefaultCharacterAttributes.Control;
      int focusToAdd12 = this.FocusToAdd;
      int skillLevelToAdd12 = this.SkillLevelToAdd;
      int attributeLevelToAdd12 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect12 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AseraiBackAlleyThugOnConsequence);
      CharacterCreationApplyFinalEffects onApply12 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AseraiBackAlleyThugOnApply);
      TextObject descriptionText12 = new TextObject("{=6bUSbsKC}Your father was not your biological father, but took you under his protection to one day strenghten his army of thugs. He worked for a fitiwi , one of the strongmen who keep order in the poorer quarters of the oasis towns. He resolved disputes over land, dice and insults, imposing his authority with the fitiwi's traditional staff.");
      creationCategory16.AddCategoryOption(text12, effectedSkills24, control4, focusToAdd12, skillLevelToAdd12, attributeLevelToAdd12, (CharacterCreationOnCondition) null, onSelect12, onApply12, descriptionText12);
      CharacterCreationCategory creationCategory17 = menu.AddMenuCategory(new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).BattanianParentsOnCondition));
      CharacterCreationCategory creationCategory18 = creationCategory17;
      TextObject text13 = new TextObject("Elvean Highborn");
      List<SkillObject> effectedSkills25 = new List<SkillObject>();
      effectedSkills25.Add(DefaultSkills.TwoHanded);
      effectedSkills25.Add(DefaultSkills.Bow);
      CharacterAttribute vigor5 = DefaultCharacterAttributes.Vigor;
      int focusToAdd13 = this.FocusToAdd;
      int skillLevelToAdd13 = this.SkillLevelToAdd;
      int attributeLevelToAdd13 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect13 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).BattaniaChieftainsHearthguardOnConsequence);
      CharacterCreationApplyFinalEffects onApply13 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).BattaniaChieftainsHearthguardOnApply);
      TextObject descriptionText13 = new TextObject("Your family were the trusted kinfolk of an Elvean lord, and sat at his table in his great hall. Your father assisted his chief in running the affairs and trained with the traditional weapons of the warrior elite, the two-handed sword or falx and the bow.");
      creationCategory18.AddCategoryOption(text13, effectedSkills25, vigor5, focusToAdd13, skillLevelToAdd13, attributeLevelToAdd13, (CharacterCreationOnCondition) null, onSelect13, onApply13, descriptionText13);
      CharacterCreationCategory creationCategory19 = creationCategory17;
      TextObject text14 = new TextObject("Druids");
      List<SkillObject> effectedSkills26 = new List<SkillObject>();
      effectedSkills26.Add(DefaultSkills.Medicine);
      effectedSkills26.Add(DefaultSkills.Charm);
      CharacterAttribute intelligence4 = DefaultCharacterAttributes.Intelligence;
      int focusToAdd14 = this.FocusToAdd;
      int skillLevelToAdd14 = this.SkillLevelToAdd;
      int attributeLevelToAdd14 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect14 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).BattaniaHealerOnConsequence);
      CharacterCreationApplyFinalEffects onApply14 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).BattaniaHealerOnApply);
      TextObject descriptionText14 = new TextObject("Your parents were healers who gathered herbs and treated the sick. As a living reservoir of elvean tradition, they were also asked to adjudicate many disputes between the clans.");
      creationCategory19.AddCategoryOption(text14, effectedSkills26, intelligence4, focusToAdd14, skillLevelToAdd14, attributeLevelToAdd14, (CharacterCreationOnCondition) null, onSelect14, onApply14, descriptionText14);
      CharacterCreationCategory creationCategory20 = creationCategory17;
      TextObject text15 = new TextObject("Elvean Folk");
      List<SkillObject> effectedSkills27 = new List<SkillObject>();
      effectedSkills27.Add(DefaultSkills.Athletics);
      effectedSkills27.Add(DefaultSkills.Throwing);
      CharacterAttribute control5 = DefaultCharacterAttributes.Control;
      int focusToAdd15 = this.FocusToAdd;
      int skillLevelToAdd15 = this.SkillLevelToAdd;
      int attributeLevelToAdd15 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect15 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).BattaniaTribesmanOnConsequence);
      CharacterCreationApplyFinalEffects onApply15 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).BattaniaTribesmanOnApply);
      TextObject descriptionText15 = new TextObject("Your family were middle-ranking members of a society, who tilled their own land. Your father fought with the kern, the main body of his people's warriors, joining in the screaming charges for which the Elveans were famous.");
      creationCategory20.AddCategoryOption(text15, effectedSkills27, control5, focusToAdd15, skillLevelToAdd15, attributeLevelToAdd15, (CharacterCreationOnCondition) null, onSelect15, onApply15, descriptionText15);
      CharacterCreationCategory creationCategory21 = creationCategory17;
      TextObject text16 = new TextObject("{=BCU6RezA}Smiths");
      List<SkillObject> effectedSkills28 = new List<SkillObject>();
      effectedSkills28.Add(DefaultSkills.Crafting);
      effectedSkills28.Add(DefaultSkills.TwoHanded);
      CharacterAttribute endurance6 = DefaultCharacterAttributes.Endurance;
      int focusToAdd16 = this.FocusToAdd;
      int skillLevelToAdd16 = this.SkillLevelToAdd;
      int attributeLevelToAdd16 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect16 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).BattaniaSmithOnConsequence);
      CharacterCreationApplyFinalEffects onApply16 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).BattaniaSmithOnApply);
      TextObject descriptionText16 = new TextObject("Your family were smiths, a revered profession. They crafted everything from fine filigree jewelry in geometric designs to the well-balanced longswords favored by the Elvean aristocracy.");
      creationCategory21.AddCategoryOption(text16, effectedSkills28, endurance6, focusToAdd16, skillLevelToAdd16, attributeLevelToAdd16, (CharacterCreationOnCondition) null, onSelect16, onApply16, descriptionText16);
      CharacterCreationCategory creationCategory22 = creationCategory17;
      TextObject text17 = new TextObject("{=7eWmU2mF}Foresters");
      List<SkillObject> effectedSkills29 = new List<SkillObject>();
      effectedSkills29.Add(DefaultSkills.Scouting);
      effectedSkills29.Add(DefaultSkills.Tactics);
      CharacterAttribute cunning5 = DefaultCharacterAttributes.Cunning;
      int focusToAdd17 = this.FocusToAdd;
      int skillLevelToAdd17 = this.SkillLevelToAdd;
      int attributeLevelToAdd17 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect17 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).BattaniaWoodsmanOnConsequence);
      CharacterCreationApplyFinalEffects onApply17 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).BattaniaWoodsmanOnApply);
      TextObject descriptionText17 = new TextObject("{=7jBroUUQ}Your family had little land of their own, so they earned their living from the woods, hunting and trapping. They taught you from an early age that skills like finding game trails and killing an animal with one shot could make the difference between eating and starvation.");
      creationCategory22.AddCategoryOption(text17, effectedSkills29, cunning5, focusToAdd17, skillLevelToAdd17, attributeLevelToAdd17, (CharacterCreationOnCondition) null, onSelect17, onApply17, descriptionText17);
      CharacterCreationCategory creationCategory23 = creationCategory17;
      TextObject text18 = new TextObject("{=SpJqhEEh}Bards");
      List<SkillObject> effectedSkills30 = new List<SkillObject>();
      effectedSkills30.Add(DefaultSkills.Roguery);
      effectedSkills30.Add(DefaultSkills.Charm);
      CharacterAttribute social5 = DefaultCharacterAttributes.Social;
      int focusToAdd18 = this.FocusToAdd;
      int skillLevelToAdd18 = this.SkillLevelToAdd;
      int attributeLevelToAdd18 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect18 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).BattaniaBardOnConsequence);
      CharacterCreationApplyFinalEffects onApply18 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).BattaniaBardOnApply);
      TextObject descriptionText18 = new TextObject("Your Father was a Bard, a sacred duty for the Elvean Folk. Responsible to keep the Song alive, he went from halls to festivities, from rituals to war camps, to teach and inspire the people into the sacred ways. Your learned from him the cleverness of the tongue and the hability to tap into your people´s soul.");
      creationCategory23.AddCategoryOption(text18, effectedSkills30, social5, focusToAdd18, skillLevelToAdd18, attributeLevelToAdd18, (CharacterCreationOnCondition) null, onSelect18, onApply18, descriptionText18);
      CharacterCreationCategory creationCategory24 = menu.AddMenuCategory(new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).KhuzaitParentsOnCondition));
      CharacterCreationCategory creationCategory25 = creationCategory24;
      TextObject text19 = new TextObject("Al-Kahuur Kinsfolk");
      List<SkillObject> effectedSkills31 = new List<SkillObject>();
      effectedSkills31.Add(DefaultSkills.Riding);
      effectedSkills31.Add(DefaultSkills.Polearm);
      CharacterAttribute endurance7 = DefaultCharacterAttributes.Endurance;
      int focusToAdd19 = this.FocusToAdd;
      int skillLevelToAdd19 = this.SkillLevelToAdd;
      int attributeLevelToAdd19 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect19 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).KhuzaitNoyansKinsmanOnConsequence);
      CharacterCreationApplyFinalEffects onApply19 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).KhuzaitNoyansKinsmanOnApply);
      TextObject descriptionText19 = new TextObject("Your family were the trusted kinsfolk of a ruler, and shared his meals in the chieftain's yurt. Your father assisted his chief in running the affairs of the clan and fought in the core of armored lancers in the center of a battle line.");
      creationCategory25.AddCategoryOption(text19, effectedSkills31, endurance7, focusToAdd19, skillLevelToAdd19, attributeLevelToAdd19, (CharacterCreationOnCondition) null, onSelect19, onApply19, descriptionText19);
      CharacterCreationCategory creationCategory26 = creationCategory24;
      TextObject text20 = new TextObject("{=TkgLEDRM}Merchants");
      List<SkillObject> effectedSkills32 = new List<SkillObject>();
      effectedSkills32.Add(DefaultSkills.Trade);
      effectedSkills32.Add(DefaultSkills.Charm);
      CharacterAttribute social6 = DefaultCharacterAttributes.Social;
      int focusToAdd20 = this.FocusToAdd;
      int skillLevelToAdd20 = this.SkillLevelToAdd;
      int attributeLevelToAdd20 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect20 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).KhuzaitMerchantOnConsequence);
      CharacterCreationApplyFinalEffects onApply20 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).KhuzaitMerchantOnApply);
      TextObject descriptionText20 = new TextObject("Your family came from one of the merchant clans that dominated the cities in the northwestern part of the world.");
      creationCategory26.AddCategoryOption(text20, effectedSkills32, social6, focusToAdd20, skillLevelToAdd20, attributeLevelToAdd20, (CharacterCreationOnCondition) null, onSelect20, onApply20, descriptionText20);
      CharacterCreationCategory creationCategory27 = creationCategory24;
      TextObject text21 = new TextObject("{=tGEStbxb}Tribespeople");
      List<SkillObject> effectedSkills33 = new List<SkillObject>();
      effectedSkills33.Add(DefaultSkills.Bow);
      effectedSkills33.Add(DefaultSkills.Riding);
      CharacterAttribute control6 = DefaultCharacterAttributes.Control;
      int focusToAdd21 = this.FocusToAdd;
      int skillLevelToAdd21 = this.SkillLevelToAdd;
      int attributeLevelToAdd21 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect21 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).KhuzaitTribesmanOnConsequence);
      CharacterCreationApplyFinalEffects onApply21 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).KhuzaitTribesmanOnApply);
      TextObject descriptionText21 = new TextObject("Your family were middle-ranking members of one of the clans. They had some herds of thier own, but were not rich. ");
      creationCategory27.AddCategoryOption(text21, effectedSkills33, control6, focusToAdd21, skillLevelToAdd21, attributeLevelToAdd21, (CharacterCreationOnCondition) null, onSelect21, onApply21, descriptionText21);
      CharacterCreationCategory creationCategory28 = creationCategory24;
      TextObject text22 = new TextObject("{=gQ2tAvCz}Farmers");
      List<SkillObject> effectedSkills34 = new List<SkillObject>();
      effectedSkills34.Add(DefaultSkills.Polearm);
      effectedSkills34.Add(DefaultSkills.Throwing);
      CharacterAttribute vigor6 = DefaultCharacterAttributes.Vigor;
      int focusToAdd22 = this.FocusToAdd;
      int skillLevelToAdd22 = this.SkillLevelToAdd;
      int attributeLevelToAdd22 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect22 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).KhuzaitFarmerOnConsequence);
      CharacterCreationApplyFinalEffects onApply22 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).KhuzaitFarmerOnApply);
      TextObject descriptionText22 = new TextObject("Your family tilled one of the small patches of arable land in the steppes for generations.");
      creationCategory28.AddCategoryOption(text22, effectedSkills34, vigor6, focusToAdd22, skillLevelToAdd22, attributeLevelToAdd22, (CharacterCreationOnCondition) null, onSelect22, onApply22, descriptionText22);
      CharacterCreationCategory creationCategory29 = creationCategory24;
      TextObject text23 = new TextObject("Spirit-Chatchers");
      List<SkillObject> effectedSkills35 = new List<SkillObject>();
      effectedSkills35.Add(DefaultSkills.Medicine);
      effectedSkills35.Add(DefaultSkills.Charm);
      CharacterAttribute intelligence5 = DefaultCharacterAttributes.Intelligence;
      int focusToAdd23 = this.FocusToAdd;
      int skillLevelToAdd23 = this.SkillLevelToAdd;
      int attributeLevelToAdd23 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect23 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).KhuzaitShamanOnConsequence);
      CharacterCreationApplyFinalEffects onApply23 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).KhuzaitShamanOnApply);
      TextObject descriptionText23 = new TextObject("Your family were guardians of the sacred traditions, channelling the spirits of the wilderness and of the ancestors. They tended the sick and dispensed wisdom, resolving disputes and providing practical advice.");
      creationCategory29.AddCategoryOption(text23, effectedSkills35, intelligence5, focusToAdd23, skillLevelToAdd23, attributeLevelToAdd23, (CharacterCreationOnCondition) null, onSelect23, onApply23, descriptionText23);
      CharacterCreationCategory creationCategory30 = creationCategory24;
      TextObject text24 = new TextObject("{=Xqba1Obq}Nomads");
      List<SkillObject> effectedSkills36 = new List<SkillObject>();
      effectedSkills36.Add(DefaultSkills.Scouting);
      effectedSkills36.Add(DefaultSkills.Riding);
      CharacterAttribute cunning6 = DefaultCharacterAttributes.Cunning;
      int focusToAdd24 = this.FocusToAdd;
      int skillLevelToAdd24 = this.SkillLevelToAdd;
      int attributeLevelToAdd24 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect24 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).KhuzaitNomadOnConsequence);
      CharacterCreationApplyFinalEffects onApply24 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).KhuzaitNomadOnApply);
      TextObject descriptionText24 = new TextObject("{=9aoQYpZs}Your family's clan never pledged its loyalty to the khan and never settled down, preferring to live out in the deep steppe away from his authority. They remain some of the finest trackers and scouts in the grasslands, as the ability to spot an enemy coming and move quickly is often all that protects their herds from their neighbors' predations.");
      creationCategory30.AddCategoryOption(text24, effectedSkills36, cunning6, focusToAdd24, skillLevelToAdd24, attributeLevelToAdd24, (CharacterCreationOnCondition) null, onSelect24, onApply24, descriptionText24);
      characterCreation.AddNewMenu(menu);
    }

    protected new void AddChildhoodMenu(CharacterCreation characterCreation)
    {
      CharacterCreationMenu menu = new CharacterCreationMenu(new TextObject("{=8Yiwt1z6}Early Childhood"), new TextObject("{=character_creation_content_16}As a child you were noted for..."), new CharacterCreationOnInit(((SandboxCharacterCreationContent) this).ChildhoodOnInit));
      CharacterCreationCategory creationCategory1 = menu.AddMenuCategory();
      CharacterCreationCategory creationCategory2 = creationCategory1;
      TextObject text1 = new TextObject("{=kmM68Qx4}your leadership skills.");
      List<SkillObject> effectedSkills1 = new List<SkillObject>();
      effectedSkills1.Add(DefaultSkills.Leadership);
      effectedSkills1.Add(DefaultSkills.Tactics);
      CharacterAttribute cunning = DefaultCharacterAttributes.Cunning;
      int focusToAdd1 = this.FocusToAdd;
      int skillLevelToAdd1 = this.SkillLevelToAdd;
      int attributeLevelToAdd1 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect1 = new CharacterCreationOnSelect(SandboxCharacterCreationContent.ChildhoodYourLeadershipSkillsOnConsequence);
      CharacterCreationApplyFinalEffects onApply1 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.ChildhoodGoodLeadingOnApply);
      TextObject descriptionText1 = new TextObject("{=FfNwXtii}If the wolf pup gang of your early childhood had an alpha, it was definitely you. All the other kids followed your lead as you decided what to play and where to play, and led them in games and mischief.");
      creationCategory2.AddCategoryOption(text1, effectedSkills1, cunning, focusToAdd1, skillLevelToAdd1, attributeLevelToAdd1, (CharacterCreationOnCondition) null, onSelect1, onApply1, descriptionText1);
      CharacterCreationCategory creationCategory3 = creationCategory1;
      TextObject text2 = new TextObject("{=5HXS8HEY}your brawn.");
      List<SkillObject> effectedSkills2 = new List<SkillObject>();
      effectedSkills2.Add(DefaultSkills.TwoHanded);
      effectedSkills2.Add(DefaultSkills.Throwing);
      CharacterAttribute vigor = DefaultCharacterAttributes.Vigor;
      int focusToAdd2 = this.FocusToAdd;
      int skillLevelToAdd2 = this.SkillLevelToAdd;
      int attributeLevelToAdd2 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect2 = new CharacterCreationOnSelect(SandboxCharacterCreationContent.ChildhoodYourBrawnOnConsequence);
      CharacterCreationApplyFinalEffects onApply2 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.ChildhoodGoodAthleticsOnApply);
      TextObject descriptionText2 = new TextObject("{=YKzuGc54}You were big, and other children looked to have you around in any scrap with children from a neighboring village. You pushed a plough and throw an axe like an adult.");
      creationCategory3.AddCategoryOption(text2, effectedSkills2, vigor, focusToAdd2, skillLevelToAdd2, attributeLevelToAdd2, (CharacterCreationOnCondition) null, onSelect2, onApply2, descriptionText2);
      CharacterCreationCategory creationCategory4 = creationCategory1;
      TextObject text3 = new TextObject("{=QrYjPUEf}your attention to detail.");
      List<SkillObject> effectedSkills3 = new List<SkillObject>();
      effectedSkills3.Add(DefaultSkills.Athletics);
      effectedSkills3.Add(DefaultSkills.Bow);
      CharacterAttribute control = DefaultCharacterAttributes.Control;
      int focusToAdd3 = this.FocusToAdd;
      int skillLevelToAdd3 = this.SkillLevelToAdd;
      int attributeLevelToAdd3 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect3 = new CharacterCreationOnSelect(SandboxCharacterCreationContent.ChildhoodAttentionToDetailOnConsequence);
      CharacterCreationApplyFinalEffects onApply3 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.ChildhoodGoodMemoryOnApply);
      TextObject descriptionText3 = new TextObject("{=JUSHAPnu}You were quick on your feet and attentive to what was going on around you. Usually you could run away from trouble, though you could give a good account of yourself in a fight with other children if cornered.");
      creationCategory4.AddCategoryOption(text3, effectedSkills3, control, focusToAdd3, skillLevelToAdd3, attributeLevelToAdd3, (CharacterCreationOnCondition) null, onSelect3, onApply3, descriptionText3);
      CharacterCreationCategory creationCategory5 = creationCategory1;
      TextObject text4 = new TextObject("{=Y3UcaX74}your aptitude for numbers.");
      List<SkillObject> effectedSkills4 = new List<SkillObject>();
      effectedSkills4.Add(DefaultSkills.Engineering);
      effectedSkills4.Add(DefaultSkills.Trade);
      CharacterAttribute intelligence = DefaultCharacterAttributes.Intelligence;
      int focusToAdd4 = this.FocusToAdd;
      int skillLevelToAdd4 = this.SkillLevelToAdd;
      int attributeLevelToAdd4 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect4 = new CharacterCreationOnSelect(SandboxCharacterCreationContent.ChildhoodAptitudeForNumbersOnConsequence);
      CharacterCreationApplyFinalEffects onApply4 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.ChildhoodGoodMathOnApply);
      TextObject descriptionText4 = new TextObject("{=DFidSjIf}Most children around you had only the most rudimentary education, but you lingered after class to study letters and mathematics. You were fascinated by the marketplace - weights and measures, tallies and accounts, the chatter about profits and losses.");
      creationCategory5.AddCategoryOption(text4, effectedSkills4, intelligence, focusToAdd4, skillLevelToAdd4, attributeLevelToAdd4, (CharacterCreationOnCondition) null, onSelect4, onApply4, descriptionText4);
      CharacterCreationCategory creationCategory6 = creationCategory1;
      TextObject text5 = new TextObject("{=GEYzLuwb}your way with people.");
      List<SkillObject> effectedSkills5 = new List<SkillObject>();
      effectedSkills5.Add(DefaultSkills.Charm);
      effectedSkills5.Add(DefaultSkills.Leadership);
      CharacterAttribute social = DefaultCharacterAttributes.Social;
      int focusToAdd5 = this.FocusToAdd;
      int skillLevelToAdd5 = this.SkillLevelToAdd;
      int attributeLevelToAdd5 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect5 = new CharacterCreationOnSelect(SandboxCharacterCreationContent.ChildhoodWayWithPeopleOnConsequence);
      CharacterCreationApplyFinalEffects onApply5 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.ChildhoodGoodMannersOnApply);
      TextObject descriptionText5 = new TextObject("{=w2TEQq26}You were always attentive to other people, good at guessing their motivations. You studied how individuals were swayed, and tried out what you learned from adults on your friends.");
      creationCategory6.AddCategoryOption(text5, effectedSkills5, social, focusToAdd5, skillLevelToAdd5, attributeLevelToAdd5, (CharacterCreationOnCondition) null, onSelect5, onApply5, descriptionText5);
      CharacterCreationCategory creationCategory7 = creationCategory1;
      TextObject text6 = new TextObject("{=MEgLE2kj}your skill with horses.");
      List<SkillObject> effectedSkills6 = new List<SkillObject>();
      effectedSkills6.Add(DefaultSkills.Riding);
      effectedSkills6.Add(DefaultSkills.Medicine);
      CharacterAttribute endurance = DefaultCharacterAttributes.Endurance;
      int focusToAdd6 = this.FocusToAdd;
      int skillLevelToAdd6 = this.SkillLevelToAdd;
      int attributeLevelToAdd6 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect6 = new CharacterCreationOnSelect(SandboxCharacterCreationContent.ChildhoodSkillsWithHorsesOnConsequence);
      CharacterCreationApplyFinalEffects onApply6 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.ChildhoodAffinityWithAnimalsOnApply);
      TextObject descriptionText6 = new TextObject("{=ngazFofr}You were always drawn to animals, and spent as much time as possible hanging out in the village stables. You could calm horses, and were sometimes called upon to break in new colts. You learned the basics of veterinary arts, much of which is applicable to humans as well.");
      creationCategory7.AddCategoryOption(text6, effectedSkills6, endurance, focusToAdd6, skillLevelToAdd6, attributeLevelToAdd6, (CharacterCreationOnCondition) null, onSelect6, onApply6, descriptionText6);
      characterCreation.AddNewMenu(menu);
    }

    protected new void AddEducationMenu(CharacterCreation characterCreation)
    {
      CharacterCreationMenu menu = new CharacterCreationMenu(new TextObject("{=rcoueCmk}Adolescence"), this._educationIntroductoryText, new CharacterCreationOnInit(((SandboxCharacterCreationContent) this).EducationOnInit));
      CharacterCreationCategory creationCategory1 = menu.AddMenuCategory();
      CharacterCreationCategory creationCategory2 = creationCategory1;
      TextObject text1 = new TextObject("{=RKVNvimC}herded the sheep.");
      List<SkillObject> effectedSkills1 = new List<SkillObject>();
      effectedSkills1.Add(DefaultSkills.Athletics);
      effectedSkills1.Add(DefaultSkills.Throwing);
      CharacterAttribute control1 = DefaultCharacterAttributes.Control;
      int focusToAdd1 = this.FocusToAdd;
      int skillLevelToAdd1 = this.SkillLevelToAdd;
      int attributeLevelToAdd1 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition1 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).RuralAdolescenceOnCondition);
      CharacterCreationOnSelect onSelect1 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).RuralAdolescenceHerderOnConsequence);
      CharacterCreationApplyFinalEffects onApply1 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.RuralAdolescenceHerderOnApply);
      TextObject descriptionText1 = new TextObject("{=KfaqPpbK}You went with other fleet-footed youths to take the villages' sheep, goats or cattle to graze in pastures near the village. You were in charge of chasing down stray beasts, and always kept a big stone on hand to be hurled at lurking predators if necessary.");
      creationCategory2.AddCategoryOption(text1, effectedSkills1, control1, focusToAdd1, skillLevelToAdd1, attributeLevelToAdd1, optionCondition1, onSelect1, onApply1, descriptionText1);
      CharacterCreationCategory creationCategory3 = creationCategory1;
      TextObject text2 = new TextObject("learned the elvean ways of smithing.");
      List<SkillObject> effectedSkills2 = new List<SkillObject>();
      effectedSkills2.Add(DefaultSkills.TwoHanded);
      effectedSkills2.Add(DefaultSkills.Crafting);
      CharacterAttribute vigor1 = DefaultCharacterAttributes.Vigor;
      int focusToAdd2 = this.FocusToAdd;
      int skillLevelToAdd2 = this.SkillLevelToAdd;
      int attributeLevelToAdd2 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition2 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).BattanianParentsOnCondition);
      CharacterCreationOnSelect onSelect2 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).RuralAdolescenceSmithyOnConsequence);
      CharacterCreationApplyFinalEffects onApply2 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.RuralAdolescenceSmithyOnApply);
      TextObject descriptionText2 = new TextObject("{=y6j1bJTH}You were apprenticed to the local smith. You learned how to heat and forge metal, hammering for hours at a time until your muscles ached.");
      creationCategory3.AddCategoryOption(text2, effectedSkills2, vigor1, focusToAdd2, skillLevelToAdd2, attributeLevelToAdd2, optionCondition2, onSelect2, onApply2, descriptionText2);
      CharacterCreationCategory creationCategory4 = creationCategory1;
      TextObject text3 = new TextObject("{=tI8ZLtoA}repaired projects.");
      List<SkillObject> effectedSkills3 = new List<SkillObject>();
      effectedSkills3.Add(DefaultSkills.Crafting);
      effectedSkills3.Add(DefaultSkills.Engineering);
      CharacterAttribute intelligence1 = DefaultCharacterAttributes.Intelligence;
      int focusToAdd3 = this.FocusToAdd;
      int skillLevelToAdd3 = this.SkillLevelToAdd;
      int attributeLevelToAdd3 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition3 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).RuralAdolescenceOnCondition);
      CharacterCreationOnSelect onSelect3 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).RuralAdolescenceRepairmanOnConsequence);
      CharacterCreationApplyFinalEffects onApply3 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.RuralAdolescenceRepairmanOnApply);
      TextObject descriptionText3 = new TextObject("{=6LFj919J}You helped dig wells, rethatch houses, and fix broken plows. You learned about the basics of construction, as well as what it takes to keep a farming community prosperous.");
      creationCategory4.AddCategoryOption(text3, effectedSkills3, intelligence1, focusToAdd3, skillLevelToAdd3, attributeLevelToAdd3, optionCondition3, onSelect3, onApply3, descriptionText3);
      CharacterCreationCategory creationCategory5 = creationCategory1;
      TextObject text4 = new TextObject("{=TRwgSLD2}gathered herbs in the wild.");
      List<SkillObject> effectedSkills4 = new List<SkillObject>();
      effectedSkills4.Add(DefaultSkills.Medicine);
      effectedSkills4.Add(DefaultSkills.Scouting);
      CharacterAttribute endurance1 = DefaultCharacterAttributes.Endurance;
      int focusToAdd4 = this.FocusToAdd;
      int skillLevelToAdd4 = this.SkillLevelToAdd;
      int attributeLevelToAdd4 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition4 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).RuralAdolescenceOnCondition);
      CharacterCreationOnSelect onSelect4 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).RuralAdolescenceGathererOnConsequence);
      CharacterCreationApplyFinalEffects onApply4 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.RuralAdolescenceGathererOnApply);
      TextObject descriptionText4 = new TextObject("{=9ks4u5cH}You were sent by the village healer up into the hills to look for useful medicinal plants. You learned which herbs healed wounds or brought down a fever, and how to find them.");
      creationCategory5.AddCategoryOption(text4, effectedSkills4, endurance1, focusToAdd4, skillLevelToAdd4, attributeLevelToAdd4, optionCondition4, onSelect4, onApply4, descriptionText4);
      CharacterCreationCategory creationCategory6 = creationCategory1;
      TextObject text5 = new TextObject("{=T7m7ReTq}hunted small game.");
      List<SkillObject> effectedSkills5 = new List<SkillObject>();
      effectedSkills5.Add(DefaultSkills.Bow);
      effectedSkills5.Add(DefaultSkills.Tactics);
      CharacterAttribute control2 = DefaultCharacterAttributes.Control;
      int focusToAdd5 = this.FocusToAdd;
      int skillLevelToAdd5 = this.SkillLevelToAdd;
      int attributeLevelToAdd5 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition5 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).RuralAdolescenceOnCondition);
      CharacterCreationOnSelect onSelect5 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).RuralAdolescenceHunterOnConsequence);
      CharacterCreationApplyFinalEffects onApply5 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.RuralAdolescenceHunterOnApply);
      TextObject descriptionText5 = new TextObject("{=RuvSk3QT}You accompanied a local hunter as he went into the wilderness, helping him set up traps and catch small animals.");
      creationCategory6.AddCategoryOption(text5, effectedSkills5, control2, focusToAdd5, skillLevelToAdd5, attributeLevelToAdd5, optionCondition5, onSelect5, onApply5, descriptionText5);
      CharacterCreationCategory creationCategory7 = creationCategory1;
      TextObject text6 = new TextObject("{=qAbMagWq}sold produce at the market.");
      List<SkillObject> effectedSkills6 = new List<SkillObject>();
      effectedSkills6.Add(DefaultSkills.Trade);
      effectedSkills6.Add(DefaultSkills.Charm);
      CharacterAttribute social1 = DefaultCharacterAttributes.Social;
      int focusToAdd6 = this.FocusToAdd;
      int skillLevelToAdd6 = this.SkillLevelToAdd;
      int attributeLevelToAdd6 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition6 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).RuralAdolescenceOnCondition);
      CharacterCreationOnSelect onSelect6 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).RuralAdolescenceHelperOnConsequence);
      CharacterCreationApplyFinalEffects onApply6 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.RuralAdolescenceHelperOnApply);
      TextObject descriptionText6 = new TextObject("{=DIgsfYfz}You took your family's goods to the nearest town to sell your produce and buy supplies. It was hard work, but you enjoyed the hubbub of the marketplace.");
      creationCategory7.AddCategoryOption(text6, effectedSkills6, social1, focusToAdd6, skillLevelToAdd6, attributeLevelToAdd6, optionCondition6, onSelect6, onApply6, descriptionText6);
      CharacterCreationCategory creationCategory8 = creationCategory1;
      TextObject text7 = new TextObject("{=nOfSqRnI}at the town watch's training ground.");
      List<SkillObject> effectedSkills7 = new List<SkillObject>();
      effectedSkills7.Add(DefaultSkills.Crossbow);
      effectedSkills7.Add(DefaultSkills.Tactics);
      CharacterAttribute control3 = DefaultCharacterAttributes.Control;
      int focusToAdd7 = this.FocusToAdd;
      int skillLevelToAdd7 = this.SkillLevelToAdd;
      int attributeLevelToAdd7 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition7 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).UrbanAdolescenceOnCondition);
      CharacterCreationOnSelect onSelect7 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).UrbanAdolescenceWatcherOnConsequence);
      CharacterCreationApplyFinalEffects onApply7 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.UrbanAdolescenceWatcherOnApply);
      TextObject descriptionText7 = new TextObject("{=qnqdEJOv}You watched the town's watch practice shooting and perfect their plans to defend the walls in case of a siege.");
      creationCategory8.AddCategoryOption(text7, effectedSkills7, control3, focusToAdd7, skillLevelToAdd7, attributeLevelToAdd7, optionCondition7, onSelect7, onApply7, descriptionText7);
      CharacterCreationCategory creationCategory9 = creationCategory1;
      TextObject text8 = new TextObject("{=8a6dnLd2}with the alley gangs.");
      List<SkillObject> effectedSkills8 = new List<SkillObject>();
      effectedSkills8.Add(DefaultSkills.Roguery);
      effectedSkills8.Add(DefaultSkills.OneHanded);
      CharacterAttribute cunning = DefaultCharacterAttributes.Cunning;
      int focusToAdd8 = this.FocusToAdd;
      int skillLevelToAdd8 = this.SkillLevelToAdd;
      int attributeLevelToAdd8 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition8 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).UrbanAdolescenceOnCondition);
      CharacterCreationOnSelect onSelect8 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).UrbanAdolescenceGangerOnConsequence);
      CharacterCreationApplyFinalEffects onApply8 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.UrbanAdolescenceGangerOnApply);
      TextObject descriptionText8 = new TextObject("{=1SUTcF0J}The gang leaders who kept watch over the slums of Athas' cities were always in need of poor youth to run messages and back them up in turf wars, while thrill-seeking merchants' sons and daughters sometimes slummed it in their company as well.");
      creationCategory9.AddCategoryOption(text8, effectedSkills8, cunning, focusToAdd8, skillLevelToAdd8, attributeLevelToAdd8, optionCondition8, onSelect8, onApply8, descriptionText8);
      CharacterCreationCategory creationCategory10 = creationCategory1;
      TextObject text9 = new TextObject("{=7Hv984Sf}at docks and building sites.");
      List<SkillObject> effectedSkills9 = new List<SkillObject>();
      effectedSkills9.Add(DefaultSkills.Athletics);
      effectedSkills9.Add(DefaultSkills.Crafting);
      CharacterAttribute vigor2 = DefaultCharacterAttributes.Vigor;
      int focusToAdd9 = this.FocusToAdd;
      int skillLevelToAdd9 = this.SkillLevelToAdd;
      int attributeLevelToAdd9 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition9 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).UrbanAdolescenceOnCondition);
      CharacterCreationOnSelect onSelect9 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).UrbanAdolescenceDockerOnConsequence);
      CharacterCreationApplyFinalEffects onApply9 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.UrbanAdolescenceDockerOnApply);
      TextObject descriptionText9 = new TextObject("{=bhdkegZ4}All towns had their share of projects that were constantly in need of both skilled and unskilled labor. You learned how hoists and scaffolds were constructed, how planks and stones were hewn and fitted, and other skills.");
      creationCategory10.AddCategoryOption(text9, effectedSkills9, vigor2, focusToAdd9, skillLevelToAdd9, attributeLevelToAdd9, optionCondition9, onSelect9, onApply9, descriptionText9);
      CharacterCreationCategory creationCategory11 = creationCategory1;
      TextObject text10 = new TextObject("{=kbcwb5TH}in the markets and merchant caravans.");
      List<SkillObject> effectedSkills10 = new List<SkillObject>();
      effectedSkills10.Add(DefaultSkills.Trade);
      effectedSkills10.Add(DefaultSkills.Charm);
      CharacterAttribute social2 = DefaultCharacterAttributes.Social;
      int focusToAdd10 = this.FocusToAdd;
      int skillLevelToAdd10 = this.SkillLevelToAdd;
      int attributeLevelToAdd10 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition10 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).UrbanPoorAdolescenceOnCondition);
      CharacterCreationOnSelect onSelect10 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).UrbanAdolescenceMarketerOnConsequence);
      CharacterCreationApplyFinalEffects onApply10 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.UrbanAdolescenceMarketerOnApply);
      TextObject descriptionText10 = new TextObject("{=lLJh7WAT}You worked in the marketplace, selling trinkets and drinks to busy shoppers.");
      creationCategory11.AddCategoryOption(text10, effectedSkills10, social2, focusToAdd10, skillLevelToAdd10, attributeLevelToAdd10, optionCondition10, onSelect10, onApply10, descriptionText10);
      CharacterCreationCategory creationCategory12 = creationCategory1;
      TextObject text11 = new TextObject("{=kbcwb5TH}in the markets and merchant caravans.");
      List<SkillObject> effectedSkills11 = new List<SkillObject>();
      effectedSkills11.Add(DefaultSkills.Trade);
      effectedSkills11.Add(DefaultSkills.Charm);
      CharacterAttribute social3 = DefaultCharacterAttributes.Social;
      int focusToAdd11 = this.FocusToAdd;
      int skillLevelToAdd11 = this.SkillLevelToAdd;
      int attributeLevelToAdd11 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition11 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).UrbanRichAdolescenceOnCondition);
      CharacterCreationOnSelect onSelect11 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).UrbanAdolescenceMarketerOnConsequence);
      CharacterCreationApplyFinalEffects onApply11 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.UrbanAdolescenceMarketerOnApply);
      TextObject descriptionText11 = new TextObject("{=rmMcwSn8}You helped your family handle their business affairs, going down to the marketplace to make purchases and oversee the arrival of caravans.");
      creationCategory12.AddCategoryOption(text11, effectedSkills11, social3, focusToAdd11, skillLevelToAdd11, attributeLevelToAdd11, optionCondition11, onSelect11, onApply11, descriptionText11);
      CharacterCreationCategory creationCategory13 = creationCategory1;
      TextObject text12 = new TextObject("{=mfRbx5KE}reading and studying.");
      List<SkillObject> effectedSkills12 = new List<SkillObject>();
      effectedSkills12.Add(DefaultSkills.Engineering);
      effectedSkills12.Add(DefaultSkills.Leadership);
      CharacterAttribute intelligence2 = DefaultCharacterAttributes.Intelligence;
      int focusToAdd12 = this.FocusToAdd;
      int skillLevelToAdd12 = this.SkillLevelToAdd;
      int attributeLevelToAdd12 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition12 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).UrbanPoorAdolescenceOnCondition);
      CharacterCreationOnSelect onSelect12 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).UrbanAdolescenceTutorOnConsequence);
      CharacterCreationApplyFinalEffects onApply12 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.UrbanAdolescenceDockerOnApply);
      TextObject descriptionText12 = new TextObject("{=elQnygal}Your family scraped up the money for a rudimentary schooling and you took full advantage, reading voraciously on history, mathematics, and philosophy and discussing what you read with your tutor and classmates.");
      creationCategory13.AddCategoryOption(text12, effectedSkills12, intelligence2, focusToAdd12, skillLevelToAdd12, attributeLevelToAdd12, optionCondition12, onSelect12, onApply12, descriptionText12);
      CharacterCreationCategory creationCategory14 = creationCategory1;
      TextObject text13 = new TextObject("{=etG87fB7}with your tutor.");
      List<SkillObject> effectedSkills13 = new List<SkillObject>();
      effectedSkills13.Add(DefaultSkills.Engineering);
      effectedSkills13.Add(DefaultSkills.Leadership);
      CharacterAttribute intelligence3 = DefaultCharacterAttributes.Intelligence;
      int focusToAdd13 = this.FocusToAdd;
      int skillLevelToAdd13 = this.SkillLevelToAdd;
      int attributeLevelToAdd13 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition13 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).UrbanRichAdolescenceOnCondition);
      CharacterCreationOnSelect onSelect13 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).UrbanAdolescenceTutorOnConsequence);
      CharacterCreationApplyFinalEffects onApply13 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.UrbanAdolescenceDockerOnApply);
      TextObject descriptionText13 = new TextObject("{=hXl25avg}Your family arranged for a private tutor and you took full advantage, reading voraciously on history, mathematics, and philosophy and discussing what you read with your tutor and classmates.");
      creationCategory14.AddCategoryOption(text13, effectedSkills13, intelligence3, focusToAdd13, skillLevelToAdd13, attributeLevelToAdd13, optionCondition13, onSelect13, onApply13, descriptionText13);
      CharacterCreationCategory creationCategory15 = creationCategory1;
      TextObject text14 = new TextObject("{=FKpLEamz}caring for horses.");
      List<SkillObject> effectedSkills14 = new List<SkillObject>();
      effectedSkills14.Add(DefaultSkills.Riding);
      effectedSkills14.Add(DefaultSkills.Steward);
      CharacterAttribute endurance2 = DefaultCharacterAttributes.Endurance;
      int focusToAdd14 = this.FocusToAdd;
      int skillLevelToAdd14 = this.SkillLevelToAdd;
      int attributeLevelToAdd14 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition14 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).UrbanRichAdolescenceOnCondition);
      CharacterCreationOnSelect onSelect14 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).UrbanAdolescenceHorserOnConsequence);
      CharacterCreationApplyFinalEffects onApply14 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.UrbanAdolescenceDockerOnApply);
      TextObject descriptionText14 = new TextObject("{=Ghz90npw}Your family owned a few horses at the town stables and you took charge of their care. Many evenings you would take them out beyond the walls and gallup through the fields, racing other youth.");
      creationCategory15.AddCategoryOption(text14, effectedSkills14, endurance2, focusToAdd14, skillLevelToAdd14, attributeLevelToAdd14, optionCondition14, onSelect14, onApply14, descriptionText14);
      CharacterCreationCategory creationCategory16 = creationCategory1;
      TextObject text15 = new TextObject("{=vH7GtuuK}working at the stables.");
      List<SkillObject> effectedSkills15 = new List<SkillObject>();
      effectedSkills15.Add(DefaultSkills.Riding);
      effectedSkills15.Add(DefaultSkills.Steward);
      CharacterAttribute endurance3 = DefaultCharacterAttributes.Endurance;
      int focusToAdd15 = this.FocusToAdd;
      int skillLevelToAdd15 = this.SkillLevelToAdd;
      int attributeLevelToAdd15 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition15 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).UrbanPoorAdolescenceOnCondition);
      CharacterCreationOnSelect onSelect15 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).UrbanAdolescenceHorserOnConsequence);
      CharacterCreationApplyFinalEffects onApply15 = new CharacterCreationApplyFinalEffects(SandboxCharacterCreationContent.UrbanAdolescenceDockerOnApply);
      TextObject descriptionText15 = new TextObject("{=csUq1RCC}You were employed as a hired hand at the town's stables. The overseers recognized that you had a knack for horses, and you were allowed to exercise them and sometimes even break in new steeds.");
      creationCategory16.AddCategoryOption(text15, effectedSkills15, endurance3, focusToAdd15, skillLevelToAdd15, attributeLevelToAdd15, optionCondition15, onSelect15, onApply15, descriptionText15);
      characterCreation.AddNewMenu(menu);
    }

    protected new void AddYouthMenu(CharacterCreation characterCreation)
    {
      CharacterCreationMenu menu = new CharacterCreationMenu(new TextObject("{=ok8lSW6M}Youth"), this._youthIntroductoryText, new CharacterCreationOnInit(((SandboxCharacterCreationContent) this).YouthOnInit));
      CharacterCreationCategory creationCategory1 = menu.AddMenuCategory(new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).AseraiParentsOnCondition));
      CharacterCreationCategory creationCategory2 = creationCategory1;
      TextObject text1 = new TextObject("{=h2KnarLL}trained with the cavalry.");
      List<SkillObject> effectedSkills1 = new List<SkillObject>();
      effectedSkills1.Add(DefaultSkills.Riding);
      effectedSkills1.Add(DefaultSkills.Polearm);
      CharacterAttribute endurance1 = DefaultCharacterAttributes.Endurance;
      int focusToAdd1 = this.FocusToAdd;
      int skillLevelToAdd1 = this.SkillLevelToAdd;
      int attributeLevelToAdd1 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect1 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthCavalryOnConsequence);
      CharacterCreationApplyFinalEffects onApply1 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthCavalryOnApply);
      TextObject descriptionText1 = new TextObject("{=7cHsIMLP}You could never have bought the equipment on your own but you were a good enough rider so that the local lord lent you a horse and equipment. You joined the armored cavalry, training with the lance.");
      creationCategory2.AddCategoryOption(text1, effectedSkills1, endurance1, focusToAdd1, skillLevelToAdd1, attributeLevelToAdd1, (CharacterCreationOnCondition) null, onSelect1, onApply1, descriptionText1);
      CharacterCreationCategory creationCategory3 = creationCategory1;
      TextObject text2 = new TextObject("partrolled the cities.");
      List<SkillObject> effectedSkills2 = new List<SkillObject>();
      effectedSkills2.Add(DefaultSkills.Crossbow);
      effectedSkills2.Add(DefaultSkills.Engineering);
      CharacterAttribute intelligence1 = DefaultCharacterAttributes.Intelligence;
      int focusToAdd2 = this.FocusToAdd;
      int skillLevelToAdd2 = this.SkillLevelToAdd;
      int attributeLevelToAdd2 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect2 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthGarrisonOnConsequence);
      CharacterCreationApplyFinalEffects onApply2 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthGarrisonOnApply);
      TextObject descriptionText2 = new TextObject("{=63TAYbkx}Urban troops spend much of their time guarding the town walls. Most of their training was in missile weapons, especially useful during sieges.");
      creationCategory3.AddCategoryOption(text2, effectedSkills2, intelligence1, focusToAdd2, skillLevelToAdd2, attributeLevelToAdd2, (CharacterCreationOnCondition) null, onSelect2, onApply2, descriptionText2);
      CharacterCreationCategory creationCategory4 = creationCategory1;
      TextObject text3 = new TextObject("joined the desert scouts.");
      List<SkillObject> effectedSkills3 = new List<SkillObject>();
      effectedSkills3.Add(DefaultSkills.Riding);
      effectedSkills3.Add(DefaultSkills.Bow);
      CharacterAttribute endurance2 = DefaultCharacterAttributes.Endurance;
      int focusToAdd3 = this.FocusToAdd;
      int skillLevelToAdd3 = this.SkillLevelToAdd;
      int attributeLevelToAdd3 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect3 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthOtherOutridersOnConsequence);
      CharacterCreationApplyFinalEffects onApply3 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthOtherOutridersOnApply);
      TextObject descriptionText3 = new TextObject("You couted ahead of the army.");
      creationCategory4.AddCategoryOption(text3, effectedSkills3, endurance2, focusToAdd3, skillLevelToAdd3, attributeLevelToAdd3, (CharacterCreationOnCondition) null, onSelect3, onApply3, descriptionText3);
      CharacterCreationCategory creationCategory5 = creationCategory1;
      TextObject text4 = new TextObject("{=a8arFSra}trained with the infantry.");
      List<SkillObject> effectedSkills4 = new List<SkillObject>();
      effectedSkills4.Add(DefaultSkills.Polearm);
      effectedSkills4.Add(DefaultSkills.OneHanded);
      CharacterAttribute vigor1 = DefaultCharacterAttributes.Vigor;
      int focusToAdd4 = this.FocusToAdd;
      int skillLevelToAdd4 = this.SkillLevelToAdd;
      int attributeLevelToAdd4 = this.AttributeLevelToAdd;
      CharacterCreationApplyFinalEffects onApply4 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthInfantryOnApply);
      TextObject descriptionText4 = new TextObject("{=afH90aNs}Young Tribesmen armed with spear and shield, drawn from smallholding farmers, have always been the backbone of most armies of Athas.");
      creationCategory5.AddCategoryOption(text4, effectedSkills4, vigor1, focusToAdd4, skillLevelToAdd4, attributeLevelToAdd4, (CharacterCreationOnCondition) null, (CharacterCreationOnSelect) null, onApply4, descriptionText4);
      CharacterCreationCategory creationCategory6 = creationCategory1;
      TextObject text5 = new TextObject("{=oMbOIPc9}joined the skirmishers.");
      List<SkillObject> effectedSkills5 = new List<SkillObject>();
      effectedSkills5.Add(DefaultSkills.Throwing);
      effectedSkills5.Add(DefaultSkills.OneHanded);
      CharacterAttribute control1 = DefaultCharacterAttributes.Control;
      int focusToAdd5 = this.FocusToAdd;
      int skillLevelToAdd5 = this.SkillLevelToAdd;
      int attributeLevelToAdd5 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect4 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthSkirmisherOnConsequence);
      CharacterCreationApplyFinalEffects onApply5 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthSkirmisherOnApply);
      TextObject descriptionText5 = new TextObject("{=bXAg5w19}Younger recruits, or those of a slighter build, or those too poor to buy shield and armor tend to join the skirmishers. Fighting with bow and javelin, they try to stay out of reach of the main enemy forces.");
      creationCategory6.AddCategoryOption(text5, effectedSkills5, control1, focusToAdd5, skillLevelToAdd5, attributeLevelToAdd5, (CharacterCreationOnCondition) null, onSelect4, onApply5, descriptionText5);
      CharacterCreationCategory creationCategory7 = creationCategory1;
      TextObject text6 = new TextObject("{=GFUggps8}marched with the free people.");
      List<SkillObject> effectedSkills6 = new List<SkillObject>();
      effectedSkills6.Add(DefaultSkills.Roguery);
      effectedSkills6.Add(DefaultSkills.Throwing);
      CharacterAttribute cunning1 = DefaultCharacterAttributes.Cunning;
      int focusToAdd6 = this.FocusToAdd;
      int skillLevelToAdd6 = this.SkillLevelToAdd;
      int attributeLevelToAdd6 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect5 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthCamperOnConsequence);
      CharacterCreationApplyFinalEffects onApply6 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthCamperOnApply);
      TextObject descriptionText6 = new TextObject("{=64rWqBLN}You avoided service with one of the main forces of your realm's armies, but followed instead in the train - the troops' wives, lovers and servants, and those who make their living by caring for, entertaining, or cheating the soldiery.");
      creationCategory7.AddCategoryOption(text6, effectedSkills6, cunning1, focusToAdd6, skillLevelToAdd6, attributeLevelToAdd6, (CharacterCreationOnCondition) null, onSelect5, onApply6, descriptionText6);
      CharacterCreationCategory creationCategory8 = menu.AddMenuCategory(new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).BattanianParentsOnCondition));
      CharacterCreationCategory creationCategory9 = creationCategory8;
      TextObject text7 = new TextObject("trained with the noble guard.");
      List<SkillObject> effectedSkills7 = new List<SkillObject>();
      effectedSkills7.Add(DefaultSkills.Riding);
      effectedSkills7.Add(DefaultSkills.Polearm);
      CharacterAttribute endurance3 = DefaultCharacterAttributes.Endurance;
      int focusToAdd7 = this.FocusToAdd;
      int skillLevelToAdd7 = this.SkillLevelToAdd;
      int attributeLevelToAdd7 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect6 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthCavalryOnConsequence);
      CharacterCreationApplyFinalEffects onApply7 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthCavalryOnApply);
      TextObject descriptionText7 = new TextObject("{=7cHsIMLP}You could never have bought the equipment on your own but you were a good enough rider so that the local lord lent you a horse and equipment. You joined the armored cavalry, training with the lance.");
      creationCategory9.AddCategoryOption(text7, effectedSkills7, endurance3, focusToAdd7, skillLevelToAdd7, attributeLevelToAdd7, (CharacterCreationOnCondition) null, onSelect6, onApply7, descriptionText7);
      CharacterCreationCategory creationCategory10 = creationCategory8;
      TextObject text8 = new TextObject("joined the folks guard");
      List<SkillObject> effectedSkills8 = new List<SkillObject>();
      effectedSkills8.Add(DefaultSkills.Crossbow);
      effectedSkills8.Add(DefaultSkills.Engineering);
      CharacterAttribute intelligence2 = DefaultCharacterAttributes.Intelligence;
      int focusToAdd8 = this.FocusToAdd;
      int skillLevelToAdd8 = this.SkillLevelToAdd;
      int attributeLevelToAdd8 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect7 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthGarrisonOnConsequence);
      CharacterCreationApplyFinalEffects onApply8 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthGarrisonOnApply);
      TextObject descriptionText8 = new TextObject("{=63TAYbkx}Urban troops spend much of their time guarding the town walls. Most of their training was in missile weapons, especially useful during sieges.");
      creationCategory10.AddCategoryOption(text8, effectedSkills8, intelligence2, focusToAdd8, skillLevelToAdd8, attributeLevelToAdd8, (CharacterCreationOnCondition) null, onSelect7, onApply8, descriptionText8);
      CharacterCreationCategory creationCategory11 = creationCategory8;
      TextObject text9 = new TextObject("rode with the scouts.");
      List<SkillObject> effectedSkills9 = new List<SkillObject>();
      effectedSkills9.Add(DefaultSkills.Riding);
      effectedSkills9.Add(DefaultSkills.Bow);
      CharacterAttribute endurance4 = DefaultCharacterAttributes.Endurance;
      int focusToAdd9 = this.FocusToAdd;
      int skillLevelToAdd9 = this.SkillLevelToAdd;
      int attributeLevelToAdd9 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect8 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthOtherOutridersOnConsequence);
      CharacterCreationApplyFinalEffects onApply9 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthOtherOutridersOnApply);
      TextObject descriptionText9 = new TextObject("You couted ahead of the army.");
      creationCategory11.AddCategoryOption(text9, effectedSkills9, endurance4, focusToAdd9, skillLevelToAdd9, attributeLevelToAdd9, (CharacterCreationOnCondition) null, onSelect8, onApply9, descriptionText9);
      CharacterCreationCategory creationCategory12 = creationCategory8;
      TextObject text10 = new TextObject("trained with the Akh'Velahr.");
      List<SkillObject> effectedSkills10 = new List<SkillObject>();
      effectedSkills10.Add(DefaultSkills.Polearm);
      effectedSkills10.Add(DefaultSkills.OneHanded);
      CharacterAttribute vigor2 = DefaultCharacterAttributes.Vigor;
      int focusToAdd10 = this.FocusToAdd;
      int skillLevelToAdd10 = this.SkillLevelToAdd;
      int attributeLevelToAdd10 = this.AttributeLevelToAdd;
      CharacterCreationApplyFinalEffects onApply10 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthInfantryOnApply);
      TextObject descriptionText10 = new TextObject("{=afH90aNs}Armed with Spear and shield, the Akh´Velahr is the bulk of the Elvean forces, drawned from the smallholding farmers.");
      creationCategory12.AddCategoryOption(text10, effectedSkills10, vigor2, focusToAdd10, skillLevelToAdd10, attributeLevelToAdd10, (CharacterCreationOnCondition) null, (CharacterCreationOnSelect) null, onApply10, descriptionText10);
      CharacterCreationCategory creationCategory13 = creationCategory8;
      TextObject text11 = new TextObject("joined the Arakhora.");
      List<SkillObject> effectedSkills11 = new List<SkillObject>();
      effectedSkills11.Add(DefaultSkills.Roguery);
      effectedSkills11.Add(DefaultSkills.Throwing);
      CharacterAttribute cunning2 = DefaultCharacterAttributes.Cunning;
      int focusToAdd11 = this.FocusToAdd;
      int skillLevelToAdd11 = this.SkillLevelToAdd;
      int attributeLevelToAdd11 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect9 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthCamperOnConsequence);
      CharacterCreationApplyFinalEffects onApply11 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthCamperOnApply);
      TextObject descriptionText11 = new TextObject("{=64rWqBLN}Arakhor, an Elvean term that translates loosely as - one who protects the forest -, were the Scounts sent to the borders of the Realm to watch over possible treats. Often you needed  trick your way into foreign armies and cities, cheating, entertaining, whatever disguise was at your disposal.");
      creationCategory13.AddCategoryOption(text11, effectedSkills11, cunning2, focusToAdd11, skillLevelToAdd11, attributeLevelToAdd11, (CharacterCreationOnCondition) null, onSelect9, onApply11, descriptionText11);
      CharacterCreationCategory creationCategory14 = menu.AddMenuCategory(new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).EmpireParentsOnCondition));
      CharacterCreationCategory creationCategory15 = creationCategory14;
      TextObject text12 = new TextObject("trained with the cavalry.");
      List<SkillObject> effectedSkills12 = new List<SkillObject>();
      effectedSkills12.Add(DefaultSkills.Riding);
      effectedSkills12.Add(DefaultSkills.Polearm);
      CharacterAttribute endurance5 = DefaultCharacterAttributes.Endurance;
      int focusToAdd12 = this.FocusToAdd;
      int skillLevelToAdd12 = this.SkillLevelToAdd;
      int attributeLevelToAdd12 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect10 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthCavalryOnConsequence);
      CharacterCreationApplyFinalEffects onApply12 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthCavalryOnApply);
      TextObject descriptionText12 = new TextObject("{=7cHsIMLP}You could never have bought the equipment on your own but you were a good enough rider so that the local lord lent you a horse and equipment. You joined the armored cavalry, training with the lance.");
      creationCategory15.AddCategoryOption(text12, effectedSkills12, endurance5, focusToAdd12, skillLevelToAdd12, attributeLevelToAdd12, (CharacterCreationOnCondition) null, onSelect10, onApply12, descriptionText12);
      CharacterCreationCategory creationCategory16 = creationCategory14;
      TextObject text13 = new TextObject("served in the Hall of Men.");
      List<SkillObject> effectedSkills13 = new List<SkillObject>();
      effectedSkills13.Add(DefaultSkills.Crossbow);
      effectedSkills13.Add(DefaultSkills.Engineering);
      CharacterAttribute intelligence3 = DefaultCharacterAttributes.Intelligence;
      int focusToAdd13 = this.FocusToAdd;
      int skillLevelToAdd13 = this.SkillLevelToAdd;
      int attributeLevelToAdd13 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect11 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthGarrisonOnConsequence);
      CharacterCreationApplyFinalEffects onApply13 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthGarrisonOnApply);
      TextObject descriptionText13 = new TextObject("{=63TAYbkx}Urban troops spend much of their time guarding the town walls. Most of their training was in missile weapons, especially useful during sieges.");
      creationCategory16.AddCategoryOption(text13, effectedSkills13, intelligence3, focusToAdd13, skillLevelToAdd13, attributeLevelToAdd13, (CharacterCreationOnCondition) null, onSelect11, onApply13, descriptionText13);
      CharacterCreationCategory creationCategory17 = creationCategory14;
      TextObject text14 = new TextObject("stood guard with the garrisons.");
      List<SkillObject> effectedSkills14 = new List<SkillObject>();
      effectedSkills14.Add(DefaultSkills.Throwing);
      effectedSkills14.Add(DefaultSkills.OneHanded);
      CharacterAttribute control2 = DefaultCharacterAttributes.Control;
      int focusToAdd14 = this.FocusToAdd;
      int skillLevelToAdd14 = this.SkillLevelToAdd;
      int attributeLevelToAdd14 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect12 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthSkirmisherOnConsequence);
      CharacterCreationApplyFinalEffects onApply14 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthSkirmisherOnApply);
      TextObject descriptionText14 = new TextObject("{=bXAg5w19}Younger recruits, or those of a slighter build, or those too poor to buy shield and armor tend to join the skirmishers. Fighting with bow and javelin, they try to stay out of reach of the main enemy forces.");
      creationCategory17.AddCategoryOption(text14, effectedSkills14, control2, focusToAdd14, skillLevelToAdd14, attributeLevelToAdd14, (CharacterCreationOnCondition) null, onSelect12, onApply14, descriptionText14);
      CharacterCreationCategory creationCategory18 = creationCategory14;
      TextObject text15 = new TextObject("rode with the scouts.");
      List<SkillObject> effectedSkills15 = new List<SkillObject>();
      effectedSkills15.Add(DefaultSkills.Riding);
      effectedSkills15.Add(DefaultSkills.Bow);
      CharacterAttribute endurance6 = DefaultCharacterAttributes.Endurance;
      int focusToAdd15 = this.FocusToAdd;
      int skillLevelToAdd15 = this.SkillLevelToAdd;
      int attributeLevelToAdd15 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect13 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthOtherOutridersOnConsequence);
      CharacterCreationApplyFinalEffects onApply15 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthOtherOutridersOnApply);
      TextObject descriptionText15 = new TextObject("You couted ahead of the army.");
      creationCategory18.AddCategoryOption(text15, effectedSkills15, endurance6, focusToAdd15, skillLevelToAdd15, attributeLevelToAdd15, (CharacterCreationOnCondition) null, onSelect13, onApply15, descriptionText15);
      CharacterCreationCategory creationCategory19 = creationCategory14;
      TextObject text16 = new TextObject("joined the spear bearers.");
      List<SkillObject> effectedSkills16 = new List<SkillObject>();
      effectedSkills16.Add(DefaultSkills.Polearm);
      effectedSkills16.Add(DefaultSkills.OneHanded);
      CharacterAttribute vigor3 = DefaultCharacterAttributes.Vigor;
      int focusToAdd16 = this.FocusToAdd;
      int skillLevelToAdd16 = this.SkillLevelToAdd;
      int attributeLevelToAdd16 = this.AttributeLevelToAdd;
      CharacterCreationApplyFinalEffects onApply16 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthInfantryOnApply);
      TextObject descriptionText16 = new TextObject("{=afH90aNs}Levy armed with spear and shield, drawn from smallholding farmers, have always been the backbone of most armies of Athas.");
      creationCategory19.AddCategoryOption(text16, effectedSkills16, vigor3, focusToAdd16, skillLevelToAdd16, attributeLevelToAdd16, (CharacterCreationOnCondition) null, (CharacterCreationOnSelect) null, onApply16, descriptionText16);
      CharacterCreationCategory creationCategory20 = creationCategory14;
      TextObject text17 = new TextObject("trained with the infantry.");
      List<SkillObject> effectedSkills17 = new List<SkillObject>();
      effectedSkills17.Add(DefaultSkills.Roguery);
      effectedSkills17.Add(DefaultSkills.Throwing);
      CharacterAttribute cunning3 = DefaultCharacterAttributes.Cunning;
      int focusToAdd17 = this.FocusToAdd;
      int skillLevelToAdd17 = this.SkillLevelToAdd;
      int attributeLevelToAdd17 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect14 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthCamperOnConsequence);
      CharacterCreationApplyFinalEffects onApply17 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthCamperOnApply);
      TextObject descriptionText17 = new TextObject("{=64rWqBLN}You avoided service with one of the main forces of your realm's armies, but followed instead in the train - the troops' wives, lovers and servants, and those who make their living by caring for, entertaining, or cheating the soldiery.");
      creationCategory20.AddCategoryOption(text17, effectedSkills17, cunning3, focusToAdd17, skillLevelToAdd17, attributeLevelToAdd17, (CharacterCreationOnCondition) null, onSelect14, onApply17, descriptionText17);
      CharacterCreationCategory creationCategory21 = menu.AddMenuCategory(new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).VlandianParentsOnCondition));
      CharacterCreationCategory creationCategory22 = creationCategory21;
      TextObject text18 = new TextObject("trained with the Nasoria cavalry.");
      List<SkillObject> effectedSkills18 = new List<SkillObject>();
      effectedSkills18.Add(DefaultSkills.Riding);
      effectedSkills18.Add(DefaultSkills.Polearm);
      CharacterAttribute endurance7 = DefaultCharacterAttributes.Endurance;
      int focusToAdd18 = this.FocusToAdd;
      int skillLevelToAdd18 = this.SkillLevelToAdd;
      int attributeLevelToAdd18 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect15 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthCavalryOnConsequence);
      CharacterCreationApplyFinalEffects onApply18 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthCavalryOnApply);
      TextObject descriptionText18 = new TextObject("{=7cHsIMLP}You could never have bought the equipment on your own but you were a good enough rider so that the local lord lent you a horse and equipment. You joined the armored cavalry, training with the lance.");
      creationCategory22.AddCategoryOption(text18, effectedSkills18, endurance7, focusToAdd18, skillLevelToAdd18, attributeLevelToAdd18, (CharacterCreationOnCondition) null, onSelect15, onApply18, descriptionText18);
      CharacterCreationCategory creationCategory23 = creationCategory21;
      TextObject text19 = new TextObject("patrolled the cities.");
      List<SkillObject> effectedSkills19 = new List<SkillObject>();
      effectedSkills19.Add(DefaultSkills.Crossbow);
      effectedSkills19.Add(DefaultSkills.Engineering);
      CharacterAttribute intelligence4 = DefaultCharacterAttributes.Intelligence;
      int focusToAdd19 = this.FocusToAdd;
      int skillLevelToAdd19 = this.SkillLevelToAdd;
      int attributeLevelToAdd19 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect16 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthGarrisonOnConsequence);
      CharacterCreationApplyFinalEffects onApply19 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthGarrisonOnApply);
      TextObject descriptionText19 = new TextObject("{=63TAYbkx}Urban troops spend much of their time guarding the town walls. Most of their training was in missile weapons, especially useful during sieges.");
      creationCategory23.AddCategoryOption(text19, effectedSkills19, intelligence4, focusToAdd19, skillLevelToAdd19, attributeLevelToAdd19, (CharacterCreationOnCondition) null, onSelect16, onApply19, descriptionText19);
      CharacterCreationCategory creationCategory24 = creationCategory21;
      TextObject text20 = new TextObject("trained with the infantry.");
      List<SkillObject> effectedSkills20 = new List<SkillObject>();
      effectedSkills20.Add(DefaultSkills.Throwing);
      effectedSkills20.Add(DefaultSkills.OneHanded);
      CharacterAttribute control3 = DefaultCharacterAttributes.Control;
      int focusToAdd20 = this.FocusToAdd;
      int skillLevelToAdd20 = this.SkillLevelToAdd;
      int attributeLevelToAdd20 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect17 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthSkirmisherOnConsequence);
      CharacterCreationApplyFinalEffects onApply20 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthSkirmisherOnApply);
      TextObject descriptionText20 = new TextObject("{=bXAg5w19}Younger recruits, or those of a slighter build, or those too poor to buy shield and armor tend to join the skirmishers. Fighting with bow and javelin, they try to stay out of reach of the main enemy forces.");
      creationCategory24.AddCategoryOption(text20, effectedSkills20, control3, focusToAdd20, skillLevelToAdd20, attributeLevelToAdd20, (CharacterCreationOnCondition) null, onSelect17, onApply20, descriptionText20);
      CharacterCreationCategory creationCategory25 = creationCategory21;
      TextObject text21 = new TextObject("rode with the scouts.");
      List<SkillObject> effectedSkills21 = new List<SkillObject>();
      effectedSkills21.Add(DefaultSkills.Riding);
      effectedSkills21.Add(DefaultSkills.Bow);
      CharacterAttribute endurance8 = DefaultCharacterAttributes.Endurance;
      int focusToAdd21 = this.FocusToAdd;
      int skillLevelToAdd21 = this.SkillLevelToAdd;
      int attributeLevelToAdd21 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect18 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthOtherOutridersOnConsequence);
      CharacterCreationApplyFinalEffects onApply21 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthOtherOutridersOnApply);
      TextObject descriptionText21 = new TextObject("You couted ahead of the army.");
      creationCategory25.AddCategoryOption(text21, effectedSkills21, endurance8, focusToAdd21, skillLevelToAdd21, attributeLevelToAdd21, (CharacterCreationOnCondition) null, onSelect18, onApply21, descriptionText21);
      CharacterCreationCategory creationCategory26 = creationCategory21;
      TextObject text22 = new TextObject("joined the spearman front.");
      List<SkillObject> effectedSkills22 = new List<SkillObject>();
      effectedSkills22.Add(DefaultSkills.Polearm);
      effectedSkills22.Add(DefaultSkills.OneHanded);
      CharacterAttribute vigor4 = DefaultCharacterAttributes.Vigor;
      int focusToAdd22 = this.FocusToAdd;
      int skillLevelToAdd22 = this.SkillLevelToAdd;
      int attributeLevelToAdd22 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect19 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthInfantryOnConsequence);
      CharacterCreationApplyFinalEffects onApply22 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthInfantryOnApply);
      TextObject descriptionText22 = new TextObject("{=afH90aNs}Levy armed with spear and shield, drawn from smallholding farmers, have always been the backbone of most armies of Athas.");
      creationCategory26.AddCategoryOption(text22, effectedSkills22, vigor4, focusToAdd22, skillLevelToAdd22, attributeLevelToAdd22, (CharacterCreationOnCondition) null, onSelect19, onApply22, descriptionText22);
      CharacterCreationCategory creationCategory27 = creationCategory21;
      TextObject text23 = new TextObject("marched with the camp followers.");
      List<SkillObject> effectedSkills23 = new List<SkillObject>();
      effectedSkills23.Add(DefaultSkills.Roguery);
      effectedSkills23.Add(DefaultSkills.Throwing);
      CharacterAttribute cunning4 = DefaultCharacterAttributes.Cunning;
      int focusToAdd23 = this.FocusToAdd;
      int skillLevelToAdd23 = this.SkillLevelToAdd;
      int attributeLevelToAdd23 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect20 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthCamperOnConsequence);
      CharacterCreationApplyFinalEffects onApply23 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthCamperOnApply);
      TextObject descriptionText23 = new TextObject("{=64rWqBLN}You avoided service with one of the main forces of your realm's armies, but followed instead in the train - the troops' wives, lovers and servants, and those who make their living by caring for, entertaining, or cheating the soldiery.");
      creationCategory27.AddCategoryOption(text23, effectedSkills23, cunning4, focusToAdd23, skillLevelToAdd23, attributeLevelToAdd23, (CharacterCreationOnCondition) null, onSelect20, onApply23, descriptionText23);
      CharacterCreationCategory creationCategory28 = menu.AddMenuCategory(new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).KhuzaitParentsOnCondition));
      CharacterCreationCategory creationCategory29 = creationCategory28;
      TextObject text24 = new TextObject("served the Al-Khuur cavalry.");
      List<SkillObject> effectedSkills24 = new List<SkillObject>();
      effectedSkills24.Add(DefaultSkills.Riding);
      effectedSkills24.Add(DefaultSkills.Polearm);
      CharacterAttribute endurance9 = DefaultCharacterAttributes.Endurance;
      int focusToAdd24 = this.FocusToAdd;
      int skillLevelToAdd24 = this.SkillLevelToAdd;
      int attributeLevelToAdd24 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect21 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthCavalryOnConsequence);
      CharacterCreationApplyFinalEffects onApply24 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthCavalryOnApply);
      TextObject descriptionText24 = new TextObject("{=7cHsIMLP}You could never have bought the equipment on your own but you were a good enough rider so that the local lord lent you a horse and equipment. You joined the armored cavalry, training with the lance.");
      creationCategory29.AddCategoryOption(text24, effectedSkills24, endurance9, focusToAdd24, skillLevelToAdd24, attributeLevelToAdd24, (CharacterCreationOnCondition) null, onSelect21, onApply24, descriptionText24);
      CharacterCreationCategory creationCategory30 = creationCategory28;
      TextObject text25 = new TextObject("patrolled the villages and cities.");
      List<SkillObject> effectedSkills25 = new List<SkillObject>();
      effectedSkills25.Add(DefaultSkills.Crossbow);
      effectedSkills25.Add(DefaultSkills.Engineering);
      CharacterAttribute intelligence5 = DefaultCharacterAttributes.Intelligence;
      int focusToAdd25 = this.FocusToAdd;
      int skillLevelToAdd25 = this.SkillLevelToAdd;
      int attributeLevelToAdd25 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect22 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthGarrisonOnConsequence);
      CharacterCreationApplyFinalEffects onApply25 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthGarrisonOnApply);
      TextObject descriptionText25 = new TextObject("{=63TAYbkx}Urban troops spend much of their time guarding the town walls. Most of their training was in missile weapons, especially useful during sieges.");
      creationCategory30.AddCategoryOption(text25, effectedSkills25, intelligence5, focusToAdd25, skillLevelToAdd25, attributeLevelToAdd25, (CharacterCreationOnCondition) null, onSelect22, onApply25, descriptionText25);
      CharacterCreationCategory creationCategory31 = creationCategory28;
      TextObject text26 = new TextObject("trained with the infrantry.");
      List<SkillObject> effectedSkills26 = new List<SkillObject>();
      effectedSkills26.Add(DefaultSkills.Throwing);
      effectedSkills26.Add(DefaultSkills.OneHanded);
      CharacterAttribute control4 = DefaultCharacterAttributes.Control;
      int focusToAdd26 = this.FocusToAdd;
      int skillLevelToAdd26 = this.SkillLevelToAdd;
      int attributeLevelToAdd26 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect23 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthSkirmisherOnConsequence);
      CharacterCreationApplyFinalEffects onApply26 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthSkirmisherOnApply);
      TextObject descriptionText26 = new TextObject("{=bXAg5w19}Younger recruits, or those of a slighter build, or those too poor to buy shield and armor tend to join the skirmishers. Fighting with bow and javelin, they try to stay out of reach of the main enemy forces.");
      creationCategory31.AddCategoryOption(text26, effectedSkills26, control4, focusToAdd26, skillLevelToAdd26, attributeLevelToAdd26, (CharacterCreationOnCondition) null, onSelect23, onApply26, descriptionText26);
      CharacterCreationCategory creationCategory32 = creationCategory28;
      TextObject text27 = new TextObject("rode with the scouts.");
      List<SkillObject> effectedSkills27 = new List<SkillObject>();
      effectedSkills27.Add(DefaultSkills.Riding);
      effectedSkills27.Add(DefaultSkills.Bow);
      CharacterAttribute endurance10 = DefaultCharacterAttributes.Endurance;
      int focusToAdd27 = this.FocusToAdd;
      int skillLevelToAdd27 = this.SkillLevelToAdd;
      int attributeLevelToAdd27 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect24 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthOtherOutridersOnConsequence);
      CharacterCreationApplyFinalEffects onApply27 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthOtherOutridersOnApply);
      TextObject descriptionText27 = new TextObject("You couted ahead of the army.");
      creationCategory32.AddCategoryOption(text27, effectedSkills27, endurance10, focusToAdd27, skillLevelToAdd27, attributeLevelToAdd27, (CharacterCreationOnCondition) null, onSelect24, onApply27, descriptionText27);
      CharacterCreationCategory creationCategory33 = creationCategory28;
      TextObject text28 = new TextObject("joined the spearmen.");
      List<SkillObject> effectedSkills28 = new List<SkillObject>();
      effectedSkills28.Add(DefaultSkills.Polearm);
      effectedSkills28.Add(DefaultSkills.OneHanded);
      CharacterAttribute vigor5 = DefaultCharacterAttributes.Vigor;
      int focusToAdd28 = this.FocusToAdd;
      int skillLevelToAdd28 = this.SkillLevelToAdd;
      int attributeLevelToAdd28 = this.AttributeLevelToAdd;
      CharacterCreationApplyFinalEffects onApply28 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthInfantryOnApply);
      TextObject descriptionText28 = new TextObject("{=afH90aNs}Levy armed with spear and shield, drawn from smallholding farmers, have always been the backbone of most armies of Athas.");
      creationCategory33.AddCategoryOption(text28, effectedSkills28, vigor5, focusToAdd28, skillLevelToAdd28, attributeLevelToAdd28, (CharacterCreationOnCondition) null, (CharacterCreationOnSelect) null, onApply28, descriptionText28);
      CharacterCreationCategory creationCategory34 = creationCategory28;
      TextObject text29 = new TextObject("marched with the campfollowers.");
      List<SkillObject> effectedSkills29 = new List<SkillObject>();
      effectedSkills29.Add(DefaultSkills.Roguery);
      effectedSkills29.Add(DefaultSkills.Throwing);
      CharacterAttribute cunning5 = DefaultCharacterAttributes.Cunning;
      int focusToAdd29 = this.FocusToAdd;
      int skillLevelToAdd29 = this.SkillLevelToAdd;
      int attributeLevelToAdd29 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect25 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthCamperOnConsequence);
      CharacterCreationApplyFinalEffects onApply29 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthCamperOnApply);
      TextObject descriptionText29 = new TextObject("{=64rWqBLN}You avoided service with one of the main forces of your realm's armies, but followed instead in the train - the troops' wives, lovers and servants, and those who make their living by caring for, entertaining, or cheating the soldiery.");
      creationCategory34.AddCategoryOption(text29, effectedSkills29, cunning5, focusToAdd29, skillLevelToAdd29, attributeLevelToAdd29, (CharacterCreationOnCondition) null, onSelect25, onApply29, descriptionText29);
      CharacterCreationCategory creationCategory35 = menu.AddMenuCategory(new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).SturgianParentsOnCondition));
      CharacterCreationCategory creationCategory36 = creationCategory35;
      TextObject text30 = new TextObject("served in the Dreadlords bodyguard.");
      List<SkillObject> effectedSkills30 = new List<SkillObject>();
      effectedSkills30.Add(DefaultSkills.Riding);
      effectedSkills30.Add(DefaultSkills.Polearm);
      CharacterAttribute endurance11 = DefaultCharacterAttributes.Endurance;
      int focusToAdd30 = this.FocusToAdd;
      int skillLevelToAdd30 = this.SkillLevelToAdd;
      int attributeLevelToAdd30 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect26 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthCavalryOnConsequence);
      CharacterCreationApplyFinalEffects onApply30 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthCavalryOnApply);
      TextObject descriptionText30 = new TextObject("Protecting your dreadlord was your main duty.");
      creationCategory36.AddCategoryOption(text30, effectedSkills30, endurance11, focusToAdd30, skillLevelToAdd30, attributeLevelToAdd30, (CharacterCreationOnCondition) null, onSelect26, onApply30, descriptionText30);
      CharacterCreationCategory creationCategory37 = creationCategory35;
      TextObject text31 = new TextObject("stood guard with the garrisons.");
      List<SkillObject> effectedSkills31 = new List<SkillObject>();
      effectedSkills31.Add(DefaultSkills.Crossbow);
      effectedSkills31.Add(DefaultSkills.Engineering);
      CharacterAttribute intelligence6 = DefaultCharacterAttributes.Intelligence;
      int focusToAdd31 = this.FocusToAdd;
      int skillLevelToAdd31 = this.SkillLevelToAdd;
      int attributeLevelToAdd31 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect27 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthGarrisonOnConsequence);
      CharacterCreationApplyFinalEffects onApply31 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthGarrisonOnApply);
      TextObject descriptionText31 = new TextObject("{=63TAYbkx}Urban troops spend much of their time guarding the town walls. Most of their training was in missile weapons, especially useful during sieges.");
      creationCategory37.AddCategoryOption(text31, effectedSkills31, intelligence6, focusToAdd31, skillLevelToAdd31, attributeLevelToAdd31, (CharacterCreationOnCondition) null, onSelect27, onApply31, descriptionText31);
      CharacterCreationCategory creationCategory38 = creationCategory35;
      TextObject text32 = new TextObject("trained with the infrantry.");
      List<SkillObject> effectedSkills32 = new List<SkillObject>();
      effectedSkills32.Add(DefaultSkills.Throwing);
      effectedSkills32.Add(DefaultSkills.OneHanded);
      CharacterAttribute control5 = DefaultCharacterAttributes.Control;
      int focusToAdd32 = this.FocusToAdd;
      int skillLevelToAdd32 = this.SkillLevelToAdd;
      int attributeLevelToAdd32 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect28 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthSkirmisherOnConsequence);
      CharacterCreationApplyFinalEffects onApply32 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthSkirmisherOnApply);
      TextObject descriptionText32 = new TextObject("{=bXAg5w19}Younger recruits, or those of a slighter build, or those too poor to buy shield and armor tend to join the skirmishers. Fighting with bow and javelin, they try to stay out of reach of the main enemy forces.");
      creationCategory38.AddCategoryOption(text32, effectedSkills32, control5, focusToAdd32, skillLevelToAdd32, attributeLevelToAdd32, (CharacterCreationOnCondition) null, onSelect28, onApply32, descriptionText32);
      CharacterCreationCategory creationCategory39 = creationCategory35;
      TextObject text33 = new TextObject("rode with the scouts.");
      List<SkillObject> effectedSkills33 = new List<SkillObject>();
      effectedSkills33.Add(DefaultSkills.Riding);
      effectedSkills33.Add(DefaultSkills.Bow);
      CharacterAttribute endurance12 = DefaultCharacterAttributes.Endurance;
      int focusToAdd33 = this.FocusToAdd;
      int skillLevelToAdd33 = this.SkillLevelToAdd;
      int attributeLevelToAdd33 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect29 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthOtherOutridersOnConsequence);
      CharacterCreationApplyFinalEffects onApply33 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthOtherOutridersOnApply);
      TextObject descriptionText33 = new TextObject("You couted ahead of the army.");
      creationCategory39.AddCategoryOption(text33, effectedSkills33, endurance12, focusToAdd33, skillLevelToAdd33, attributeLevelToAdd33, (CharacterCreationOnCondition) null, onSelect29, onApply33, descriptionText33);
      CharacterCreationCategory creationCategory40 = creationCategory35;
      TextObject text34 = new TextObject("joined the skirmishers.");
      List<SkillObject> effectedSkills34 = new List<SkillObject>();
      effectedSkills34.Add(DefaultSkills.Polearm);
      effectedSkills34.Add(DefaultSkills.OneHanded);
      CharacterAttribute vigor6 = DefaultCharacterAttributes.Vigor;
      int focusToAdd34 = this.FocusToAdd;
      int skillLevelToAdd34 = this.SkillLevelToAdd;
      int attributeLevelToAdd34 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect30 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthInfantryOnConsequence);
      CharacterCreationApplyFinalEffects onApply34 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthInfantryOnApply);
      TextObject descriptionText34 = new TextObject("{=afH90aNs}Levy armed with spear and shield, drawn from smallholding farmers, have always been the backbone of most armies of Athas.");
      creationCategory40.AddCategoryOption(text34, effectedSkills34, vigor6, focusToAdd34, skillLevelToAdd34, attributeLevelToAdd34, (CharacterCreationOnCondition) null, onSelect30, onApply34, descriptionText34);
      CharacterCreationCategory creationCategory41 = creationCategory35;
      TextObject text35 = new TextObject("marched with the army retinue.");
      List<SkillObject> effectedSkills35 = new List<SkillObject>();
      effectedSkills35.Add(DefaultSkills.Roguery);
      effectedSkills35.Add(DefaultSkills.Throwing);
      CharacterAttribute cunning6 = DefaultCharacterAttributes.Cunning;
      int focusToAdd35 = this.FocusToAdd;
      int skillLevelToAdd35 = this.SkillLevelToAdd;
      int attributeLevelToAdd35 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect31 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).YouthCamperOnConsequence);
      CharacterCreationApplyFinalEffects onApply35 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).YouthCamperOnApply);
      TextObject descriptionText35 = new TextObject("{=64rWqBLN}You avoided service with one of the main forces of your realm's armies, but followed instead in the train - the troops' wives, lovers and servants, and those who make their living by caring for, entertaining, or cheating the soldiery.");
      creationCategory41.AddCategoryOption(text35, effectedSkills35, cunning6, focusToAdd35, skillLevelToAdd35, attributeLevelToAdd35, (CharacterCreationOnCondition) null, onSelect31, onApply35, descriptionText35);
      characterCreation.AddNewMenu(menu);
    }

    protected new void AddAdulthoodMenu(CharacterCreation characterCreation)
    {
      MBTextManager.SetTextVariable("EXP_VALUE", this.SkillLevelToAdd);
      CharacterCreationMenu menu = new CharacterCreationMenu(new TextObject("{=MafIe9yI}Young Adulthood"), new TextObject("{=4WYY0X59}Before you set out for a life of adventure, your biggest achievement was..."), new CharacterCreationOnInit(((SandboxCharacterCreationContent) this).AccomplishmentOnInit));
      CharacterCreationCategory creationCategory1 = menu.AddMenuCategory();
      CharacterCreationCategory creationCategory2 = creationCategory1;
      TextObject text1 = new TextObject("{=8bwpVpgy}you defeated an enemy in battle.");
      List<SkillObject> effectedSkills1 = new List<SkillObject>();
      effectedSkills1.Add(DefaultSkills.OneHanded);
      effectedSkills1.Add(DefaultSkills.TwoHanded);
      CharacterAttribute vigor = DefaultCharacterAttributes.Vigor;
      int focusToAdd1 = this.FocusToAdd;
      int skillLevelToAdd1 = this.SkillLevelToAdd;
      int attributeLevelToAdd1 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect1 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AccomplishmentDefeatedEnemyOnConsequence);
      CharacterCreationApplyFinalEffects onApply1 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AccomplishmentDefeatedEnemyOnApply);
      TextObject descriptionText1 = new TextObject("{=1IEroJKs}Not everyone who musters for the levy marches to war, and not everyone who goes on campaign sees action. You did both, and you also took down an enemy warrior in direct one-to-one combat, in the full view of your comrades.");
      creationCategory2.AddCategoryOption(text1, effectedSkills1, vigor, focusToAdd1, skillLevelToAdd1, attributeLevelToAdd1, (CharacterCreationOnCondition) null, onSelect1, onApply1, descriptionText1, new List<TraitObject>()
      {
        DefaultTraits.Valor
      }, 1, 20);
      CharacterCreationCategory creationCategory3 = creationCategory1;
      TextObject text2 = new TextObject("{=mP3uFbcq}you led a successful manhunt.");
      List<SkillObject> effectedSkills2 = new List<SkillObject>();
      effectedSkills2.Add(DefaultSkills.Tactics);
      effectedSkills2.Add(DefaultSkills.Leadership);
      CharacterAttribute cunning1 = DefaultCharacterAttributes.Cunning;
      int focusToAdd2 = this.FocusToAdd;
      int skillLevelToAdd2 = this.SkillLevelToAdd;
      int attributeLevelToAdd2 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition1 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).AccomplishmentPosseOnConditions);
      CharacterCreationOnSelect onSelect2 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AccomplishmentExpeditionOnConsequence);
      CharacterCreationApplyFinalEffects onApply2 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AccomplishmentExpeditionOnApply);
      TextObject descriptionText2 = new TextObject("{=4f5xwzX0}When your community needed to organize a posse to pursue horse thieves, you were the obvious choice. You hunted down the raiders, surrounded them and forced their surrender, and took back your stolen property.");
      creationCategory3.AddCategoryOption(text2, effectedSkills2, cunning1, focusToAdd2, skillLevelToAdd2, attributeLevelToAdd2, optionCondition1, onSelect2, onApply2, descriptionText2, new List<TraitObject>()
      {
        DefaultTraits.Calculating
      }, 1, 10);
      CharacterCreationCategory creationCategory4 = creationCategory1;
      TextObject text3 = new TextObject("{=wfbtS71d}you led a caravan.");
      List<SkillObject> effectedSkills3 = new List<SkillObject>();
      effectedSkills3.Add(DefaultSkills.Tactics);
      effectedSkills3.Add(DefaultSkills.Leadership);
      CharacterAttribute cunning2 = DefaultCharacterAttributes.Cunning;
      int focusToAdd3 = this.FocusToAdd;
      int skillLevelToAdd3 = this.SkillLevelToAdd;
      int attributeLevelToAdd3 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition2 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).AccomplishmentMerchantOnCondition);
      CharacterCreationOnSelect onSelect3 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AccomplishmentMerchantOnConsequence);
      CharacterCreationApplyFinalEffects onApply3 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AccomplishmentExpeditionOnApply);
      TextObject descriptionText3 = new TextObject("{=joRHKCkm}Your family needed someone trustworthy to take a caravan to a neighboring town. You organized supplies, ensured a constant watch to keep away bandits, and brought it safely to its destination.");
      creationCategory4.AddCategoryOption(text3, effectedSkills3, cunning2, focusToAdd3, skillLevelToAdd3, attributeLevelToAdd3, optionCondition2, onSelect3, onApply3, descriptionText3, new List<TraitObject>()
      {
        DefaultTraits.Calculating
      }, 1, 10);
      CharacterCreationCategory creationCategory5 = creationCategory1;
      TextObject text4 = new TextObject("{=x1HTX5hq}you saved your village from a flood.");
      List<SkillObject> effectedSkills4 = new List<SkillObject>();
      effectedSkills4.Add(DefaultSkills.Tactics);
      effectedSkills4.Add(DefaultSkills.Leadership);
      CharacterAttribute cunning3 = DefaultCharacterAttributes.Cunning;
      int focusToAdd4 = this.FocusToAdd;
      int skillLevelToAdd4 = this.SkillLevelToAdd;
      int attributeLevelToAdd4 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition3 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).AccomplishmentSavedVillageOnCondition);
      CharacterCreationOnSelect onSelect4 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AccomplishmentSavedVillageOnConsequence);
      CharacterCreationApplyFinalEffects onApply4 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AccomplishmentExpeditionOnApply);
      TextObject descriptionText4 = new TextObject("{=bWlmGDf3}When a sudden storm caused the local stream to rise suddenly, your neighbors needed quick-thinking leadership. You provided it, directing them to build levees to save their homes.");
      creationCategory5.AddCategoryOption(text4, effectedSkills4, cunning3, focusToAdd4, skillLevelToAdd4, attributeLevelToAdd4, optionCondition3, onSelect4, onApply4, descriptionText4, new List<TraitObject>()
      {
        DefaultTraits.Calculating
      }, 1, 10);
      CharacterCreationCategory creationCategory6 = creationCategory1;
      TextObject text5 = new TextObject("{=s8PNllPN}you saved your city quarter from a fire.");
      List<SkillObject> effectedSkills5 = new List<SkillObject>();
      effectedSkills5.Add(DefaultSkills.Tactics);
      effectedSkills5.Add(DefaultSkills.Leadership);
      CharacterAttribute cunning4 = DefaultCharacterAttributes.Cunning;
      int focusToAdd5 = this.FocusToAdd;
      int skillLevelToAdd5 = this.SkillLevelToAdd;
      int attributeLevelToAdd5 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition4 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).AccomplishmentSavedStreetOnCondition);
      CharacterCreationOnSelect onSelect5 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AccomplishmentSavedStreetOnConsequence);
      CharacterCreationApplyFinalEffects onApply5 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AccomplishmentExpeditionOnApply);
      TextObject descriptionText5 = new TextObject("{=ZAGR6PYc}When a sudden blaze broke out in a back alley, your neighbors needed quick-thinking leadership and you provided it. You organized a bucket line to the nearest well, putting the fire out before any homes were lost.");
      creationCategory6.AddCategoryOption(text5, effectedSkills5, cunning4, focusToAdd5, skillLevelToAdd5, attributeLevelToAdd5, optionCondition4, onSelect5, onApply5, descriptionText5, new List<TraitObject>()
      {
        DefaultTraits.Calculating
      }, 1, 10);
      CharacterCreationCategory creationCategory7 = creationCategory1;
      TextObject text6 = new TextObject("{=xORjDTal}you invested some money in a workshop.");
      List<SkillObject> effectedSkills6 = new List<SkillObject>();
      effectedSkills6.Add(DefaultSkills.Trade);
      effectedSkills6.Add(DefaultSkills.Crafting);
      CharacterAttribute intelligence1 = DefaultCharacterAttributes.Intelligence;
      int focusToAdd6 = this.FocusToAdd;
      int skillLevelToAdd6 = this.SkillLevelToAdd;
      int attributeLevelToAdd6 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition5 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).AccomplishmentUrbanOnCondition);
      CharacterCreationOnSelect onSelect6 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AccomplishmentWorkshopOnConsequence);
      CharacterCreationApplyFinalEffects onApply6 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AccomplishmentWorkshopOnApply);
      TextObject descriptionText6 = new TextObject("{=PyVqDLBu}Your parents didn't give you much money, but they did leave just enough for you to secure a loan against a larger amount to build a small workshop. You paid back what you borrowed, and sold your enterprise for a profit.");
      creationCategory7.AddCategoryOption(text6, effectedSkills6, intelligence1, focusToAdd6, skillLevelToAdd6, attributeLevelToAdd6, optionCondition5, onSelect6, onApply6, descriptionText6, new List<TraitObject>()
      {
        DefaultTraits.Calculating
      }, 1, 10);
      CharacterCreationCategory creationCategory8 = creationCategory1;
      TextObject text7 = new TextObject("{=xKXcqRJI}you invested some money in land.");
      List<SkillObject> effectedSkills7 = new List<SkillObject>();
      effectedSkills7.Add(DefaultSkills.Trade);
      effectedSkills7.Add(DefaultSkills.Crafting);
      CharacterAttribute intelligence2 = DefaultCharacterAttributes.Intelligence;
      int focusToAdd7 = this.FocusToAdd;
      int skillLevelToAdd7 = this.SkillLevelToAdd;
      int attributeLevelToAdd7 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition6 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).AccomplishmentRuralOnCondition);
      CharacterCreationOnSelect onSelect7 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AccomplishmentWorkshopOnConsequence);
      CharacterCreationApplyFinalEffects onApply7 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AccomplishmentWorkshopOnApply);
      TextObject descriptionText7 = new TextObject("{=cbF9jdQo}Your parents didn't give you much money, but they did leave just enough for you to purchase a plot of unused land at the edge of the village. You cleared away rocks and dug an irrigation ditch, raised a few seasons of crops, than sold it for a considerable profit.");
      creationCategory8.AddCategoryOption(text7, effectedSkills7, intelligence2, focusToAdd7, skillLevelToAdd7, attributeLevelToAdd7, optionCondition6, onSelect7, onApply7, descriptionText7, new List<TraitObject>()
      {
        DefaultTraits.Calculating
      }, 1, 10);
      CharacterCreationCategory creationCategory9 = creationCategory1;
      TextObject text8 = new TextObject("{=TbNRtUjb}you hunted a dangerous animal.");
      List<SkillObject> effectedSkills8 = new List<SkillObject>();
      effectedSkills8.Add(DefaultSkills.Polearm);
      effectedSkills8.Add(DefaultSkills.Crossbow);
      CharacterAttribute control1 = DefaultCharacterAttributes.Control;
      int focusToAdd8 = this.FocusToAdd;
      int skillLevelToAdd8 = this.SkillLevelToAdd;
      int attributeLevelToAdd8 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition7 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).AccomplishmentRuralOnCondition);
      CharacterCreationOnSelect onSelect8 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AccomplishmentSiegeHunterOnConsequence);
      CharacterCreationApplyFinalEffects onApply8 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AccomplishmentSiegeHunterOnApply);
      TextObject descriptionText8 = new TextObject("{=I3PcdaaL}Wolves, bears are a constant menace to the flocks of northern Athas, while hyenas and leopards trouble the south. You went with a group of your fellow villagers and fired the missile that brought down the beast.");
      creationCategory9.AddCategoryOption(text8, effectedSkills8, control1, focusToAdd8, skillLevelToAdd8, attributeLevelToAdd8, optionCondition7, onSelect8, onApply8, descriptionText8, renownToAdd: 5);
      CharacterCreationCategory creationCategory10 = creationCategory1;
      TextObject text9 = new TextObject("{=WbHfGCbd}you survived a siege.");
      List<SkillObject> effectedSkills9 = new List<SkillObject>();
      effectedSkills9.Add(DefaultSkills.Bow);
      effectedSkills9.Add(DefaultSkills.Crossbow);
      CharacterAttribute control2 = DefaultCharacterAttributes.Control;
      int focusToAdd9 = this.FocusToAdd;
      int skillLevelToAdd9 = this.SkillLevelToAdd;
      int attributeLevelToAdd9 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition8 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).AccomplishmentUrbanOnCondition);
      CharacterCreationOnSelect onSelect9 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AccomplishmentSiegeHunterOnConsequence);
      CharacterCreationApplyFinalEffects onApply9 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AccomplishmentSiegeHunterOnApply);
      TextObject descriptionText9 = new TextObject("{=FhZPjhli}Your hometown was briefly placed under siege, and you were called to defend the walls. Everyone did their part to repulse the enemy assault, and everyone is justly proud of what they endured.");
      creationCategory10.AddCategoryOption(text9, effectedSkills9, control2, focusToAdd9, skillLevelToAdd9, attributeLevelToAdd9, optionCondition8, onSelect9, onApply9, descriptionText9, renownToAdd: 5);
      CharacterCreationCategory creationCategory11 = creationCategory1;
      TextObject text10 = new TextObject("{=kNXet6Um}you had a famous escapade in town.");
      List<SkillObject> effectedSkills10 = new List<SkillObject>();
      effectedSkills10.Add(DefaultSkills.Athletics);
      effectedSkills10.Add(DefaultSkills.Roguery);
      CharacterAttribute endurance1 = DefaultCharacterAttributes.Endurance;
      int focusToAdd10 = this.FocusToAdd;
      int skillLevelToAdd10 = this.SkillLevelToAdd;
      int attributeLevelToAdd10 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition9 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).AccomplishmentRuralOnCondition);
      CharacterCreationOnSelect onSelect10 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AccomplishmentEscapadeOnConsequence);
      CharacterCreationApplyFinalEffects onApply10 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AccomplishmentEscapadeOnApply);
      TextObject descriptionText10 = new TextObject("{=DjeAJtix}Maybe it was a love affair, or maybe you cheated at dice, or maybe you just chose your words poorly when drinking with a dangerous crowd. Anyway, on one of your trips into town you got into the kind of trouble from which only a quick tongue or quick feet get you out alive.");
      creationCategory11.AddCategoryOption(text10, effectedSkills10, endurance1, focusToAdd10, skillLevelToAdd10, attributeLevelToAdd10, optionCondition9, onSelect10, onApply10, descriptionText10, new List<TraitObject>()
      {
        DefaultTraits.Valor
      }, 1, 5);
      CharacterCreationCategory creationCategory12 = creationCategory1;
      TextObject text11 = new TextObject("{=qlOuiKXj}you had a famous escapade.");
      List<SkillObject> effectedSkills11 = new List<SkillObject>();
      effectedSkills11.Add(DefaultSkills.Athletics);
      effectedSkills11.Add(DefaultSkills.Roguery);
      CharacterAttribute endurance2 = DefaultCharacterAttributes.Endurance;
      int focusToAdd11 = this.FocusToAdd;
      int skillLevelToAdd11 = this.SkillLevelToAdd;
      int attributeLevelToAdd11 = this.AttributeLevelToAdd;
      CharacterCreationOnCondition optionCondition10 = new CharacterCreationOnCondition(((SandboxCharacterCreationContent) this).AccomplishmentUrbanOnCondition);
      CharacterCreationOnSelect onSelect11 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AccomplishmentEscapadeOnConsequence);
      CharacterCreationApplyFinalEffects onApply11 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AccomplishmentEscapadeOnApply);
      TextObject descriptionText11 = new TextObject("{=lD5Ob3R4}Maybe it was a love affair, or maybe you cheated at dice, or maybe you just chose your words poorly when drinking with a dangerous crowd. Anyway, you got into the kind of trouble from which only a quick tongue or quick feet get you out alive.");
      creationCategory12.AddCategoryOption(text11, effectedSkills11, endurance2, focusToAdd11, skillLevelToAdd11, attributeLevelToAdd11, optionCondition10, onSelect11, onApply11, descriptionText11, new List<TraitObject>()
      {
        DefaultTraits.Valor
      }, 1, 5);
      CharacterCreationCategory creationCategory13 = creationCategory1;
      TextObject text12 = new TextObject("{=Yqm0Dics}you treated people well.");
      List<SkillObject> effectedSkills12 = new List<SkillObject>();
      effectedSkills12.Add(DefaultSkills.Charm);
      effectedSkills12.Add(DefaultSkills.Steward);
      CharacterAttribute social = DefaultCharacterAttributes.Social;
      int focusToAdd12 = this.FocusToAdd;
      int skillLevelToAdd12 = this.SkillLevelToAdd;
      int attributeLevelToAdd12 = this.AttributeLevelToAdd;
      CharacterCreationOnSelect onSelect12 = new CharacterCreationOnSelect(((SandboxCharacterCreationContent) this).AccomplishmentTreaterOnConsequence);
      CharacterCreationApplyFinalEffects onApply12 = new CharacterCreationApplyFinalEffects(((SandboxCharacterCreationContent) this).AccomplishmentTreaterOnApply);
      TextObject descriptionText12 = new TextObject("{=dDmcqTzb}Yours wasn't the kind of reputation that local legends are made of, but it was the kind that wins you respect among those around you. You were consistently fair and honest in your business dealings and helpful to those in trouble. In doing so, you got a sense of what made people tick.");
      creationCategory13.AddCategoryOption(text12, effectedSkills12, social, focusToAdd12, skillLevelToAdd12, attributeLevelToAdd12, (CharacterCreationOnCondition) null, onSelect12, onApply12, descriptionText12, new List<TraitObject>()
      {
        DefaultTraits.Mercy,
        DefaultTraits.Generosity,
        DefaultTraits.Honor
      }, 1, 5);
      characterCreation.AddNewMenu(menu);
    }
  }
}

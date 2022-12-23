// Decompiled with JetBrains decompiler
// Type: RealmsForgotten.Patches
// Assembly: RealmsForgotten, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B26E324A-F09C-4542-BFFC-02D91686071A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\RF_Core\bin\Win64_Shipping_Client\RealmsForgotten.dll

using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Core;

namespace RealmsForgotten
{
  public class Patches
  {
    private static readonly AccessTools.StructFieldRef<BodyProperties, StaticBodyProperties> StaticBodyProps = AccessTools.StructFieldRefAccess<BodyProperties, StaticBodyProperties>("_staticBodyProperties");
    private static readonly Random random = new Random();

    [HarmonyPatch(typeof (SandboxCharacterCreationContent), "OnCultureSelected")]
    public class SandboxCharacterCreationContentRefreshPropsAndClothing
    {
      public static void Postfix()
      {
        CharacterObject playerCharacter = CharacterObject.PlayerCharacter;
        playerCharacter.UpdatePlayerCharacterBodyProperties(Helper.GenerateCultureBodyProperties(playerCharacter.Culture.StringId), playerCharacter.Race, playerCharacter.IsFemale);
      }
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: RealmsForgotten.Main
// Assembly: RealmsForgotten, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B26E324A-F09C-4542-BFFC-02D91686071A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\RF_Core\bin\Win64_Shipping_Client\RealmsForgotten.dll

using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.ModuleManager;
using TaleWorlds.MountAndBlade;
using TaleWorlds.DotNet;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Library;
using TaleWorlds.CampaignSystem.CharacterDevelopment;

namespace RealmsForgotten
{
  public class Main : MBSubModuleBase
  {
    internal static readonly Random random = new Random();
    internal static Dictionary<string, Tuple<string, string, string, string>> villagerMin = new Dictionary<string, Tuple<string, string, string, string>>();
    internal static Dictionary<string, Tuple<string, string, string, string>> villagerMax = new Dictionary<string, Tuple<string, string, string, string>>();
    internal static Dictionary<string, Tuple<string, string, string, string>> fighterMin = new Dictionary<string, Tuple<string, string, string, string>>();
    internal static Dictionary<string, Tuple<string, string, string, string>> fighterMax = new Dictionary<string, Tuple<string, string, string, string>>();
    internal static readonly string[] cultures = new string[6]
    {
      "battania",
      "aserai",
      "empire",
      "khuzait",
      "sturgia",
      "vlandia"
    };

    protected override void OnSubModuleLoad()
    {
      base.OnSubModuleLoad();
      TextObject coreContentDisabledReason = new TextObject("Disabled during installation.");
      Module.CurrentModule.AddInitialStateOption(new InitialStateOption("RT", new TextObject("Realms Forgotten"), 3, (Action) (() => MBGameManager.StartNewGame((MBGameManager) new RFCampaignManager())), (Func<(bool, TextObject)>) (() => (Module.CurrentModule.IsOnlyCoreContentEnabled, coreContentDisabledReason))));
      new Harmony("mod.bannerlord.realmsforgotten").PatchAll();
    }

    protected override void InitializeGameStarter(Game game, IGameStarter starterObject)
    {
      base.InitializeGameStarter(game, starterObject);
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(Path.Combine(ModuleHelper.GetModuleFullPath("SandBoxCore") + "ModuleData/sandboxcore_bodyproperties.xml"));
      Main.villagerMax = new Dictionary<string, Tuple<string, string, string, string>>();
      Main.villagerMin = new Dictionary<string, Tuple<string, string, string, string>>();
      Main.fighterMax = new Dictionary<string, Tuple<string, string, string, string>>();
      Main.fighterMin = new Dictionary<string, Tuple<string, string, string, string>>();
      foreach (XmlNode childNode1 in xmlDocument.ChildNodes)
      {
        if (!(childNode1.Name != "BodyProperties"))
        {
          foreach (XmlNode xmlNode in childNode1)
          {
            if (!(xmlNode.Name != "BodyProperty"))
            {
              XmlAttribute attribute = xmlNode.Attributes["id"];
              for (int index = 0; index < Main.cultures.Length; ++index)
              {
                foreach (XmlElement childNode2 in xmlNode.ChildNodes)
                {
                  if (attribute.FirstChild.Value.Contains(Main.cultures[index]))
                  {
                    Tuple<string, string, string, string> tuple;
                    if (!Main.villagerMin.TryGetValue(Main.cultures[index], out tuple) && childNode2.Name == "BodyPropertiesMin" && xmlNode.Attributes["id"].Value.Contains("villager"))
                    {
                      Dictionary<string, Tuple<string, string, string, string>> villagerMin = Main.villagerMin;
                      Dictionary<string, Tuple<string, string, string, string>> villagerMax = Main.villagerMax;
                      Main.villagerMin.Add(Main.cultures[index], new Tuple<string, string, string, string>(childNode2.Attributes["age"].Value, childNode2.Attributes["weight"].Value, childNode2.Attributes["build"].Value, childNode2.Attributes["key"].Value));
                    }
                    else if (!Main.villagerMax.TryGetValue(Main.cultures[index], out tuple) && childNode2.Name == "BodyPropertiesMax" && xmlNode.Attributes["id"].Value.Contains("villager"))
                      Main.villagerMax.Add(Main.cultures[index], new Tuple<string, string, string, string>(childNode2.Attributes["age"].Value, childNode2.Attributes["weight"].Value, childNode2.Attributes["build"].Value, childNode2.Attributes["key"].Value));
                    else if (!Main.fighterMin.TryGetValue(Main.cultures[index], out tuple) && childNode2.Name == "BodyPropertiesMin" && xmlNode.Attributes["id"].Value.Contains("fighter"))
                      Main.fighterMin.Add(Main.cultures[index], new Tuple<string, string, string, string>(childNode2.Attributes["age"].Value, childNode2.Attributes["weight"].Value, childNode2.Attributes["build"].Value, childNode2.Attributes["key"].Value));
                    else if (!Main.fighterMax.TryGetValue(Main.cultures[index], out tuple) && childNode2.Name == "BodyPropertiesMax" && xmlNode.Attributes["id"].Value.Contains("fighter"))
                      Main.fighterMax.Add(Main.cultures[index], new Tuple<string, string, string, string>(childNode2.Attributes["age"].Value, childNode2.Attributes["weight"].Value, childNode2.Attributes["build"].Value, childNode2.Attributes["key"].Value));
                  }
                }
              }
            }
          }
        }
      }
    }
  }
}

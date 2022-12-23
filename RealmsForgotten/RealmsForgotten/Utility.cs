// Decompiled with JetBrains decompiler
// Type: RealmsForgotten.Utility
// Assembly: RealmsForgotten, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B26E324A-F09C-4542-BFFC-02D91686071A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\RF_Core\bin\Win64_Shipping_Client\RealmsForgotten.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace RealmsForgotten
{
  internal class Utility
  {
    public static void removeInitialStateOption(string name)
    {
      try
      {
        FieldInfo field = typeof (TaleWorlds.MountAndBlade.Module).GetField("_initialStateOptions", BindingFlags.Instance | BindingFlags.NonPublic);
        object obj = field.GetValue((object) TaleWorlds.MountAndBlade.Module.CurrentModule);
        if (!(obj.GetType() == typeof (List<InitialStateOption>)))
          return;
        List<InitialStateOption> initialStateOptionList = (List<InitialStateOption>) obj;
        foreach (InitialStateOption initialStateOption in initialStateOptionList)
        {
          if (initialStateOption.Id.Contains(name))
            initialStateOptionList.Remove(initialStateOption);
        }
        field.SetValue((object) typeof (TaleWorlds.MountAndBlade.Module).GetField("_initialStateOptions", BindingFlags.Instance | BindingFlags.NonPublic), (object) initialStateOptionList);
      }
      catch (Exception ex)
      {
        InformationManager.DisplayMessage(new InformationMessage(ex.Message));
      }
    }
  }
}

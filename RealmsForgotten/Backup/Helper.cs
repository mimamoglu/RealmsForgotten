// Decompiled with JetBrains decompiler
// Type: Helper
// Assembly: RealmsForgotten, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B26E324A-F09C-4542-BFFC-02D91686071A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Mount & Blade II Bannerlord\Modules\RF_Core\bin\Win64_Shipping_Client\RealmsForgotten.dll

using HarmonyLib;
using RealmsForgotten;
using System;
using System.Xml;
using TaleWorlds.Core;

public static class Helper
{
  public static long NextLong(this Random random, long min, long max)
  {
    ulong num = (ulong) (max - min);
    ulong int64;
    do
    {
      byte[] buffer = new byte[8];
      random.NextBytes(buffer);
      int64 = (ulong) BitConverter.ToInt64(buffer, 0);
    }
    while (int64 > ulong.MaxValue - (ulong.MaxValue % num + 1UL) % num);
    return (long) (int64 % num) + min;
  }

  internal static BodyProperties GenerateCultureBodyProperties(string culture)
  {
    Tuple<string, string, string, string> tuple1 = Main.fighterMin[culture];
    Tuple<string, string, string, string> tuple2 = Main.fighterMax[culture];
    XmlDocument xmlDocument = new XmlDocument();
    XmlNode node = xmlDocument.CreateNode(XmlNodeType.Element, "BodyProperty", (string) null);
    xmlDocument.AppendChild(node);
    XmlAttribute attribute = xmlDocument.CreateAttribute("key", (string) null);
    attribute.Value = tuple1.Item4;
    node.Attributes.Append(attribute);
    BodyProperties bodyProperties;
    BodyProperties.FromXmlNode(node, out bodyProperties);
    ulong num1 = Traverse.Create((object) bodyProperties).Property<ulong>("KeyPart1", (object[]) null).Value;
    ulong num2 = Traverse.Create((object) bodyProperties).Property<ulong>("KeyPart2", (object[]) null).Value;
    ulong num3 = Traverse.Create((object) bodyProperties).Property<ulong>("KeyPart3", (object[]) null).Value;
    ulong num4 = Traverse.Create((object) bodyProperties).Property<ulong>("KeyPart4", (object[]) null).Value;
    ulong num5 = Traverse.Create((object) bodyProperties).Property<ulong>("KeyPart5", (object[]) null).Value;
    ulong num6 = Traverse.Create((object) bodyProperties).Property<ulong>("KeyPart8", (object[]) null).Value;
    ulong num7 = num1 << 32;
    ulong num8 = num2 << 32;
    ulong num9 = num3 << 32;
    ulong num10 = num4 << 32;
    ulong num11 = num5 << 32;
    ulong num12 = num6 << 32;
    attribute.Value = tuple2.Item4;
    StaticBodyProperties staticBodyProperties1;
    StaticBodyProperties.FromXmlNode(node, out staticBodyProperties1);
    ulong num13 = Traverse.Create((object) staticBodyProperties1).Property<ulong>("KeyPart1", (object[]) null).Value;
    ulong num14 = Traverse.Create((object) staticBodyProperties1).Property<ulong>("KeyPart2", (object[]) null).Value;
    ulong num15 = Traverse.Create((object) staticBodyProperties1).Property<ulong>("KeyPart3", (object[]) null).Value;
    ulong num16 = Traverse.Create((object) staticBodyProperties1).Property<ulong>("KeyPart4", (object[]) null).Value;
    ulong num17 = Traverse.Create((object) staticBodyProperties1).Property<ulong>("KeyPart5", (object[]) null).Value;
    ulong num18 = Traverse.Create((object) staticBodyProperties1).Property<ulong>("KeyPart8", (object[]) null).Value;
    ulong max1 = num13 << 32;
    ulong max2 = num14 << 32;
    ulong max3 = num15 << 32;
    ulong max4 = num16 << 32;
    ulong max5 = num17 << 32;
    ulong max6 = num18 << 32;
    ulong num19 = (ulong) Main.random.NextLong((long) num7, (long) max1);
    ulong num20 = (ulong) Main.random.NextLong((long) num8, (long) max2);
    ulong num21 = (ulong) Main.random.NextLong((long) num9, (long) max3);
    ulong num22 = (ulong) Main.random.NextLong((long) num10, (long) max4);
    ulong num23 = (ulong) Main.random.NextLong((long) num11, (long) max5);
    ulong num24 = (ulong) Main.random.NextLong((long) num12, (long) max6);
    ulong num25 = num19 << 32;
    ulong num26 = num20 << 32;
    ulong num27 = num21 << 32;
    ulong num28 = num22 << 32;
    ulong num29 = num23 << 32;
    ulong num30 = (ulong) Main.random.NextLong(long.MinValue, long.MaxValue);
    ulong num31 = (ulong) Main.random.NextLong(long.MinValue, long.MaxValue);
    ulong num32 = num24 << 32;
    StaticBodyProperties staticBodyProperties2 = new StaticBodyProperties(num7, num8, num9, num10, num11, 0UL, 0UL, num12);
    float age = MBRandom.RandomFloatRanged(Convert.ToSingle(tuple1.Item1), Convert.ToSingle(tuple2.Item1));
    float build = MBRandom.RandomFloatRanged(Convert.ToSingle(tuple1.Item2), Convert.ToSingle(tuple2.Item2));
    float weight = MBRandom.RandomFloatRanged(Convert.ToSingle(tuple1.Item3), Convert.ToSingle(tuple2.Item3));
    return new BodyProperties(new DynamicBodyProperties(age, weight, build), staticBodyProperties2);
  }
}

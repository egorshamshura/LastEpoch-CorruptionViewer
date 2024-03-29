using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2Cpp;
using Il2CppTMPro;
using MelonLoader;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;
using HarmonyLib;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using System.Collections;
using Il2Cpp;
using System.IO;

namespace CorruptionViewer
{
    public static class Utility
    {
        public static void changeMonolithName(MonolithIslandInfo __instance)
        {
            StringBuilder islandName = new StringBuilder(__instance.IslandName.text);
            TimelineID timelineID = __instance.timelineID;
            islandName.Append(" (" + CorruptionViewer.monolithCorrupt[timelineID] + ")");
            __instance.IslandName.SetText(String.Empty);
            __instance.IslandName.SetText(islandName.ToString());
        }

        public static void updateCorruptionInFile()
        {
            File.WriteAllText(CorruptionViewer.storageCorruptionPath, String.Empty);
            using (StreamWriter writer = new StreamWriter(CorruptionViewer.storageCorruptionPath))
            {
                foreach (TimelineID tl in Enum.GetValues(typeof(TimelineID)))
                {
                    writer.WriteLine(CorruptionViewer.monolithCorrupt[tl]);
                }
            }
        }
    }
}

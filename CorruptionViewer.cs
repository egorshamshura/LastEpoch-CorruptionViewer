using MelonLoader;
using HarmonyLib;
using System;
using Il2Cpp;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace CorruptionViewer
{
    public class CorruptionViewer : MelonMod
    {
        public static CorruptionViewer __instance;
        private static MelonPreferences_Category CorruptionViewerCategory;
        public static Dictionary<TimelineID, int> monolithCorrupt;
        public const string storageCorruptionPath = "UserData/CorruptionStorage.txt";
        
        public override void OnEarlyInitializeMelon()
        {
            __instance = this;
            CorruptionViewerCategory = MelonPreferences.CreateCategory("CorruptionViewer");
            CorruptionViewerCategory.SetFilePath(storageCorruptionPath, autoload: true);
            if (!File.Exists(storageCorruptionPath)) 
            {
                File.Create(storageCorruptionPath);
            }
        }

        public override void OnPreferencesLoaded()
        {
            int lineCount = File.ReadLines(storageCorruptionPath).Count();
            monolithCorrupt = new Dictionary<TimelineID, int>();
            if (lineCount == 0)
            {
                using (StreamWriter writer = new StreamWriter(storageCorruptionPath))
                {
                    foreach (TimelineID tl in Enum.GetValues(typeof(TimelineID)))
                    {
                        monolithCorrupt[tl] = 0;
                    }
                }
            }
            else
            {
                using (var stream = File.Open(storageCorruptionPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8, false))
                    {
                        foreach (TimelineID tl in Enum.GetValues(typeof(TimelineID)))
                        {
                            monolithCorrupt[tl] = int.Parse(reader.ReadLine());
                        }
                    }
                }
            }
        }

        [HarmonyPatch(typeof(MonolithPanelManager), nameof(MonolithPanelManager.displayTimelineRun))]
        private static class MonolithPanelManager_displayTimelineRun_Patch
        {
            private static void Postfix(object[] __args)
            {
                MonolithRun run = (MonolithRun)__args[0]; 
                monolithCorrupt[run.timelineID] = run.web.corruption;
                Utility.updateCorruptionInFile();
            }
        }

        [HarmonyPatch(typeof(MapPanel), nameof(MapPanel.SelectLocation))]
        private static class MapPanel_SelectLocation_Patch
        {
            private static void Prefix(object[] __args)
            {
                UIWaypoint waypoint = (UIWaypoint) __args[3];
                Utility.changeMonolithName(waypoint.monolithIslandInfo);
                Utility.updateCorruptionInFile();
            }
        }
    }
}

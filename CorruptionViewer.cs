using MelonLoader;
using HarmonyLib;
using System;
using Il2Cpp;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Il2CppLE.Telemetry;
using Il2CppLE.Data;


namespace CorruptionViewer
{
    public class CorruptionViewer : MelonMod
    {
        public static CorruptionViewer __instance;
        private static MelonPreferences_Category CorruptionViewerCategory;
        public static Dictionary<TimelineID, int> monolithCorrupt;
        public const string storageCorruptionPath = "UserData/CorruptionStorage.json";
        public static HashSet<CharacterData> characters;
        
        public override void OnEarlyInitializeMelon()
        {
            __instance = this;
            CorruptionViewerCategory = MelonPreferences.CreateCategory("CorruptionViewer");
        }

        public override void OnDeinitializeMelon()
        {
            Utility.updateCorruptionInFile();
        }

        public override void OnPreferencesLoaded()
        {
            if (!File.Exists(storageCorruptionPath))
            {
                var file = File.Create(storageCorruptionPath);
                file.Close();
            }
            int lineCount = File.ReadLines(storageCorruptionPath).Count();
            Console.WriteLine(lineCount);
            monolithCorrupt = new Dictionary<TimelineID, int>();
            if (lineCount == 0)
            { 
                using (StreamWriter writer = new StreamWriter(storageCorruptionPath))
                {
                    foreach (TimelineID tl in Enum.GetValues(typeof(TimelineID)))
                    {
                        monolithCorrupt[tl] = 0;
                    }
                    JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
                    writer.Write(JsonSerializer.Serialize(CorruptionViewer.monolithCorrupt, options));
                    writer.Close();
                }
            }
            else
            {
                using (var stream = File.Open(storageCorruptionPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8, false))
                    {
                        monolithCorrupt = JsonSerializer.Deserialize<Dictionary<TimelineID, int>>(reader.ReadToEnd());
                        reader.Close();
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
                if (waypoint.monolithWaypoint)
                {
                    Utility.changeMonolithName(waypoint.monolithIslandInfo);
                }
                Utility.updateCorruptionInFile();
            }
        }
    }
}

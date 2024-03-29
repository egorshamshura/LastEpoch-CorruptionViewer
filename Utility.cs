using System;
using System.Text;
using Il2Cpp;
using System.IO;
using System.Text.Json;

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
            JsonSerializerOptions options = new JsonSerializerOptions{ WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(CorruptionViewer.monolithCorrupt, options);
            using (StreamWriter writer = new StreamWriter(CorruptionViewer.storageCorruptionPath))
            {
                writer.Write(jsonString);
            }
        }
    }
}

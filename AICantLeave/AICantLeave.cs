using System.Collections.Generic;
using ThunderRoad;

namespace AICantLeave
{
    public class AICantLeave : ThunderScript
    {
        private static List<FleePoint> currentFleePoints;
        private static bool isModEnabled;

        [ModOption(name: "Use AICantLeave Mod", tooltip: "Determines whether to use the AICantLeave mod.", defaultValueIndex = 1)]
        public static void UseMod(bool useMod)
        {
            isModEnabled = useMod;

            if (useMod)
            {
                FleePoint.list.Clear();
            } 
            else
            {
                FleePoint.list.AddRange(currentFleePoints);
            }
        }

        public override void ScriptLoaded(ModManager.ModData modData)
        {
            base.ScriptLoaded(modData);
            EventManager.onLevelLoad += OnLevelLoad;

        }

        private void OnLevelLoad(LevelData levelData, LevelData.Mode mode, EventTime eventTime)
        {
            if (eventTime == EventTime.OnStart)
            {
                return;
            }

            currentFleePoints = new List<FleePoint>(FleePoint.list);

            if (isModEnabled)
            {
                FleePoint.list.Clear();
            }
        }
    }
}

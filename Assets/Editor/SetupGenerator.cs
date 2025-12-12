#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public static class SetupGenerator
{
    private const string BasePath = "Assets/ScriptableObjects";

    [MenuItem("Tools/Setup/Criar Configurações Básicas")]
    public static void CreateDefaults()
    {
        EnsureFolders();
        CreateEconomy();
        var level = CreateLevelConfig("LevelConfig_001", 1, 60f, 20, 50);
        CreateLevelCatalog(level);
        CreateMission();
        CreateEvent();
        CreateUpgrades();
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("Configurações padrão criadas.");
    }

    private static void EnsureFolders()
    {
        CreateFolder("Assets", "ScriptableObjects");
        CreateFolder(BasePath, "Levels");
        CreateFolder(BasePath, "Missions");
        CreateFolder(BasePath, "Events");
        CreateFolder(BasePath, "Upgrades");
    }

    private static void CreateFolder(string parent, string child)
    {
        var path = $"{parent}/{child}";
        if (!AssetDatabase.IsValidFolder(path))
        {
            AssetDatabase.CreateFolder(parent, child);
        }
    }

    private static void CreateEconomy()
    {
        var asset = ScriptableObject.CreateInstance<EconomyConfig>();
        asset.maxEnergy = 10;
        asset.energyRechargeMinutes = 10f;
        asset.baseCoinsReward = 50;
        AssetDatabase.CreateAsset(asset, $"{BasePath}/EconomyConfig.asset");
    }

    private static LevelConfig CreateLevelConfig(string name, int id, float time, int moves, int reward)
    {
        var level = ScriptableObject.CreateInstance<LevelConfig>();
        level.levelId = id;
        level.timeLimitSeconds = time;
        level.movesLimit = moves;
        level.baseCoinsReward = reward;
        AssetDatabase.CreateAsset(level, $"{BasePath}/Levels/{name}.asset");
        return level;
    }

    private static void CreateLevelCatalog(LevelConfig level)
    {
        var catalog = ScriptableObject.CreateInstance<LevelCatalog>();
        catalog.levels = new LevelConfig[] { level };
        AssetDatabase.CreateAsset(catalog, $"{BasePath}/Levels/LevelCatalog.asset");
    }

    private static void CreateMission()
    {
        var mission = ScriptableObject.CreateInstance<MissionDefinition>();
        mission.missionId = "daily_play_3";
        mission.type = MissionType.Play;
        mission.targetAmount = 3;
        mission.rewardCoins = 100;
        mission.rewardGems = 0;
        mission.rewardEnergy = 1;
        AssetDatabase.CreateAsset(mission, $"{BasePath}/Missions/DailyPlay.asset");
    }

    private static void CreateEvent()
    {
        var ev = ScriptableObject.CreateInstance<EventDefinition>();
        ev.eventId = "weekly_event";
        ev.durationDays = 7;
        ev.pointPerWin = 10;
        AssetDatabase.CreateAsset(ev, $"{BasePath}/Events/WeeklyEvent.asset");
    }

    private static void CreateUpgrades()
    {
        CreateUpgrade("prod_base", UpgradeType.Production, 100, 0.15f, 5);
        CreateUpgrade("cap_base", UpgradeType.Capacity, 120, 0.18f, 5);
        CreateUpgrade("aest_base", UpgradeType.Aesthetics, 80, 0.12f, 5);
    }

    private static void CreateUpgrade(string id, UpgradeType type, int baseCost, float growth, int maxLevel)
    {
        var up = ScriptableObject.CreateInstance<UpgradeDefinition>();
        up.upgradeId = id;
        up.type = type;
        up.baseCost = baseCost;
        up.costGrowth = growth;
        up.maxLevel = maxLevel;
        AssetDatabase.CreateAsset(up, $"{BasePath}/Upgrades/{id}.asset");
    }
}
#endif

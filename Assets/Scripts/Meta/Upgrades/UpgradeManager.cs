using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance { get; private set; }

    [SerializeField] private UpgradeDefinition[] upgrades;

    private const string UpgradeKeyPrefix = "upgrade_level_";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public int GetLevel(string upgradeId)
    {
        return PlayerPrefs.GetInt(UpgradeKeyPrefix + upgradeId, 0);
    }

    public int GetCost(UpgradeDefinition def)
    {
        if (def == null) return 0;
        int level = GetLevel(def.upgradeId);
        return def.GetCost(level);
    }

    public UpgradeDefinition GetDefinition(string id)
    {
        return Find(id);
    }

    public bool TryUpgrade(string upgradeId)
    {
        var def = Find(upgradeId);
        if (def == null) return false;
        int level = GetLevel(upgradeId);
        if (def.maxLevel > 0 && level >= def.maxLevel) return false;

        int cost = def.GetCost(level);
        var wallet = Meta.Economy.EconomyWallet.Instance;
        if (wallet == null || !wallet.SpendCoins(cost)) return false;

        level++;
        PlayerPrefs.SetInt(UpgradeKeyPrefix + upgradeId, level);
        PlayerPrefs.Save();

        Analytics.AnalyticsService.Instance.TrackEvent("upgrade_purchase", new System.Collections.Generic.Dictionary<string, object>
        {
            {"upgrade_id", upgradeId},
            {"level", level},
            {"cost", cost}
        });
        return true;
    }

    private UpgradeDefinition Find(string id)
    {
        if (upgrades == null) return null;
        foreach (var u in upgrades)
        {
            if (u != null && u.upgradeId == id) return u;
        }
        return null;
    }
}

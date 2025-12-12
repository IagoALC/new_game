using UnityEngine;

public enum UpgradeType { Production, Capacity, Aesthetics }

[CreateAssetMenu(fileName = "UpgradeDefinition", menuName = "Meta/UpgradeDefinition")]
public class UpgradeDefinition : ScriptableObject
{
    public string upgradeId;
    public UpgradeType type;
    public int baseCost = 100;
    public float costGrowth = 0.15f;
    public int maxLevel = 5;

    public int GetCost(int level)
    {
        return Mathf.CeilToInt(baseCost * (1f + costGrowth * level));
    }
}

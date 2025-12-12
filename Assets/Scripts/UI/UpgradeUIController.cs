using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIController : MonoBehaviour
{
    [SerializeField] private string upgradeId;
    [SerializeField] private Text levelText;
    [SerializeField] private Text costText;

    private void OnEnable()
    {
        Refresh();
    }

    public void OnUpgrade()
    {
        if (UpgradeManager.Instance == null) return;
        if (UpgradeManager.Instance.TryUpgrade(upgradeId)) Refresh();
    }

    public void Refresh()
    {
        if (UpgradeManager.Instance == null) return;
        int level = UpgradeManager.Instance.GetLevel(upgradeId);
        int cost = UpgradeManager.Instance.GetCost(UpgradeManager.Instance.GetDefinition(upgradeId));
        if (levelText != null) levelText.text = $"Lv {level}";
        if (costText != null) costText.text = cost.ToString();
    }
}

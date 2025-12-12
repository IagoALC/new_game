using UnityEngine;

public class PuzzleGameController : MonoBehaviour
{
    [SerializeField] private LevelConfig levelConfig;
    [SerializeField] private LevelCatalog levelCatalog;
    [SerializeField] private GameProgress progress;
    [SerializeField] private int energyCost = 1;

    private bool levelRunning;

    private void Start()
    {
        LoadLevel();
        StartLevel();
    }

    private void LoadLevel()
    {
        if (progress != null && levelCatalog != null)
        {
            var cfg = levelCatalog.GetById(progress.GetCurrentLevelId());
            if (cfg != null) levelConfig = cfg;
        }
    }

    public void StartLevel()
    {
        if (!Meta.Economy.EnergySystem.Instance.Consume(energyCost))
        {
            // Energia insuficiente; sugerir rewarded
            Debug.Log("Sem energia. Oferecer anúncio recompensado.");
            return;
        }

        levelRunning = true;
        Analytics.AnalyticsService.Instance.TrackEvent("level_start", new System.Collections.Generic.Dictionary<string, object>
        {
            {"level_id", levelConfig != null ? levelConfig.levelId : 0}
        });
    }

    public void CompleteLevel(int performanceBonus)
    {
        if (!levelRunning) return;
        levelRunning = false;

        int coins = (levelConfig != null ? levelConfig.baseCoinsReward : 0) + performanceBonus;
        Meta.Economy.EconomyWallet.Instance.AddCoins(coins);
        progress?.CompleteCurrentLevel();

        Analytics.AnalyticsService.Instance.TrackEvent("level_win", new System.Collections.Generic.Dictionary<string, object>
        {
            {"level_id", levelConfig != null ? levelConfig.levelId : 0},
            {"coins", coins}
        });
        SceneLoader.LoadHub();
    }

    public void FailLevel()
    {
        if (!levelRunning) return;
        levelRunning = false;

        Analytics.AnalyticsService.Instance.TrackEvent("level_fail", new System.Collections.Generic.Dictionary<string, object>
        {
            {"level_id", levelConfig != null ? levelConfig.levelId : 0}
        });

        // Oferecer retry via rewarded
        Ads.AdService.Instance.ShowRewarded("retry", OnRewardedRetry);
    }

    private void OnRewardedRetry(bool rewarded)
    {
        if (!rewarded) return;
        StartLevel();
    }
}

using UnityEngine;

public class DailyStreak : MonoBehaviour
{
    public static DailyStreak Instance { get; private set; }

    [SerializeField] private int currentStreak;
    [SerializeField] private int coinsPerDay = 50;
    [SerializeField] private int energyPerDay = 1;

    private const string StreakKey = "streak_value";
    private const string LastDayKey = "streak_last_day";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void ClaimToday()
    {
        var today = System.DateTime.UtcNow.Date.ToString();
        var last = PlayerPrefs.GetString(LastDayKey, string.Empty);
        if (today == last) return;

        if (!string.IsNullOrEmpty(last)) currentStreak++;
        else currentStreak = 1;

        PlayerPrefs.SetString(LastDayKey, today);
        PlayerPrefs.SetInt(StreakKey, currentStreak);
        PlayerPrefs.Save();

        var wallet = Meta.Economy.EconomyWallet.Instance;
        var energy = Meta.Economy.EnergySystem.Instance;
        if (wallet != null) wallet.AddCoins(coinsPerDay);
        if (energy != null) energy.Add(energyPerDay);

        Analytics.AnalyticsService.Instance.TrackEvent("streak_claim", new System.Collections.Generic.Dictionary<string, object>
        {
            {"streak", currentStreak}
        });
    }

    private void Load()
    {
        currentStreak = PlayerPrefs.GetInt(StreakKey, 0);
    }
}

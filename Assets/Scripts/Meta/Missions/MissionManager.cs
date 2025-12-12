using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance { get; private set; }

    [SerializeField] private MissionDefinition[] dailyMissions;

    private int progress;

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

    public void AddProgress(MissionType type)
    {
        foreach (var mission in dailyMissions)
        {
            if (mission == null || mission.type != type) continue;
            progress++;
            if (progress >= mission.targetAmount)
            {
                Reward(mission);
                progress = 0;
            }
        }
    }

    private void Reward(MissionDefinition mission)
    {
        var wallet = Meta.Economy.EconomyWallet.Instance;
        var energy = Meta.Economy.EnergySystem.Instance;
        if (wallet != null)
        {
            wallet.AddCoins(mission.rewardCoins);
            wallet.AddGems(mission.rewardGems);
        }
        if (energy != null) energy.Add(mission.rewardEnergy);
        Analytics.AnalyticsService.Instance.TrackEvent("mission_complete", new System.Collections.Generic.Dictionary<string, object>
        {
            {"mission_id", mission.missionId}
        });
    }
}

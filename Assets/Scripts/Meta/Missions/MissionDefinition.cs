using UnityEngine;

public enum MissionType { Play, WinWithoutBooster, WatchAd, EventPoints }

[CreateAssetMenu(fileName = "MissionDefinition", menuName = "Meta/MissionDefinition")]
public class MissionDefinition : ScriptableObject
{
    public string missionId;
    public MissionType type;
    public int targetAmount = 1;
    public int rewardCoins;
    public int rewardGems;
    public int rewardEnergy;
}

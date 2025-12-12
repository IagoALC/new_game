using UnityEngine;

[CreateAssetMenu(fileName = "EconomyConfig", menuName = "Meta/EconomyConfig")]
public class EconomyConfig : ScriptableObject
{
    public int maxEnergy = 10;
    public float energyRechargeMinutes = 10f;
    public int baseCoinsReward = 50;
}

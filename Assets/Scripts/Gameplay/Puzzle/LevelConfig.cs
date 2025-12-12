using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Puzzle/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    public int levelId = 1;
    public float timeLimitSeconds = 60f;
    public int movesLimit = 20;
    public int baseCoinsReward = 50;
}

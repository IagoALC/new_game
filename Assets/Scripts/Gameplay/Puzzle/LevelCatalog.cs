using UnityEngine;

[CreateAssetMenu(fileName = "LevelCatalog", menuName = "Puzzle/LevelCatalog")]
public class LevelCatalog : ScriptableObject
{
    public LevelConfig[] levels;

    public LevelConfig GetById(int levelId)
    {
        if (levels == null || levels.Length == 0) return null;
        foreach (var lvl in levels)
        {
            if (lvl != null && lvl.levelId == levelId)
                return lvl;
        }
        return null;
    }
}

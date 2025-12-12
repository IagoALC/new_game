using UnityEngine;

public class GameProgress : MonoBehaviour
{
    public static GameProgress Instance { get; private set; }

    [SerializeField] private int currentLevelId = 1;

    private const string LevelKey = "progress_level";

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

    public int GetCurrentLevelId()
    {
        return currentLevelId;
    }

    public void CompleteCurrentLevel()
    {
        currentLevelId++;
        Save();
    }

    public void SetLevel(int levelId)
    {
        currentLevelId = Mathf.Max(1, levelId);
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt(LevelKey, currentLevelId);
        PlayerPrefs.Save();
    }

    private void Load()
    {
        currentLevelId = PlayerPrefs.GetInt(LevelKey, currentLevelId);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadHub(string hubSceneName = "Hub")
    {
        SceneManager.LoadScene(hubSceneName);
    }

    public static void LoadPuzzle(string puzzleSceneName = "Puzzle")
    {
        SceneManager.LoadScene(puzzleSceneName);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private string hubSceneName = "Hub";

    private void Awake()
    {
        Ads.AdService.Instance.Initialize();
        Analytics.AnalyticsService.Instance.Initialize();
        RemoteConfig.RemoteConfigService.Instance.Initialize();
        LoadHub();
    }

    private void LoadHub()
    {
        SceneManager.LoadScene(hubSceneName);
    }
}

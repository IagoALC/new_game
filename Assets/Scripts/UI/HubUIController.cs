using UnityEngine;

public class HubUIController : MonoBehaviour
{
    public void OnPlayPuzzle()
    {
        SceneLoader.LoadPuzzle();
    }

    public void OnOpenStore()
    {
        Debug.Log("Abrir loja");
    }

    public void OnOpenUpgrades()
    {
        Debug.Log("Abrir upgrades");
    }

    public void OnOpenEvents()
    {
        Debug.Log("Abrir eventos");
    }

    public void OnClaimStreak()
    {
        DailyStreak.Instance?.ClaimToday();
    }
}

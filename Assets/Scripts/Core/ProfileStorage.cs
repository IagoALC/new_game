using UnityEngine;

public class ProfileStorage : MonoBehaviour
{
    public static ProfileStorage Instance { get; private set; }

    [SerializeField] private Meta.Economy.EconomyWallet wallet;
    [SerializeField] private Meta.Economy.EnergySystem energy;

    private const string CoinsKey = "profile_coins";
    private const string GemsKey = "profile_gems";
    private const string EnergyKey = "profile_energy";

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

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) Save();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        if (wallet != null)
        {
            PlayerPrefs.SetInt(CoinsKey, wallet.Coins);
            PlayerPrefs.SetInt(GemsKey, wallet.Gems);
        }
        if (energy != null)
        {
            PlayerPrefs.SetInt(EnergyKey, energy.CurrentEnergy);
        }
        PlayerPrefs.Save();
    }

    public void Load()
    {
        if (wallet != null)
        {
            wallet.SetCoins(PlayerPrefs.GetInt(CoinsKey, 0));
            wallet.SetGems(PlayerPrefs.GetInt(GemsKey, 0));
        }
        if (energy != null)
        {
            int savedEnergy = PlayerPrefs.GetInt(EnergyKey, energy.MaxEnergy);
            energy.Set(savedEnergy);
        }
    }
}

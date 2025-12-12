using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    [SerializeField] private Text energyText;
    [SerializeField] private Meta.Economy.EconomyWallet wallet;
    [SerializeField] private Meta.Economy.EnergySystem energy;
    [SerializeField] private float refreshInterval = 0.2f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer < refreshInterval) return;
        timer = 0f;
        Refresh();
    }

    public void Refresh()
    {
        if (wallet != null && coinsText != null) coinsText.text = wallet.Coins.ToString();
        if (energy != null && energyText != null) energyText.text = $"{energy.CurrentEnergy}/{energy.MaxEnergy}";
    }
}

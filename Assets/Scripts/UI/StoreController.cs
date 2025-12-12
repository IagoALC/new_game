using UnityEngine;

public class StoreController : MonoBehaviour
{
    [SerializeField] private int starterCoins = 500;
    [SerializeField] private int starterGems = 20;
    [SerializeField] private int rewardedEnergyAmount = 3;

    public void BuyStarterPack()
    {
        Billing.BillingService.Instance.Purchase("starter_pack", OnStarterPack);
    }

    public void BuyCoinsPack()
    {
        Billing.BillingService.Instance.Purchase("coins_pack_small", success =>
        {
            if (!success) return;
            Meta.Economy.EconomyWallet.Instance.AddCoins(300);
        });
    }

    public void WatchAdForEnergy()
    {
        Ads.AdService.Instance.ShowRewarded("energy", rewarded =>
        {
            if (!rewarded) return;
            Meta.Economy.EnergySystem.Instance.Add(rewardedEnergyAmount);
        });
    }

    private void OnStarterPack(bool success)
    {
        if (!success) return;
        var wallet = Meta.Economy.EconomyWallet.Instance;
        if (wallet != null)
        {
            wallet.AddCoins(starterCoins);
            wallet.AddGems(starterGems);
        }
    }
}

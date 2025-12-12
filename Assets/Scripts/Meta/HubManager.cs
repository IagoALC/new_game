using UnityEngine;

namespace Meta
{
    public class HubManager : MonoBehaviour
    {
        [SerializeField] private Meta.Economy.EconomyWallet wallet;

        public bool Upgrade(int cost)
        {
            // Controla compra de upgrade do hub
            if (wallet == null) return false;
            if (!wallet.SpendCoins(cost)) return false;
            return true;
        }
    }
}

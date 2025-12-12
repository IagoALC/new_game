using UnityEngine;

namespace Meta.Economy
{
    public class EconomyWallet : MonoBehaviour
    {
        public static EconomyWallet Instance { get; private set; }

        [SerializeField] private int coins;
        [SerializeField] private int gems;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void AddCoins(int amount)
        {
            if (amount <= 0) return;
            coins += amount;
        }

        public void SetCoins(int amount)
        {
            coins = Mathf.Max(0, amount);
        }

        public int Coins => coins;

        public bool SpendCoins(int amount)
        {
            if (amount <= 0) return true;
            if (coins < amount) return false;
            coins -= amount;
            return true;
        }

        public void AddGems(int amount)
        {
            if (amount <= 0) return;
            gems += amount;
        }

        public void SetGems(int amount)
        {
            gems = Mathf.Max(0, amount);
        }

        public int Gems => gems;

        public bool SpendGems(int amount)
        {
            if (amount <= 0) return true;
            if (gems < amount) return false;
            gems -= amount;
            return true;
        }
    }
}

using UnityEngine;

namespace Meta.Economy
{
    public class EnergySystem : MonoBehaviour
    {
        public static EnergySystem Instance { get; private set; }

        [SerializeField] private EconomyConfig config;
        [SerializeField] private int currentEnergy;
        private float timer;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
            currentEnergy = config != null ? config.maxEnergy : 10;
        }

        private void Update()
        {
            if (config == null || currentEnergy >= config.maxEnergy) return;
            timer += Time.deltaTime;
            float interval = config.energyRechargeMinutes * 60f;
            if (interval <= 0f) return;
            if (timer >= interval)
            {
                timer -= interval;
                currentEnergy = Mathf.Min(currentEnergy + 1, config.maxEnergy);
            }
        }

        public bool Consume(int amount)
        {
            if (amount <= 0) return true;
            if (currentEnergy < amount) return false;
            currentEnergy -= amount;
            return true;
        }

        public void Add(int amount)
        {
            if (amount <= 0 || config == null) return;
            currentEnergy = Mathf.Min(currentEnergy + amount, config.maxEnergy);
        }

        public int CurrentEnergy => currentEnergy;
        public int MaxEnergy => config != null ? config.maxEnergy : 0;

        public void Set(int amount)
        {
            if (config == null) return;
            currentEnergy = Mathf.Clamp(amount, 0, config.maxEnergy);
        }
    }
}

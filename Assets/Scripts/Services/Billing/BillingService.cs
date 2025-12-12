using UnityEngine;

namespace Billing
{
    public class BillingService : MonoBehaviour
    {
        public static BillingService Instance { get; private set; }

        public void Initialize()
        {
            EnsureInstance();
            Debug.Log("BillingService inicializado");
        }

        public void Purchase(string sku, System.Action<bool> callback)
        {
            Debug.Log($"Iniciar compra: {sku}");
            callback?.Invoke(true);
        }

        private void EnsureInstance()
        {
            if (Instance != null) return;
            var go = new GameObject("BillingService");
            Instance = go.AddComponent<BillingService>();
            DontDestroyOnLoad(go);
        }
    }
}

using UnityEngine;

namespace Ads
{
    public class AdService : MonoBehaviour
    {
        public static AdService Instance { get; private set; }

        public void Initialize()
        {
            // Inicializar SDK de anúncios aqui
            EnsureInstance();
            Debug.Log("AdService inicializado");
        }

        public void ShowRewarded(string placement, System.Action<bool> callback)
        {
            // Exibir rewarded; callback indica se usuário ganhou a recompensa
            Debug.Log($"Mostrar rewarded: {placement}");
            callback?.Invoke(true);
        }

        public void ShowInterstitial(string placement)
        {
            // Exibir interstitial em pontos seguros
            Debug.Log($"Mostrar interstitial: {placement}");
        }

        private void EnsureInstance()
        {
            if (Instance != null) return;
            var go = new GameObject("AdService");
            Instance = go.AddComponent<AdService>();
            DontDestroyOnLoad(go);
        }
    }
}

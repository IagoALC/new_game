using UnityEngine;

namespace RemoteConfig
{
    public class RemoteConfigService : MonoBehaviour
    {
        public static RemoteConfigService Instance { get; private set; }

        public void Initialize()
        {
            EnsureInstance();
            Debug.Log("RemoteConfigService inicializado");
        }

        public int GetInt(string key, int defaultValue)
        {
            // Buscar remoto; fallback no default
            return defaultValue;
        }

        public float GetFloat(string key, float defaultValue)
        {
            return defaultValue;
        }

        private void EnsureInstance()
        {
            if (Instance != null) return;
            var go = new GameObject("RemoteConfigService");
            Instance = go.AddComponent<RemoteConfigService>();
            DontDestroyOnLoad(go);
        }
    }
}

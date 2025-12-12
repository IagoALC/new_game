using UnityEngine;
using System.Collections.Generic;

namespace Analytics
{
    public class AnalyticsService : MonoBehaviour
    {
        public static AnalyticsService Instance { get; private set; }

        public void Initialize()
        {
            EnsureInstance();
            Debug.Log("AnalyticsService inicializado");
        }

        public void TrackEvent(string name, Dictionary<string, object> data = null)
        {
            // Enviar evento para provider selecionado
            Debug.Log($"Evento: {name}");
        }

        private void EnsureInstance()
        {
            if (Instance != null) return;
            var go = new GameObject("AnalyticsService");
            Instance = go.AddComponent<AnalyticsService>();
            DontDestroyOnLoad(go);
        }
    }
}

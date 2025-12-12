using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    [SerializeField] private EventDefinition activeEvent;
    [SerializeField] private int currentPoints;

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

    public void AddPoints(int amount)
    {
        if (activeEvent == null || amount <= 0) return;
        currentPoints += amount;
        Analytics.AnalyticsService.Instance.TrackEvent("event_point_gain", new System.Collections.Generic.Dictionary<string, object>
        {
            {"event_id", activeEvent.eventId},
            {"points", currentPoints}
        });
    }
}

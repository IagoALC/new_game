using UnityEngine;

[CreateAssetMenu(fileName = "EventDefinition", menuName = "Meta/EventDefinition")]
public class EventDefinition : ScriptableObject
{
    public string eventId;
    public int durationDays = 7;
    public int pointPerWin = 10;
}

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


public class UpdateTest : MonoBehaviour
{
    [SerializeField] private List<UpdateEvent> StoredTestEvents;
    private Dictionary<KeyCode, UnityEvent> _updateEvents = new Dictionary<KeyCode, UnityEvent>();

    private void Start()
    {
        foreach (var stored in StoredTestEvents) 
            _updateEvents.Add(stored.AssignedKey, stored.AssignedEvent);
    }

    void Update()
    {
        if (_updateEvents.Count <= 0) return;
        foreach (var holder in _updateEvents
                     .Where(holder => Input.GetKeyDown(holder.Key)))
        {
            holder.Value?.Invoke();
        }
    }
}

[Serializable]
public struct UpdateEvent
{
    public KeyCode AssignedKey;
    public UnityEvent AssignedEvent;
}



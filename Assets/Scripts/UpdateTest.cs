using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


public class UpdateTest : MonoBehaviour
{
    [SerializeField] private List<UpdateEvent> StoredTestEvents;
    [SerializeField] private List<UnityEvent> _onAwakeEvents, _onUpdateEvents, _onFixedUpdateEvents;
    private Dictionary<KeyCode, UnityEvent> _updateOnKeyEvents = new Dictionary<KeyCode, UnityEvent>();

    private void Awake()
    {
        if (_onAwakeEvents.Count <= 0) return;
        foreach (var uevent in _onUpdateEvents) uevent?.Invoke();
    }

    private void Start()
    {
        foreach (var stored in StoredTestEvents) 
            _updateOnKeyEvents.Add(stored.AssignedKey, stored.AssignedEvent);
    }

    private void Update()
    {
        if (_updateOnKeyEvents.Count > 0)
        {
            foreach (var holder in _updateOnKeyEvents
                         .Where(holder => Input.GetKeyDown(holder.Key)))
            {
                holder.Value?.Invoke();
            }    
        }

        if (_onUpdateEvents.Count <= 0) return;
        foreach (var uevent in _onUpdateEvents) uevent?.Invoke();
    }

    private void FixedUpdate()
    {
        if (_onFixedUpdateEvents.Count <= 0) return;
        foreach (var uevent in _onFixedUpdateEvents) uevent?.Invoke();
    }
}

[Serializable]
public struct UpdateEvent
{
    public KeyCode AssignedKey;
    public UnityEvent AssignedEvent;
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class OnHit : MonoBehaviour
{
    [Serializable] public class OnHitEvent : UnityEvent<GameObject> { }

    [SerializeField]
    [Tooltip("Events to fire when a matcing object collides with this trigger.")]
    OnHitEvent m_OnHitEnter = new OnHitEvent();

    /// <summary>
    /// Events to fire when a matching object collides with this trigger.
    /// </summary>
    public OnHitEvent OnEnter => m_OnHitEnter;

    void OnTriggerEnter(Collider other)
    {
        if (PlayerData.instance.isGameActive)
            if (other.CompareTag("Bullet")) 
                m_OnHitEnter?.Invoke(other.gameObject);
    }
}

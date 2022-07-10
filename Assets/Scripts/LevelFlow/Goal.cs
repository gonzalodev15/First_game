using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public static Action GoalReached;
    private Collider _goalCollider;

    private void Start()
    {
        _goalCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GoalReached?.Invoke();
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    GoalReached?.Invoke();
        //    _goalCollider.enabled = false;
        //}
    }
}

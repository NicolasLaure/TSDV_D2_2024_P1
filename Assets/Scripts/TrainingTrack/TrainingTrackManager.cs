using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingTrackManager : MonoBehaviour
{
    [SerializeField] private List<TrackState> targetGroups = new List<TrackState>();
    public Action<string> onStateChange;
    public event Action onRestart;
    Coroutine trackCoroutine = null;
    private float elapsedTime = 0;
    private float startTime = 0;
    private void Awake()
    {
        onStateChange += AddState;
    }
    private void Start()
    {
        InitializeStates();
    }
    private void OnDestroy()
    {
        onStateChange -= AddState;
    }
    public void StartTrack()
    {
        if (trackCoroutine != null)
            StopCoroutine(trackCoroutine);

        trackCoroutine = StartCoroutine(TrackCoroutine());
    }
    private IEnumerator TrackCoroutine()
    {
        InitializeStates();
        targetGroups[0].Enter();
        StartTimer();
        onRestart?.Invoke();
        while (!AreAllTargetsDown())
        {
            elapsedTime = Time.time - startTime;
            yield return null;
        }
    }
    private void AddState(string stateName)
    {
        foreach (TrackState state in targetGroups)
        {
            if (state.StateName == stateName)
            {
                state.Enter();
            }
        }
    }
    private void InitializeStates()
    {
        foreach (TrackState state in targetGroups)
        {
            state.Initialize();
        }
    }
    private bool AreAllTargetsDown()
    {
        foreach (TrackState state in targetGroups)
        {
            foreach (TrackTarget target in state.Targets)
            {
                if (!target.WasShotDown)
                    return false;
            }
        }
        return true;
    }
    public void StartTimer()
    {
        elapsedTime = 0;
        startTime = Time.time;
    }
}
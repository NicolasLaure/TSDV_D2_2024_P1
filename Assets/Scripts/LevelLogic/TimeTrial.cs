using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeTrial : MonoBehaviour
{
    [SerializeField] private float trialDuration;
    [SerializeField] private TrialTarget target;
    [SerializeField] private List<Transform> possiblePositions = new List<Transform>();
    private Coroutine trial;

    private bool canSpawn = true;
    public Action onTrialFinish;
    private void Start()
    {
        //suscribe to start level
        OnStartTrial();
    }

    private void OnStartTrial()
    {
        if (trial != null)
            StopCoroutine(trial);
        trial = StartCoroutine(TrialCoroutine());
    }
    private IEnumerator TrialCoroutine()
    {
        float startTime = Time.time;
        float timer = 0;
        while (timer < trialDuration)
        {
            timer = Time.time - startTime;
            if (!target.gameObject.activeInHierarchy && canSpawn)
                StartCoroutine(PresentTarget());
            yield return null;
        }
        onTrialFinish.Invoke();
    }

    private IEnumerator PresentTarget()
    {
        Debug.Log("TARGEEET");
        canSpawn = false;
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 0.5f));

        target.isEnemy = UnityEngine.Random.Range(0, 2) == 1;
        target.transform.position = GetRandomPosition();
        target.gameObject.SetActive(true);
        canSpawn = true;
    }

    private Vector3 GetRandomPosition()
    {
        Transform randomPos = possiblePositions[UnityEngine.Random.Range(0, possiblePositions.Count)].transform;
        return randomPos.position;
    }
}
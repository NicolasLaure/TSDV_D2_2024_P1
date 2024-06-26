using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeTrial : MonoBehaviour
{
    [SerializeField] private float trialDuration;
    [SerializeField] private TrialTarget target;
    [SerializeField] private List<Transform> possiblePositions = new List<Transform>();
    [SerializeField] private GameSaveSO save;
    [SerializeField] private TrialUI trialUI;
    [SerializeField] private GameObject results;
    private Coroutine trial;

    private bool canSpawn = true;
    public Action onTrialFinish;

    private int highScore = 0;
    private int score = 0;

    public int HighScore { get { return highScore; } }
    public int Score { get { return score; } }

    private void Awake()
    {
        target.onTrialTargetShot += OnTargetShot;
    }

    private void OnEnable()
    {
        OnStartTrial();
        trialUI.gameObject.SetActive(true);
    }
    private void OnDisable()
    {
        trialUI.gameObject.SetActive(false);
    }
    private void OnStartTrial()
    {
        if (trial != null)
            StopCoroutine(trial);

        score = 0;
        trial = StartCoroutine(TrialCoroutine());
    }
    private IEnumerator TrialCoroutine()
    {
        float startTime = Time.time;
        float timer = 0;
        while (timer < trialDuration)
        {
            timer = Time.time - startTime;
            trialUI.OnTimeUpdated((int)trialDuration - (int)timer);
            if (!target.gameObject.activeInHierarchy && canSpawn)
                StartCoroutine(PresentTarget());
            yield return null;
        }
        if (score > save.shootingRangeHighScore)
            save.shootingRangeHighScore = score;

        highScore = save.shootingRangeHighScore;

        results.GetComponent<LevelResults>().SetScores(score, highScore);
        results.SetActive(true);
        onTrialFinish?.Invoke();
    }

    private IEnumerator PresentTarget()
    {
        canSpawn = false;
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 0.5f));

        target.isEnemy = UnityEngine.Random.value > 0.2f;
        target.transform.position = GetRandomPosition();
        target.gameObject.SetActive(true);
        canSpawn = true;
    }

    private Vector3 GetRandomPosition()
    {
        Transform randomPos = possiblePositions[UnityEngine.Random.Range(0, possiblePositions.Count)].transform;
        return randomPos.position;
    }

    private void OnTargetShot(bool isEnemy)
    {
        if (isEnemy)
            score++;
        else
            score--;

        trialUI.OnScoreUpdated(score);
    }
}

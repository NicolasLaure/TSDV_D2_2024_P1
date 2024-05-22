using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTutorial : TutorialState
{
    protected override IEnumerator StartStateCoroutine()
    {
        yield return new WaitForSeconds(2);
        onStateFinished.Invoke();
    }
}

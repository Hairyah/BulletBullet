using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    //public List<GameObject> Targets = new List<GameObject>();
    public GameObject[] PossibleTargets;

    public int currentTargetIndex;
    public GameObject currentTargetObject;

    public int score = 0; 

    private void Start()
    {
        PossibleTargets = GameObject.FindGameObjectsWithTag("cible");
        currentTargetIndex = ChooseRandomNumber(-1);
        currentTargetObject = PossibleTargets[currentTargetIndex];

        currentTargetObject.GetComponent<Outlinez>().enabled = true;
    }

    private int ChooseRandomNumber(int currentTargetIndex)
    {

        int targetIntex = Random.Range(0, PossibleTargets.Length);
        if(currentTargetIndex == targetIntex)
        {
            ChooseRandomNumber(currentTargetIndex);
        }
        return (targetIntex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == currentTargetObject)
        {
            currentTargetObject.GetComponent<Outlinez>().enabled = false;
            score += 100;

            currentTargetIndex = ChooseRandomNumber(currentTargetIndex);
            currentTargetObject = PossibleTargets[currentTargetIndex];
            currentTargetObject.GetComponent<Outlinez>().enabled = true;
        }
    }
}

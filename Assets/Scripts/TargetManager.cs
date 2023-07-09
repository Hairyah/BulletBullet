using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    //public List<GameObject> Targets = new List<GameObject>();
    public GameObject[] PossibleTargets;

    public int currentTargetIndex;
    public GameObject currentTargetObject;

    public Outlinez outlinez;

    private void Start()
    {
        PossibleTargets = GameObject.FindGameObjectsWithTag("cible");
        currentTargetIndex = ChooseRandomNumber(-1);
        currentTargetObject = PossibleTargets[currentTargetIndex];

        var outline = currentTargetObject.AddComponent<Outlinez>();
        outline.OutlineColor = Color.red;
        outline.OutlineWidth = 5f;

        // currentTargetObject.GetComponent<Outlinez>().enabled = true;
    }

    private int ChooseRandomNumber(int currentTargetIndex)
    {

        int targetIndex = Random.Range(0, PossibleTargets.Length);
        if(currentTargetIndex == targetIndex)
        {
            ChooseRandomNumber(currentTargetIndex);
        }
        return (targetIndex);
    }

    public void remplacement(Collider other)
    {
        Debug.Log(other.gameObject) ;
        Debug.Log(currentTargetObject);
        if (other.gameObject == currentTargetObject)
        {
            Debug.Log("La cible est touchée = " + other);
            Destroy(currentTargetObject.GetComponent<Outlinez>());
            //Add Score
           ScoreManager.Instance.AddScore(100);

            currentTargetIndex = ChooseRandomNumber(currentTargetIndex);
            currentTargetObject = PossibleTargets[currentTargetIndex];
            var outline = currentTargetObject.AddComponent<Outlinez>();
            outline.OutlineColor = Color.red;
            outline.OutlineWidth = 5f;
        }
    }
}

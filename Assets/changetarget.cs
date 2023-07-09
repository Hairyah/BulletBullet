using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changetarget : MonoBehaviour
{
    public TargetManager targetmanager;
    void Start()
    {
        targetmanager = GameObject.Find("GameManager").GetComponent<TargetManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        targetmanager.remplacement(other);
    }
}

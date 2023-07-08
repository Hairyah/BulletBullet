using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private void Start()
    {
        CameraShake.Instance.Shake(0.08f, 1000f);
    }
}

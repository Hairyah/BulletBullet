using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    public Camera cam;
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void Shake(float strenght, float duration)
    {
        cam.DOShakePosition(duration, strenght);
    }
}

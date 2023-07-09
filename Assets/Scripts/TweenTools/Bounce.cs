using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bounce : MonoBehaviour
{
    public Ease ease;

    private void Start()
    {
        transform.DOScale(1.25f, 0.5f).From(1).SetLoops(-1, LoopType.Yoyo);
    }
}

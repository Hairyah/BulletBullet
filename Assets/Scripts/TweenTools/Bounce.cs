using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bounce : MonoBehaviour
{
    private void Bound()
    {
        transform.DOPunchScale(Vector3.one * 0.15f, 0.2f);
    }
}

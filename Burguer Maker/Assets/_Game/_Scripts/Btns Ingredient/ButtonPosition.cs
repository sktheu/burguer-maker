using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPosition : MonoBehaviour
{
    [SerializeField] private Vector3[] positions = new Vector3[2];

    public void Realocate()
    {
        if (transform.localPosition == positions[0])
            transform.localPosition = positions[1];
        else
            transform.localPosition = positions[0];
    }
}

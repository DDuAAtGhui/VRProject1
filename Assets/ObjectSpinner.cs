using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpinner : MonoBehaviour
{
    [SerializeField] float spinSpeed = 1f;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}

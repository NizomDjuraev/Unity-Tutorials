using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    // Start is called before the first frame update
     public float rotationSpeed = 1;
    void Start()
        {

        }
    void Update()
        {
            transform.Rotate(rotationSpeed,0,0,Space.Self);
        } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{

    public GameObject targetObject;
    private Vector3 initialPositionRelativeToTarget;

    // Start is called before the first frame update
    void Start()
    {
    if (targetObject == null)
        {
            targetObject = this.gameObject;
            Debug.Log ("defaultTarget target not specified. Defaulting to parent GameObject");
        }
    initialPositionRelativeToTarget = transform.position - targetObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = initialPositionRelativeToTarget + targetObject.transform.position;
        transform.LookAt(targetObject.transform);
    }
}

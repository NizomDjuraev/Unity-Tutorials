using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableRotator : MonoBehaviour
{
    public float rotationSpeed = 10;
    public int angularLimit = 45;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
    }

    // Update is called once per frame
    void Update()
    {
        float newZAxisRotation = transform.rotation.eulerAngles.z;
        float newXAxisRotation = transform.rotation.eulerAngles.x;


        if (Input.GetKey(KeyCode.LeftArrow))
            newZAxisRotation += rotationSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
            newZAxisRotation -= rotationSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow))
            newXAxisRotation += rotationSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
            newXAxisRotation -= rotationSpeed * Time.deltaTime;

        newZAxisRotation = (newZAxisRotation<90 && newZAxisRotation>angularLimit) ? angularLimit : newZAxisRotation;
        newZAxisRotation = (newZAxisRotation>90 && newZAxisRotation<360-angularLimit) ? 360-angularLimit : newZAxisRotation;
        newXAxisRotation = (newXAxisRotation<90 && newXAxisRotation>angularLimit) ? angularLimit : newXAxisRotation;
        newXAxisRotation = (newXAxisRotation>90 && newXAxisRotation<360-angularLimit) ? 360-angularLimit : newXAxisRotation;


        Vector3 newRotationEulars = new Vector3(newXAxisRotation, transform.rotation.eulerAngles.y, newZAxisRotation);
        transform.rotation = Quaternion.Euler(newRotationEulars);
    }
}

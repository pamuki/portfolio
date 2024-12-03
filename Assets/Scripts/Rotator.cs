using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float xRotate;
    [SerializeField] float yRotate;
    [SerializeField] float zRotate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UnscaledRotate(transform, xRotate, yRotate, zRotate);
    }

    void UnscaledRotate(Transform trans, float x,float y,float z)
    {
        Vector3 rotatingVector = new Vector3(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);

        trans.Rotate(rotatingVector);
    }
 
}

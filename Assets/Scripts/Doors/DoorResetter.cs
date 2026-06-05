using UnityEngine;

public class DoorResetter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private Rigidbody rb1;
    [SerializeField]
    private Rigidbody rb2;
    [SerializeField]
    private Transform door1;
    [SerializeField]
    private Transform door2;
    [SerializeField]
    private Transform handle1;
    [SerializeField]
    private Transform handle2;
    [SerializeField]
    private Rigidbody handleRb1;
    [SerializeField]
    private Rigidbody handleRb2;
    private Quaternion startRotationDoor1;
    private Quaternion startRotationDoor2;
    private Vector3 startPoisitionHandle1;
    private Vector3 startPoisitionHandle2;
    private Quaternion startRotationHandle1;
    private Quaternion startRotationHandle2;

    void Start()
    {
        // Store the default position and rotation at the start
        startRotationDoor1 = door1.rotation;
        startRotationDoor2 = door2.rotation;
        startRotationHandle1 = handle1.rotation;
        startRotationHandle2 = handle2.rotation;
        startPoisitionHandle1 = handle1.position;
        startPoisitionHandle2 = handle2.position;
    }
    public void resetDoors()
    {
        rb1.isKinematic = true;
        rb2.isKinematic = true;
        handleRb1.isKinematic = true;
        handleRb2.isKinematic = true;
        door1.rotation = startRotationDoor1;
        door2.rotation = startRotationDoor2;
        handle1.position = startPoisitionHandle1;
        handle2.position = startPoisitionHandle2;
        handle1.rotation = startRotationHandle1;
        handle2.rotation = startRotationHandle2;
        rb1.isKinematic = false;
        rb2.isKinematic = false;
        handleRb1.isKinematic = false;
        handleRb2.isKinematic = false;
    }
}

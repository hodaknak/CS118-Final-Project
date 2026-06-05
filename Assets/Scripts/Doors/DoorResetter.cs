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
    private Vector3 startPositionDoor1;
    private Quaternion startRotationDoor1;
    private Vector3 startPositionDoor2;
    private Quaternion startRotationDoor2;
    private Vector3 startPositionHandle1;
    private Quaternion startRotationHandle1;
    private Vector3 startPositionHandle2;
    private Quaternion startRotationHandle2;

    void Start()
    {
        // Store the default position and rotation at the start
        startPositionDoor1 = door1.position;
        startRotationDoor1 = door1.rotation;
        startPositionDoor2 = door2.position;
        startRotationDoor2 = door2.rotation;
        startPositionHandle1 = handle1.position;
        startRotationHandle1 = handle1.rotation;
        startPositionHandle2 = handle2.position;
        startRotationHandle2 = handle2.rotation;
    }
    public void resetDoors()
    {
        rb1.isKinematic = true;
        rb2.isKinematic = true;
        door1.position = startPositionDoor1;
        door1.rotation = startRotationDoor1;
        door2.position = startPositionDoor2;
        door2.rotation = startRotationDoor2;
        handle1.position = startPositionHandle1;
        handle1.rotation = startRotationHandle1;
        handle2.position = startPositionHandle2;
        handle2.rotation = startRotationHandle2;
        rb1.isKinematic = false;
        rb2.isKinematic = false;
        rb1.linearVelocity = Vector3.zero;
        rb2.linearVelocity = Vector3.zero;  
        rb1.angularVelocity = Vector3.zero;
        rb2.angularVelocity = Vector3.zero;
    }
}

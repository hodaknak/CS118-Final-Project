using System.Collections;
using UnityEngine;

public class DoubleDoor : MonoBehaviour
{
    public bool isOpen = false;

    [SerializeField]
    private GameObject hingeLeft = null;
    private Transform hingeTransformLeft = null;
    [SerializeField]
    private GameObject hingeRight = null;
    private Transform hingeTransformRight = null;

    [SerializeField]
    private float openSpeed = 1f;
    [SerializeField]
    private float openAngle = 90f;
    [SerializeField]
    private float forwardDirection = 0f;

    private Vector3 closeRotation = new Vector3(0, 0, 0);
    private Vector3 forward;

    private Coroutine animationCoroutine;

    private void Awake()
    {
        hingeTransformLeft = hingeLeft.transform;
        hingeTransformRight = hingeRight.transform;
        forward = hingeTransformLeft.forward;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        if (isOpen)
            return;

        Debug.Log("door opening");

        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }

        float dot = Vector3.Dot(forward, (new Vector3(0, 0, 0) - hingeTransformLeft.position).normalized);
        animationCoroutine = StartCoroutine(DoRotationOpen(dot));
    }

    private IEnumerator DoRotationOpen(float forwardAmount)
    {
        Quaternion startRotationLeft = hingeTransformLeft.rotation;
        float rotationAmountLeft = forwardAmount >= forwardDirection ? startRotationLeft.y - openAngle : startRotationLeft.y + openAngle;
        Quaternion endRotationLeft = Quaternion.Euler(new Vector3(0, rotationAmountLeft, 0));

        Quaternion startRotationRight = hingeTransformRight.rotation;
        float rotationAmountRight = forwardAmount >= forwardDirection ? startRotationRight.y - openAngle : startRotationRight.y + openAngle;
        Quaternion endRotationRight = Quaternion.Euler(new Vector3(0, rotationAmountRight, 0));

        isOpen = true;

        float time = 0;
        while (time < 1)
        {
            hingeTransformLeft.rotation = Quaternion.Slerp(startRotationLeft, endRotationLeft, time);
            hingeTransformRight.rotation = Quaternion.Slerp(startRotationRight, endRotationRight, time);
            yield return null;
            time += Time.deltaTime * openSpeed;
        }
    }

    public void Close()
    {
        if (!isOpen)
            return;

        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }

        animationCoroutine = StartCoroutine(DoRotationClose());
    }

    private IEnumerator DoRotationClose()
    {
        Quaternion startRotationLeft = hingeTransformLeft.rotation;
        Quaternion startRotationRight = hingeTransformRight.rotation;
        Quaternion endRotation = Quaternion.Euler(closeRotation);

        isOpen = false;

        float time = 0;
        while (time < 1)
        {
            hingeTransformLeft.rotation = Quaternion.Slerp(startRotationLeft, endRotation, time);
            hingeTransformRight.rotation = Quaternion.Slerp(startRotationRight, endRotation, time);
            yield return null;
            time += Time.deltaTime * openSpeed;
        }
    }
}

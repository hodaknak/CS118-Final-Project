using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;

    [SerializeField]
    private GameObject hinge = null;
    private Transform hingeTransform = null;

    [SerializeField]
    private float openSpeed = 1f;
    [SerializeField]
    private float openAngle = 90f;
    [SerializeField]
    private float forwardDirection = 0f;

    private Vector3 closeRotation;
    private Vector3 forward;

    private Coroutine animationCoroutine;

    private void Awake()
    {
        hingeTransform = hinge.transform;
        closeRotation = hingeTransform.rotation.eulerAngles;
        forward = hingeTransform.forward;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open(Vector3 userPos)
    {
        if (isOpen)
            return;

        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }

        float dot = Vector3.Dot(forward, (userPos - hingeTransform.position).normalized);
        animationCoroutine = StartCoroutine(DoRotationOpen(dot));
    }

    private IEnumerator DoRotationOpen(float forwardAmount)
    {
        Quaternion startRotation = hingeTransform.rotation;
        float rotationAmount = forwardAmount >= forwardDirection ? startRotation.y - openAngle : startRotation.y + openAngle;
        Quaternion endRotation = Quaternion.Euler(new Vector3(0, rotationAmount, 0));

        isOpen = true;

        float time = 0;
        while (time < 1)
        {
            hingeTransform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
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
        Quaternion startRotation = hingeTransform.rotation;
        Quaternion endRotation = Quaternion.Euler(closeRotation);

        isOpen = false;

        float time = 0;
        while (time < 1)
        {
            hingeTransform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * openSpeed;
        }
    }
}

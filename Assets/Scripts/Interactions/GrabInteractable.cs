using UnityEngine;
using VRCourse.Interaction;

public class GrabInteractable : SimpleVRInteractble
{
    [SerializeField] private Renderer targetRenderer;
    [SerializeField] private Color hoverColor = Color.yellow;
    [SerializeField] private Color tooFarColor = Color.red;

    protected Color originalColor;
    protected bool isGrabbed = false;

    protected float maxDistance = 3f;
    protected float distance;

    protected SimpleVRInteractorContext tempParent;
    protected Rigidbody rb;
    protected Vector3 objectPosition;

    protected override void Awake()
    {
        base.Awake();

        if (targetRenderer == null)
            targetRenderer = GetComponentInChildren<Renderer>();

        if (targetRenderer != null)
            originalColor = targetRenderer.material.color;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isGrabbed)
        {
            Hold();
        }
    }

    protected override void OnVRHoverEnter(SimpleVRInteractorContext context)
    {
        if (InRange(context))
        {
            if (!isGrabbed)
                SetColor(hoverColor);
        }
        else
        {
            SetColor(tooFarColor);
        }
    }

    protected override void OnVRHoverExit(SimpleVRInteractorContext context)
    {
        SetColor(originalColor);
        Drop();
    }

    protected override void OnVRSelectEnter(SimpleVRInteractorContext context)
    {
        if (InRange(context))
        {
            isGrabbed = true;
            rb.useGravity = false;
            rb.detectCollisions = true;

            transform.SetParent(context.Transform);
            tempParent = context;
        }
    }

    protected override void OnVRSelectExit(SimpleVRInteractorContext context)
    {

        SetColor(hoverColor);
        Drop();
    }

    protected void Hold()
    {
        distance = Vector3.Distance(transform.position, tempParent.Transform.position);
        if (distance >= maxDistance)
        {
            Drop();
        }
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    protected void Drop()
    {
        if (isGrabbed)
        {
            isGrabbed = false;
            objectPosition = transform.position;
            transform.position = objectPosition;
            transform.SetParent(null);
            rb.useGravity = true;
            tempParent = null;
        }
    }

    protected bool InRange(SimpleVRInteractorContext context)
    {
        distance = Vector3.Distance(transform.position, context.Transform.position);
        return distance <= maxDistance;
    }

    protected void SetColor(Color color)
    {
        if (targetRenderer != null)
            targetRenderer.material.color = color;
    }
}

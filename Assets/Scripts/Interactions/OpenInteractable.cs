using UnityEngine;
using VRCourse.Interaction;

public class OpenInteractable : SimpleVRInteractble
{
    [SerializeField] private Renderer targetRenderer;
    [SerializeField] private Color hoverColor = Color.white;
    [SerializeField] private Color selectedColor = Color.yellow;

    private Door door = null;

    private Color originalColor;

    protected override void Awake()
    {
        base.Awake();

        if (targetRenderer == null)
            targetRenderer = GetComponentInChildren<Renderer>();

        if (targetRenderer != null)
            originalColor = targetRenderer.material.color;

        door = GetComponentInChildren<Door>();
    }

    protected override void OnVRHoverEnter(SimpleVRInteractorContext context)
    {
        SetColor(hoverColor);
    }

    protected override void OnVRHoverExit(SimpleVRInteractorContext context)
    {
        SetColor(originalColor);
    }

    protected override void OnVRSelectEnter(SimpleVRInteractorContext context)
    {
        SetColor(selectedColor);
    }

    protected override void OnVRSelectExit(SimpleVRInteractorContext context)
    {
        SetColor(hoverColor);
    }

    protected override void OnVRActivate(SimpleVRInteractorContext context)
    {
        door.Toggle();
    }

    private void SetColor(Color color)
    {
        if (targetRenderer != null)
            targetRenderer.material.color = color;
    }
}

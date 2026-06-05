using VRCourse.Interaction;

public class ThrowInteractable : GrabInteractable
{
    private float throwForce = 600f;
    protected override void OnVRActivate(SimpleVRInteractorContext context)
    {
        rb.AddForce(context.Transform.forward * throwForce);
        Drop();
    }
}

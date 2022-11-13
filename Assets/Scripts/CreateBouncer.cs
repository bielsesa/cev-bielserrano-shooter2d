using UnityEngine;

public class CreateBouncer : MonoBehaviour
{
    public Transform bouncerPosition;
    public GameObject bouncer;

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded) return;
        Instantiate(bouncer, bouncerPosition.position, bouncerPosition.rotation);
    }
}

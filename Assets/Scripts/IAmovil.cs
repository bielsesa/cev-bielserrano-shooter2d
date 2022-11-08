using UnityEngine;

public class IAmovil : MonoBehaviour
{
    public float velocidad = 2f;
    public Vector3 direccion = Vector3.right;

    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
    }
}

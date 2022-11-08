using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{
    public GameObject bala;
    public GameObject puntoDisparo;

    public Animator myAnimator;
    public Animator myAnimatorPistola;

    public Vector3 direccionDisparo = Vector3.right;

    public float velocity = 14f;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            direccionDisparo = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direccionDisparo = Vector3.right;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        myAnimator.SetTrigger("Shoot");
        myAnimatorPistola.SetTrigger("Shoot");
        GameObject nuevaBala = Instantiate(bala, puntoDisparo.transform.position, bala.transform.rotation) as GameObject;
        nuevaBala.GetComponent<Rigidbody>().velocity = velocity * direccionDisparo;
        Destroy(nuevaBala, 3);
    }
}

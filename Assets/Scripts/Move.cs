using UnityEngine;

public class Move : MonoBehaviour
{
    public float velocity = 5f;
    public Animator myAnimator;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-velocity * Time.deltaTime, 0, 0, Space.World);
            transform.localScale = new Vector3(-1, 1, 1);
            myAnimator.SetBool("Walking", true);
        }   
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(velocity * Time.deltaTime, 0, 0, Space.World);
            transform.localScale = new Vector3(1, 1, 1);
            myAnimator.SetBool("Walking", true);
        }
        else
        {
            myAnimator.SetBool("Walking", false);
        }
    }
}

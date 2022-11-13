using UnityEngine;

public class Jump : MonoBehaviour
{
    public float velocity = 5f;
    public bool canDoubleJump; // false as default value

    private Rigidbody _rigidbody;
    private bool _grounded; // false as default value

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            _rigidbody.velocity = Vector3.up * velocity;
        }
    }

    private bool CanJump()
    {
        _grounded = false;

        RaycastHit raycastHit;
        if (Physics.Raycast(transform.position, Vector3.down, out raycastHit, .51f))
        {
            if (raycastHit.transform.tag == "Floor")
            {
                _grounded = true;
            }
        }

        if (_grounded)
        {
            canDoubleJump = true;
            return true;
        }

        if (canDoubleJump)
        {
            canDoubleJump = false;
            return true;
        }

        return false;
    }
}

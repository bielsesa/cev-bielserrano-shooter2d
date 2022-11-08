using UnityEngine;

public class IAspawn : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 direccion = Vector3.right;

    [Header("Límites Spawn")]
    public float counter = 0;
    public float limit;
    public float minLimit = 3;
    public float maxLimit = 6;

    private void Start()
    {
        RandomLimit();
    }

    private void Update()
    {
        counter += Time.deltaTime;

        if (counter >= limit)
        {
            GameObject newEnemy = Instantiate(enemy, transform.position, transform.rotation);
            newEnemy.GetComponent<IAmovil>().direccion = direccion;
            counter = 0;
            RandomLimit();
        }
    }

    private void RandomLimit()
    {
        limit = Random.Range(minLimit, maxLimit);
    }
}

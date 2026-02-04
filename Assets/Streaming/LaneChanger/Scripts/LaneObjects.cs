using UnityEngine;

public class LaneObjects : MonoBehaviour
{
    public float objectSpeed;
    [SerializeField] float initialSpeed = 5f;

    private void Start()
    {
        if (objectSpeed < initialSpeed + 10)
        {
            objectSpeed = initialSpeed + Time.time;
        }
        else
        {
            objectSpeed = 15;
        }
    }
    void Update()
    {
        float zPos = transform.position.z;
        zPos -= objectSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, zPos);

        if (objectSpeed < initialSpeed + 10)
        {
            objectSpeed = initialSpeed + Time.time;
        }

        if (zPos < -10)
        {
            Destroy(gameObject);
        }
    }
}

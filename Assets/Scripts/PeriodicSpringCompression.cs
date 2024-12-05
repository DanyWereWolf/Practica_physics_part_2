using UnityEngine;

public class PeriodicSpringCompression : MonoBehaviour
{
    public SpringJoint springJoint;
    public float compressionAmount = 0.7f;
    public float Speed = 1f;
    public float compressionInterval = 2f;

    private float currentCompression = 0f;
    private float compressionTimer = 0f;
    private bool isCompressed = false;

    private void Start()
    {
        springJoint = GetComponent<SpringJoint>();

        compressionTimer = compressionInterval;
    }

    private void Update()
    {
        compressionTimer -= Time.deltaTime;

        if (compressionTimer <= 0f)
        {
           
            isCompressed = !isCompressed;

            if (isCompressed)
            {
                currentCompression = 1f;
            }
            else
            {
                currentCompression = 0f;
            }
            compressionTimer = compressionInterval;
        }
        springJoint.minDistance = 0f;
        springJoint.maxDistance = currentCompression * compressionAmount;
    }
}
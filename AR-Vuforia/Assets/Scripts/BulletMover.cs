using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public GameObject spawn;
    public GameObject wall1;
    public GameObject wall2;

    public float constantSpeed = 1.0f;
    public float increaseOverBound = 0.01f;

    public static BulletMover Call
    {
        get { return bulletMover; }
    }

    [HideInInspector]
    public float speed;

    private static BulletMover bulletMover = null;

    private BulletMover()
    {
        bulletMover = this;
    }

    void Start()
    {
        speed = constantSpeed;
    }
    
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            speed += increaseOverBound;

            Vector3 worldForward = (transform.forward);
            Vector3 reflection = Vector3.Reflect(worldForward, collision.GetContact(0).normal);
            
            transform.rotation = Quaternion.LookRotation((reflection));

            AudioManager.Call.PlayPaddle();
        }
        else if (LayerMask.LayerToName(collision.gameObject.layer) == "Wall")
        {
            Vector3 worldForward = (transform.forward);
            Vector3 reflection = Vector3.Reflect(worldForward, collision.GetContact(0).normal);
            transform.rotation = Quaternion.LookRotation(reflection);

            AudioManager.Call.PlayWall();
        }
        else if (LayerMask.LayerToName(collision.gameObject.layer) == "Goal")
        {
            speed = constantSpeed;
            transform.position = spawn.transform.position;
            if (gameObject == wall1)
                transform.rotation = Quaternion.LookRotation(wall1.transform.position - transform.position);
            else
                transform.rotation = Quaternion.LookRotation(wall2.transform.position - transform.position);

            AudioManager.Call.PlayScore();
        }
    }
}

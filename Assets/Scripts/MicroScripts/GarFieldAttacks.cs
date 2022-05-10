using UnityEngine;

public class GarFieldAttacks : MonoBehaviour
{
    public int GarfieldAtt = 1;
    public Rigidbody2D EnemyProjectiles;
    public int enemyProjectileSpeed;
    public int Angle;
    public float speed = 3;
    public float direction = 1;
    public float MaxHeight;
    public float MinHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            Debug.Log("Got HIT!");
            StickManControlls player = coll.GetComponent<StickManControlls>();
            player.Damage(GarfieldAtt);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        GarfieldAttacks();
        transform.position += Vector3.up * speed * Time.deltaTime * direction;
        if (direction > 0 && transform.position.y >= MaxHeight)
        {
            direction *= -1;
        }
        else if (direction < 0 && transform.position.y <= MinHeight)
        {
            direction *= -1;
        }
    }

    public void GarfieldAttacks()
    {
        if (Random.Range(0f, 500f) < 1)
        {
            Rigidbody2D proj = Instantiate(EnemyProjectiles);
            proj.transform.position = transform.position;
            proj.velocity = Vector2.left * enemyProjectileSpeed;
        }
    }
}

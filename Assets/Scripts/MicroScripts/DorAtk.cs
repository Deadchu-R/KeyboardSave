using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DorAtk : MonoBehaviour
{
    public int DorAtkR = 3;
    public Rigidbody2D DorProjectile;
    public int DorAtkSpeed;
    public float speed = 3;
    public float direction = 1;
    public float respawnX, respawnY;
    public ParticleSystem ExplodeParticle = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //public void OnTriggerEnter2D(Collider2D coll)
    //{
    //    if (coll.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("HIT!!!");
    //        StickManControlls player = coll.GetComponent<StickManControlls>();
    //        player.Damage(DorAtkR);
    //        ParticleSystem explosion = Instantiate(ExplodeParticle, transform.position, transform.rotation);
    //        explosion.Play();
    //        Destroy(explosion);

    //        transform.position = new Vector3(respawnX, respawnY);
    //    }
    //    if (coll.gameObject.CompareTag("Floor"))
    //    {
    //        ParticleSystem explosion = Instantiate(ExplodeParticle, transform.position, transform.rotation);
    //        explosion.Play();
    //        GetComponent<ParticleSystem>().Clear();
    //        Destroy(explosion);
    //        DestroyParticleSystem(explosion);
    //        transform.position = new Vector3(respawnX, respawnY);
    //    }
    //}

    //public void DestroyParticleSystem(ParticleSystem particleSystem)
    //{
    //    float startTime = particleSystem.main.startLifetime.constantMax;
    //    float duration = particleSystem.main.duration;
    //    float totalDuration = startTime + duration;
    //    Destroy(particleSystem.gameObject, totalDuration);
    //}

    void Update()
    {
        Doratk();
        transform.position += Vector3.up * speed * Time.deltaTime * direction;
        
    }
    public void Doratk()
    {
        if (Random.Range(0f, 500f) < 1)
        {
            Rigidbody2D proj = Instantiate(DorProjectile);
            proj.transform.position = transform.position;
            proj.velocity = Vector2.left * DorAtkSpeed;
        }
    }
    
}

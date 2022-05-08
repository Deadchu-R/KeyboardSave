using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorProj : MonoBehaviour
{
    // Start is called before the first frame update
    public int DorAtkR = 3;
    public ParticleSystem ExplodeParticle = null;
    public float respawnX, respawnY;
    void Start()
    {
       // Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            //Debug.Log("HIT!!!");
            StickManControlls player = coll.GetComponent<StickManControlls>();
            player.Damage(DorAtkR);
            //ParticleSystem explosion = Instantiate(ExplodeParticle, transform.position, transform.rotation);
            //explosion.Play();
            //Destroy(explosion);

            //transform.position = new Vector3(respawnX, respawnY);
        }
        if (coll.gameObject.CompareTag("Floor"))
        {
            //ParticleSystem explosion = Instantiate(ExplodeParticle, transform.position, transform.rotation);
            //explosion.Play();
            //explosion.Stop();
            //GetComponent<ParticleSystem>().Stop();
            //  Destroy(explosion);
            transform.position = new Vector3(respawnX, respawnY);
            //Invoke("StopParticle", 0.1f);
        }
        
    }
    //public void StopParticle()
    //{
    //    ParticleSystem explosion = Instantiate(ExplodeParticle, transform.position, transform.rotation);
    //    explosion.Clear();
    //    explosion.Stop();
    //}
    public void respawn()
    {
        transform.position = new Vector3(respawnX, respawnY);
        

    }
}

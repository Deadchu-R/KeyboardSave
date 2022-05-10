using UnityEngine;

public class Shredder : MonoBehaviour
{
    // ontriggerMethod
    private void OnTriggerEnter2D(Collider2D collision) // when any object colide with Shredder 
    {
        Destroy(collision.gameObject); // will destroy gameObject
    }
}

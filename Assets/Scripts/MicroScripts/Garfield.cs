using UnityEngine;
using UnityEngine.SceneManagement;
public class Garfield : MonoBehaviour
{
    public float HP;  // float for HP
    public float CurrentHP; // float for currentHP
    public AudioSource Hurt; // AudioSource for "Hurt" Sound
    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = HP; // setting currnetHP to be equal to HP at the start of the game
    }

    // Update is called once per frame
    void Update()
    {

    }

    // method for getting damage
    public void Damage(int damage)
    {

        CurrentHP -= damage; // will recieve damage from player
        Hurt.Play(); // will player "Hurt" sound
        Debug.Log("Cat got Hit! Remaining HP : " + CurrentHP); // debug
        if (CurrentHP <= 0) //check if Healf is equal or below 0
        {
            Debug.Log("big cat dead"); // debug
            Destroy(gameObject); // killing Garfield aka "Destroying the Object"
            SceneManager.LoadScene("WinScreen 3");
        }
    }
}


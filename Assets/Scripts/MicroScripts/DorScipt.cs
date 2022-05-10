using UnityEngine;
using UnityEngine.SceneManagement;

public class DorScipt : MonoBehaviour
{
    public float HP; // float for HP
    public float CurrentHP; // float for currentHP
    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage(int damage)
    {

        CurrentHP -= damage; // will recieve damage from player
        Debug.Log("dor got damage"); // debug
        if (CurrentHP <= 0) //check if Healf is equal or below 0
        {
            Debug.Log("Revenge Complete"); // debug
            Destroy(gameObject); // killing Garfield aka "Destroying the Object"
            SceneManager.LoadScene("Intro5");
        }
    }
}

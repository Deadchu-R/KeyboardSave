using UnityEngine;
using UnityEngine.SceneManagement;
public class Snuffles : MonoBehaviour
{
    public float HP; // float for HP
    public float CurrentHP; // float for currentHP
    public Animator SnufAni;
    public float edgeX; // float edgeX for telling the edge for movement 
    public float edgeY;// float edgeY for telling the edge for movement 
    public float speedX; // float SpeedX for to set spring speed on X Axis
    public float speedY; // float SpeedY for to set spring speed on Y Axis
    public float directionX; // float direction X to set sping direction on X Axis
    public float directionY; // float direction Y to set sping direction on Y Axis
    public int damage; // int for damage (the damage the spring does to player)
    public int SnuffleDMG;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = HP; // setting currentHP To be HP At start of the game
    }

    // Update is called once per frame
    void Update()
    {
        SnuffleMove();
    }

    // method to recieve damage
    public void Damage(int damage)
    {
        CurrentHP -= damage; // will take damage from player 
        
        Debug.Log("Snuffles is hurt :( .  Remaining HP :" + CurrentHP); //debug
        if (CurrentHP <= 0) // if health is below or equal to 0 snuffles will die
        {
            Debug.Log("Snuffles go bye-bye."); //debug
            Destroy(gameObject); //destroying snuffles gameobject
            SceneManager.LoadScene("WinScreen 2");
        }
    }
    // method for snuffles movement
    public void SnuffleMove()
    {
            transform.position += Vector3.right * speedX * Time.deltaTime * directionX; // will set transformPosition + vectorRight * the speed for X Axis * direction for X Axis
            transform.position += Vector3.up * speedY * Time.deltaTime * directionY; // will set transformPosition + vectorRight * the speed for Y Axis * direction for Y Axis

            if (directionX > 0 && transform.position.x >= edgeX) // if direction X is bigger than 0 and transformPostion.x is bigger or equal to edgeX
            {
                directionX *= -1; // move to opposite direction
            }
            else if (directionX < 0 && transform.position.x <= -edgeX) // if direction X is smaller than 0 and transformPostion.x is smaller or equal to -edgeX
            {
                directionX *= -1; // move to opposite direction
            }
            if (directionY > 0 && transform.position.y >= edgeY) // if direction Y is bigger than 0 and transformPostion.y is bigger or equal to edgeY
            {
                directionY *= -1; // move to opposite direction
            }
            else if (directionY < 0 && transform.position.y <= -edgeY) // if direction Y is smaller than 0 and transformPostion.y is smaller or equal to -edgeY
            {
                directionY *= -1; // move to opposite direction
            }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player")) // if colide with player
        {
            Debug.Log("Got HIT!"); //debug 
            StickManControlls player = coll.GetComponent<StickManControlls>(); // talking to player script
            player.Damage(SnuffleDMG); //damage player by SnuffleDMG
        }
    }

}

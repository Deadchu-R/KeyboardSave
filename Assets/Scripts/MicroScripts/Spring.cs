using UnityEngine;

public class Spring : MonoBehaviour
{
    public float HP; // float for HP
    public float currentHP; // float for currentHP 
    public float edgeX; // float edgeX for telling the edge for movement 
    public float edgeY;// float edgeY for telling the edge for movement 
    public float speedX; // float SpeedX for to set spring speed on X Axis
    public float speedY; // float SpeedY for to set spring speed on Y Axis
    public float directionX; // float direction X to set sping direction on X Axis
    public float directionY; // float direction Y to set sping direction on Y Axis
    public int damage; // int for damage (the damage the spring does to player)
    public int SpringDamage; // actual Spring damage for invincibliy method
    bool springAlive = true; // bool to check if spring is alive 
    public AudioSource springDmg; // setting AudioSource for the springDMG (everytime he get hit, will play sound)
    public BoxCollider2D springColider; // setting Box Colider for Spring 
    public GameObject player;
    public Animator wallAni;
    public StickManControlls JumpCheck;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHP = HP; // setting currentHP to be Equal to HP at the start of the game
    }

    // method on triggerEnter
    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Collected " + gameObject.name); // debug
        StickManControlls player = coll.gameObject.GetComponent<StickManControlls>(); // getting StickManControlls script from player and call it "player" 
        player.jumpAbi = true; // when player collects a dead spring he will achieve jumping ability
        player.JumpAbiPop = true; // setting JumpAbiPop to true
        Destroy(gameObject); // destroying the object
    }

    // method onCollisionEnter 
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (springAlive == true) //if spring is alive 
        {
            if (coll.gameObject.name == "Player") // if spring colide with player
            {
                Debug.Log("hit player"); // debug
                StickManControlls player = coll.gameObject.GetComponent<StickManControlls>(); // will get player script component from player
                player.Damage(damage); // will damage the the player
                player.invincibility = true; // will set invicibily to true WIP
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (springAlive == true) // if spring is alive 
        {
            StartSpring(); // manage the Movement of the spring. 
            Damage(damage); // manage damage method
        }
    }

    // SpringMovement Method
    void SpringMove()
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

    void StartSpring()
    {
        if (player.transform.position.x >= -11)
        {
            wallAni.SetBool("Near", true);
            SpringMove();
        }

    }
    

    //method for damage
    public void Damage(int damage)
    {
        if (transform.position.y <= -edgeY) // if player Y Axis position smaller or equal to -edgeY
        {
            springDmg.Play(); // play springDmg Sound
            currentHP -= damage; // will damage player
            Debug.Log("Countdown to spring's end: " + currentHP); // debug
            if (currentHP <= 0) // if HP smaller or equal to 0
            {
                Debug.Log("spring dead"); // debug
                //  died = true;
                springAlive = false; // setting springALive bool to false
                springColider.isTrigger = true; // setting SpringColider to true
                //  Destroy(gameObject);
                //  TextMeshProUGUI text = Instantiate(HPText);
                //  HPText.text = "" + currentHP;
            }
        }
    }
}

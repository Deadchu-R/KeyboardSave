using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StickManControlls : MonoBehaviour
{
    public float speed; // a float for speed (will let as the devs choose move-speed for player)
    public float HP; // a float for HP (the number of health the player start with)
    public float currentHP; //a float for currentHP (the amount of health player have in every single moment {will change by conditions})
    public float invTime; // a float in invincibility time (W.I.P)
    public float jumpSpeed = 5; // a float for jumpspeed (to manage speed of player jump)
    public float chargeJumpSpeed = 7; // a float for ChargeJumpSpeed (to manage speed of player Charged jump)
    public int damage = 1; // int for damage, this is how much damage player can do to some objects
    public float knockback; // float for knockback, some enemies will knock player back when get attacked, this will let devs choose how much knockback
    public float respawnX, respawnY; // float for respawn pos , for if player falling off the map and still have HP he will be respawned on posX and Y for each scene 
    public float OutOfBoundsY = -4.5f; // float to check when player is OutOfBounds in order to respawn him back and give him 1 damage
    public Rigidbody2D playerRigid; // creating a Rigidbody to mess with inside the script
    public AudioSource jumpSound; // An audioSource for jumpSound (we made a special boing)
    public Animator playerAni; // an Animator for the player (for jumping, walking, etc)
    public Animator PopAni; // an Animator for PopAnimation
    public TMP_Text popUpText; // setting TextMeshPro for text over PopUp
    public GameObject cam; // a gameobject in script for the camera (so we can make some shananigans)
    public GameObject block; // gameobject for block
    float currentPosX, currentPosY; // currentPosX and Y to check player position at any moment
    public TextMeshProUGUI HPText; // TextMeshProUGUI called HPText to show player health on screen
    public bool died = false; // a bool for player death will check if player is alive or dead
    public bool jumpAbi = false; // a bool that checks if player have the jump abbility 
    public bool jump = false; // a bool that check that player can jump (if player already jumping, he cant jump twice)
    public bool JumpCheck = false;  // will check if player jumped in level1 for WinCondition
    public bool invincibility; // bool for invincibilty (W.I.P)
    public  bool getInputs = false; // Bool to declare if player can use Inputs or not
    public bool JumpAbiPop = false; // a bool to declare if the JumpAbilityPopUp should appear



    private void Awake()
    {
        FirstPopUp(); // method for PopUp in any level
        
    }
    // Start is called before the first frame update
    void Start()
    {
        currentPosY = transform.position.y; // setting currentPosY and X to the start Position at start of the game
        currentPosX = transform.position.x;
        currentHP = HP; // setting current HP to match HP at the start of the game
        
    }
    void Update()
    {
        currentPosY = transform.position.y; // setting currentPosY to player Position.y on any frame
        currentPosX = transform.position.x; // setting currentPosX to player Position.x on any frame   
        HPText.text = "" + currentHP;
        Inputs(); // method for player Inputs and Actions
        Fallen(); // falling through the Map method
        Cheats(); // cheats method
        PopUp(); // PopUpMethod
        //Pause();
    }
    // method for PopUps
    void PopUp()
    {
       if (SceneManager.GetActiveScene().name == "Level1") //if its level1
       {
         if (JumpAbiPop == true) //if JumpAbiPop bool is true 
         {
           PopAni.SetTrigger("StartPop"); // start PopUp
           popUpText.text = "i see you obtained \nthe JumpAbility \npress Space to Jump \nover that block \nto your right ";
           getInputs = false; // set getInputs to false
           JumpAbiPop = false; //set JumpAbiPop to false;
           block.SetActive(true); // set block to be active
         }
         if (transform.position.x >= -17 && transform.position.x <= -16.5 )
         {
           PopAni.SetTrigger("StartPop"); // start PopUp
           popUpText.text = "Beware of the \nenemy ahead \nno marker can \nhit him \nhe is strong \ndon't get hit";
           getInputs = false; // set getInputs to false
           transform.position = new Vector3(-16, -1, 0); // move the player a littleBit outside of PopUp Zone;
         }
        
       }
    }
    // method for the first PopUp in any level
    void FirstPopUp()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            PopAni.SetTrigger("StartPop");
            popUpText.text = "hello, i am E-Doge. \nto move left or right \npress A or D \npress F key \nto continue";
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            PopAni.SetTrigger("StartPop");
            popUpText.text = "Theres snuffles\nyour wife lover.\nkick him in the dick!";
        }

        if (SceneManager.GetActiveScene().name == "Level3")
        {
            PopAni.SetTrigger("StartPop");
            popUpText.text = "Watch his lasers!";
        }

        if (SceneManager.GetActiveScene().name == "LevelDor")
        {
            PopAni.SetTrigger("StartPop");
            popUpText.text = "there he is,\nthe boss himself!\nTime to finish this!";
        }
    }
    // a method to manage playerInputs
     void Inputs()
     {
        if (getInputs == true) // if getInputs is true 
        {
        Movement(); // Player Movement
        Jump(); // JumpingMethod
        }
        if (Input.GetKey(KeyCode.F)) // if player press the F key
        {
            PopAni.SetTrigger("close"); // will close PopUp
            getInputs = true; // will set getInputs to true
        }
     }

    // a method for cheats :)))
    public void Cheats() 
    {
            int i = SceneManager.GetActiveScene().buildIndex;
        if (Input.GetKeyDown(KeyCode.H)) // if press H 
        {
            Debug.Log("M O R E   HP!!!"); // for debuging
            currentHP += 500; // give 500 HP
        }
        if (Input.GetKeyDown(KeyCode.L)) // if press L
        {
            SceneManager.LoadScene(i + 1); // will loadNext Scene
            if (SceneManager.GetActiveScene().name == "LevelDor") // if on LevelDor
            {
                SceneManager.LoadScene("Credits"); // will load credits
            }
        }
        if (Input.GetKeyDown(KeyCode.F1)) // if press F1 
        {
            speed *= 2; // speed multiply by 2
        }
        if (Input.GetKeyDown(KeyCode.F2))// if press F2
        {
            jumpSpeed *= 2; // jumpSPeed multiply by 2
        }
        if (Input.GetKeyDown(KeyCode.F3))// if press F3
        {
            damage = 100; // player do 100 damage
        }
    }

    // method for Jumping
    public void Jump()
    {
        if (jumpAbi == true) // checking if player have jump ability
        {
            if (jump == true) // checking if player jumped already, while player jump he cant jump, only when he on floor
            {
                if (Input.GetKeyDown(KeyCode.LeftShift)) // if player press left shift
                {                                        //  v
                    if (Input.GetKeyDown(KeyCode.Space)) // if player press space 
                    {                                    //  v

                        jumpSound.Play(); // will play jump sound "Boing"
                        Debug.Log("Charge Jump"); // for debuging
                        playerRigid.velocity = Vector2.up * chargeJumpSpeed; // let player jump by moving Rigidbody
                        jump = false; // setting jump to false after a jump so player could not do multiple jumps at the same time
                        playerAni.SetBool("Jumping", true); // setting animation bool "Jumping" to true to show animation of jump
                    }
                }

                if (Input.GetKey(KeyCode.Space)) // if player press space 
                {                               //   v
                    jumpSound.Play(); // will play jump sound "Boing"
                    Debug.Log("Jumping"); // for debuging
                    playerRigid.velocity = Vector2.up * jumpSpeed; // setting jump to false after a jump so player could not do multiple jumps at the same time
                    jump = false; // setting jump to false after a jump so player could not do multiple jumps at the same time
                    playerAni.SetBool("Jumping", true); // setting animation bool "Jumping" to true to show animation of jump

                }
            }
            else 
            {
                playerAni.SetBool("Jumping", false); //setting animation bool "Jumping"
            }
        }
    }

    // method the checks collision with objects
    private void OnCollisionEnter2D(Collision2D coll) 
    {
        if (coll.gameObject.CompareTag ("Floor")) // if player touching the floor 
        {
            //Debug.Log("Grounded"); // debugging
            jump = true; // will set jump to true (so player could jump)
        }

        if (coll.gameObject.name == "Garfield") // if player colide with Garfield Enemy
        {
            Debug.Log("hit big cat"); // debugging
            Garfield garfield = coll.gameObject.GetComponent<Garfield>(); // will get component from Garfield Garfield Script
            garfield.Damage(damage); // will transfer player damage (int) onto Garfield through garfield script "Damage" Method
            playerRigid.velocity = Vector2.left * knockback; // will knockback player on collision
        }

        if (coll.gameObject.name == "Snuffles") // if player colide with Snuffles Enemy
        {
            Debug.Log("hit big cat"); // debuging
            Snuffles snuffle = coll.gameObject.GetComponent<Snuffles>();
            snuffle.Damage(damage);
            playerRigid.velocity = Vector2.left * knockback;
        }

        if (coll.gameObject.tag == "JumpCheck") // if colider with a "JumpCheck" Object
        {
            SceneManager.LoadScene("WinScreen 1"); // will load next scene
        }
        if (coll.gameObject.CompareTag("Dor")) // if player colide with Dor1 Enemy
        {
            Debug.Log("hit Evil Dor"); // debugging
            DorScipt dor = coll.gameObject.GetComponent<DorScipt>(); // will get component from Garfield Garfield Script
            dor.Damage(damage); // will transfer player damage (int) onto Garfield through garfield script "Damage" Method
            transform.position = new Vector3(respawnX, respawnY); // will respawn player afer he hit dor
        }
    }

    // a method for player movement
    void Movement()
    {
        float MoveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime; // will set moveX to be moving Horizontal with Unity Keys and multiply by player speed and deltaTime {for smoother transition}
        transform.position += new Vector3(MoveX, 0); // setting player position X Axis to be + MoveX and to not change the Y Axis
        if (transform.position.x == currentPosX) // check if player not moving
        {
            playerAni.SetBool("Walking", false); // then set walking animation to false
        }
        else // checking if player moving 
        {
            playerAni.SetBool("Walking", true); // then set walking animation to true 
        }
    }
    
    //a method to recieve Damage
    public void Damage(int damage)
    {
        currentHP -= damage; // if player get daamged will lose Health Points depending on which enemy he fighting
        Debug.Log("Took DMG! Remaining HP: " + currentHP); // debugging
        if (currentHP <= 0) // if player have 0 Health or less
        {
            Debug.Log("Player dead"); // debugging
            died = true; // setting player died to true
            Destroy(gameObject); // destroying player
           TextMeshProUGUI text = Instantiate(HPText); // will take TextMeshProGUI and call it text then put HPText in it
             HPText.text = "" + currentHP; // will update the text for HPtext
            if (SceneManager.GetActiveScene().name == "Level1") // if player died in level1
            {
                SceneManager.LoadScene("LoseScreen 1"); // will load lose Scene for level1
            }
            if (SceneManager.GetActiveScene().name == "Level2")// if player died in level2
            {
                SceneManager.LoadScene("LoseScreen 2");// will load lose Scene for level2
            }
            if (SceneManager.GetActiveScene().name == "Level3")// if player died in level3
            {
                SceneManager.LoadScene("LoseScreen 3");// will load lose Scene for level3
            }
            if (SceneManager.GetActiveScene().name == "LevelDor")// if player died in levelDor
            {
                SceneManager.LoadScene("LoseScreen 4");// will load lose Scene for levelDor
            }
        }

    }


    // Fallen Method to check if player falls out of the map
    public void Fallen()
    {
        if (transform.position.y <= OutOfBoundsY) // checking of player falled belown the damage point
        {
            currentHP--; // damage the player by 1
            Debug.Log("Fell off the map , careful next time! Remaining HP: " + currentHP); // debuging
            transform.position = new Vector3(respawnX, respawnY); // returning player to Respawn Points
            if (currentHP <= 0) // checks if player is dead {if he have 0 or less HP}
            {
                Debug.Log("Player dead");
                died = true; // setting player "died" to true
                Destroy(gameObject); // destroying player object

                //TextMeshProUGUI text = Instantiate(HPText);
                //HPText.text = "" + currentHP;
            }
        }
    }



}

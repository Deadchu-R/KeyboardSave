using TMPro;
using UnityEngine;

public class PopUpSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject popUpBox; // setting gameobject for PopUpScreen/Box
    public Animator animator; // setting Animator for the animation of the PopUp
    public TMP_Text popUpText; // setting TextMeshPro for text over PopUp

    //PopUp Methoud
    public void PopUp(string text)
    {
        popUpBox.SetActive(true); // set the PopUp To Active
        popUpText.text = text; // set popUpText to be the Actual Text
        animator.SetTrigger("pop"); // will set trigger for the animation
        
    }

}

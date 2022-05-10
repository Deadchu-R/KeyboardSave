using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StringSave : MonoBehaviour
{ 
   private string _fileLocation;
    private string _saveMe;
    [SerializeField] private InputField input;
    [SerializeField] private Text reactText;
    [SerializeField] private Text reactText2;
    [SerializeField] private Sprite[] images;
    [SerializeField] private Image imageContainer;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource music;
    [SerializeField] private GameObject imageContainerObject;

    private void SetMusic(int index)
    {
        if (audioClips.Length >= index)
        {
            music.clip = audioClips[index];
        }
        music.Play();
    }
    private void SetImage(int index)
    {
        if (images.Length >= index)
        {
            imageContainer.sprite = images[index];       
        }
    }
    public void SaveString()
    {
        
        _saveMe = input.text;
        File.Delete(_fileLocation);
        File.AppendAllText(_fileLocation, _saveMe);
        Debug.Log("saved" + _saveMe);

        EasterEggs();
    }

   
    private void EasterEggs()
    {
        foreach (string line in File.ReadLines(_fileLocation))
        {
            if (line.Contains("Cake") || line.Contains("cake"))
            {
                reactText.text = "cake";
                imageContainerObject.SetActive(true);
                SetImage(4);
                break;
            }
            if (line.Contains("Sean"))
            {
                reactText.text = "Peysakhovitz";
                imageContainerObject.SetActive(true);
                SetImage(2);
                break;
            }
            if (line.Contains("Amir"))
            {
                reactText.text = "Kovalenko";
                imageContainerObject.SetActive(true);
                SetImage(3);
                break;
            }
            if (line.Contains("Roee"))
            {
                reactText.text = "Tal";
                imageContainerObject.SetActive(true);
                SetImage(1);
                break;
            }
            if (line.Contains("UnrealEngine"))
            {
                reactText.text = "No!";
                break;
            }
            if (line.Contains("The Stanley Parable"))
            {
                reactText.text = "Worker 427";
                imageContainerObject.SetActive(true);
                SetImage(5);
                break;
            }
            if (line.Contains("Perry"))
            {
                reactText.text = "Perry the Platypus";
                imageContainerObject.SetActive(true);
                SetImage(0);
                SetMusic(0);
                break;
            }
            if (line.Contains("Sanic"))
            {
                reactText.text = "Sanic The Hedgehog";
                imageContainerObject.SetActive(true);
                SetImage(8);
                SetMusic(1);
                break;
            }
            if (line.Contains("Arabs are terrorists"))
            {
                reactText.text = "You are racist...";
                reactText2.text = "Me too (,-,)";
                imageContainerObject.SetActive(true);
                SetImage(7);
                break;
            }
            if (line.Contains("Angry Birds"))
            {
                SceneManager.LoadScene("AngryBirds");
                break;
            }
            if (line.Contains("MicroPlatina"))
            {
                SceneManager.LoadScene("Level1");
                break;
            }
            if (line.Contains("Portal 2") || line.Contains("portal 2") || line.Contains("portal2") || line.Contains("Portal2") || line.Contains("Portal") || line.Contains("portal"))
            {
                reactText.text = "Spaaaaaaaaaaace";            
                imageContainerObject.SetActive(true);
                SetImage(6);
                break;
            }

            if (!line.Contains("Save String")) continue;
            reactText.text = "Didn't Save ";
            break;

        }
    }
    private void Start()
    {
        _fileLocation = Application.persistentDataPath + "/file.txt";
    }
    public void LoadString()
    {
        if (!File.Exists(_fileLocation)) return;
        //string savedText = fileLocation;
        string savedText = File.ReadAllText(_fileLocation);
        input.text = savedText;
        Debug.Log("loaded" + File.ReadAllText(Application.persistentDataPath + "/file.txt"));
        Debug.Log("loaded file location" + _fileLocation);
        EasterEggs();
    }



}

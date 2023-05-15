using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro; 
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool puzzleLevel = true;
    public AudioSource puzzleMusic;

    public Button harborLocation;
    public Button gateLocation;

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public Button examineButton;
    public Sprite picture;

    public ScriptableObjectsScript currentLocation;
    public ChangeSpriteScript changeSpriteScript;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        //Play puzzle music only when in puzzle level; 
        /* puzzleMusic = GetComponent<AudioSource>();
         
          if (puzzleLevel == true)
         {
             puzzleMusic.Play(1);
             Debug.Log("puzzle music started");
         }
         else
         {
             puzzleMusic.Pause();
             Debug.Log("puzzle music paused");
         } */

        UpdateLocation();
    }

    // Update is called once per frame
    void UpdateLocation()
    {
        Debug.Log(message: examineButton);
        if (examineButton == null) //if there is no examineButton gameObject
        {
            //don't destroy examineButton
        }
        else
        {
            Destroy(examineButton.gameObject); //destroy previous clone
            Debug.Log(message: "destroyed");
        }

        title.text = currentLocation.locationName;
        description.text = currentLocation.locationDescription;
        examineButton = Instantiate(currentLocation.locationButton, GameObject.Find("Canvas").transform);
        picture = Instantiate(currentLocation.locationPicture, GameObject.Find("Canvas").transform);
        //currentLocation.locationPicture; //TODO update sprite by Instantiate, check burn after reading code
    }

    public void MoveDirection(int dir)
    {
        switch (dir)
        {
            case 0:
                currentLocation = currentLocation.harborLocation;
                break;
            case 1:
                currentLocation = currentLocation.gateLocation;
                break;
            case 2:
                currentLocation = currentLocation.startLocation;
                break;
        }

        UpdateLocation();
    }

    public void ChangeButton()
    {
        Debug.Log(message: "change button script called " + currentLocation);
    }


    public void ChangeImage()
    {
        if (currentLocation == currentLocation.harborLocation)
        {
            examineButton.GetComponent<ChangeSpriteScript>().SpawnSprite(0);
        }

        if (currentLocation == currentLocation.gateLocation)
        {
            examineButton.GetComponent<ChangeSpriteScript>().SpawnSprite(1);

        }

    }
}

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
    public Button button;
    public Sprite picture;

    public ScriptableObjectsScript currentLocation;
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
        title.text = currentLocation.locationName;
        description.text = currentLocation.locationDescription;
        //button = startButton;
       //picture = locationPicture; 
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
}
//TODO: figure out why text isn't loading, how to update the image and the start level button per location

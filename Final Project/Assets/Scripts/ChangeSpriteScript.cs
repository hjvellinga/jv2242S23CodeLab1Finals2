using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteScript : MonoBehaviour
{
    private Dictionary <int, Sprite> locationImage = new Dictionary<int, Sprite>();

    public Image defaultImage;
    public Sprite harborSprite;
    public Sprite gateSprite;
    public Sprite locationSpriteButton;

    public ScriptableObjectsScript currentLocation;
    // Start is called before the first frame update
    void Start()
    {
        locationImage.Add(0, harborSprite);
        locationImage.Add(1, gateSprite);
    }

    public void SpawnSprite (int currentLocation) //using dictionary to spawn the correct sprite for each location upon clicking Examine button
    {
        Sprite locationSprite = locationImage[currentLocation]; //define instance of Sprite for leach location, refer to dict. + key (int)
        defaultImage.sprite = locationSprite; //using key value of the int, pull correct Sprite object. 
    }

   
}

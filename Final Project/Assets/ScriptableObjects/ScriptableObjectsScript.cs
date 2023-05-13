using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu 
( fileName = "new Location",
    menuName = "ScriptableObject/Location",
    order = 0)]

public class ScriptableObjectsScript : ScriptableObject
{
    public string locationName;
    public string locationDescription; 
    public Sprite locationPicture;
    public Button startButton;

    public ScriptableObjectsScript harborLocation;
    public ScriptableObjectsScript gateLocation;
    public ScriptableObjectsScript startLocation;
}

using UnityEngine;

/// <summary>
/// Load the beginning of the Game and change settings
/// </summary>
public class Load {

    //Variables
    public float horizontalResolution = 1920;

	//Use this for initialization
	void Start () {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        Camera.main.orthographicSize = horizontalResolution / currentAspect / 200;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantController : MonoBehaviour
{
    public int day = 1;
    public TMP_Text dayText;
    public TMP_Text dayTextUI;
    public GameObject origin;
    private Vector3 origPos;
    private Animation canvasAnimation; // private Animation variable

    void Start()
    {
        origPos = origin.transform.position;
        canvasAnimation = GameObject.Find("Canvas").GetComponent<Animation>(); // get reference to Animation component
        Debug.Log("Found animation component: " + canvasAnimation.name);
    }

    void Update()
    {
        // code to control plant growth
    }

    public void incrementDay()
    {
        origin.transform.position = origPos;
        origin.transform.rotation = Quaternion.identity;
        day += 1;
        dayText.text = $"Day {day}";
        dayTextUI.text = $"Day {day}";

        canvasAnimation.Play("CanvasFade"); // play the animation
    }
}

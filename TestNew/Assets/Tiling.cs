using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour
{
    public int offsetX = 2; //offset for buddy

    public bool hasARightBuddy = false; //instanciate checks
    public bool hasALeftBuddy = false;

    public bool reverseScale = false; //if not tileable

    private float spriteWidth = 0f; //width of element
    private Camera cam;
    private Transform myTransform;

    void Awake()
    {
        cam = Camera.main;
        myTransform = transform;
    }
    
    // Use this for initialization
	void Start ()
    {
        SpriteRenderer sRender = GetComponent < SpriteRenderer>();
        spriteWidth = sRender.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //does it need buddy if not do nothing
        if (hasALeftBuddy == false || hasARightBuddy == false)
        {
            float camHorizontalextent = cam.orthographicSize * Screen.width / Screen.height;
            float edgeVisablePosRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalextent;
            float edgeVisablePosLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalextent;

            if (cam.transform.position.x >= edgeVisablePosRight - offsetX && hasARightBuddy == false)
            {
                makeNewBuddy(1);
                hasARightBuddy = true;
            }
            else if (cam.transform.position.x <= edgeVisablePosLeft + offsetX && hasALeftBuddy == false)
            {
                makeNewBuddy(-1); 
                hasALeftBuddy = true;
                
            }


        }
      
	}

    void makeNewBuddy(int rightOrLeft)
    {
        Vector3 newPos = new Vector3(myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
        Transform newBuddy = (Transform) Instantiate (myTransform, newPos, myTransform.rotation) ;

        if (reverseScale == true)
        {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
        }

        newBuddy.parent = myTransform.parent;

        if (rightOrLeft > 0)
        {
            newBuddy.GetComponent<Tiling>().hasALeftBuddy = true;

        }
        else
        {
            newBuddy.GetComponent<Tiling>().hasARightBuddy = true;
        }

    }
}

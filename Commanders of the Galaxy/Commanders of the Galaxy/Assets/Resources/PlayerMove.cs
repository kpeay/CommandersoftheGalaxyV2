using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : TacticsMove {

    public static bool playerMoving = false;

    // Use this for initialization
    void Start ()
    {
        Init();

        //Anim = GetComponent<Animator>;

    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.DrawRay(transform.position, transform.forward);

        if (!turn)
        {
            return;
        }

        if (!moving)
        {
            FindSelectableTiles();
            CheckMouse();
            playerMoving = false;
        }
        else
        {
            Move();
            playerMoving = true;
            NPCMove.NPCMoving = false;
        }
	}

    void CheckMouse()
    {

        NPCMove.NPCMoving = false;

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tile")
                {
                    Tile t = hit.collider.GetComponent<Tile>();

                    if (t.selectable)
                    {
                        MoveToTile(t);
                    }
                }
            }
        }
    }
}

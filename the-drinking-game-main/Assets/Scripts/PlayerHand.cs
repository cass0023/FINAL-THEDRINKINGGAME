using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHand : MonoBehaviour
{

    public float radius = 5f;
    public float distance = 50f;

    public GameObject[] allowedInteractables;
    public GameObject currentHeld;
    public KeyCode grabRelease;
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public float moveSpeed = 10f;
    public int inversion = 1;
    private bool doGrabRelease;
    RaycastHit2D[] hit;
    private void Start()
    {

    }

    void Update()
    {
        if (doGrabRelease == false)
        {
            doGrabRelease = Input.GetKeyDown(grabRelease);
        }
    }

    void FixedUpdate()
    {

        if (doGrabRelease && currentHeld == null) //if player is pressing grab and hand is empty
        {

               RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.3f);
               Debug.DrawRay(transform.position, -Vector2.up * hit.distance, Color.red);

                if (hit.collider != null)
                {
                    bool canGrab = false;
                    for (int i = 0; i < allowedInteractables.Length; i++)
                    {
                        if (hit.transform.gameObject == allowedInteractables[i])
                        {
                            canGrab = true;
                        }
                    }
                    if (canGrab == true)
                    {
                        currentHeld = hit.transform.gameObject;
                        currentHeld.GetComponent<Collider2D>().enabled = false;
                        currentHeld.SetActive(false);
                    }
                }
            
        }
        else //is holding object
        {
            if (doGrabRelease)
            {
                currentHeld.SetActive(true);
                hit = Physics2D.RaycastAll(transform.position + Vector3.forward, -Vector2.up);

                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].transform != null)
                    {
                        if (hit[i].transform.gameObject.GetComponent<ShakerScript>() != null)
                        {
                            
                            hit[i].transform.gameObject.GetComponent<ShakerScript>().CheckForIngredient(currentHeld);
                        }
                    }
                }

                currentHeld.GetComponent<Collider2D>().enabled = true;
                currentHeld = null;

            }
        }


        // move
        if (Input.GetKey(right))
        {
            transform.Translate(new Vector2(0, -1) * moveSpeed * Time.deltaTime * inversion);
        }
        if (Input.GetKey(left))
        {
            transform.Translate(new Vector2(0, 1) * moveSpeed * Time.deltaTime * inversion);
        }
        if (Input.GetKey(up))
        {
            transform.Translate(new Vector2(1, 0) * moveSpeed * Time.deltaTime * inversion);
        }
        if (Input.GetKey(down))
        {
            transform.Translate(new Vector2(-1, 0) * moveSpeed * Time.deltaTime * inversion);
        }

        // move object
        if (currentHeld != null)
        {
            currentHeld.transform.position = this.transform.position;
        }

        // clean up
        doGrabRelease = false;
    }
}

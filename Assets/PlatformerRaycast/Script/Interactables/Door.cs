using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool doorOpen;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("open", doorOpen);
    }

    public void ToogleDoor()
    {
        if (doorOpen)
            doorOpen = false;
        else
            doorOpen = true;
    }
}

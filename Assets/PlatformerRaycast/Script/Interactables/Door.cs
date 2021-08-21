using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : AbstractInteractables
{
    public bool toogle;
    [SerializeField] private List<Animator> interactableDoor = new List<Animator>();
    [SerializeField] private List<Animator> oppositeInteractableDoor = new List<Animator>();
    public override void Interactables()
    {
        toogle = !toogle;
        Debug.Log("DOOR TOOGLE");
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Animator anim in interactableDoor)
            anim.SetBool("open", true);
        foreach (Animator anim in oppositeInteractableDoor)
            anim.SetBool("open", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (toogle)
        {
            foreach (Animator anim in interactableDoor)
                anim.SetBool("open", false);
            foreach (Animator anim in oppositeInteractableDoor)
                anim.SetBool("open", true);
        }
        else
        {
            foreach (Animator anim in interactableDoor)
                anim.SetBool("open", true);
            foreach (Animator anim in oppositeInteractableDoor)
                anim.SetBool("open", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machineInteraction : interactable
{
    protected override void interact()
    {
        Debug.Log("interacted with" + gameObject.name);  
    }
}

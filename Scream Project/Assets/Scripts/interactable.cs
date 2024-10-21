using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactable : MonoBehaviour
{
    public string prompt_message;

    public void BaseInteract()
    {
        interact();
    }

    protected virtual void interact()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactable : MonoBehaviour
{
    public bool use_events;
    public string prompt_message;

    public void BaseInteract()
    {
        if (use_events)
        {
            GetComponent<interactionEvents>().OnInteract.Invoke();
        }
        interact();
    }

    protected virtual void interact()
    {

    }
}

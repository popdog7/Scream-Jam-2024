using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;

public class playerInteract : MonoBehaviour
{
    private Camera main_camera;

    [SerializeField] float distance = 3f;
    [SerializeField] LayerMask mask;

    private interactionUI interaction_UI;
    public gameInput game_input;

    private void Start()
    {
        main_camera = GetComponent<playerLook>().main_camera;
        interaction_UI = GetComponent<interactionUI>();
    }

    private void Update()
    {
        detectInteraction();
    }

    private void detectInteraction()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(main_camera.transform.position, main_camera.transform.forward);

        interaction_UI.updatePromptText(string.Empty);
        
        Debug.DrawRay(ray.origin, ray.direction * distance);
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            promptInteraction(hitInfo);
        }
    }

    private void promptInteraction(RaycastHit hitInfo)
    {
        if (hitInfo.collider.GetComponent<interactable>() != null)
        {
            interactable interactable = hitInfo.collider.GetComponent<interactable>();
            interaction_UI.updatePromptText(interactable.prompt_message);
            if (game_input.player_input_actions.Player.Interact.triggered)
            {
                interactable.BaseInteract();
            }
        }
    }

}

using UnityEditor;

[CustomEditor(typeof(interactable),true)]
public class interactableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        interactable interactable_object = (interactable)target;
        if (target.GetType() == typeof(eventOnlyInteractable))
        {
            interactable_object.prompt_message = EditorGUILayout.TextField("Prompt Message", interactable_object.prompt_message);
            EditorGUILayout.HelpBox("eventOnlyInteract can only use UnityEvents. ", MessageType.Info);
            if (interactable_object.GetComponent<interactionEvents>() == null)
            {
                interactable_object.use_events = true;
                interactable_object.gameObject.AddComponent<interactionEvents>();
            }
        }
        else
        {
            base.OnInspectorGUI();
            if (interactable_object.use_events)
            {
                addInteractionEvents(interactable_object);
            }
            else
            {
                removeInteractionEvents(interactable_object);
            }
        }
    }

    public void addInteractionEvents(interactable interactable_object)
    {
        if (interactable_object.GetComponent<interactionEvents>() == null)
        {
            interactable_object.gameObject.AddComponent<interactionEvents>();
        }

    }

    public void removeInteractionEvents(interactable interactable_object)
    {
        if (interactable_object.GetComponent<interactionEvents>() != null)
        {
            DestroyImmediate(interactable_object.GetComponent<interactionEvents>());
        }
    }
}

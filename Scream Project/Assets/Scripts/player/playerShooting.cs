using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class playerShooting : MonoBehaviour
{
    [SerializeField] int damage = 50;
    [SerializeField] int ammo_before_reload = 1;
    [SerializeField] Camera main_camera;
    [SerializeField] LayerMask mask;

    public gameInput gameInput;

    private void Start()
    {
        gameInput.on_shoot_action += GameInput_on_shoot_action;
        gameInput.on_reloading_action += GameInput_on_reloading_action;
    }


    private void GameInput_on_shoot_action(object sender, System.EventArgs e)
    {
        if(ammo_before_reload != 0)
        {
            processShooting();
        }
        else
        {
            Debug.Log("need to reload");
        }
    }

    private void processShooting()
    {
        Ray ray = new Ray(main_camera.transform.position, main_camera.transform.forward);
        RaycastHit hit_info;

        if (Physics.Raycast(ray, out hit_info, 100f, mask))
        {
            Debug.Log("Enemy Hit");
            health enemy_health = hit_info.collider.gameObject.GetComponent<health>();
            enemy_health.changeHealth(-damage);
            --ammo_before_reload;
        }
        else
        {
            Debug.Log("Enemy Not Hit");
            --ammo_before_reload;
        }
    }

    private void GameInput_on_reloading_action(object sender, System.EventArgs e)
    {
        throw new System.NotImplementedException();
    }
}

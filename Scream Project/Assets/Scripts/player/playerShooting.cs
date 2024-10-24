using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class playerShooting : MonoBehaviour
{
    [SerializeField] int damage = 50;
    [SerializeField] int gun_ammo_capacity = 1;
    [SerializeField] Camera main_camera;
    [SerializeField] LayerMask mask;

    public int ammo_in_gun;
    public int total_ammo;

    public gameInput gameInput;

    private void Start()
    {
        gameInput.on_shoot_action += GameInput_on_shoot_action;
        gameInput.on_reloading_action += GameInput_on_reloading_action;
        ammo_in_gun = gun_ammo_capacity;
    }


    private void GameInput_on_shoot_action(object sender, System.EventArgs e)
    {
        if(ammo_in_gun != 0)
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
            --ammo_in_gun;
        }
        else
        {
            Debug.Log("Enemy Not Hit");
            --ammo_in_gun;
        }
    }

    private void GameInput_on_reloading_action(object sender, System.EventArgs e)
    {
        if(ammo_in_gun != gun_ammo_capacity && total_ammo != 0)
        {
            updateAmmoValues();
        }
        else
        {
            Debug.Log("cant reload");
        }
    }

    private void updateAmmoValues()
    {
        int ammo_missing = gun_ammo_capacity - ammo_in_gun;
        if(ammo_missing > total_ammo)
        {
            ammo_in_gun += total_ammo;
            total_ammo = 0;
            Debug.Log("no more ammo reseve");
            Debug.Log(ammo_in_gun + " ammo in gun");
        }
        else
        {
            ammo_in_gun += ammo_missing;
            total_ammo -= ammo_missing;
            Debug.Log(total_ammo + " ammo left");
            Debug.Log(ammo_in_gun + " ammo in gun");
        }
        
    }
}

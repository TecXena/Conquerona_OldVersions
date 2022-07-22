using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponChange : MonoBehaviour
{
    private GameObject fireArmWeapon;
    private GameObject meleeWeapon;
    private int selectWeaponCase;


    // Start is called before the first frame update
    void Start()
    {
        // Locates the weapons 
        fireArmWeapon = GameObject.Find("GunPrototype");
        meleeWeapon = GameObject.Find("Melee");

        // Initializes the selected weapon 
        // (for now wala, sa future vers kung kaya kung pumasok yun player sa ibang scene same parin yun weapon nahawak nila)
        selectWeaponCase = 0;
        SelectWeapon();
    }

    // When the button is pressed, it will cycle between these cases
    private void SelectWeapon()
    {
        switch(selectWeaponCase){
            case 1:
                fireArmWeapon.SetActive(false);
                meleeWeapon.SetActive(true);
                break;
            case 2:
                fireArmWeapon.SetActive(true);
                meleeWeapon.SetActive(false);
                break;
            default:
                fireArmWeapon.SetActive(false);
                meleeWeapon.SetActive(false);
                Debug.Log("default Selected Weapon Case");
                break;
        }
    }

    // Method to change weapon - being pressed by btnChangeWeapon
    public void ChangeWeapon(){
        // increments the value of selected weapon variable and updates the selected weapon method
        selectWeaponCase++;
        SelectWeapon();

        // To make the selection of weapons loop between melee and firearm
        if (selectWeaponCase >= 2){
            selectWeaponCase = 0;
        }
    }



}

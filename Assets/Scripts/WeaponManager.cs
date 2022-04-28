using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapons { Sword, Blunt, Fists }
public class WeaponManager : MonoBehaviour
{
    public Weapons weapon;
    
    

    void Start()
    {
        weapon = Weapons.Fists;
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon = Weapons.Fists;
            print("Fists");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon = Weapons.Blunt;
            print("Blunt");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weapon = Weapons.Sword;
            print("Sword");
        }
    }

    

    

   


}

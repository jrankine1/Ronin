using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapons { Sword, Blunt, Fists }
public class WeaponManager : MonoBehaviour
{
    public Weapons weapon;
    float DamageMultiplier = 1;
    void Start()
    {
        weapon = Weapons.Fists;
        WeaponDamage();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon = Weapons.Fists;
            //print("Fists");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon = Weapons.Blunt;
            //print("Blunt");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weapon = Weapons.Sword;
            //print("Sword");
        }
    }

    void WeaponDamage()
    {
        switch(weapon)
        {
            case Weapons.Fists:
                DamageMultiplier = 1f;
                break;
            case Weapons.Blunt:
                DamageMultiplier = 2f;
                break;
            case Weapons.Sword:
                DamageMultiplier = 0.5f;
                break;

        }
    }
}

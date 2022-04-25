using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    
}

public class GameBehaviour<T> : GameBehaviour where T : GameBehaviour
{
    protected static PlayerMovement _PM { get { return PlayerMovement.INSTANCE; } }
    protected static EnemyManager _EM { get { return EnemyManager.INSTANCE; } }
    protected static GameManager _GM { get { return GameManager.INSTANCE; } }
    protected static WeaponManager _WM { get { return WeaponManager.INSTANCE; } }
    protected static Enemy _E { get { return Enemy.INSTANCE; } }

    private static T instance_;
    public static T INSTANCE
    {
        get
        {
            if (instance_ == null)
            {
                instance_ = FindObjectOfType<T>();
                if (instance_ == null)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    singleton.AddComponent<T>();
                }
            }
            return instance_;
        }
    }
    protected virtual void Awake()
    {
        if (instance_ == null)
            instance_ = this as T;
        else
            Destroy(gameObject);
    }
}

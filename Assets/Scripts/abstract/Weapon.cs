using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using zhb;

public abstract class Weapon : MonoBehaviour
{
    public virtual void Shoot(Vector2 mPosition){}

    public GameObject initPrefab(string name,Vector2 position,quaternion rotation){
        //if (bulletFactory.Instance == null)
        //{
        //    Debug.Log("factory≥ı ºªØ");
            
        //}
        return bulletFactory.Instance.GetBullet(name,position,rotation);
    }
}

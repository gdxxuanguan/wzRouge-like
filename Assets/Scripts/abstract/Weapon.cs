using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using zhb;

public abstract class Weapon : MonoBehaviour
{
    private string frendTag { get; set; }
    public virtual void Shoot(Vector2 mPosition){}

    public GameObject initPrefab(string name,Vector2 position,quaternion rotation){
        var bullet= bulletFactory.Instance.GetBullet(name, position, rotation);
        bullet.GetComponent<bullet>().frendTag = frendTag;
        return bullet;
    }
}

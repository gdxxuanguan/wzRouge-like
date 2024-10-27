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

    public void pickup()//拾取武器时，地上武器消失
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enter");
        // 检查是否是玩家进入
        if (other.CompareTag("Player"))
        {
            // 显示拾取提示，例如显示UI
            UiView.Instance.weaponNoticeActive();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 检查是否是玩家退出
        if (other.CompareTag("Player"))
        {
            // 隐藏拾取提示
            UiView.Instance.weaponNoticeHide();
        }
    }

}

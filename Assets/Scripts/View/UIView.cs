using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UiView 
{
    private static UiView instance;
    public static UiView Instance {  
        get {
            if(instance == null)
            {
                instance = new UiView();
            }
            return instance; 
        }
    }
    private GameObject weaponNotice;
    private UiView()
    {
        weaponNotice = UnityTool.Instance.GetGameObjectFromCanvas("weaponPickupNotice");
    }

    public void weaponNoticeActive()
    {
        weaponNotice.SetActive(true);
    }
    public void weaponNoticeHide()
    {
        weaponNotice.SetActive(false);
    } 
}

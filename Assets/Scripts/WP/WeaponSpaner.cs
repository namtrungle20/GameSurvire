using System.Collections.Generic;
using UnityEngine;

public class WeaponSpaner : MonoBehaviour
{
    [SerializeField] protected List<GameObject> prefabsWeapon; // danh sách các prefab của vũ khí
    protected void Reset()
    {
        LoadComponents();
    }
    protected virtual void LoadComponents()
    {
        LoadPrefabs();
    }
    protected virtual void LoadPrefabs()
    {
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            prefabsWeapon.Add(prefab.gameObject);
        }
        HidePrefabs();
    }
    protected virtual void HidePrefabs()
    {
        foreach (GameObject prefab in prefabsWeapon)
        {
            prefab.gameObject.SetActive(false);
        }
    }
}
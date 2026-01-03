using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "New Weapon",
    menuName = "Items/Weapon"
)]
public class WeaponItemData : ItemData
{
    [Header("Weapon Stats")]
    public float damage;
    public float attackRate;
    public float range;
    public float ammo;
    public float durability;
}

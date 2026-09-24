using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StaffData : ScriptableObject
{
    public string Name;
    public int hp_bonus = 0;
    public int Damage;
    public int StaminaDamage;
    public int DamageTime;
    public int MP_cost;
}

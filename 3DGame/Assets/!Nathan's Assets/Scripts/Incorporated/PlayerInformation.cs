using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInformation : MonoBehaviour {

    public int knightMaxHealth;
    public int knightHealthPoints;
    public int knightPhysicalDamag;
    public int knightMagicDamage;
    public int knightArmorValue;
    public int knightResistValue;
    public int knightSpeedValue;

    public int archerMaxHealth;
    public int archerHealthPoints;
    public int archerPhysicalDamage;
    public int archerMagicDamage;
    public int archerArmorValue;
    public int archerResistValue;
    public int archerSpeedValue;

    public int healerMaxHealth;
    public int healerHealthPoints;
    public int healerPhysicalDamage;
    public int healerMagicDamage;
    public int healerArmorValue;
    public int healerResistValue;
    public int healerSpeedValue;

    public int mageMaxHealth;
    public int mageHealthPoints;
    public int magePhysicalDamage;
    public int mageMagicDamage;
    public int mageArmorValue;
    public int mageResistValue;
    public int mageSpeedValue;

    public int playerMoney;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}

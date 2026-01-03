using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public PlayerController player;

    public Slider healthBar;
    public Slider staminaBar;
    public Slider hungerBar;
    public Slider thirstBar;

    void Update()
    {
        if (player == null) return;

        healthBar.maxValue = player.maxHealth;
        healthBar.value = player.health;

        staminaBar.maxValue = player.maxStamina;
        staminaBar.value = player.stamina;

        hungerBar.maxValue = player.maxHunger;
        hungerBar.value = player.hunger;

        thirstBar.maxValue = player.maxThirst;
        thirstBar.value = player.thirst;
    }
}

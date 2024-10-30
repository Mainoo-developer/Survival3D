using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IDamagable
{
    void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition hunger { get { return uiCondition.hunger; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public float noHungerHealthDecay;
    public event Action onTakeDamage;


    private Coroutine speedBoostCoroutine;

    private void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime);

        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (hunger.curValue <= 0f)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if (health.curValue <= 0f)
        {
            Die();
        }


    }
    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        hunger.Add(amount);
    }

    public IEnumerator SpeedBoost(float speedMultiplier, float duration)
    {
        PlayerController playerController = GetComponent<PlayerController>();
        if (playerController == null) yield break;

        // 기존 Coroutine이 실행 중이면 중지
        if (speedBoostCoroutine != null)
        {
            StopCoroutine(speedBoostCoroutine);
        }

        speedBoostCoroutine = StartCoroutine(ApplySpeedBoost(playerController, speedMultiplier, duration));
    }

    private IEnumerator ApplySpeedBoost(PlayerController playerController, float speedMultiplier, float duration)
    {
        float originalSpeed = playerController.moveSpeed;
        playerController.moveSpeed += speedMultiplier;
        yield return new WaitForSeconds(duration);    
        playerController.moveSpeed = originalSpeed;   
        speedBoostCoroutine = null;                   
    }

    public void Die()
    {
        Debug.Log("넌 죽었다.");
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    // Condition 스크립트에서 계속 이 변수들을 업데이트 시켜 주겠다
    public Condition health;
    public Condition hunger;
    public Condition stamina;


    private void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    // Condition ��ũ��Ʈ���� ��� �� �������� ������Ʈ ���� �ְڴ�
    public Condition health;
    public Condition hunger;
    public Condition stamina;


    private void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;
    }
}

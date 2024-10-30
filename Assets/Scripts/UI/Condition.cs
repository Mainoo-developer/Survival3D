using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float startValue;
    public float maxValue;
    public float passiveValue;

    public Image uiBar;



    private void Start()
    {
        curValue = startValue;
    }

    private void Update()
    {
        // fillAmount �� �ִ� ���� 1
        uiBar.fillAmount = GetPercentage();
    }

    float GetPercentage()
    {
        return curValue / maxValue;
    }

    public void Add(float value)
    {
        // curValue + value �� maxValue �� �� ���� ���� ǥ���Ѵ�
        // �ִ� ü���� 100 �ε� 110�� �� ���� ������...
        curValue = Mathf.Min(curValue + value, maxValue);
    }

    public void Subtract(float value)
    {
        // curValue - value �� 0 �߿��� �� ū ���� ǥ���Ѵ�.
        // �ּ� ü���� 0 �ε� -�� ���� ���� ���� ������...
        curValue = Mathf.Max(curValue - value, 0f);
    }
}
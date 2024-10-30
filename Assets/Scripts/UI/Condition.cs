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
        // fillAmount 의 최대 값은 1
        uiBar.fillAmount = GetPercentage();
    }

    float GetPercentage()
    {
        return curValue / maxValue;
    }

    public void Add(float value)
    {
        // curValue + value 와 maxValue 중 더 작은 것을 표시한다
        // 최대 체력이 100 인데 110이 될 수는 없으니...
        curValue = Mathf.Min(curValue + value, maxValue);
    }

    public void Subtract(float value)
    {
        // curValue - value 와 0 중에서 더 큰 것을 표시한다.
        // 최소 체력이 0 인데 -의 수를 가질 수는 없으니...
        curValue = Mathf.Max(curValue - value, 0f);
    }
}

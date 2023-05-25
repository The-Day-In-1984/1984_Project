using UnityEngine;
using UnityEngine.EventSystems;
using Enums;

public class SameNumberLogicMission : LogicMission
{
    [Header("Target")]
    [SerializeField] private string successValue = "1234";

    private CountLogic _countLogic;
    private string _number = "";
    
    protected override void Awake()
    {
        base.Awake();
        
        _countLogic = new CountLogic(successValue.ToString().Length);
        _countLogic.onCountMax += SameNumberCheck;
    }
    
    private void SameNumberCheck()
    {
        if (_number.Equals(successValue.ToString()))
        {
            OnMissionComplete();
        }
        else
        {
            OnMissionFail();
        }
    }
    
    public void AddString(string number)
    {
        _number += number;
        _countLogic.AddCount(1);
    }
}

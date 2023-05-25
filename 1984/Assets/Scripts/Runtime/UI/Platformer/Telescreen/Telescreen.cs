using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class Telescreen : MonoBehaviour
{
    public bool isVisible = false; // 텔레스크린이 범위에 있는지
    private bool nowVisible;
    private Transform transform;
    public GameObject Player; 
    public Camera camera;
    [HideInInspector] public PlayerMoveTracker playerMoveTracker;
 
    [Header("State Time Setting")]
    public float readyTime = 2f;
    public float onTime = 4f;
    public float offMinTime = 3f;
    public float offMaxTime = 6f;

    private readonly Dictionary<TeleScreenType, ITelescreen> stateDictinoary = new Dictionary<TeleScreenType, ITelescreen>();
    public ITelescreen currentState;


    private void Start()
    {
        playerMoveTracker = Player.GetComponent<PlayerMoveTracker>();
        transform = this.gameObject.transform;
        stateDictinoary.Add(TeleScreenType.Ready, new TeleScreen.ReadyState(this));
        stateDictinoary.Add(TeleScreenType.On, new TeleScreen.OnState(this));
        stateDictinoary.Add(TeleScreenType.Off, new TeleScreen.OffState(this));

    }
    // Update is called once per frame
    void Update()
    {
        
        nowVisible = IsTargetVisible(camera, transform);
        if( nowVisible != isVisible)
        {
            //Debug.Log("CHANGE");
            ChangeState(TeleScreenType.Off);
        }
        isVisible = nowVisible;

        if (isVisible)
        {
            //Debug.Log(this.gameObject.ToString());
            currentState.OnExcute();
            Debug.Log(currentState);
        }
    }

    public void ChangeState(TeleScreenType state)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }

        if (stateDictinoary.TryGetValue(state, out var stateType))
        {
            currentState = stateType;
            currentState.OnEnter();
        }
    }

    //게임 화면에 오브젝트가 보이는지 체크
    public bool IsTargetVisible(Camera _camera, Transform _transform)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        var point = _transform.position;
        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
                return false;
        }
        return true;
    }

}

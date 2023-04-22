using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public enum PLAYER_STATE
{ 
    IDLE,
    RUN,
    JUMP,
    CLIMB
}

public interface IState
{
    void Enter();
    void Execute();
    void FixedExecute();
    void Exit();
}

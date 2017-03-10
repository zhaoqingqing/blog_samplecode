using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
Description		:   游戏状态机类, 所有游戏状态均继承此类
Author		:    Jeg
CreateTime	:  2016-7-29 15:40:40
*/
public class GameBase
{
    protected GameState _state = GameState.INVALID;
    public GameState State
    {
        get { return this._state; }
        //set { this._state = value; }
    }

    public GameBase(GameState state)
    {
        _state = state;
    }

    /// <summary>
    /// 进入状态调用
    /// 子类重写该方法
    /// </summary>
    public virtual void OnEnter()
    {
        GameManager.Instance.CurrentState = _state;
        Debug.LogFormat("Enter {0}", _state);
    }

    /// <summary>
    /// 处于状态中调用
    /// 子类重写该方法
    /// </summary>
    public virtual void OnExecute() { }

    /// <summary>
    /// 退出状态调用
    /// 子类重写该方法
    /// </summary>
    public virtual void OnExit()
    {
        //Debug.LogFormat("Exit {0}", _state);
    }

}
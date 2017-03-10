using UnityEngine;
using System.Collections;
using System.Collections.Generic;



/*
Description		:   游戏状态总控
Author		:    Jeg
CreateTime	:  2016-7-30 10:10:40
*/
public class GameSystem
{
    private Dictionary<GameState, GameBase> _gameDictionary;
    //该值不能直接修改, 只能通过状态转换
    private GameState _currentState;
    public GameState CurrentState { get { return this._currentState; } }
    //记录当前GameBase
    private GameBase _currentBase;
    public GameBase CurrentBase { get { return this._currentBase; } }

    public GameSystem()
    {
        _gameDictionary = new Dictionary<GameState, GameBase>();
    }

    /// <summary>
    /// 添加一个新的GameBase对象到映射表中
    /// </summary>
    /// <param name="gbase">待添加的GameBase对象</param>
    public void AddState(GameBase gbase)
    {
        if (gbase == null)
        {
            Debug.LogError("Error: Null reference is not allowed...");
        }

        //第一次添加时必定执行这里, 因为一开始list是空的, 并且这里设置了第一次添加的状态是默认的状态
        if (this._gameDictionary.Count == 0)
        {
            this._gameDictionary.Add(gbase.State, gbase);
            //初始化以下值
            this._currentState = gbase.State;
            this._currentBase = gbase;
            //执行初始状态的Enter
            this._currentBase.OnEnter();
            return;
        }

        if (this._gameDictionary.ContainsKey(gbase.State))
        {
            Debug.LogErrorFormat("Error: {0} has already been added...",
                    System.Enum.GetName(typeof(GameState), gbase.State));
            return;
        }
        this._gameDictionary.Add(gbase.State, gbase);
    }

    /// <summary>
    /// 从列表中根据当前的state删除与之对应的GameBase对象
    /// </summary>
    /// <param name="state">要删除的状态key</param>
    public void DeleteState(GameState state)
    {
        if (state == GameState.INVALID)
        {
            Debug.LogError("Error: Could not delete the gamebase, INVALID is not allowed for a real state...");
            return;
        }

        if (this._gameDictionary.ContainsKey(state))
        {
            this._gameDictionary.Remove(state);
            return;
        }
        Debug.LogErrorFormat("Error: {0} was not on the list of states...",
            System.Enum.GetName(typeof(GameState), state));
    }

    /// <summary>
    /// 从列表中根据当前的state获取与之对应的GameBase对象
    /// </summary>
    /// <param name="state">要获取GameBase对象的key</param>
    /// <returns>返回状态对应的GameBase对象</returns>
    public GameBase GetState(GameState state)
    {
        GameBase gbase = null;
        if (state == GameState.INVALID)
        {
            Debug.LogError("Error: Could not get the gamebase, INVALID is not allowed for a real state...");
            return null;
        }
        if (this._gameDictionary.ContainsKey(state))
        {
            gbase = this._gameDictionary[state];
        }
        else
        {
            Debug.LogErrorFormat("Error: Could not get the gamebase, {0} was not on the list of states...",
                System.Enum.GetName(typeof(GameState), state));
        }
        return gbase;
    }


    /// <summary>
    /// 状态转换, 当前状态和下一个状态切换时的操作
    /// </summary>
    /// <param name="state">输入需要转换的状态</param>
    public void PerformTransition(GameState state)
    {
        if (state == GameState.INVALID)
        {
            Debug.LogError("Error: INVALID is not allowed for a real state...");
            return;
        }

        GameState curState = this._currentState;
        if (curState != state)
        {
            //赋值当前状态为转换后的状态
            this._currentState = state;
            this.OnStateTransited(curState, state);
        }
    }

    /// <summary>
    /// 这函数在PerformTransition内部调用, 当调用PerformTransition
    /// 函数成功设置状态之后, state得到改变之后, 马上要做的事情, 这是状态机
    /// 切换的核心函数
    /// </summary>
    /// <param name="curState">当前状态</param>
    /// <param name="nextState">下一个状态</param>
    protected virtual void OnStateTransited(GameState curState, GameState nextState)
    {
        //转换前状态执行exit
        this.GetState(curState).OnExit();
        this._currentBase = this.GetState(nextState);
        //转换后的状态执行enter
        this._currentBase.OnEnter();
    }

}

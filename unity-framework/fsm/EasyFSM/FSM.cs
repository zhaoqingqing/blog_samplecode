using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
Description		:   状态机类，角色的每一个状态对应于一个FSM类的实例。如果有特殊的
             状态处理逻辑，可以考虑继承实现FSM
Author		:    Jeg
CreateTime	:  2016-7-22 16:21:17
*/

    public class FSM
    {
        //FSM唯一ID
        protected FSMState _state = FSMState.INVALID;
        public FSMState State { get { return this._state; } }
        public static Dictionary<FSMTransitCondition, FSMState> _stateDictionary = new Dictionary<FSMTransitCondition, FSMState>();
        public static List<FSMTransitConditionPriority> _conditionList = new List<FSMTransitConditionPriority>();

        public FSM(FSMState state)
        {
            this._state = state;
        }

        /// <summary>
        /// 添加状态转换条件
        /// </summary>
        /// <param name="condition">转到另一种状态所需的条件</param>
        /// <param name="state">转到另一种的状态</param>
        public void AddTransition(FSMTransitCondition condition, FSMState state)
        {
            if (condition == FSMTransitCondition.INVALID)
            {
                Debug.LogError("Error: You want to add condition is INVALID...");
                return;
            }

            if (state == FSMState.INVALID)
            {
                Debug.LogError("Error: You want to add state is INVALID...");
                return;
            }

            if (_stateDictionary.ContainsKey(condition))
            {
                Debug.LogWarningFormat("Warning: You want to add condition {0} to state {1}. But this condition had exist...",
                System.Enum.GetName(typeof(FSMTransitCondition), condition),
                System.Enum.GetName(typeof(FSMState), state));
                return;
            }

            _stateDictionary.Add(condition, state);
        }

        /// <summary>
        /// 删除对应条件的条件状态
        /// </summary>
        /// <param name="condition">要删除的条件</param>
        public void DeleteTransition(FSMTransitCondition condition)
        {
            if (condition == FSMTransitCondition.INVALID)
            {
                Debug.LogError("Error: You want to delete condition is INVALID...");
                return;
            }

            if (_stateDictionary.ContainsKey(condition))
            {
                _stateDictionary.Remove(condition);
                return;
            }
            Debug.LogErrorFormat("Error: Could not delete condition {0}...",
               System.Enum.GetName(typeof(FSMTransitCondition), condition));
        }

        /// <summary>
        /// 根据给定的输入条件，返回将会转到的输出状态 
        /// </summary>
        /// <param name="condition">给定的输入条件</param>
        /// <returns>转换的输出状态</returns>
        public FSMState GetOutputState(FSMTransitCondition condition)
        {
            if (_stateDictionary.ContainsKey(condition))
            {
                return _stateDictionary[condition];
            }
            Debug.LogWarningFormat("Warning: Could not found the condition {0}, return INVALID...",
                System.Enum.GetName(typeof(FSMTransitCondition), condition));
            return FSMState.INVALID;
        }

        /// <summary>
        /// 设置每种迁移条件的优先级，数值越小优先级越高
        /// </summary>
        /// <param name="condition">迁移条件</param>
        /// <param name="priority">迁移条件对应的优先级, 默认为最后</param>
        public void SetStateTransitConditionPriority(FSMTransitCondition condition, uint priority = uint.MaxValue)
        {
            FSMTransitConditionPriority cp = new FSMTransitConditionPriority(condition, priority);
            _conditionList.Add(cp);
        }

        /// <summary>
        /// 获取本状态切换到其他状态的条件中，优先级最高的那个条件
        /// </summary>
        /// <param name="conditions">条件列表</param>
        /// <returns></returns>
        public FSMTransitCondition GetPrioritizedCondition(List<FSMTransitCondition> conditions)
        {
            int conditionCount = conditions.Count;

            if (0 == conditionCount)
            {
                Debug.LogError("Error: The condition list is empty...");
                return FSMTransitCondition.INVALID;
            }

            if (1 == conditionCount)
            {
                return conditions[0];
            }

            FSMTransitCondition resultCondition = conditions[0];
            uint resultPriority = this.GetConditionPriority(resultCondition);
            FSMTransitCondition curCondition;
            uint curPriority;

            for (int i = 1; i < conditionCount; ++i)
            {
                curCondition = conditions[i];
                curPriority = this.GetConditionPriority(curCondition);

                //如果当前的这个condition的优先级值小于上一个
                if (resultPriority > curPriority) 
                {
                    resultPriority = curPriority;
                    resultCondition = curCondition;
                }
            }
            return resultCondition;
        }

        /// <summary>
        /// 根据传递进来的条件，获取到对应的优先级
        /// </summary>
        /// <param name="condition">待判断优先级的条件值</param>
        /// <returns>返回待判断条件所处对应的优先级</returns>
        public uint GetConditionPriority(FSMTransitCondition condition)
        {
            for (int i = 0, length = _conditionList.Count; i < length; i++)
            {
                if (_conditionList[i]._condition == condition)
                {
                    return _conditionList[i]._priority;
                }
            }
            return uint.MaxValue;
        }

        /// <summary>
        /// 进入状态时逻辑操作
        /// </summary>
        public virtual void EnterState()
        {
            //Debug.LogFormat("Enter {0}", _state); 
        }

        /// <summary>
        /// 处于该状态下所做的逻辑操作
        /// </summary>
        public virtual void ExecuteState() { }

        /// <summary>
        /// 离开状态时逻辑操作
        /// </summary>
        public virtual void ExitState()
        {
            //Debug.LogFormat("Exit {0}", _state); 
        }

        /// <summary>
        /// 监听环境条件的改变并触发相应的事件转换
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Reason(GameObject obj) { }
    }

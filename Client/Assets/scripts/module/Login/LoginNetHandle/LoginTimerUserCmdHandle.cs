﻿using Game.Msg;
using SDK.Common;
namespace Game.Login
{
    public class LoginTimerUserCmdHandle : NetCmdHandleBase
    {
        public LoginTimerUserCmdHandle()
        { 
            m_id2HandleDic[stTimerUserCmd.GAMETIME_TIMER_USERCMD_PARA] = LoginSys.m_instance.m_loginFlowHandle.receiveMsg7f;
            m_id2HandleDic[stTimerUserCmd.REQUESTUSERGAMETIME_TIMER_USERCMD_PARA] = LoginSys.m_instance.m_loginFlowHandle.receiveMsg8f;
        }
    }
}
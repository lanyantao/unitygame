﻿using SDK.Common;
using System.Collections.Generic;

namespace SDK.Lib
{
    public class BeingMgr : ITickedObject, IDelayHandleItem
    {
        public List<BeingEntity> m_list = new List<BeingEntity>();

        public void OnTick(float delta)
        {
            //foreach (BeingEntity being in m_list)
            //{
            //    being.OnTick(delta);
            //}

            int idx = 0;
            while (idx < m_list.Count)
            {
                m_list[idx].OnTick(delta);
                ++idx;
            }
        }

        public void add(BeingEntity being)
        {
            m_list.Add(being as BeingEntity);
        }

        public void remove(int tmpid)
        {

        }

        public void setClientDispose()
        {

        }

        public bool getClientDispose()
        {
            return false;
        }
    }
}
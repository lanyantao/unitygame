﻿namespace SDK.Lib
{
    /**
     * @brief 当需要管理的对象可能在遍历中间添加的时候，需要这个管理器
     */
    public class DelayHandleMgrBaseObsolete : GObject
    {
        protected MList<DelayHandleObjectObsolete> mDeferredAddQueue;
        protected MList<DelayHandleObjectObsolete> mDeferredDelQueue;

        protected LoopDepth mLoopDepth;           // 是否在循环中，支持多层嵌套，就是循环中再次调用循环

        public DelayHandleMgrBaseObsolete()
        {
            this.mDeferredAddQueue = new MList<DelayHandleObjectObsolete>();
            this.mDeferredDelQueue = new MList<DelayHandleObjectObsolete>();

            this.mLoopDepth = new LoopDepth();
            this.mLoopDepth.setZeroHandle(this.processDelayObjects);
        }

        virtual public void init()
        {

        }

        virtual public void dispose()
        {

        }

        virtual protected void addObject(IDelayHandleItem delayObject, float priority = 0.0f)
        {
            if(this.mLoopDepth.isInDepth())
            {
                if (!this.existAddList(delayObject))        // 如果添加列表中没有
                {
                    if (this.existDelList(delayObject))    // 如果已经添加到删除列表中
                    {
                        this.removeFromDelayDelList(delayObject);
                    }

                    DelayHandleObjectObsolete delayHandleObject = new DelayHandleObjectObsolete();
                    delayHandleObject.mDelayParam = new DelayAddParamObsolete();
                    this.mDeferredAddQueue.Add(delayHandleObject);

                    delayHandleObject.mDelayObject = delayObject;
                    (delayHandleObject.mDelayParam as DelayAddParamObsolete).mPriority = priority;
                }
            }
        }

        virtual protected void removeObject(IDelayHandleItem delayObject)
        {
            if (this.mLoopDepth.isInDepth())
            {
                if (!this.existDelList(delayObject))
                {
                    if (this.existAddList(delayObject))    // 如果已经添加到删除列表中
                    {
                        this.removeFromDelayAddList(delayObject);
                    }

                    delayObject.setClientDispose(true);

                    DelayHandleObjectObsolete delayHandleObject = new DelayHandleObjectObsolete();
                    delayHandleObject.mDelayParam = new DelayDelParamObsolete();
                    this.mDeferredDelQueue.Add(delayHandleObject);
                    delayHandleObject.mDelayObject = delayObject;
                }
            }
        }

        // 只有没有添加到列表中的才能添加
        protected bool existAddList(IDelayHandleItem delayObject)
        {
            foreach(DelayHandleObjectObsolete item in this.mDeferredAddQueue.list())
            {
                if(UtilApi.isAddressEqual(item.mDelayObject, delayObject))
                {
                    return true;
                }
            }

            return false;
        }

        // 只有没有添加到列表中的才能添加
        protected bool existDelList(IDelayHandleItem delayObject)
        {
            foreach (DelayHandleObjectObsolete item in this.mDeferredDelQueue.list())
            {
                if (UtilApi.isAddressEqual(item.mDelayObject, delayObject))
                {
                    return true;
                }
            }

            return false;
        }

        // 从延迟添加列表删除一个 Item
        protected void removeFromDelayAddList(IDelayHandleItem delayObject)
        {
            foreach (DelayHandleObjectObsolete item in this.mDeferredAddQueue.list())
            {
                if (UtilApi.isAddressEqual(item.mDelayObject, delayObject))
                {
                    this.mDeferredAddQueue.Remove(item);
                }
            }
        }

        // 从延迟删除列表删除一个 Item
        protected void removeFromDelayDelList(IDelayHandleItem delayObject)
        {
            foreach (DelayHandleObjectObsolete item in this.mDeferredDelQueue.list())
            {
                if(UtilApi.isAddressEqual(item.mDelayObject, delayObject))
                {
                    this.mDeferredDelQueue.Remove(item);
                }
            }
        }

        private void processDelayObjects()
        {
            int idx = 0;
            // len 是 Python 的关键字
            int elemLen = 0;

            if (!this.mLoopDepth.isInDepth())       // 只有全部退出循环后，才能处理添加删除
            {
                if (this.mDeferredAddQueue.Count() > 0)
                {
                    idx = 0;
                    elemLen = this.mDeferredAddQueue.Count();
                    while(idx < elemLen)
                    {
                        this.addObject(this.mDeferredAddQueue[idx].mDelayObject, (this.mDeferredAddQueue[idx].mDelayParam as DelayAddParamObsolete).mPriority);

                        idx += 1;
                    }

                    this.mDeferredAddQueue.Clear();
                }

                if (this.mDeferredDelQueue.Count() > 0)
                {
                    idx = 0;
                    elemLen = this.mDeferredDelQueue.Count();

                    while(idx < elemLen)
                    {
                        this.removeObject(this.mDeferredDelQueue[idx].mDelayObject);

                        idx += 1;
                    }

                    this.mDeferredDelQueue.Clear();
                }
            }
        }

        protected void incDepth()
        {
            this.mLoopDepth.incDepth();
        }

        protected void decDepth()
        {
            this.mLoopDepth.decDepth();
        }

        protected bool isInDepth()
        {
            return this.mLoopDepth.isInDepth();
        }
    }
}
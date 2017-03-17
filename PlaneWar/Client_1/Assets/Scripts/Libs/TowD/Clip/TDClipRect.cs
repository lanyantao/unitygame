namespace SDK.Lib
{
    public class TDClipRect : ITickedObject, IDelayHandleItem, INoOrPriorityObject
    {
        protected UnityEngine.Vector2 mCenter;
        protected float mWidth;    // 宽度
        protected float mHeight;    // 高度

        protected UnityEngine.Vector2 mPrePos;  // 之前的位置
        protected UnityEngine.Vector2 mCurPos;  // 当前位置
        protected float mTolerance;     // 允许移动的范围
        protected bool mIsRectDirty;    // 裁剪矩形是否是 Dirty

        protected int mExtendRange;          // 扩展范围
        protected bool mIsFirst;        // 是否是第一次

        public TDClipRect()
        {
            this.init();
        }

        public void init()
        {
            this.mCenter = UtilMath.ZeroVec2;
            this.mWidth = 2;    // 设置一个最小宽度
            this.mHeight = 2;   // 设置一个最小高度
            this.mExtendRange = 0;

            this.mCurPos = UtilMath.ZeroVec2;
            this.mTolerance = 1.0f;
            this.mIsRectDirty = false;
            this.mIsFirst = true;

            Ctx.mInstance.mGlobalDelegate.mMainChildChangedDispatch.addEventHandle(null, this.onPosChanged);
        }

        public void dispose()
        {
            Ctx.mInstance.mGlobalDelegate.mMainChildChangedDispatch.removeEventHandle(null, this.onPosChanged);
        }

        public void onTick(float delta, TickMode tickMode)
        {
            if(TickMode.eTM_LateUpdate == tickMode)
            {
                if (MacroDef.ENABLE_SCENE2D_CLIP)
                {
                    this.updateSceneGraph();     // 更新场景图
                }
            }
        }

        public void setClientDispose(bool isDispose)
        {

        }

        public bool isClientDispose()
        {
            return false;
        }

        public void setIsRectDirty(bool value)
        {
            this.mIsRectDirty = value;
        }

        public void setCam(UnityEngine.Camera cam)
        {
            UnityEngine.Vector2 size = UtilApi.getOrthoCamSize(cam);

            this.mWidth = size.x;
            this.mHeight = size.y;
        }

        public UnityEngine.Vector2 getCurPos()
        {
            return this.mCurPos;
        }

        public float getLeft()
        {
            float pos = this.mCurPos.x - this.mWidth / 2 - this.mExtendRange;
            return pos;
        }

        public float getRight()
        {
            float pos = this.mCurPos.x + this.mWidth / 2 + this.mExtendRange;
            return pos;
        }

        public float getTop()
        {
            float pos = this.mCurPos.y + this.mHeight / 2 + this.mExtendRange;
            return pos;
        }

        public float getBottom()
        {
            float pos = this.mCurPos.y - this.mHeight / 2 - this.mExtendRange;
            return pos;
        }

        public bool isPosVisible(UnityEngine.Vector3 pos)
        {
            bool visible = true;

            if(pos.x < this.mCenter.x - this.mWidth / 2 - this.mExtendRange ||
               pos.x > this.mCenter.x + this.mWidth / 2 + this.mExtendRange ||
               pos.y < this.mCenter.y - this.mHeight / 2 - this.mExtendRange ||
               pos.y > this.mCenter.y + this.mHeight / 2 + this.mExtendRange)
            {
                visible = false;
            }

            return visible;
        }

        public void onPosChanged(IDispatchObject dispObj)
        {
            if (null != Ctx.mInstance.mPlayerMgr.getHero())
            {
                UnityEngine.Vector3 pos = Ctx.mInstance.mPlayerMgr.getHero().getPos();
                this.updateClipRect(pos);
            }
        }

        public void updateClipRect(UnityEngine.Vector3 pos)
        {
            this.mCurPos.x = pos.x;
            this.mCurPos.y = pos.y;

            this.mCenter = this.mCurPos;    // 现在不做动画，直接移动过来就行了

            if (!UtilMath.isEqualVec2(this.mPrePos, this.mCurPos, mTolerance))
            {
                this.mIsRectDirty = true;
                this.mPrePos = this.mCurPos;
            }
        }

        // 更新场景图
        public void updateSceneGraph()
        {
            if(this.mIsRectDirty || this.mIsFirst)
            {
                this.mIsRectDirty = false;
                this.mIsFirst = false;

                // 更新场景管理器
                Ctx.mInstance.mTileMgr.updateClipRect(this);

                // 更新地形管理器
                this.mExtendRange = 4;  // District 区域的一般
                Ctx.mInstance.mTwoDTerrain.updateClipRect(this);
                this.mExtendRange = 0;
            }
            else
            {
                Ctx.mInstance.mTileMgr.updateDirtyEntity();
            }
        }
    }
}
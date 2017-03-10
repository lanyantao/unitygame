﻿namespace SDK.Lib
{
    public class PlayerMainChildMovement : PlayerChildMovement
    {
        protected UnityEngine.Quaternion mSeparateDestRotate;
        protected bool mIsContactNotMergeFlag;
        protected UnityEngine.Quaternion mMergeDestRotate;

        public PlayerMainChildMovement(SceneEntityBase entity)
            : base(entity)
        {
            //Ctx.mInstance.mInputMgr.addKeyListener(InputKey.G, EventId.KEYUP_EVENT, onTestKeyUp);
            this.mIsContactNotMergeFlag = false;
        }

        override public void init()
        {
            base.init();

            this.initSeparate();
        }

        override public void dispose()
        {
            //Ctx.mInstance.mInputMgr.removeKeyListener(InputKey.G, EventId.KEYUP_EVENT, onTestKeyUp);
            this.removeParentOrientChangedhandle();

            base.dispose();
        }

        override public void onTick(float delta)
        {
            base.onTick(delta);

            //if (Ctx.mInstance.mCommonData.isClickSplit())
            //{
            //    this.updateSeparate();
            //}
        }

        // 被控制的时候向前移动，需要走这里
        override public void moveForward()
        {
            this.updateDir();   // 如果从空闲状态开始走，第一次需要更新一下方向

            //(this.mEntity as BeingEntity).setBeingState(BeingState.eBSWalk);

            //this.setIsMoveToDest(true);
            //this.mMoveWay = MoveWay.eIOControlMove;

            base.moveForward();

            //(this.mEntity as BeingEntity).setBeingState(BeingState.eBSIOControlWalk);

            //UnityEngine.Vector3 localMove = new UnityEngine.Vector3(0.0f, 0.0f, (mEntity as BeingEntity).getMoveSpeed() * Ctx.mInstance.mSystemTimeData.deltaSec);

            //this.addActorLocalDestOffset(localMove);
        }

        // 向目的前向移动
        //override public void addActorLocalDestOffset(UnityEngine.Vector3 DeltaLocation)
        //{
        //    UnityEngine.Vector3 localOffset;
        //    if (!this.mIsContactNotMergeFlag)
        //    {
        //        localOffset = this.mDestRotate * DeltaLocation;
        //    }
        //    else
        //    {
        //        localOffset = this.mMergeDestRotate * DeltaLocation;
        //    }
        //    mEntity.setPos(mEntity.getPos() + localOffset);

        //    this.sendMoveMsg();
        //}

        // Parent Player 方向改变事件处理器
        public void handleParentOrientChanged(IDispatchObject dispObj)
        {
            if ((this.mEntity as BeingEntity).canIOControlMoveForward())
            {
                this.updateDir();
            }
        }

        // Parent Player 位置改变事件处理器
        public void handleParentPosChanged(IDispatchObject dispObj)
        {
            if ((this.mEntity as BeingEntity).canIOControlMoveForward())
            {
                this.moveForward();
            }
        }

        // 方向停止改变
        public void handleParentOrientStopChanged(IDispatchObject dispObj)
        {
            this.movePause();
        }

        // 位置停止改变
        public void handleParentPosStopChanged(IDispatchObject dispObj)
        {
            this.movePause();

            // 修改面向到中心位置
            //int childnum = (this.mEntity as PlayerChild).mParentPlayer.mPlayerSplitMerge.mPlayerChildMgr.getEntityCount();
            //if(childnum > 1)
            //{
            //    UnityEngine.Vector3 targetPoint;
            //    targetPoint = (this.mEntity as PlayerChild).mParentPlayer.mPlayerSplitMerge.getCenterPoint();
            //    UnityEngine.Quaternion retQuat = UtilMath.getRotateByStartAndEndPoint(this.mEntity.getPos(), targetPoint);
            //    (this.mEntity as BeingEntity).setDestRotate(retQuat.eulerAngles, false);
            //}
        }

        protected void updateDir()
        {
            //UnityEngine.Vector3 targetPoint;

            //if ((this.mEntity as PlayerMainChild).isBehindTargetPoint())
            //{
            //    targetPoint = (this.mEntity as PlayerChild).mParentPlayer.mPlayerSplitMerge.getTargetPoint();
            //    UnityEngine.Quaternion retQuat = UtilMath.getRotateByStartAndEndPoint(this.mEntity.getPos(), targetPoint);
            //    (this.mEntity as BeingEntity).setDestRotate(retQuat.eulerAngles, false);
            //}
            //else
            //{
            //    (this.mEntity as BeingEntity).setDestRotate((this.mEntity as PlayerChild).mParentPlayer.getRotateEulerAngle(), false);
            //}

            (this.mEntity as BeingEntity).setDestRotate((this.mEntity as PlayerChild).mParentPlayer.getRotateEulerAngle(), false);
        }

        // 添加监听 Parent 方向位置改变事件
        public void addParentOrientChangedhandle()
        {
            Ctx.mInstance.mGlobalDelegate.mMainOrientChangedDispatch.addEventHandle(null, this.handleParentOrientChanged);
            Ctx.mInstance.mGlobalDelegate.mMainPosChangedDispatch.addEventHandle(null, this.handleParentPosChanged);
            Ctx.mInstance.mGlobalDelegate.mMainOrientStopChangedDispatch.addEventHandle(null, this.handleParentOrientStopChanged);
            Ctx.mInstance.mGlobalDelegate.mMainPosStopChangedDispatch.addEventHandle(null, this.handleParentPosStopChanged);
        }

        public void removeParentOrientChangedhandle()
        {
            Ctx.mInstance.mGlobalDelegate.mMainOrientChangedDispatch.removeEventHandle(null, this.handleParentOrientChanged);
            Ctx.mInstance.mGlobalDelegate.mMainPosChangedDispatch.removeEventHandle(null, this.handleParentPosChanged);
            Ctx.mInstance.mGlobalDelegate.mMainOrientStopChangedDispatch.removeEventHandle(null, this.handleParentOrientStopChanged);
            Ctx.mInstance.mGlobalDelegate.mMainPosStopChangedDispatch.removeEventHandle(null, this.handleParentPosStopChanged);
        }

        protected void onTestKeyUp(IDispatchObject dispObj)
        {
            //(this.mEntity as BeingEntity).setBeingState(BeingState.eBSAttack);
            //(this.mEntity as BeingEntity).setBeingState(BeingState.eBSSplit);
            (this.mEntity as BeingEntity).setTexture("Materials/Textures/Terrain/haidi02.png");
        }

        override public void setSeparateForwardRotate(UnityEngine.Vector3 rotate)
        {
            this.mSeparateDestRotate = UnityEngine.Quaternion.Euler(rotate);
        }

        override public void moveSeparateForwardToDest(float delta)
        {
            UnityEngine.Vector3 localMove = UtilApi.convPosByMode(new UnityEngine.Vector3(0.0f, 0.0f, (mEntity as BeingEntity).getMoveSpeed() * delta));
            this.addActorLocalOffset(localMove);
        }

        public void addActorSeparateOffset(UnityEngine.Vector3 DeltaLocation)
        {
            UnityEngine.Vector3 localOffset = this.mSeparateDestRotate * DeltaLocation;
            mEntity.setPos(mEntity.getPos() + localOffset);
        }

        override public void setNotMergeRotate(UnityEngine.Quaternion quat)
        {
            this.mIsContactNotMergeFlag = true;
            this.mMergeDestRotate = quat;
        }

        override public void clearNotMerge()
        {
            this.mIsContactNotMergeFlag = false;
        }

        //---------------------- SteerForSeparation Start ---------------------------
        private float _comfortDistance = 1;
        private float _multiplierInsideComfortDistance = 1;
        private float _vehicleRadiusImpact = 0;
        private float _comfortDistanceSquared;

        protected MList<SceneEntityBase> _neighbors;
        protected bool _drawNeighbors;

        private float _minDistance = 1;
        private float _maxDistance = 10;

        public float ComfortDistance
        {
            get { return _comfortDistance; }
            set
            {
                _comfortDistance = value;
                _comfortDistanceSquared = _comfortDistance * _comfortDistance;
            }
        }

        public float MaxDistanceSquared { get; private set; }
        public float MinDistanceSquared { get; private set; }

        protected void initSeparate()
        {
            MaxDistanceSquared = _maxDistance * _maxDistance;
            MinDistanceSquared = _minDistance * _minDistance;

            _drawNeighbors = true;
            _comfortDistanceSquared = _comfortDistance * _comfortDistance;
            _neighbors = ((this.mEntity as PlayerChild).mParentPlayer as Player).getChildList();
        }

        public UnityEngine.Vector3 CalculateNeighborContribution(PlayerMainChild other)
        {
            UnityEngine.Vector3 steering = UnityEngine.Vector3.zero;

            // 如果正好重叠， offset 正好是 0
            UnityEngine.Vector3 offset = other.getPos() - this.mEntity.getPos();

            if (UnityEngine.Vector3.zero == offset)  // 如果两个位置重叠，就随机一个方向移动
            {
                offset = UtilMath.UnitCircleRandom();   // 获取一个单位圆随机位置

                if (UnityEngine.Vector3.zero == offset)  // 如果正好随机一个 zero，需要赋值一个值
                {
                    offset = new UnityEngine.Vector3(0.1f, 0.1f, 0.1f);
                }
            }

            float offsetSqrMag = offset.sqrMagnitude;
            steering = (offset / -offsetSqrMag);

            if (!UnityEngine.Mathf.Approximately(_multiplierInsideComfortDistance, 1) && offsetSqrMag < _comfortDistanceSquared)
            {
                steering *= _multiplierInsideComfortDistance;
            }

            if (_vehicleRadiusImpact > 0)
            {
                steering *= (other.getBallRadius() + (this.mEntity as PlayerMainChild).getBallRadius()) * _vehicleRadiusImpact;
            }

            return steering;
        }

        protected UnityEngine.Vector3 CalculateForces()
        {
            UnityEngine.Vector3 steering = UnityEngine.Vector3.zero;

            for (var i = 0; i < _neighbors.Count(); i++)
            {
                PlayerMainChild other = _neighbors[i] as PlayerMainChild;

                if (other != this.mEntity && other.canSeparateByState())
                {
                    if (_drawNeighbors)
                    {
                        if (MacroDef.DRAW_DEBUG)
                        {
                            UtilApi.DrawLine(this.mEntity.getPos(), other.getPos(), UnityEngine.Color.magenta);
                        }
                    }

                    if ((this.mEntity as BeingEntity).isNeedSeparate(other as BeingEntity))
                    {
                        steering += this.CalculateNeighborContribution(other);
                    }
                }
            }

            steering.Normalize();

            return steering;
        }

        public bool IsDirectionInRange(UnityEngine.Vector3 difference)
        {
            return
                UtilMath.IntervalComparison(difference.sqrMagnitude, MinDistanceSquared, MaxDistanceSquared) ==
                0;
        }

        private void updateSeparate()
        {
            if ((this.mEntity as BeingEntity).canSeparateByState())
            {
                UnityEngine.Vector3 steering = this.CalculateForces();

                if (UnityEngine.Vector3.zero != steering)
                {
                    UnityEngine.Quaternion rotate = UtilMath.getRotateByOrient(steering);
                    (this.mEntity as PlayerMainChild).setDestRotate(rotate.eulerAngles, true);
                    //(this.mEntity as PlayerMainChild).setSeparateForwardRotate(rotate.eulerAngles);

                    this.moveForwardSeparate();
                }
                else
                {
                    this.stopMove();
                }
            }
        }

        //---------------------- SteerForSeparation Start ---------------------------
    }
}
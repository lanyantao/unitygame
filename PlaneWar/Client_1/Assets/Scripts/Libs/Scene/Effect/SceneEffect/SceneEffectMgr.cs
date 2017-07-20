﻿using UnityEngine;

namespace SDK.Lib
{
    /**
     * @brief 这个场景特效管理器
     */
    public class SceneEffectMgr : EntityMgrBase
    {
        public void addEffect(EffectBase effect, float priority = 0.0f)
        {
            this.addObject(effect, priority);
        }

        public void removeEffect(EffectBase effect)
        {
            this.removeObject(effect);
        }

        override protected void onTickExec(float delta, TickMode tickMode)
        {
            base.onTickExec(delta, tickMode);
        }

        public EffectBase createAndAdd(EffectType type, EffectRenderType renderType)
        {
            EffectBase effect = null;

            if(EffectType.eLinkEffect == type)
            {
                effect = new LinkEffect(renderType);
            }
            else if (EffectType.eMoveEffect == type)
            {
                effect = new MoveEffect(renderType);
            }
            else if (EffectType.eSceneEffect == type)
            {
                effect = new SceneEffect(renderType);
            }

            Ctx.mInstance.mSceneEffectMgr.addObject(effect);

            return effect;
        }

        //public void removeAndDestroy(EffectBase effect)
        //{
        //    this.delObject(effect);
        //    effect.dispose();
        //}

        // 添加连接特效，固定不动
        public LinkEffect addLinkEffect(int id, GameObject pntGO_, bool bAutoRemove = true, bool bLoop = false, bool bPlay = true)
        {
            LinkEffect effect = createAndAdd(EffectType.eLinkEffect, EffectRenderType.eSpriteEffectRender) as LinkEffect;

            effect.setPnt(pntGO_);
            effect.setLoop(bLoop);
            effect.setTableID(id);
            effect.bAutoRemove = bAutoRemove;

            if (bPlay)
            {
                effect.play();
            }

            return effect;
        }


        // 添加移动特效
        public MoveEffect addMoveEffect(int id, GameObject pntGO_, Vector3 srcPos, Vector3 destPos, float moveTime, bool bAutoRemove = true, bool bLoop = false, bool bPlay = true)
        {
            MoveEffect effect = createAndAdd(EffectType.eMoveEffect, EffectRenderType.eSpriteEffectRender) as MoveEffect;

            effect.setPnt(pntGO_);
            effect.setLoop(bLoop);
            effect.setTableID(id);
            effect.srcPos = srcPos;
            effect.destPos = destPos;
            effect.effectMoveTime = moveTime;
            effect.bAutoRemove = bAutoRemove;

            if (bPlay)
            {
                effect.play();
            }

            return effect;
        }

        // 添加一个场景特效
        public SceneEffect addSceneEffect(int id, GameObject pntGO_, bool bAutoRemove = true, bool bLoop = false, bool bPlay = true)
        {
            SceneEffect effect = createAndAdd(EffectType.eSceneEffect, EffectRenderType.eSpriteEffectRender) as SceneEffect;

            effect.setPnt(pntGO_);
            effect.setLoop(bLoop);
            effect.setTableID(id);
            effect.bAutoRemove = bAutoRemove;

            if (bPlay)
            {
                effect.play();
            }

            return effect;
        }
    }
}
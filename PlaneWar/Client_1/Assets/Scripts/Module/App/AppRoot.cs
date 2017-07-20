﻿using UnityEngine;
using SDK.Lib;

/**
 * @brief 这个模块主要是代码，启动必要的核心代码都在这里，可能某些依赖模块延迟加载
 */
public class AppRoot : MonoBehaviour 
{
    void Awake()
    {
#if UNITY_EDITOR

#else
        // 费编辑器模式下才限制帧数
        //Application.targetFrameRate = 24;
        //QualitySettings.vSyncCount = 0;     // Edit -- Project Settings -- Quality
#endif
        // 全部限制帧数
        Application.targetFrameRate = 24;
        QualitySettings.vSyncCount = 0;     // Edit -- Project Settings -- Quality
        // Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Use this for initialization
    void Start()
    {
        init();
	}
	
	// Update is called once per frame
    void Update()
    {
        //BugResolve();
        //try
        //{
            Ctx.mInstance.mEngineLoop.MainLoop();
        //}
        //catch(Exception err)
        //{
        //}
    }

    void FixedUpdate()
    {
        Ctx.mInstance.mEngineLoop.fixedUpdate();
    }

    void LateUpdate()
    {
        Ctx.mInstance.mEngineLoop.postUpdate();
    }

    void OnApplicationQuit()
    {
        Ctx.mInstance.quitApp();
    }

    // unity 自己产生的 bug ，DontDestroyOnLoad 的对象，加载 Level 后会再产生一个
    private void BugResolve()
    {
        GameObject[] nodestroy = GameObject.FindGameObjectsWithTag("AppGo");  //得到存在的实例列表
        if (nodestroy.Length > 1)
        {
            // 将后产生的毁掉，保留第一个
            //GameObject.Destroy(nodestroy[1]);
            UtilApi.Destroy(nodestroy[1]);
        }
    }

    //public Ctx getCtx()
    //{
    //    return Ctx.mInstance;
    //}

    public void init()
    {
        // 初始化全局数据
        Ctx.instance();
        Ctx.mInstance.init();

        Ctx.mInstance.mDownloadFileMgr.downloadFile();
        // 加载模块
        if (MacroDef.PKG_RES_LOAD)
        {
            Ctx.mInstance.mModuleSys.loadModule(ModuleId.AUTOUPDATEMN);
        }
        else
        {
            Ctx.mInstance.mModuleSys.loadModule(ModuleId.LOGINMN);
            //Ctx.mInstance.mModuleSys.loadModule(ModuleId.GAMEMN);
        }
    }
}
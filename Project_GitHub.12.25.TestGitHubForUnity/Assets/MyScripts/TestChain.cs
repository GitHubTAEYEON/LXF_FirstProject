using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChain : MonoBehaviour {
    private void Start()
    {
        HandleC handleC = new HandleC(null);
        HandleB handleB = new HandleB(handleC);
        HandleA handleA = new HandleA(handleB);

        handleA.ChainHandleWay(10);
        handleA.ChainHandleWay(20);
        handleA.ChainHandleWay(30);
    }
}

//链式处理类
public abstract class ChainHandle {
    ChainHandle nextChainHandle = null;
    public ChainHandle(ChainHandle nextHandle) {
        nextChainHandle = nextHandle;
    }

    public virtual void ChainHandleWay(int cost) {
        if (nextChainHandle != null)
            nextChainHandle.ChainHandleWay(cost);
    }
}

//处理方法一
public class HandleA : ChainHandle {
    private int m_cost = 15;
    public HandleA(ChainHandle ch) : base(ch) {

    }
    public override void ChainHandleWay(int cost)
    {
        if (cost < m_cost) {
            Debug.Log("这个问题由HandleA来解决");
        }
        else
            base.ChainHandleWay(cost);
    }
}

//处理方法二
public class HandleB : ChainHandle {
    private int m_cost = 25;
    public HandleB(ChainHandle ch) : base(ch) {

    }
    public override void ChainHandleWay(int cost)
    {
        if (cost < m_cost)
        {
            Debug.Log("这个问题由HandleB来解决");
        }
        else
            base.ChainHandleWay(cost);
    }
}

//处理方法三
public class HandleC : ChainHandle {
    public HandleC(ChainHandle ch) : base(ch) {

    }
    public override void ChainHandleWay(int cost)
    {
        Debug.Log("AB都无法解决的问题由Handle来解决");
    }
}
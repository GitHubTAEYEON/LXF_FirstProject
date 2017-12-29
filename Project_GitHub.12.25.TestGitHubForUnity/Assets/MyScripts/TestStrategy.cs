using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStrategy : MonoBehaviour {
    private void Start()
    {
        StrategyWay sw = new StrategyWay(new StrategyA());
        sw.StrategyWayInterface();

        StrategyWay sw2 = new StrategyWay(new StrategyB());
        sw2.StrategyWayInterface();
    }
}

public abstract class Strategy {
    public abstract void AlgorithmInterface();
}

public class StrategyA : Strategy {
    public override void AlgorithmInterface()
    {
        Debug.Log("StrategyA所提供的方法");
    }
}

public class StrategyB : Strategy {
    public override void AlgorithmInterface()
    {
        Debug.Log("StrategyB所提供的方法");
    }
}

public class StrategyWay {
    private Strategy m_Strategy=null;
    public StrategyWay(Strategy tmpStrategy) {
        m_Strategy = tmpStrategy;
    }
    //执行当前算法
    public void StrategyWayInterface() {
        m_Strategy.AlgorithmInterface();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObserver : MonoBehaviour {
    private void Start()
    {
        SubjectA sA = new SubjectA();
        ObserverA oA = new ObserverA(sA);
        //ObserverB oB = new ObserverB(sA);
        sA.AttachObserver(oA);
        sA.AttachObserver(new ObserverB(sA));

        sA.SetSubjectName("状态2");
    }
}

//被观察对象父类
public abstract class Subject {
    public List<Observer> m_observers = new List<Observer>();
    //添加订阅者
    public void AttachObserver(Observer ob) {
        m_observers.Add(ob);
    }
    //移除订阅者
    public void RemoveObserver(Observer ob) {
        m_observers.Remove(ob);
    }
    //通知订阅者状态改变
    public void NoteObserver() {
        foreach (Observer ob in m_observers) {
            ob.Update();
        }
    }
}
//被观察对象
public class SubjectA : Subject {
    public string m_subjectName=null;
    public void SetSubjectName(string name) {
        m_subjectName = name;
        //通知订阅者
        NoteObserver();
    }
    public string GetSubjectName() {
        return m_subjectName;
    }
}

//观察者（订阅者）
public abstract class Observer {
    public abstract void Update();
}

//观察者一
public class ObserverA : Observer {
    private string m_subjectName;

    private SubjectA m_subject;
    public ObserverA(SubjectA s) {
        m_subject = s;
    }
    public override void Update()
    {
        m_subjectName = m_subject.GetSubjectName();
        Debug.Log("观察者A更新状态：" + m_subjectName);
    }
}
//观察者二
public class ObserverB : Observer {
    public SubjectA m_subject;
    public ObserverB(SubjectA s) {
        m_subject = s;
    }
    public override void Update()
    {
        Debug.Log("观察者B接收到来自被观察者的状态变化");
        Debug.Log("当前状态为：" + m_subject.GetSubjectName());
    }
}
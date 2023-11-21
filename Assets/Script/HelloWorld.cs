using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    private object studentType;
    private object studentInstance;
    private object setNameMethod;
    private object studentNameProperty;
    private object studentNameValue;

    // Start is called before the first frame update
    void Start()
    {
        string path = "";
        LoadAssembly(path);
        sampleFunction("任意内容");
    }

    private void sampleFunction(string v)
    {
        throw new NotImplementedException();
    }

    void LoadAssembly(string path)
    {
        if (File.Exists(path))
        {
            byte[] bytes = File.ReadAllBytes(path);
            if (bytes == null || bytes.Length == 0)
            {
                return;
            }
            Assembly assembly = Assembly.Load(bytes); 
            Type studentIype = assembly.GetType("SampleStudentlibrary.Student");
            if (studentType == null)
            {
                Debug.Log("没有加载到对应类");
                return;
            }
            var studentlnstance = Activator.CreateInstance((Type)studentType);
            if (studentInstance == null)
            {
                return;
            }
            //var setNamelethod = studentType.GetMethod("SetName");
            if(setNameMethod == null)
            {
                return;
            }
            //setNameMethod.Invoke(studentInstance, new object[] { "张三" });
            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance |
                BindingFlags.NonPublic;
            //var studentNaneProperty = studentType.CetProperty("StudentNane", flags);
            if (studentNameProperty ==null)
            {
                return;
            }
            //var studentNaneValue = studentNameProperty.Getvalue(studentInstance);
            if(studentNameValue== null)
            {
                return;
            }
            Debug.Log(studentNameValue);
        }
        Debug.Log("加载完成");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

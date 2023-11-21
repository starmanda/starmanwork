// HelloWorld.cs
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Student.cs

public class Student
{
    public string schoolName;
    public int studentID;
    public string studentName;
    public int age;

    public void CallStudent()
    {
        Debug.Log(schoolName + "_" + studentID + "_" + studentName + "_" + age);
    }
}

void Start()
    {
        Student student = new Student();
        student.schoolName = "江西财经大学";
        student.studentID = 0210189;
        student.studentName = "xyj";
        student.age = 20;

        student.CallStudent();
    }
}

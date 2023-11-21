using UnityEngine;

public class Student
{
    public int ID { get; set; }
    public string Name { get; set; }

    public Student(int id, string name)
    {
        ID = id;
        Name = name;
    }
}

public class LambdaExample : MonoBehaviour
{
    void Start()
    {
        System.Func<int, string, Student> createStudent = (id, name) => new Student(id, name);

        // 调用Lambda表达式
        Student newStudent = createStudent(0210189, "xyj");

        Debug.Log("New student created with ID: " + newStudent.ID + " and name: " + newStudent.Name);
    }
}

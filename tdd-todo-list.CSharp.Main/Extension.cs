﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_todo_list.CSharp.Main
{
    public class TaskItem
    {
        private int _id;
        private string _name;
        private bool _isComplete;
        private string _date;

        public TaskItem()
        {
            _id = 0;
            _name = "write some more code";
            _isComplete = false;
            _date = DateTime.Now.ToString("dddd, dd mm yyyy hh:mm tt");
        }

        public TaskItem(int taskId, string name, bool isComplete, string date)
        {
            _id = taskId;
            _name = name;
            _isComplete = isComplete;
            _date = date;
        }

        public string ToString()
        {
            return $"Task #{_id}: {_name} ({(_isComplete ? "complete" : "incomplete")}) {_date}";
        }

        public int Id { get => _id; }
        public string Name { get => _name; set => _name = value; }
        public bool IsComplete { get => _isComplete; set => _isComplete = value; }
    }

    public class TodoListExtension
    {
        List<TaskItem> _list = new List<TaskItem>();

        public void Add(TaskItem task)
        {
            _list.Add(task);
        }

        public TaskItem GetTask(int taskId)
        {
            return _list.Find(t => t.Id == taskId);
        }

        public bool UpdateTaskName(int taskId, string name)
        {
            TaskItem task = GetTask(taskId);
            if (task == null) return false;
            task.Name = name;
            return true;
        }

        public bool ChangeTaskStatus(int taskId, bool isComplete)
        {
            TaskItem task = GetTask(taskId);
            if (task == null) return false;
            task.IsComplete = isComplete;
            return true;
        }

        public string GetTaskDates()
        {
            StringBuilder sb = new StringBuilder();

            _list.ForEach(task => sb.Append(task.ToString() + '\n'));

            return sb.ToString();
        }
    }
}

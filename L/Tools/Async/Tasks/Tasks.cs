using System;
using System.Collections.Generic;
using LCore.Extensions;
using System.Threading;
using System.Diagnostics;

namespace LCore.Tasks
    {
    public static class Tasks
        {
        public static int TotalTasks => ToDoTasks.Count + FinishedTasks.Count;

        public static int CompletedTasks => FinishedTasks.Count;

        public static string StatusString
            {
            get
                {
                try
                    {
                    return $"Task {CompletedTasks + 1} of {TotalTasks}: {ToDoTasks[0].StatusMessage}";
                    }
                catch
                    {
                    return "";
                    }
                }
            }

        public delegate void EmptyHandler();

        public static List<TaskInfo> FinishedTasks = new List<TaskInfo>();
        public static List<TaskInfo> ToDoTasks = new List<TaskInfo>();
        public static bool Running;
        public static bool TriggerStop;

        public static void AddPriorityTask(EmptyHandler RunTask, string StatusMessage)
            {
            TaskInfo Task = new TaskInfo { Task = RunTask, StatusMessage = StatusMessage };

            if (ToDoTasks.Count <= 1)
                ToDoTasks.Add(Task);
            else
                ToDoTasks.Insert(1, Task);
            if (!Running)
                {
                Thread t = new Thread(RunTasks);
                t.Start();
                }

            Progress_Updated?.Invoke(null, null);
            }
        public static void AddTask(EmptyHandler RunTask, string StatusMessage)
            {
            TaskInfo Task = new TaskInfo { Task = RunTask, StatusMessage = StatusMessage };
            ToDoTasks.Add(Task);
            if (!Running)
                {
                Thread t = new Thread(RunTasks)
                    {
                    Priority = ThreadPriority.Lowest
                    };
                t.Start();
                }

            Progress_Updated?.Invoke(null, null);
            }
        [DebuggerStepThrough]
        public static void AddTask(EventHandler RunTask, string StatusMessage)
            {
            AddTask(RunTask, StatusMessage, null);

            Progress_Updated?.Invoke(null, null);
            }
        [DebuggerStepThrough]
        public static void AddTask(EventHandler RunTask, string StatusMessage, object Sender)
            {
            if (TaskManager.NoAsyncTasks)
                RunTask(Sender, null);
            else
                {
                TaskInfo Task = new TaskInfo { Task = RunTask, Sender = Sender, StatusMessage = StatusMessage };
                ToDoTasks.Add(Task);
                if (!Running)
                    {
                    Thread t = new Thread(RunTasks);
                    t.Start();
                    }

                Progress_Updated?.Invoke(null, null);
                }
            }

        private static void RunTasks(object Empty)
            {
            if (Running)
                return;

            Running = true;
            while (ToDoTasks.Count > 0)
                {
                if (TriggerStop)
                    break;

                TaskInfo CurrentTask = ToDoTasks[0];

                UpdateTaskBar();
                Progress_Updated?.Invoke(null, null);

                try
                    {
                    CurrentTask.Status = TaskInfo.TaskStatus.InProgress;

                    EventHandler task = CurrentTask.Task as EventHandler;
                    if (task != null)
                        {
                        task(ToDoTasks[0].Sender, EventArgs.Empty);
                        }
                    else
                        {
                        (CurrentTask.Task as EmptyHandler)?.Invoke();
                        }

                    CurrentTask.Status = TaskInfo.TaskStatus.Finished;
                    }
                catch (Exception e)
                    {
                    if (CurrentTask != null)
                        {
                        CurrentTask.Status = TaskInfo.TaskStatus.Error;
                        CurrentTask.Error = e;
                        }
                    throw new Exception("", e);
                    }

                FinishedTasks.Add(CurrentTask);

                ToDoTasks.RemoveAt_Checked(0);
                }
            Running = false;

            UpdateTaskBar();

            UpdateTaskBar();
            Progress_Updated?.Invoke(null, null);

            FinishedTasks = new List<TaskInfo>();
            }
        public static void WaitForFinish()
            {
            while (Running &&
                !StatusString.Contains("Saving Configuration") &&
                !StatusString.Contains("Saving and quitting") &&
                !TriggerStop)
                {
                Thread.Sleep(1000);
                }
            }
        public static void StopTasks()
            {
            TriggerStop = true;
            }
        public static event EventHandler Progress_Updated;

        public class TaskInfo
            {
            public enum TaskStatus { Undone, InProgress, Finished, Error }

            public object Sender;
            public Delegate Task;
            public TaskStatus Status = TaskStatus.Undone;
            public Exception Error;

            public string StatusMessage;

            public override string ToString()
                {
                return this.Status.ToString();
                }
            }
        public static void UpdateTaskBar()
            {
            try
                {
                /*
				Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager TaskMan = Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.Instance;

				if (Tasks.Running)
					{
					TaskMan.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.Normal);
					TaskMan.SetProgressValue(Tasks.CompletedTasks, Tasks.TotalTasks);
					}
				else
					{
					TaskMan.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.NoProgress);
					}
				 */
                }
            catch
                {
                }
            }
        }
    }
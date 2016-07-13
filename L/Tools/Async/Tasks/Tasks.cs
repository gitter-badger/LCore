using System;
using System.Collections.Generic;
using LCore.Extensions;
using System.Threading;
using System.Diagnostics;
#pragma warning disable 1591

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

        /// <exception cref="ThreadStateException">The thread has already been started. </exception>
        /// <exception cref="OutOfMemoryException">There is not enough memory available to start this thread. </exception>
        public static void AddPriorityTask(EmptyHandler RunTask, string StatusMessage)
            {
            var Task = new TaskInfo { Task = RunTask, StatusMessage = StatusMessage };

            if (ToDoTasks.Count <= 1)
                ToDoTasks.Add(Task);
            else
                ToDoTasks.Insert(1, Task);
            if (!Running)
                {
                var Thread = new Thread(RunTasks);
                Thread.Start();
                }

            ProgressUpdated?.Invoke(null, null);
            }

        /// <exception cref="ThreadStateException">The thread has already been started. </exception>
        /// <exception cref="OutOfMemoryException">There is not enough memory available to start this thread. </exception>
        public static void AddTask(EmptyHandler RunTask, string StatusMessage)
            {
            var Task = new TaskInfo { Task = RunTask, StatusMessage = StatusMessage };
            ToDoTasks.Add(Task);
            if (!Running)
                {
                var Thread = new Thread(RunTasks)
                    {
                    Priority = ThreadPriority.Lowest
                    };
                Thread.Start();
                }

            ProgressUpdated?.Invoke(null, null);
            }

        /// <exception cref="ThreadStateException">The thread has already been started. </exception>
        /// <exception cref="OutOfMemoryException">There is not enough memory available to start this thread. </exception>
        [DebuggerStepThrough]
        public static void AddTask(EventHandler RunTask, string StatusMessage)
            {
            AddTask(RunTask, StatusMessage, null);

            ProgressUpdated?.Invoke(null, null);
            }

        /// <exception cref="ThreadStateException">The thread has already been started. </exception>
        /// <exception cref="OutOfMemoryException">There is not enough memory available to start this thread. </exception>
        [DebuggerStepThrough]
        public static void AddTask(EventHandler RunTask, string StatusMessage, object Sender)
            {
            if (TaskManager.NoAsyncTasks)
                RunTask(Sender, null);
            else
                {
                var Task = new TaskInfo { Task = RunTask, Sender = Sender, StatusMessage = StatusMessage };
                ToDoTasks.Add(Task);
                if (!Running)
                    {
                    var Thread = new Thread(RunTasks);
                    Thread.Start();
                    }

                ProgressUpdated?.Invoke(null, null);
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

                var CurrentTask = ToDoTasks[0];

                UpdateTaskBar();
                ProgressUpdated?.Invoke(null, null);

                try
                    {
                    CurrentTask.Status = TaskInfo.TaskStatus.InProgress;

                    var Task = CurrentTask.Task as EventHandler;
                    if (Task != null)
                        {
                        Task(ToDoTasks[0].Sender, EventArgs.Empty);
                        }
                    else
                        {
                        (CurrentTask.Task as EmptyHandler)?.Invoke();
                        }

                    CurrentTask.Status = TaskInfo.TaskStatus.Finished;
                    }
                catch (Exception Ex)
                    {
                    if (CurrentTask != null)
                        {
                        CurrentTask.Status = TaskInfo.TaskStatus.Error;
                        CurrentTask.Error = Ex;
                        }
                    throw new Exception("", Ex);
                    }

                FinishedTasks.Add(CurrentTask);

                ToDoTasks.RemoveAt_Checked(0);
                }
            Running = false;

            UpdateTaskBar();

            UpdateTaskBar();
            ProgressUpdated?.Invoke(null, null);

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
        public static event EventHandler ProgressUpdated;

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
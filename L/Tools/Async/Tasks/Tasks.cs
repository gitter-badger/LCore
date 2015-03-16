using System;
using System.Collections.Generic;
using LCore;
using System.Threading;
using System.Diagnostics;

namespace LCore.Tasks
	{
	public static class Tasks
		{
		public static int TotalTasks
			{
			get
				{
				return ToDoTasks.Count + FinishedTasks.Count;
				}
			}
		public static int CompletedTasks
			{
			get
				{
				return FinishedTasks.Count;
				}
			}
		public static String StatusString
			{
			get
				{
				try
					{
					return "Task " + (CompletedTasks + 1) + " of " + TotalTasks + ": " + ToDoTasks[0].StatusMessage;
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
		public static Boolean Running = false;
		public static Boolean TriggerStop = false;

		public static void AddPriorityTask(EmptyHandler RunTask, String StatusMessage)
			{
			TaskInfo Task = new TaskInfo() { Task = RunTask, StatusMessage = StatusMessage };

			if (ToDoTasks.Count <= 1)
				ToDoTasks.Add(Task);
			else
				ToDoTasks.Insert(1, Task);
			if (!Running)
				{
				Thread t = new Thread(new ParameterizedThreadStart(RunTasks));
				t.Start();
				}

			if (Tasks.Progress_Updated != null)
				Tasks.Progress_Updated(null, null);
			}
		public static void AddTask(EmptyHandler RunTask, String StatusMessage)
			{
			TaskInfo Task = new TaskInfo() { Task = RunTask, StatusMessage = StatusMessage };
			ToDoTasks.Add(Task);
			if (!Running)
				{
				Thread t = new Thread(new ParameterizedThreadStart(RunTasks))
				{
					Priority = ThreadPriority.Lowest
				};
				t.Start();
				}

			if (Tasks.Progress_Updated != null)
				Tasks.Progress_Updated(null, null);
			}
		[DebuggerStepThrough]
		public static void AddTask(EventHandler RunTask, String StatusMessage)
			{
			AddTask(RunTask, StatusMessage, null);

			if (Tasks.Progress_Updated != null)
				Tasks.Progress_Updated(null, null);
			}
		[DebuggerStepThrough]
		public static void AddTask(EventHandler RunTask, String StatusMessage, Object Sender)
			{
			if (TaskManager.NoAsyncTasks)
				RunTask(Sender, null);
			else
				{
				TaskInfo Task = new TaskInfo() { Task = RunTask, Sender = Sender, StatusMessage = StatusMessage };
				ToDoTasks.Add(Task);
				if (!Running)
					{
					Thread t = new Thread(new ParameterizedThreadStart(RunTasks));
					t.Start();
					}

				if (Tasks.Progress_Updated != null)
					Tasks.Progress_Updated(null, null);
				}
			}

		private static void RunTasks(Object Empty)
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
				if (Tasks.Progress_Updated != null)
					{
					Tasks.Progress_Updated(null, null);
					}

				try
					{
					CurrentTask.Status = TaskInfo.TaskStatus.InProgress;

					if (CurrentTask.Task is EventHandler)
						{
						(CurrentTask.Task as EventHandler)(ToDoTasks[0].Sender, EventArgs.Empty);
						}
					else if (CurrentTask.Task is EmptyHandler)
						{
						(CurrentTask.Task as EmptyHandler)();
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
			if (Tasks.Progress_Updated != null)
				{
				Tasks.Progress_Updated(null, null);
				}

			FinishedTasks = new List<TaskInfo>();
			}
		public static void WaitForFinish()
			{
			while (Tasks.Running &&
				!Tasks.StatusString.Contains("Saving Configuration") &&
				!Tasks.StatusString.Contains("Saving and quitting") &&
				!Tasks.TriggerStop)
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
			public enum TaskStatus { Undone, InProgress, Finished, Error };

			public Object Sender;
			public Delegate Task;
			public TaskStatus Status = TaskStatus.Undone;
			public Exception Error;

			public String StatusMessage;

			public override string ToString()
				{
				return Status.ToString();
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
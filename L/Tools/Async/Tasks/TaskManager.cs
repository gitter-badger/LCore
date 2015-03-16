using System;
using System.Collections.Generic;
using LCore;
using System.Text;


namespace LCore.Tasks
	{
	public class TaskManager
		{
		public static Boolean NoAsyncTasks = false;

		private List<TaskTimer> AllTasks = new List<TaskTimer>();

		public TaskManager()
			{
			}

		public void AddTask(Task NewTask)
			{
			NewTask.NextRun_Changed += ScheduleTask;
			AllTasks.Add(new TaskTimer(NewTask));

			ScheduleTask(NewTask);
			}

		public void ScheduleTask(Object o, EventArgs e)
			{
			if (!(o is Task))
				return;

			ScheduleTask((Task)o);
			}

		public void ScheduleTask(Task t)
			{
			for (int i = 0; i < AllTasks.Count; i++)
				{
				if (AllTasks[i].TimerTask == t)
					{
					AllTasks[i].Timer_Reset();
					break;
					}
				}
			}

		public int RunningTasks
			{
			get
				{
				int Running = 0;
				for (int i = 0; i < AllTasks.Count; i++)
					{
					if (AllTasks[i].TimerTask.IsRunning)
						Running++;
					}
				return Running;
				}
			}
		public int TotalTasks
			{
			get
				{
				return AllTasks.Count;
				}
			}
		}
	}
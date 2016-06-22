using System;
using System.Collections.Generic;
using System.Linq;


namespace LCore.Tasks
    {
    public class TaskManager
        {
        public static bool NoAsyncTasks = false;

        private readonly List<TaskTimer> AllTasks = new List<TaskTimer>();

        public void AddTask(Task NewTask)
            {
            NewTask.NextRun_Changed += this.ScheduleTask;
            this.AllTasks.Add(new TaskTimer(NewTask));

            this.ScheduleTask(NewTask);
            }

        public void ScheduleTask(object o, EventArgs e)
            {
            if (!(o is Task))
                return;

            this.ScheduleTask((Task)o);
            }

        public void ScheduleTask(Task t)
            {
            foreach (TaskTimer t1 in this.AllTasks)
                {
                if (t1.TimerTask == t)
                    {
                    t1.Timer_Reset();
                    break;
                    }
                }
            }

        public int RunningTasks
            {
            get
                {
                return this.AllTasks.Count(t => t.TimerTask.IsRunning);
                }
            }

        public int TotalTasks => this.AllTasks.Count;
        }
    }
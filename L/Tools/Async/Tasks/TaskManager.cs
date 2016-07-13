using System;
using System.Collections.Generic;
using System.Linq;
#pragma warning disable 1591


namespace LCore.Tasks
    {
    // ReSharper disable once ClassNeverInstantiated.Global
    public class TaskManager
        {
        public static readonly bool NoAsyncTasks = false;

        private readonly List<TaskTimer> _AllTasks = new List<TaskTimer>();

        public void AddTask(Task NewTask)
            {
            NewTask.NextRunChanged += this.ScheduleTask;
            this._AllTasks.Add(new TaskTimer(NewTask));

            this.ScheduleTask(NewTask);
            }

        public void ScheduleTask(object Obj, EventArgs Event)
            {
            if (!(Obj is Task))
                return;

            this.ScheduleTask((Task)Obj);
            }

        public void ScheduleTask(Task NewTask)
            {
            foreach (var Task in this._AllTasks)
                {
                if (Task.TimerTask == NewTask)
                    {
                    Task.Timer_Reset();
                    break;
                    }
                }
            }

        public int RunningTasks
            {
            get
                {
                return this._AllTasks.Count(Task => Task.TimerTask.IsRunning);
                }
            }

        public int TotalTasks => this._AllTasks.Count;
        }
    }
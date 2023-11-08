using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using Services.Contracts;

namespace Services
{
    public class ProgramService : IProgramService
    {
        public const string TaskName = "LaptopKeyboardRemover";
        public bool IsStartupEnabled()
        {
            using (TaskService ts = new TaskService())
            {
                return ts.RootFolder.AllTasks.Any(task => task.Name == TaskName);
            }
        }

        public void SetStartup(bool enable)
        {
            using (TaskService ts = new TaskService())
            {
                if (enable)
                {

                    TaskDefinition td = ts.NewTask();
                    td.Principal.RunLevel = TaskRunLevel.Highest;

                    td.Triggers.Add(new LogonTrigger { Enabled = true });

                    td.Actions.Add(new ExecAction(Environment.ProcessPath, null, null));

                    ts.RootFolder.RegisterTaskDefinition(TaskName, td);
                }
                else
                {
                    ts.RootFolder.DeleteTask(TaskName);
                }
            }
        }
    }
}
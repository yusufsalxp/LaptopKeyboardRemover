using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using Services.Contracts;

namespace Services
{
    public class ProgramService : IProgramService
    {
        public bool IsStartupEnabled()
        {
            using (TaskService ts = new TaskService())
            {
                return ts.RootFolder.AllTasks.Any(task => task.Name == "LaptopKeyboardRemover");
            }
        }

        public void SetStartup(bool enable)
        {
            if (enable)
            {

                using (TaskService ts = new TaskService())
                {
                    TaskDefinition td = ts.NewTask();
                    td.Principal.RunLevel = TaskRunLevel.Highest;

                    td.Triggers.Add(new LogonTrigger { Enabled = true });

                    td.Actions.Add(new ExecAction(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, null, null));

                    ts.RootFolder.RegisterTaskDefinition("LaptopKeyboardRemover", td);
                }
            }
            else
            {
                using (TaskService ts = new TaskService())
                {
                    ts.RootFolder.DeleteTask("LaptopKeyboardRemover");
                }
            }
        }
    }
}
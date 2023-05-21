using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AsyncTaskProcessor
    {
        private readonly Queue<Func<Task>> _taskQueue = new Queue<Func<Task>>();
        private bool _isProcessing = false;

        public void AddTask(Func<Task> task)
        {
            _taskQueue.Enqueue(task);
            if (!_isProcessing)
            {
                ProcessTasks();
            }
        }

        private async void ProcessTasks()
        {
            _isProcessing = true;
            while (_taskQueue.Count > 0)
            {
                var task = _taskQueue.Dequeue();
                await task();
            }
            _isProcessing = false;
        }

        public async Task WaitAllTasks()
        {
            while (_isProcessing)
            {
                await Task.Delay(10);
            }
        }
    }
}

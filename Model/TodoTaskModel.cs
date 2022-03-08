using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTodoList.Model
{
    public class TodoTask
    {
        public string? Text { get; set; }
        public bool IsCompleted { get; set; }

        public TodoTask(string? text, bool isCompleted)
        {
            Text = text;
            IsCompleted = isCompleted;
        }
    }
}

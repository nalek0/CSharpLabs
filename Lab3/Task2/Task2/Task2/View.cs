using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class View
    {
        public delegate void OnInputEvent(string cost, string tips);
        public event OnInputEvent onInput;

        public void Execute()
        {
            Console.Write("Cost: ");
            string cost = Console.ReadLine();
            Console.Write("Tips(%): ");
            string tips = Console.ReadLine();

            onInput?.Invoke(cost, tips);
        }

        public void OnFeedback(FeedbackData feedbackData)
        {
            Console.WriteLine($"Total sum: {feedbackData.TotalSum}");
        }
    }
}

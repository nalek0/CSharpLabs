using System;

namespace Task2
{
    public class Model
    {
        public delegate void OnFeedbackEvent(FeedbackData feedbackData);
        public event OnFeedbackEvent OnFeeback;

        public void OnInput(int cost, int tips)
        {
            if (cost < 0)
            {
                throw new ModelException("Cost should not be negative.");
            }

            if (tips < 0 || tips >= 100)
            {
                throw new ModelException("Tips should not be negative and less, than 100%.");
            }

            int totalSum = cost + tips * cost / 100;
            FeedbackData feedback = new FeedbackData(totalSum);
            OnFeeback?.Invoke(feedback);
        }
    }

    public class ModelException : Exception {
        public ModelException() { }
        public ModelException(string message) : base(message) { }
        public ModelException(string message, Exception inner) : base(message, inner) { }
    }
}
namespace Task2
{
    internal class Model
    {
        public delegate void OnFeedbackEvent(FeedbackData feedbackData);
        public event OnFeedbackEvent OnFeeback;

        public void OnInput(int cost, int tips)
        {
            int totalSum = cost + tips * cost / 100;
            FeedbackData feedback = new FeedbackData(totalSum);
            OnFeeback?.Invoke(feedback);
        }
    }
}
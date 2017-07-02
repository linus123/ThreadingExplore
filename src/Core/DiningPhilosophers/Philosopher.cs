namespace ThreadingExplore.Core.DiningPhilosophers
{
    public class Philosopher
    {
        private PhilosopherAction[] _philosopherActions;

        private PhilosopherFork _leftFork;
        private PhilosopherFork _rightFork;

        public Philosopher(
            PhilosopherAction[] philosopherActions,
            PhilosopherFork leftFork,
            PhilosopherFork rightFork)
        {
            _rightFork = rightFork;
            _leftFork = leftFork;
            _philosopherActions = philosopherActions;
        }
    }

    public enum PhilosopherActionType
    {
        Think,
        Eat
    }

    public class PhilosopherAction
    {
        private PhilosopherActionType _philosopherActionType;
        private int _typeInMilli;

        public PhilosopherAction(
            PhilosopherActionType philosopherActionType,
            int typeInMilli)
        {
            _typeInMilli = typeInMilli;
            _philosopherActionType = philosopherActionType;
        }
    }
}
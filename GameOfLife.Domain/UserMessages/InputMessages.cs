namespace GameOfLife.Domain.UserMessages
{
    public static class InputMessages
    {
        public const string InitialUserRequest = "Please enter the grid {0}:";

        public const string AfterIncorrectAttemptUserRequest = "Please enter the grid {0} as an integer, larger than 0 (e.g. 100):";
        
        public const string InitialGenerationRequest = "Please enter the number of generations to evolve the grid:";
    
        public const string AfterIncorrectGenerationAttempt = "Please enter the number of generations to evolve the grid as an integer, larger than 0 (e.g. 100):";
    }
}

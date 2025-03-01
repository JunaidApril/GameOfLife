namespace GameOfLife.Domain.Errors
{
    public static class ErrorMessage
    {
        public const string InvalidDimensions = "Invalid dimensions. Rows and columns must be greater than 0.";
        public const string GeneralCreatingError = "An error occurred while creating the game.";
        public const string GeneralRunningError = "An error occurred while running the game.";
        public const string GameNotCreated = "Game has not been created!";
    }
}

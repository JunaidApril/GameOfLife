# Conway's Game of Life - Console Application

## Overview
This project is an implementation of **Conway's Game of Life**, a zero-player game that simulates the evolution of cells in a grid over multiple generations. The application allows users to create a game board of customizable size and observe the changes over multiple generations.

## Features
- Generate a random initial state for the game board
- Simulate the evolution of the game using the classic Game of Life rules
- Display the board at each generation in the console
- Adjustable grid size and number of generations

## Technologies Used
- C# (.NET Core)
- Logging with Microsoft.Extensions.Logging

## Installation & Setup
### Prerequisites
- .NET SDK (version 8.0 or higher)
- A terminal or command prompt to run the application

### Clone the Repository
```sh
git clone https://github.com/JunaidApril/GameOfLife.git
cd GameOfLife
```

### Build the Application
```sh
dotnet build
```

### Run the Application
```sh
dotnet run
```

## Usage
### Creating a New Game
The `GameService` class provides a method to create a new game with a specified number of rows and columns.
```csharp
gameService.CreateGame(10, 10); // Creates a 10x10 grid
```

### Running the Game
To run the game for a specific number of generations:
```csharp
gameService.RunGame(50); // Runs for 50 generations
```
The game will display the board at each generation and update in real time.

## Rules of the Game
The Game of Life follows these simple rules:
1. Any live cell with fewer than two live neighbors dies (underpopulation).
2. Any live cell with two or three live neighbors survives.
3. Any live cell with more than three live neighbors dies (overpopulation).
4. Any dead cell with exactly three live neighbors becomes a live cell (reproduction).

## Project Structure
```
GameOfLife/
│── src
│   │── GameOfLife.Application/
│       ├── Interfaces/
│       ├── Services/
│   │── GameOfLife.Domain/
│       ├── Entities/
│       ├── Interfaces/
│       ├── Errors/
│       ├── UserMessages/
│   │── GameOfLife.Presentation/
│       │── Program.cs
│── test
│   │── GameOfLife.Tests
│       │── GameOfLifeTests.cs
│── README.md
```
- **Application Layer**: Contains business logic (`GameService`).
- **Domain Layer**: Defines core entities (`Game`) and interfaces (`IGame`, `IGameService`).



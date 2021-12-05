namespace AdventOfCode2021.Days;

/// <summary>
/// Class representing the advent day 4.
/// </summary>
public class Day4 : AdventDay
{
    private readonly List<int> numbersToDraw;
    private readonly List<BingoBoard> bingoBoards = new();

    /// <summary>
    /// Initializes the class representing the advent day 4.
    /// </summary>
    /// <param name="isExample">Should example input be used.</param>
    public Day4(bool isExample = false) : base(4, isExample)
    {
        var inputSections = this.InputContents
            .Replace("\r", "")
            .Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

        this.numbersToDraw = inputSections[0]
            .Split(',')
            .Select(int.Parse)
            .ToList();

        foreach (var boardInput in inputSections[1..])
        {
            this.bingoBoards.Add(new BingoBoard(boardInput));
        }
    }

    /// <summary>
    /// Solves the first part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveFirstPart()
    {
        // Draw numbers in the given order.
        foreach (var number in numbersToDraw)
        {
            // Mark the number on all boards.
            this.bingoBoards.ForEach(bb => bb.MarkNumber(number));

            var winningBoard = bingoBoards.FirstOrDefault(bb => bb.IsWinner());

            // Check if winner board found.
            if (winningBoard != null)
            {
                var sumOfUnmarkedNumbers = winningBoard.SumOfUnmarkedNumbers();

                Console.WriteLine($"Sum of unmarked numbers: {sumOfUnmarkedNumbers}");
                Console.WriteLine($"Number that was called: {number}");
                Console.WriteLine($"Final score: {sumOfUnmarkedNumbers * number}");

                return $"{sumOfUnmarkedNumbers * number}";
            }
        }

        return string.Empty;
    }

    /// <summary>
    /// Solves the second part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveSecondPart()
    {
        // Draw numbers in the given order.
        for (var i = 0; i < this.numbersToDraw.Count; i++)
        {
            var number = this.numbersToDraw[i];

            // Mark the number on all boards.
            this.bingoBoards.ForEach(bb => bb.MarkNumber(number));

            var winningBoards = this.bingoBoards
                .Where(bb => bb.IsWinner()).ToList();

            // Check if winner boards are found.
            if (winningBoards.Any())
            {
                // If we are the last board to win.
                if (this.bingoBoards.Count == 1 || i == this.numbersToDraw.Count - 1) 
                {
                    var sumOfUnmarkedNumbers = winningBoards.First().SumOfUnmarkedNumbers();

                    Console.WriteLine($"Sum of unmarked numbers: {sumOfUnmarkedNumbers}");
                    Console.WriteLine($"Number that was called: {number}");
                    Console.WriteLine($"Final score: {sumOfUnmarkedNumbers * number}");

                    return $"{sumOfUnmarkedNumbers * number}";
                }

                foreach (var winningBoard in winningBoards) this.bingoBoards.Remove(winningBoard);
            }
        }

        return string.Empty;
    }
}

/// <summary>
/// Bingo board class.
/// </summary>
public class BingoBoard
{
    public static int Columns => 5;
    public static int Rows => 5;

    private readonly (int boardNumber, bool isMarked)[,] board;

    /// <summary>
    /// Bingo board class constructor.
    /// </summary>
    /// <param name="boardInput">Input that contains the bingo board numbers.</param>
    public BingoBoard(string boardInput)
    {
        this.board = new (int boardNumber, bool isMarked)[Rows, Columns];

        var boardRows = boardInput.Split('\n', StringSplitOptions.TrimEntries);

        for (var i = 0; i < Rows; i++)
        {
            var rowNumbers = boardRows[i]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (var j = 0; j < Columns; j++)
            {
                this.board[i, j] = (rowNumbers[j], false);
            }
        }
    }

    /// <summary>
    /// Marks the number (if it exists) on the board.
    /// </summary>
    /// <param name="number">Number to mark on the board.</param>
    public void MarkNumber(int number)
    {
        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                if (this.board[i, j].boardNumber == number && !this.board[i, j].isMarked)
                    this.board[i, j] = (number, true);
            }
        }
    }

    /// <summary>
    /// Checks to see if the bingo board is a winner.
    /// </summary>
    /// <returns><c>True</c> if the bingo board is a winner.</returns>
    public bool IsWinner()
    {
        // Check rows
        for (var i = 0; i < Rows; i++)
        {
            var winnerRow = true;

            for (var j = 0; j < Columns; j++)
            {
                if (!this.board[i, j].isMarked)
                {
                    winnerRow = false;
                    break;
                }
            }

            if (winnerRow) return true;
        }

        // Check columns
        for (var j = 0; j < Columns; j++)
        {
            var winnerColumn = true;

            for (var i = 0; i < Rows; i++)
            {
                if (!this.board[i, j].isMarked)
                {
                    winnerColumn = false;
                    break;
                }
            }

            if (winnerColumn) return true;
        }

        return false;
    }

    /// <summary>
    /// Gets the sum of unmarked numbers.
    /// </summary>
    /// <returns>Sum of unmarked numbers.</returns>
    public int SumOfUnmarkedNumbers()
    {
        var sum = 0;

        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                if (!this.board[i, j].isMarked) sum += this.board[i, j].boardNumber;
            }
        }

        return sum;
    }
}
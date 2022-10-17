﻿const int MinNumber = 1;
const int MaxNumber = 99;
Random keygen = new Random();
// Generate two random numbers between 1 and 9
int number1 = keygen.Next(MinNumber, MaxNumber + 1);
int number2 = keygen.Next(MinNumber, MaxNumber + 1);
// Caclulate the correct answer
int correctAnswer = number1 + number2;

int answer = PromptForNonZeroPositiveNumber($"What is {number1} + {number2} = ? ");

// Determine if the answer is correct or not
if (answer == correctAnswer)
{
    Console.WriteLine("Correct answer.");
}
else
{
    Console.WriteLine($"Incorrect answer. The correct answer is {correctAnswer}");
}

static int PromptForNonZeroPositiveNumber(string promptMessage)
{
    int intValue = 0;

    bool validInput = false;

    while (!validInput)
    {
        Console.Write(promptMessage);
        while ( ! int.TryParse(Console.ReadLine(), out intValue))
        {
            Console.WriteLine("Invalid input! You must enter a positive non-zero number.");
            Console.Write(promptMessage);
        }
        if ( intValue > 0 )
        {
            validInput = true;
        }
        else
        {
            Console.WriteLine("Invalid input! Negative or zero is not allowed.");
        }
    }

    return intValue;
}
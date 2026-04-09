using System.Collections.Generic;

namespace Codey.Extension.Models
{
    public static class ExerciseRepository
    {
        public static List<Exercise> GetAll() => new List<Exercise>
        {
            // ── BEGINNER ────────────────────────────────────────────────────────

            new Exercise
            {
                Level          = "Beginner",
                Title          = "Hello World",
                Description    = "Print 'Hello, World!' to the console.",
                Concept        = "Console.WriteLine() writes a line of text to the console output. It's the most fundamental way to produce output in a C# program and is almost always the first thing you learn.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        // Write your code here\n    }\n}",
                ExpectedOutput = "Hello, World!",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        Console.WriteLine(\"Hello, World!\");\n    }\n}",
                Hints          = new[]
                {
                    "The method you need is in the Console class.",
                    "Try Console.WriteLine(...) — it prints text followed by a newline.",
                    "Put the string \"Hello, World!\" inside the parentheses."
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "Sum of Two Numbers",
                Description    = "Create two integer variables a = 5 and b = 3, then print their sum.",
                Concept        = "Variables are named storage locations. The int type holds whole numbers. The + operator adds numbers together, and you can pass an expression directly to Console.WriteLine.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int a = 5;\n        int b = 3;\n        // Print the sum of a and b\n    }\n}",
                ExpectedOutput = "8",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int a = 5;\n        int b = 3;\n        Console.WriteLine(a + b);\n    }\n}",
                Hints          = new[]
                {
                    "You already have a and b declared. You just need to output their sum.",
                    "Console.WriteLine can take a number directly: Console.WriteLine(someNumber).",
                    "Use the + operator between a and b inside Console.WriteLine."
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "Even or Odd",
                Description    = "Given n = 7, print 'Even' if n is even, or 'Odd' if it is not.",
                Concept        = "The modulo operator % gives the remainder of division. If n % 2 == 0, the number divides evenly by 2, so it's even. An if/else block runs different code based on a condition.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int n = 7;\n        // Print \"Even\" or \"Odd\"\n    }\n}",
                ExpectedOutput = "Odd",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int n = 7;\n        if (n % 2 == 0)\n            Console.WriteLine(\"Even\");\n        else\n            Console.WriteLine(\"Odd\");\n    }\n}",
                Hints          = new[]
                {
                    "Use an if/else statement to choose between two outputs.",
                    "The modulo operator % gives you the remainder: 7 % 2 equals 1.",
                    "Check if n % 2 == 0 to determine evenness."
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "Count to Ten",
                Description    = "Print the numbers 1 through 10, each on its own line, using a for loop.",
                Concept        = "A for loop repeats code a set number of times. It has three parts: initialization (int i = 1), condition (i <= 10), and increment (i++). The body runs once per iteration.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        // Use a for loop to print 1 through 10\n    }\n}",
                ExpectedOutput = "1\n2\n3\n4\n5\n6\n7\n8\n9\n10",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        for (int i = 1; i <= 10; i++)\n            Console.WriteLine(i);\n    }\n}",
                Hints          = new[]
                {
                    "A for loop has the form: for (start; condition; step) { ... }",
                    "Start i at 1 and continue while i <= 10.",
                    "Use i++ to increment by 1 each iteration, and print i inside the loop."
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "Reverse a String",
                Description    = "Reverse the string \"hello\" and print the result.",
                Concept        = "Strings are sequences of characters. You can convert a string to a char array with ToCharArray(), then use Array.Reverse() to flip it, and new string(array) to convert back.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string s = \"hello\";\n        // Reverse s and print it\n    }\n}",
                ExpectedOutput = "olleh",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string s = \"hello\";\n        char[] chars = s.ToCharArray();\n        Array.Reverse(chars);\n        Console.WriteLine(new string(chars));\n    }\n}",
                Hints          = new[]
                {
                    "Strings are immutable in C#, so you need to work with a char array.",
                    "Convert the string with s.ToCharArray(), then use Array.Reverse().",
                    "Convert the reversed array back to a string using new string(chars)."
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "Max of Three",
                Description    = "Given a = 4, b = 9, c = 6, print the largest of the three numbers.",
                Concept        = "You can use Math.Max() to compare two values, or chain comparisons with if/else if. Math.Max(Math.Max(a, b), c) is a concise one-liner approach.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int a = 4, b = 9, c = 6;\n        // Print the largest value\n    }\n}",
                ExpectedOutput = "9",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int a = 4, b = 9, c = 6;\n        Console.WriteLine(Math.Max(Math.Max(a, b), c));\n    }\n}",
                Hints          = new[]
                {
                    "You can compare values using > or the Math.Max() method.",
                    "Math.Max(x, y) returns the larger of two numbers.",
                    "To find the max of three, apply Math.Max twice: Math.Max(Math.Max(a, b), c)."
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "Multiplication Table",
                Description    = "Print the multiplication table for 7 (from 7×1 to 7×10).",
                Concept        = "String interpolation ($\"...\") lets you embed expressions inside a string using {expression} placeholders. Combined with a for loop, you can format each line of output neatly.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        // Print 7x1=7, 7x2=14, ..., 7x10=70\n    }\n}",
                ExpectedOutput = "7 x 1 = 7\n7 x 2 = 14\n...\n7 x 10 = 70",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        for (int i = 1; i <= 10; i++)\n            Console.WriteLine($\"7 x {i} = {7 * i}\");\n    }\n}",
                Hints          = new[]
                {
                    "Use a for loop from 1 to 10.",
                    "Inside the loop, calculate 7 * i for the result.",
                    "Use string interpolation: Console.WriteLine($\"7 x {i} = {7 * i}\");"
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "FizzBuzz",
                Description    = "Print numbers 1-20. For multiples of 3 print 'Fizz', multiples of 5 print 'Buzz', multiples of both print 'FizzBuzz'.",
                Concept        = "FizzBuzz is a classic problem that tests conditional logic. The key is checking the combined condition (divisible by both) first, before checking each individually. Use % to test divisibility.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        for (int i = 1; i <= 20; i++)\n        {\n            // FizzBuzz logic here\n        }\n    }\n}",
                ExpectedOutput = "1\n2\nFizz\n4\nBuzz\nFizz\n7\n8\nFizz\nBuzz\n11\nFizz\n13\n14\nFizzBuzz\n16\n17\nFizz\n19\nBuzz",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        for (int i = 1; i <= 20; i++)\n        {\n            if (i % 15 == 0)      Console.WriteLine(\"FizzBuzz\");\n            else if (i % 3 == 0)  Console.WriteLine(\"Fizz\");\n            else if (i % 5 == 0)  Console.WriteLine(\"Buzz\");\n            else                  Console.WriteLine(i);\n        }\n    }\n}",
                Hints          = new[]
                {
                    "Start with the most specific case — divisible by both 3 and 5.",
                    "A number divisible by both 3 and 5 is divisible by 15 (i % 15 == 0).",
                    "Order your if/else if checks: FizzBuzz first, then Fizz, then Buzz, then the number."
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "Temperature Converter",
                Description    = "Given a temperature in Celsius (c = 100), convert it to Fahrenheit using the formula F = C * 9/5 + 32 and print the result.",
                Concept        = "Arithmetic expressions follow standard operator precedence. When mixing integer and floating-point math in C#, at least one operand must be a double (or cast with (double)) to avoid integer division losing the decimal part.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        double c = 100;\n        // Convert to Fahrenheit and print\n    }\n}",
                ExpectedOutput = "212",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        double c = 100;\n        double f = c * 9.0 / 5.0 + 32;\n        Console.WriteLine(f);\n    }\n}",
                Hints          = new[]
                {
                    "The formula is F = C * 9/5 + 32.",
                    "Use 9.0 and 5.0 (or 9.0/5.0) to avoid integer division.",
                    "Store the result in a double and pass it to Console.WriteLine."
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "Count Vowels",
                Description    = "Count how many vowels (a, e, i, o, u) are in the string \"programming\" and print the count.",
                Concept        = "You can iterate over a string character by character with a foreach loop. The string.IndexOf() or a switch/if chain can check membership. Converting to lowercase first simplifies the comparison.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string s = \"programming\";\n        int count = 0;\n        // Count vowels and print count\n    }\n}",
                ExpectedOutput = "3",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string s = \"programming\";\n        int count = 0;\n        foreach (char c in s)\n            if (\"aeiou\".IndexOf(c) >= 0)\n                count++;\n        Console.WriteLine(count);\n    }\n}",
                Hints          = new[]
                {
                    "Loop over each character in s with foreach (char c in s).",
                    "Check if c is a vowel — one easy way: \"aeiou\".IndexOf(c) >= 0.",
                    "Increment count when the condition is true, then print count after the loop."
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "Swap Two Variables",
                Description    = "Swap the values of a = 10 and b = 20 without using a third variable, then print a and b.",
                Concept        = "C# supports tuple deconstruction, which lets you swap two variables in one line: (a, b) = (b, a). This is cleaner than the classic temp-variable approach and compiles to the same efficient code.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int a = 10, b = 20;\n        // Swap a and b without a temp variable\n        Console.WriteLine(a);\n        Console.WriteLine(b);\n    }\n}",
                ExpectedOutput = "20\n10",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int a = 10, b = 20;\n        (a, b) = (b, a);\n        Console.WriteLine(a);\n        Console.WriteLine(b);\n    }\n}",
                Hints          = new[]
                {
                    "C# 7+ supports tuple deconstruction — you can assign two variables at once.",
                    "Try: (a, b) = (b, a); — this swaps in a single statement.",
                    "You can also use arithmetic: a = a + b; b = a - b; a = a - b; — but tuples are cleaner."
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "Simple Calculator",
                Description    = "Given op = '+', a = 8, b = 3, use a switch statement to perform the operation and print the result.",
                Concept        = "A switch statement matches a value against multiple cases. It's cleaner than a long if/else chain when checking one variable against many constants. Don't forget the break in each case to prevent fall-through.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        char op = '+';\n        int a = 8, b = 3;\n        // Use switch to compute and print the result\n    }\n}",
                ExpectedOutput = "11",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        char op = '+';\n        int a = 8, b = 3;\n        switch (op)\n        {\n            case '+': Console.WriteLine(a + b); break;\n            case '-': Console.WriteLine(a - b); break;\n            case '*': Console.WriteLine(a * b); break;\n            case '/': Console.WriteLine(a / b); break;\n            default:  Console.WriteLine(\"Unknown op\"); break;\n        }\n    }\n}",
                Hints          = new[]
                {
                    "Use switch (op) { case '+': ... break; case '-': ... break; ... }",
                    "Each case should print the result of the corresponding arithmetic operation.",
                    "Add a default case to handle unknown operators."
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "Sum of Array",
                Description    = "Sum all numbers in the array {4, 7, 2, 9, 1} and print the total.",
                Concept        = "You can loop over an array with foreach or use LINQ's Sum() method. The manual approach builds intuition: start with a total of 0 and add each element. Arrays have a fixed Length property.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int[] nums = { 4, 7, 2, 9, 1 };\n        int total = 0;\n        // Add up all elements and print total\n    }\n}",
                ExpectedOutput = "23",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int[] nums = { 4, 7, 2, 9, 1 };\n        int total = 0;\n        foreach (int n in nums)\n            total += n;\n        Console.WriteLine(total);\n    }\n}",
                Hints          = new[]
                {
                    "Use foreach (int n in nums) to iterate over the array.",
                    "Inside the loop, add each element to total: total += n;",
                    "Print total after the loop."
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "String Contains",
                Description    = "Check if the string \"Visual Studio\" contains the word \"Studio\" and print True or False.",
                Concept        = "The string.Contains() method returns true if the specified substring is found anywhere in the string. It is case-sensitive by default. This is one of the most commonly used string methods in C#.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string s = \"Visual Studio\";\n        // Print True if s contains \"Studio\", else False\n    }\n}",
                ExpectedOutput = "True",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string s = \"Visual Studio\";\n        Console.WriteLine(s.Contains(\"Studio\"));\n    }\n}",
                Hints          = new[]
                {
                    "Strings have a built-in method for checking substrings.",
                    "Try s.Contains(\"Studio\") — it returns a bool.",
                    "Pass the result directly to Console.WriteLine to print True or False."
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "Countdown with While",
                Description    = "Use a while loop to print 10 down to 1, then print 'Go!'.",
                Concept        = "A while loop repeats as long as its condition is true. You control the loop variable manually: initialize it before the loop, check it in the condition, and update it inside the body. It's more flexible than a for loop when the number of iterations isn't fixed.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int i = 10;\n        // Count down and print each number, then print \"Go!\"\n    }\n}",
                ExpectedOutput = "10\n9\n8\n7\n6\n5\n4\n3\n2\n1\nGo!",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int i = 10;\n        while (i >= 1)\n        {\n            Console.WriteLine(i);\n            i--;\n        }\n        Console.WriteLine(\"Go!\");\n    }\n}",
                Hints          = new[]
                {
                    "Start with while (i >= 1) as the condition.",
                    "Print i inside the loop, then decrement it with i--.",
                    "After the loop ends, print \"Go!\"."
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "Average of Array",
                Description    = "Calculate the average of {10, 20, 30, 40, 50} and print it as a decimal.",
                Concept        = "To calculate an average, sum all elements and divide by the count. In C#, dividing two ints gives an int (integer division). Cast one operand to double before dividing to get a decimal result.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int[] nums = { 10, 20, 30, 40, 50 };\n        // Calculate and print the average\n    }\n}",
                ExpectedOutput = "30",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int[] nums = { 10, 20, 30, 40, 50 };\n        int sum = 0;\n        foreach (int n in nums) sum += n;\n        Console.WriteLine((double)sum / nums.Length);\n    }\n}",
                Hints          = new[]
                {
                    "Sum all elements first with a foreach loop.",
                    "Then divide by nums.Length to get the average.",
                    "Cast to double before dividing: (double)sum / nums.Length"
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "Nested Loops: Star Triangle",
                Description    = "Print a right-angled triangle of stars with 5 rows. Row 1 has 1 star, row 2 has 2, etc.",
                Concept        = "Nested loops let you generate 2D patterns. The outer loop controls the row, the inner loop controls how many characters to print on that row. string.Repeat-style output can also be done with new string('*', n).",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        // Print 5 rows of stars\n    }\n}",
                ExpectedOutput = "*\n**\n***\n****\n*****",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        for (int i = 1; i <= 5; i++)\n            Console.WriteLine(new string('*', i));\n    }\n}",
                Hints          = new[]
                {
                    "Loop from i = 1 to 5 in the outer loop.",
                    "For each row, print i stars. You can use a nested loop or new string('*', i).",
                    "new string('*', i) creates a string of i asterisks — clean one-liner."
                }
            },

            new Exercise
            {
                Level          = "Beginner",
                Title          = "Type Casting",
                Description    = "Declare a double d = 9.99, cast it to int, and print both the original and the casted value.",
                Concept        = "Explicit casting with (int) truncates the decimal part — it doesn't round, it just drops everything after the decimal point. Implicit conversion goes from smaller to larger types; explicit is needed from larger to smaller or when precision is lost.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        double d = 9.99;\n        // Cast to int and print both values\n    }\n}",
                ExpectedOutput = "9.99\n9",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        double d = 9.99;\n        int i = (int)d;\n        Console.WriteLine(d);\n        Console.WriteLine(i);\n    }\n}",
                Hints          = new[]
                {
                    "Use (int)d to explicitly cast the double to an integer.",
                    "Note that casting truncates, not rounds — 9.99 becomes 9.",
                    "Print d first (the original double), then the casted int."
                }
            },

            // ── INTERMEDIATE ─────────────────────────────────────────────────────

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "Fibonacci Sequence",
                Description    = "Print the first 10 numbers of the Fibonacci sequence (0, 1, 1, 2, 3, 5, ...).",
                Concept        = "The Fibonacci sequence starts with 0 and 1. Each subsequent number is the sum of the two before it. You can compute it iteratively by keeping track of the last two values and updating them in a loop.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        // Print the first 10 Fibonacci numbers\n    }\n}",
                ExpectedOutput = "0\n1\n1\n2\n3\n5\n8\n13\n21\n34",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int a = 0, b = 1;\n        for (int i = 0; i < 10; i++)\n        {\n            Console.WriteLine(a);\n            int next = a + b;\n            a = b;\n            b = next;\n        }\n    }\n}",
                Hints          = new[]
                {
                    "Keep two variables — let's call them a and b — initialized to 0 and 1.",
                    "Each iteration: print a, compute next = a + b, then shift: a = b, b = next.",
                    "Loop 10 times, printing a at the start of each iteration."
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "Prime Number Check",
                Description    = "Write a method IsPrime(int n) that returns true if n is prime. Test it with 17.",
                Concept        = "A prime number is only divisible by 1 and itself. To check, try dividing by every integer from 2 up to the square root of n. If none divide evenly, it's prime. Checking up to sqrt(n) is the key optimization.",
                StarterCode    = "using System;\nclass Program\n{\n    static bool IsPrime(int n)\n    {\n        // Return true if n is prime\n        return false;\n    }\n    static void Main()\n    {\n        Console.WriteLine(IsPrime(17));\n    }\n}",
                ExpectedOutput = "True",
                Solution       = "using System;\nclass Program\n{\n    static bool IsPrime(int n)\n    {\n        if (n < 2) return false;\n        for (int i = 2; i * i <= n; i++)\n            if (n % i == 0) return false;\n        return true;\n    }\n    static void Main()\n    {\n        Console.WriteLine(IsPrime(17));\n    }\n}",
                Hints          = new[]
                {
                    "Handle edge cases first: numbers less than 2 are not prime.",
                    "Loop from 2 up to — and including — the square root of n.",
                    "Inside the loop, if n % i == 0 then n is not prime — return false. If the loop finishes without finding a divisor, return true."
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "Sort an Array",
                Description    = "Sort the array {5, 2, 8, 1, 9, 3} in ascending order and print each element.",
                Concept        = "Array.Sort() is a built-in method that sorts an array in place using an efficient algorithm (typically IntroSort). After sorting, you can iterate with a foreach loop to print each element.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int[] arr = { 5, 2, 8, 1, 9, 3 };\n        // Sort and print each element\n    }\n}",
                ExpectedOutput = "1\n2\n3\n5\n8\n9",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        int[] arr = { 5, 2, 8, 1, 9, 3 };\n        Array.Sort(arr);\n        foreach (int n in arr)\n            Console.WriteLine(n);\n    }\n}",
                Hints          = new[]
                {
                    "C# has a built-in method to sort arrays — look in the Array class.",
                    "Array.Sort(arr) sorts the array in place (modifies arr directly).",
                    "After sorting, use a foreach loop to print each element."
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "Palindrome Check",
                Description    = "Check whether the string \"racecar\" is a palindrome and print True or False.",
                Concept        = "A palindrome reads the same forwards and backwards. The simplest check: reverse the string and compare it to the original. String comparison in C# is case-sensitive by default.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string s = \"racecar\";\n        // Print True if palindrome, False otherwise\n    }\n}",
                ExpectedOutput = "True",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string s = \"racecar\";\n        char[] chars = s.ToCharArray();\n        Array.Reverse(chars);\n        Console.WriteLine(s == new string(chars));\n    }\n}",
                Hints          = new[]
                {
                    "Reverse the string, then compare the reversed version to the original.",
                    "Convert to char array, use Array.Reverse(), then convert back to string.",
                    "Compare with == : Console.WriteLine(s == new string(reversed));"
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "Create a Class",
                Description    = "Create a Person class with Name (string) and Age (int) properties. Instantiate it and print both values.",
                Concept        = "Classes are blueprints for objects. Properties expose data with get/set accessors. The new keyword creates an instance. Object initializer syntax ({ Name = \"...\", Age = ... }) lets you set properties in one expression.",
                StarterCode    = "using System;\nclass Person\n{\n    // Add Name and Age properties\n}\nclass Program\n{\n    static void Main()\n    {\n        // Create a Person and print their Name and Age\n    }\n}",
                ExpectedOutput = "Alice\n30",
                Solution       = "using System;\nclass Person\n{\n    public string Name { get; set; }\n    public int    Age  { get; set; }\n}\nclass Program\n{\n    static void Main()\n    {\n        var p = new Person { Name = \"Alice\", Age = 30 };\n        Console.WriteLine(p.Name);\n        Console.WriteLine(p.Age);\n    }\n}",
                Hints          = new[]
                {
                    "Add two auto-properties to the Person class: public string Name { get; set; } and public int Age { get; set; }",
                    "Instantiate with: var p = new Person { Name = \"Alice\", Age = 30 };",
                    "Access properties with dot notation: p.Name and p.Age."
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "Filter with LINQ",
                Description    = "From the list {1..10}, use LINQ to filter out only the even numbers and print them.",
                Concept        = "LINQ (Language Integrated Query) provides a clean, declarative way to query collections. The Where() extension method filters elements based on a predicate lambda. You need 'using System.Linq' at the top.",
                StarterCode    = "using System;\nusing System.Collections.Generic;\nusing System.Linq;\nclass Program\n{\n    static void Main()\n    {\n        var nums = new List<int> { 1,2,3,4,5,6,7,8,9,10 };\n        // Filter even numbers using LINQ and print them\n    }\n}",
                ExpectedOutput = "2\n4\n6\n8\n10",
                Solution       = "using System;\nusing System.Collections.Generic;\nusing System.Linq;\nclass Program\n{\n    static void Main()\n    {\n        var nums = new List<int> { 1,2,3,4,5,6,7,8,9,10 };\n        var evens = nums.Where(n => n % 2 == 0);\n        foreach (int n in evens)\n            Console.WriteLine(n);\n    }\n}",
                Hints          = new[]
                {
                    "Use the Where() method on the list — it takes a lambda that returns bool.",
                    "The lambda looks like: n => n % 2 == 0",
                    "Store the result in a variable and foreach over it to print."
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "Word Frequency",
                Description    = "Count how many times each word appears in \"the cat sat on the mat the cat\" and print the results.",
                Concept        = "A Dictionary<string, int> maps keys to values. Split() breaks a string into words. For each word, check if it exists in the dictionary — if yes, increment the count; if no, add it with count 1. TryGetValue is efficient for this pattern.",
                StarterCode    = "using System;\nusing System.Collections.Generic;\nclass Program\n{\n    static void Main()\n    {\n        string s = \"the cat sat on the mat the cat\";\n        var freq = new Dictionary<string, int>();\n        // Count each word and print word: count\n    }\n}",
                ExpectedOutput = "the: 3\ncat: 2\nsat: 1\non: 1\nmat: 1",
                Solution       = "using System;\nusing System.Collections.Generic;\nclass Program\n{\n    static void Main()\n    {\n        string s = \"the cat sat on the mat the cat\";\n        var freq = new Dictionary<string, int>();\n        foreach (string word in s.Split(' '))\n        {\n            freq.TryGetValue(word, out int count);\n            freq[word] = count + 1;\n        }\n        foreach (var kv in freq)\n            Console.WriteLine($\"{kv.Key}: {kv.Value}\");\n    }\n}",
                Hints          = new[]
                {
                    "Split the string into words using s.Split(' ').",
                    "For each word, use freq.TryGetValue(word, out int count) — it sets count to 0 if not found.",
                    "Then set freq[word] = count + 1. Finally, loop over freq to print key/value pairs."
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "String Methods",
                Description    = "Given the string \" Hello, World! \", print it trimmed, uppercased, and then replace 'World' with 'C#'.",
                Concept        = "Strings in C# have many built-in methods. Trim() removes leading/trailing whitespace. ToUpper() returns an uppercase copy. Replace(old, new) substitutes substrings. All string methods return new strings — strings are immutable.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string s = \"  Hello, World!  \";\n        // 1. Print trimmed\n        // 2. Print trimmed and uppercased\n        // 3. Print with 'World' replaced by 'C#'\n    }\n}",
                ExpectedOutput = "Hello, World!\nHELLO, WORLD!\nHello, C#!",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string s = \"  Hello, World!  \";\n        string trimmed = s.Trim();\n        Console.WriteLine(trimmed);\n        Console.WriteLine(trimmed.ToUpper());\n        Console.WriteLine(trimmed.Replace(\"World\", \"C#\"));\n    }\n}",
                Hints          = new[]
                {
                    "Call s.Trim() first to remove whitespace, store the result.",
                    "Chain .ToUpper() on the trimmed string for the second line.",
                    "Use .Replace(\"World\", \"C#\") on the trimmed string for the third line."
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "Exception Handling",
                Description    = "Parse the string \"abc\" to an integer inside a try/catch block. Catch the FormatException and print 'Invalid number'.",
                Concept        = "try/catch blocks let you handle runtime errors gracefully. int.Parse() throws FormatException when the string is not a valid number. catch (FormatException ex) catches that specific error type — catching specific exceptions is better practice than catching all exceptions.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string input = \"abc\";\n        // Try to parse, catch FormatException\n    }\n}",
                ExpectedOutput = "Invalid number",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string input = \"abc\";\n        try\n        {\n            int n = int.Parse(input);\n            Console.WriteLine(n);\n        }\n        catch (FormatException)\n        {\n            Console.WriteLine(\"Invalid number\");\n        }\n    }\n}",
                Hints          = new[]
                {
                    "Wrap int.Parse(input) inside a try { } block.",
                    "Follow it with catch (FormatException) { } — this runs when parsing fails.",
                    "Print \"Invalid number\" inside the catch block."
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "Interface: IShape",
                Description    = "Define an IShape interface with a double Area() method. Implement it in a Rectangle class (width=5, height=3) and print the area.",
                Concept        = "Interfaces define contracts — any class implementing an interface must provide all its methods. This enables polymorphism: you can treat a Rectangle as an IShape. Properties and methods in interfaces are implicitly public and abstract.",
                StarterCode    = "using System;\ninterface IShape\n{\n    // Declare Area() method\n}\nclass Rectangle : IShape\n{\n    public double Width  { get; set; }\n    public double Height { get; set; }\n    // Implement Area()\n}\nclass Program\n{\n    static void Main()\n    {\n        IShape r = new Rectangle { Width = 5, Height = 3 };\n        Console.WriteLine(r.Area());\n    }\n}",
                ExpectedOutput = "15",
                Solution       = "using System;\ninterface IShape\n{\n    double Area();\n}\nclass Rectangle : IShape\n{\n    public double Width  { get; set; }\n    public double Height { get; set; }\n    public double Area() => Width * Height;\n}\nclass Program\n{\n    static void Main()\n    {\n        IShape r = new Rectangle { Width = 5, Height = 3 };\n        Console.WriteLine(r.Area());\n    }\n}",
                Hints          = new[]
                {
                    "Declare Area() in the interface: double Area();",
                    "In Rectangle, implement it: public double Area() => Width * Height;",
                    "The variable r is typed as IShape — this is polymorphism in action."
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "Anagram Check",
                Description    = "Check if \"listen\" and \"silent\" are anagrams of each other. Print True or False.",
                Concept        = "Two strings are anagrams if they contain the same characters in any order. The simplest approach: convert both to char arrays, sort them, and compare. LINQ also works: OrderBy(c => c) produces a sorted sequence.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string a = \"listen\";\n        string b = \"silent\";\n        // Print True if they are anagrams\n    }\n}",
                ExpectedOutput = "True",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string a = \"listen\";\n        string b = \"silent\";\n        char[] ca = a.ToCharArray();\n        char[] cb = b.ToCharArray();\n        Array.Sort(ca);\n        Array.Sort(cb);\n        Console.WriteLine(new string(ca) == new string(cb));\n    }\n}",
                Hints          = new[]
                {
                    "Convert both strings to char arrays, sort each array.",
                    "Convert the sorted arrays back to strings and compare with ==.",
                    "Also check that the lengths are equal first for efficiency (though Sort handles it implicitly)."
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "List Add and Remove",
                Description    = "Create a List<string> with 'Apple', 'Banana', 'Cherry'. Remove 'Banana' and print the remaining items.",
                Concept        = "List<T> is a dynamic array that grows as needed. Add() appends, Remove() removes the first matching element, and Count gives the current size. Unlike arrays, lists don't need a fixed size at creation.",
                StarterCode    = "using System;\nusing System.Collections.Generic;\nclass Program\n{\n    static void Main()\n    {\n        var fruits = new List<string> { \"Apple\", \"Banana\", \"Cherry\" };\n        // Remove \"Banana\" and print the remaining items\n    }\n}",
                ExpectedOutput = "Apple\nCherry",
                Solution       = "using System;\nusing System.Collections.Generic;\nclass Program\n{\n    static void Main()\n    {\n        var fruits = new List<string> { \"Apple\", \"Banana\", \"Cherry\" };\n        fruits.Remove(\"Banana\");\n        foreach (string f in fruits)\n            Console.WriteLine(f);\n    }\n}",
                Hints          = new[]
                {
                    "Call fruits.Remove(\"Banana\") to remove the first matching element.",
                    "Then iterate with foreach and print each remaining fruit.",
                    "Remove() returns a bool indicating whether the element was found and removed."
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "LINQ: Select and Transform",
                Description    = "Use LINQ to double every number in {1, 2, 3, 4, 5} and print the results.",
                Concept        = "LINQ's Select() method transforms (projects) each element using a lambda. It returns an IEnumerable<T> with the transformed values. Combined with foreach or ToList(), it's a concise way to apply a function to every element in a collection.",
                StarterCode    = "using System;\nusing System.Collections.Generic;\nusing System.Linq;\nclass Program\n{\n    static void Main()\n    {\n        var nums = new List<int> { 1, 2, 3, 4, 5 };\n        // Use LINQ Select to double each number and print\n    }\n}",
                ExpectedOutput = "2\n4\n6\n8\n10",
                Solution       = "using System;\nusing System.Collections.Generic;\nusing System.Linq;\nclass Program\n{\n    static void Main()\n    {\n        var nums = new List<int> { 1, 2, 3, 4, 5 };\n        var doubled = nums.Select(n => n * 2);\n        foreach (int n in doubled)\n            Console.WriteLine(n);\n    }\n}",
                Hints          = new[]
                {
                    "Use nums.Select(n => n * 2) to project each element.",
                    "Select returns IEnumerable<int> — iterate it with foreach.",
                    "You can chain directly: foreach (int n in nums.Select(n => n * 2)) ..."
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "Null Coalescing",
                Description    = "Given string name = null, use the null coalescing operator to print 'Guest' if name is null, otherwise print the name.",
                Concept        = "The ?? operator returns the left-hand value if it is not null, otherwise it returns the right-hand value. It's a concise replacement for if (x == null) { ... }. The ??= operator also exists to assign only when null.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string name = null;\n        // Print name if not null, otherwise \"Guest\"\n    }\n}",
                ExpectedOutput = "Guest",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string name = null;\n        Console.WriteLine(name ?? \"Guest\");\n    }\n}",
                Hints          = new[]
                {
                    "The ?? operator evaluates to the right side when the left side is null.",
                    "Try: Console.WriteLine(name ?? \"Guest\");",
                    "This is equivalent to: name != null ? name : \"Guest\""
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "Class Inheritance",
                Description    = "Create an Animal base class with a virtual Speak() method. Override it in a Dog class to print 'Woof!'. Instantiate Dog and call Speak().",
                Concept        = "Inheritance lets a derived class inherit members from a base class. The virtual keyword allows a method to be overridden in subclasses. override replaces the base implementation. This is a core pillar of OOP — polymorphism lets you call Speak() on an Animal reference that holds a Dog.",
                StarterCode    = "using System;\nclass Animal\n{\n    public virtual void Speak()\n    {\n        Console.WriteLine(\"...\");\n    }\n}\nclass Dog : Animal\n{\n    // Override Speak()\n}\nclass Program\n{\n    static void Main()\n    {\n        Animal a = new Dog();\n        a.Speak();\n    }\n}",
                ExpectedOutput = "Woof!",
                Solution       = "using System;\nclass Animal\n{\n    public virtual void Speak()\n    {\n        Console.WriteLine(\"...\");\n    }\n}\nclass Dog : Animal\n{\n    public override void Speak()\n    {\n        Console.WriteLine(\"Woof!\");\n    }\n}\nclass Program\n{\n    static void Main()\n    {\n        Animal a = new Dog();\n        a.Speak();\n    }\n}",
                Hints          = new[]
                {
                    "Add public override void Speak() inside the Dog class.",
                    "Inside Dog's Speak(), call Console.WriteLine(\"Woof!\").",
                    "The variable a is typed as Animal but holds a Dog — the runtime calls Dog's version."
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "Dictionary Lookup",
                Description    = "Create a Dictionary mapping country codes to names: {\"US\":\"United States\",\"UK\":\"United Kingdom\",\"DE\":\"Germany\"}. Look up \"UK\" and print its value.",
                Concept        = "Dictionary<TKey,TValue> provides O(1) average lookup by key using a hash table. Access by key with dict[key] throws KeyNotFoundException if missing. Use TryGetValue() for safe lookup when the key may not exist.",
                StarterCode    = "using System;\nusing System.Collections.Generic;\nclass Program\n{\n    static void Main()\n    {\n        var countries = new Dictionary<string, string>\n        {\n            { \"US\", \"United States\" },\n            { \"UK\", \"United Kingdom\" },\n            { \"DE\", \"Germany\" }\n        };\n        // Print the country name for key \"UK\"\n    }\n}",
                ExpectedOutput = "United Kingdom",
                Solution       = "using System;\nusing System.Collections.Generic;\nclass Program\n{\n    static void Main()\n    {\n        var countries = new Dictionary<string, string>\n        {\n            { \"US\", \"United States\" },\n            { \"UK\", \"United Kingdom\" },\n            { \"DE\", \"Germany\" }\n        };\n        Console.WriteLine(countries[\"UK\"]);\n    }\n}",
                Hints          = new[]
                {
                    "Access a dictionary value with square brackets: dict[key].",
                    "Try: Console.WriteLine(countries[\"UK\"]);",
                    "For safe lookup when the key might not exist, use countries.TryGetValue(\"UK\", out string val)."
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "Properties with Validation",
                Description    = "Create a Temperature class with a Celsius property that throws ArgumentOutOfRangeException if set below -273.15. Test it with a valid value of 25.",
                Concept        = "Properties can contain logic in their get and set accessors — they're not just simple field wrappers. The set accessor receives the incoming value via the implicit parameter 'value'. Throwing exceptions in setters enforces invariants (rules your object must always satisfy).",
                StarterCode    = "using System;\nclass Temperature\n{\n    private double _celsius;\n    public double Celsius\n    {\n        get => _celsius;\n        set\n        {\n            // Throw ArgumentOutOfRangeException if value < -273.15\n            _celsius = value;\n        }\n    }\n}\nclass Program\n{\n    static void Main()\n    {\n        var t = new Temperature();\n        t.Celsius = 25;\n        Console.WriteLine(t.Celsius);\n    }\n}",
                ExpectedOutput = "25",
                Solution       = "using System;\nclass Temperature\n{\n    private double _celsius;\n    public double Celsius\n    {\n        get => _celsius;\n        set\n        {\n            if (value < -273.15)\n                throw new ArgumentOutOfRangeException(nameof(value), \"Below absolute zero!\");\n            _celsius = value;\n        }\n    }\n}\nclass Program\n{\n    static void Main()\n    {\n        var t = new Temperature();\n        t.Celsius = 25;\n        Console.WriteLine(t.Celsius);\n    }\n}",
                Hints          = new[]
                {
                    "Inside the set accessor, check: if (value < -273.15) throw ...",
                    "Throw new ArgumentOutOfRangeException(nameof(value), \"message\");",
                    "Only assign _celsius = value; after the validation check passes."
                }
            },

            new Exercise
            {
                Level          = "Intermediate",
                Title          = "String Split and Join",
                Description    = "Split \"one,two,three,four\" by comma, reverse the array, then join it back with \" | \" and print.",
                Concept        = "string.Split(char) breaks a string into an array of substrings. Array.Reverse() reverses an array in place. string.Join(separator, array) combines an array back into a string with a delimiter between each element.",
                StarterCode    = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string s = \"one,two,three,four\";\n        // Split, reverse, join with \" | \" and print\n    }\n}",
                ExpectedOutput = "four | three | two | one",
                Solution       = "using System;\nclass Program\n{\n    static void Main()\n    {\n        string s = \"one,two,three,four\";\n        string[] parts = s.Split(',');\n        Array.Reverse(parts);\n        Console.WriteLine(string.Join(\" | \", parts));\n    }\n}",
                Hints          = new[]
                {
                    "Use s.Split(',') to split the string into a string array.",
                    "Call Array.Reverse(parts) to reverse the array in place.",
                    "Use string.Join(\" | \", parts) to rejoin the array into a single string."
                }
            },

            // ── ADVANCED ─────────────────────────────────────────────────────────

            new Exercise
            {
                Level          = "Advanced",
                Title          = "Recursive Factorial",
                Description    = "Implement Factorial(n) recursively and print 10! (3628800).",
                Concept        = "Recursion is when a method calls itself. Every recursive function needs a base case (where it stops) and a recursive case (where it calls itself with a smaller input). Factorial: n! = n * (n-1)! with base case 0! = 1.",
                StarterCode    = "using System;\nclass Program\n{\n    static long Factorial(int n)\n    {\n        // Implement recursively\n        return 0;\n    }\n    static void Main()\n    {\n        Console.WriteLine(Factorial(10));\n    }\n}",
                ExpectedOutput = "3628800",
                Solution       = "using System;\nclass Program\n{\n    static long Factorial(int n)\n    {\n        if (n <= 1) return 1;\n        return n * Factorial(n - 1);\n    }\n    static void Main()\n    {\n        Console.WriteLine(Factorial(10));\n    }\n}",
                Hints          = new[]
                {
                    "Define the base case first: Factorial(0) and Factorial(1) both equal 1.",
                    "For any other n, return n multiplied by Factorial(n - 1).",
                    "The recursive case is: return n * Factorial(n - 1);"
                }
            },

            new Exercise
            {
                Level          = "Advanced",
                Title          = "Generic Stack",
                Description    = "Implement a generic MyStack<T> class with Push, Pop, and Peek methods. Test with integers.",
                Concept        = "Generics let you write type-safe code that works with any type. MyStack<T> uses a List<T> internally. Push adds to the end, Pop removes and returns the last item, Peek returns the last item without removing it.",
                StarterCode    = "using System;\nusing System.Collections.Generic;\nclass MyStack<T>\n{\n    // Implement Push, Pop, Peek\n}\nclass Program\n{\n    static void Main()\n    {\n        var s = new MyStack<int>();\n        s.Push(1); s.Push(2); s.Push(3);\n        Console.WriteLine(s.Pop());   // 3\n        Console.WriteLine(s.Peek());  // 2\n        Console.WriteLine(s.Pop());   // 2\n    }\n}",
                ExpectedOutput = "3\n2\n2",
                Solution       = "using System;\nusing System.Collections.Generic;\nclass MyStack<T>\n{\n    private readonly List<T> _data = new List<T>();\n    public void Push(T item)  => _data.Add(item);\n    public T Pop()            { T top = _data[_data.Count - 1]; _data.RemoveAt(_data.Count - 1); return top; }\n    public T Peek()           => _data[_data.Count - 1];\n    public int Count          => _data.Count;\n}\nclass Program\n{\n    static void Main()\n    {\n        var s = new MyStack<int>();\n        s.Push(1); s.Push(2); s.Push(3);\n        Console.WriteLine(s.Pop());\n        Console.WriteLine(s.Peek());\n        Console.WriteLine(s.Pop());\n    }\n}",
                Hints          = new[]
                {
                    "Add a private List<T> field to store the elements.",
                    "Push: call _data.Add(item). Peek: return _data[_data.Count - 1].",
                    "Pop: save the last element, call _data.RemoveAt(_data.Count - 1), then return the saved element."
                }
            },

            new Exercise
            {
                Level          = "Advanced",
                Title          = "Bubble Sort",
                Description    = "Implement Bubble Sort manually (without Array.Sort) on {64, 34, 25, 12, 22, 11, 90}.",
                Concept        = "Bubble Sort repeatedly steps through the array comparing adjacent elements and swapping them if they are in the wrong order. After each pass, the largest unsorted element 'bubbles' to its correct position. It's O(n²) — slow but educational.",
                StarterCode    = "using System;\nclass Program\n{\n    static void BubbleSort(int[] arr)\n    {\n        // Implement bubble sort\n    }\n    static void Main()\n    {\n        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };\n        BubbleSort(arr);\n        Console.WriteLine(string.Join(\", \", arr));\n    }\n}",
                ExpectedOutput = "11, 12, 22, 25, 34, 64, 90",
                Solution       = "using System;\nclass Program\n{\n    static void BubbleSort(int[] arr)\n    {\n        int n = arr.Length;\n        for (int i = 0; i < n - 1; i++)\n            for (int j = 0; j < n - i - 1; j++)\n                if (arr[j] > arr[j + 1])\n                {\n                    int tmp = arr[j];\n                    arr[j] = arr[j + 1];\n                    arr[j + 1] = tmp;\n                }\n    }\n    static void Main()\n    {\n        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };\n        BubbleSort(arr);\n        Console.WriteLine(string.Join(\", \", arr));\n    }\n}",
                Hints          = new[]
                {
                    "Use two nested for loops. The outer loop runs n-1 times (passes), the inner compares adjacent pairs.",
                    "The inner loop only needs to go up to n - i - 1 because the last i elements are already sorted.",
                    "To swap arr[j] and arr[j+1], use a temporary variable: int tmp = arr[j]; arr[j] = arr[j+1]; arr[j+1] = tmp;"
                }
            },

            new Exercise
            {
                Level          = "Advanced",
                Title          = "Binary Search",
                Description    = "Implement Binary Search on a sorted array {1,3,5,7,9,11,13} and find the index of 7.",
                Concept        = "Binary Search works on sorted arrays by repeatedly halving the search range. Compare the target to the middle element: if equal, found; if smaller, search the left half; if larger, search the right half. O(log n) — very efficient.",
                StarterCode    = "using System;\nclass Program\n{\n    static int BinarySearch(int[] arr, int target)\n    {\n        // Return the index of target, or -1 if not found\n        return -1;\n    }\n    static void Main()\n    {\n        int[] arr = { 1, 3, 5, 7, 9, 11, 13 };\n        Console.WriteLine(BinarySearch(arr, 7));  // Expected: 3\n    }\n}",
                ExpectedOutput = "3",
                Solution       = "using System;\nclass Program\n{\n    static int BinarySearch(int[] arr, int target)\n    {\n        int lo = 0, hi = arr.Length - 1;\n        while (lo <= hi)\n        {\n            int mid = lo + (hi - lo) / 2;\n            if (arr[mid] == target) return mid;\n            if (arr[mid] < target)  lo = mid + 1;\n            else                    hi = mid - 1;\n        }\n        return -1;\n    }\n    static void Main()\n    {\n        int[] arr = { 1, 3, 5, 7, 9, 11, 13 };\n        Console.WriteLine(BinarySearch(arr, 7));\n    }\n}",
                Hints          = new[]
                {
                    "Track the search range with two variables: lo (low index) and hi (high index).",
                    "In each iteration, compute mid = lo + (hi - lo) / 2 and compare arr[mid] to target.",
                    "If arr[mid] < target, set lo = mid + 1. If arr[mid] > target, set hi = mid - 1. Loop until lo > hi, then return -1."
                }
            },

            new Exercise
            {
                Level          = "Advanced",
                Title          = "Observer Pattern",
                Description    = "Implement the Observer design pattern using C# events. A publisher fires an event, and a subscriber reacts.",
                Concept        = "The Observer pattern lets objects subscribe to events without tight coupling. In C#, events are built-in: declare an event EventHandler<T>, raise it with Invoke(), and subscribe with +=. This is the foundation of UI event systems.",
                StarterCode    = "using System;\nclass EventPublisher\n{\n    public event EventHandler<string> OnEvent;\n    public void Trigger(string msg) => OnEvent?.Invoke(this, msg);\n}\nclass Program\n{\n    static void Main()\n    {\n        var pub = new EventPublisher();\n        // Subscribe a handler lambda, then trigger the event\n    }\n}",
                ExpectedOutput = "Received: Hello Observer!",
                Solution       = "using System;\nclass EventPublisher\n{\n    public event EventHandler<string> OnEvent;\n    public void Trigger(string msg) => OnEvent?.Invoke(this, msg);\n}\nclass Program\n{\n    static void Main()\n    {\n        var pub = new EventPublisher();\n        pub.OnEvent += (sender, e) => Console.WriteLine(\"Received: \" + e);\n        pub.Trigger(\"Hello Observer!\");\n    }\n}",
                Hints          = new[]
                {
                    "Subscribe to pub.OnEvent using the += operator with a lambda.",
                    "The lambda signature for EventHandler<string> is: (sender, e) => { ... } where e is the string.",
                    "After subscribing, call pub.Trigger(\"Hello Observer!\") to fire the event."
                }
            },

            new Exercise
            {
                Level          = "Advanced",
                Title          = "Async / Await",
                Description    = "Write an async method DoubleAsync(int n) that waits 500ms then returns n*2. Await it in Main and print the result for n=21.",
                Concept        = "async/await makes asynchronous code readable. An async method returns Task or Task<T>. The await keyword suspends the method until the awaited task completes, without blocking the thread. Task.Delay() is the async equivalent of Thread.Sleep().",
                StarterCode    = "using System;\nusing System.Threading.Tasks;\nclass Program\n{\n    static async Task<int> DoubleAsync(int n)\n    {\n        // Wait 500ms, then return n * 2\n        return 0;\n    }\n    static async Task Main()\n    {\n        int result = await DoubleAsync(21);\n        Console.WriteLine(result);\n    }\n}",
                ExpectedOutput = "42",
                Solution       = "using System;\nusing System.Threading.Tasks;\nclass Program\n{\n    static async Task<int> DoubleAsync(int n)\n    {\n        await Task.Delay(500);\n        return n * 2;\n    }\n    static async Task Main()\n    {\n        int result = await DoubleAsync(21);\n        Console.WriteLine(result);\n    }\n}",
                Hints          = new[]
                {
                    "Inside DoubleAsync, use await Task.Delay(500) to pause for 500 milliseconds.",
                    "After the delay, return n * 2. The async keyword lets you use await inside the method.",
                    "The return type Task<int> means the method asynchronously produces an int."
                }
            },
            new Exercise
            {
                Level          = "Advanced",
                Title          = "Extension Methods",
                Description    = "Write an extension method IsPalindrome() on string. Use it to check \"racecar\" and print True.",
                Concept        = "Extension methods let you add methods to existing types without modifying them. They are static methods in a static class, with 'this TypeName paramName' as the first parameter. They appear as instance methods on the extended type.",
                StarterCode    = "using System;\nstatic class StringExtensions\n{\n    // Add IsPalindrome extension method here\n}\nclass Program\n{\n    static void Main()\n    {\n        Console.WriteLine(\"racecar\".IsPalindrome());\n    }\n}",
                ExpectedOutput = "True",
                Solution       = "using System;\nstatic class StringExtensions\n{\n    public static bool IsPalindrome(this string s)\n    {\n        char[] chars = s.ToCharArray();\n        Array.Reverse(chars);\n        return s == new string(chars);\n    }\n}\nclass Program\n{\n    static void Main()\n    {\n        Console.WriteLine(\"racecar\".IsPalindrome());\n    }\n}",
                Hints          = new[]
                {
                    "Declare: public static bool IsPalindrome(this string s) inside a static class.",
                    "The 'this string s' syntax is what makes it an extension method.",
                    "Reverse the char array and compare the resulting string to the original."
                }
            },

            new Exercise
            {
                Level          = "Advanced",
                Title          = "yield return Iterator",
                Description    = "Write a method EvenNumbers(int max) using yield return that produces even numbers from 0 to max. Print all evens up to 10.",
                Concept        = "yield return turns a method into an iterator — it produces values one at a time without building a list in memory. The method's return type must be IEnumerable<T>. Execution resumes after yield return on each next iteration, making it memory-efficient for large or infinite sequences.",
                StarterCode    = "using System;\nusing System.Collections.Generic;\nclass Program\n{\n    static IEnumerable<int> EvenNumbers(int max)\n    {\n        // Use yield return\n    }\n    static void Main()\n    {\n        foreach (int n in EvenNumbers(10))\n            Console.WriteLine(n);\n    }\n}",
                ExpectedOutput = "0\n2\n4\n6\n8\n10",
                Solution       = "using System;\nusing System.Collections.Generic;\nclass Program\n{\n    static IEnumerable<int> EvenNumbers(int max)\n    {\n        for (int i = 0; i <= max; i += 2)\n            yield return i;\n    }\n    static void Main()\n    {\n        foreach (int n in EvenNumbers(10))\n            Console.WriteLine(n);\n    }\n}",
                Hints          = new[]
                {
                    "Loop from 0 to max, stepping by 2 each time.",
                    "Inside the loop, use yield return i; instead of adding to a list.",
                    "The caller consumes values lazily via foreach — no list is created."
                }
            },

            new Exercise
            {
                Level          = "Advanced",
                Title          = "LINQ GroupBy",
                Description    = "Group the strings {\"cat\",\"car\",\"bar\",\"bat\",\"bin\"} by their first letter and print each group key and its members.",
                Concept        = "LINQ's GroupBy() partitions a sequence into groups, each identified by a key. Each group is an IGrouping<TKey, TElement> — it has a Key property and is itself enumerable. This is the LINQ equivalent of SQL GROUP BY.",
                StarterCode    = "using System;\nusing System.Collections.Generic;\nusing System.Linq;\nclass Program\n{\n    static void Main()\n    {\n        var words = new List<string> { \"cat\", \"car\", \"bar\", \"bat\", \"bin\" };\n        // Group by first letter and print each group\n    }\n}",
                ExpectedOutput = "c: cat, car\nb: bar, bat, bin",
                Solution       = "using System;\nusing System.Collections.Generic;\nusing System.Linq;\nclass Program\n{\n    static void Main()\n    {\n        var words = new List<string> { \"cat\", \"car\", \"bar\", \"bat\", \"bin\" };\n        var groups = words.GroupBy(w => w[0]);\n        foreach (var g in groups)\n            Console.WriteLine($\"{g.Key}: {string.Join(\", \", g)}\");\n    }\n}",
                Hints          = new[]
                {
                    "Use words.GroupBy(w => w[0]) to group by the first character.",
                    "Each group g has a Key (the letter) and is itself an IEnumerable<string>.",
                    "Use string.Join(\", \", g) to format the group members on one line."
                }
            },

            new Exercise
            {
                Level          = "Advanced",
                Title          = "Func and Action Delegates",
                Description    = "Write a method Apply(int[] arr, Func<int,int> fn) that returns a new array with fn applied to each element. Use it to square {1,2,3,4,5} and print the results.",
                Concept        = "Func<TIn,TOut> is a built-in delegate type for functions that take an input and return a value. Passing functions as parameters (higher-order functions) enables reusable, flexible code. This is the foundation of functional programming in C#.",
                StarterCode    = "using System;\nclass Program\n{\n    static int[] Apply(int[] arr, Func<int, int> fn)\n    {\n        // Apply fn to each element and return a new array\n        return null;\n    }\n    static void Main()\n    {\n        int[] result = Apply(new[] { 1, 2, 3, 4, 5 }, n => n * n);\n        foreach (int n in result)\n            Console.WriteLine(n);\n    }\n}",
                ExpectedOutput = "1\n4\n9\n16\n25",
                Solution       = "using System;\nclass Program\n{\n    static int[] Apply(int[] arr, Func<int, int> fn)\n    {\n        int[] result = new int[arr.Length];\n        for (int i = 0; i < arr.Length; i++)\n            result[i] = fn(arr[i]);\n        return result;\n    }\n    static void Main()\n    {\n        int[] result = Apply(new[] { 1, 2, 3, 4, 5 }, n => n * n);\n        foreach (int n in result)\n            Console.WriteLine(n);\n    }\n}",
                Hints          = new[]
                {
                    "Create a result array of the same length as arr.",
                    "Loop through arr and assign result[i] = fn(arr[i]);",
                    "fn is called like a regular method — fn(value) returns the transformed value."
                }
            },

            new Exercise
            {
                Level          = "Advanced",
                Title          = "Enum State Machine",
                Description    = "Model a traffic light with an enum (Red, Yellow, Green). Write a Next() method that cycles Red→Green→Yellow→Red. Start at Red, call Next() twice, and print each state.",
                Concept        = "Enums define a named set of constant integer values, making code more readable than raw numbers. A switch on an enum value is exhaustive and clear. State machines map well to enums — each case defines a transition to the next state.",
                StarterCode    = "using System;\nenum TrafficLight { Red, Green, Yellow }\nclass Program\n{\n    static TrafficLight Next(TrafficLight current)\n    {\n        // Return the next state\n        return current;\n    }\n    static void Main()\n    {\n        var light = TrafficLight.Red;\n        Console.WriteLine(light);\n        light = Next(light);\n        Console.WriteLine(light);\n        light = Next(light);\n        Console.WriteLine(light);\n    }\n}",
                ExpectedOutput = "Red\nGreen\nYellow",
                Solution       = "using System;\nenum TrafficLight { Red, Green, Yellow }\nclass Program\n{\n    static TrafficLight Next(TrafficLight current)\n    {\n        switch (current)\n        {\n            case TrafficLight.Red:    return TrafficLight.Green;\n            case TrafficLight.Green:  return TrafficLight.Yellow;\n            case TrafficLight.Yellow: return TrafficLight.Red;\n            default: return TrafficLight.Red;\n        }\n    }\n    static void Main()\n    {\n        var light = TrafficLight.Red;\n        Console.WriteLine(light);\n        light = Next(light);\n        Console.WriteLine(light);\n        light = Next(light);\n        Console.WriteLine(light);\n    }\n}",
                Hints          = new[]
                {
                    "Use a switch statement on the current enum value.",
                    "Each case returns the next state: Red→Green, Green→Yellow, Yellow→Red.",
                    "Console.WriteLine on an enum prints its name (e.g. \"Red\") automatically."
                }
            },

            new Exercise
            {
                Level          = "Advanced",
                Title          = "Lazy Initialization",
                Description    = "Use Lazy<T> to defer creation of an expensive object (simulate with a class that prints 'Created!' in its constructor). Show that the object is only created when first accessed.",
                Concept        = "Lazy<T> delays construction of an object until its Value property is first accessed. This is useful for expensive resources you might not need. The constructor runs at most once — subsequent access to Value returns the cached instance.",
                StarterCode    = "using System;\nclass HeavyObject\n{\n    public HeavyObject() => Console.WriteLine(\"Created!\");\n    public void Use()    => Console.WriteLine(\"Used!\");\n}\nclass Program\n{\n    static void Main()\n    {\n        var lazy = new Lazy<HeavyObject>(() => new HeavyObject());\n        Console.WriteLine(\"Before access\");\n        // Access the lazy value here\n        Console.WriteLine(\"After access\");\n    }\n}",
                ExpectedOutput = "Before access\nCreated!\nUsed!\nAfter access",
                Solution       = "using System;\nclass HeavyObject\n{\n    public HeavyObject() => Console.WriteLine(\"Created!\");\n    public void Use()    => Console.WriteLine(\"Used!\");\n}\nclass Program\n{\n    static void Main()\n    {\n        var lazy = new Lazy<HeavyObject>(() => new HeavyObject());\n        Console.WriteLine(\"Before access\");\n        lazy.Value.Use();\n        Console.WriteLine(\"After access\");\n    }\n}",
                Hints          = new[]
                {
                    "Access the wrapped object via lazy.Value — this triggers construction the first time.",
                    "Call lazy.Value.Use() to both trigger creation and call the method.",
                    "Notice 'Created!' only appears when lazy.Value is first accessed, not at declaration."
                }
            },

            new Exercise
            {
                Level          = "Advanced",
                Title          = "Pattern Matching with is",
                Description    = "Create a list of objects containing an int (42), a string (\"hello\"), and a double (3.14). Use pattern matching to print each value prefixed with its type.",
                Concept        = "C# pattern matching with 'is' (and switch expressions) lets you test an object's type and extract its value in one step. 'if (obj is int n)' both checks the type and binds the value to n — cleaner than a cast after an is-check.",
                StarterCode    = "using System;\nusing System.Collections.Generic;\nclass Program\n{\n    static void Main()\n    {\n        var items = new List<object> { 42, \"hello\", 3.14 };\n        foreach (var item in items)\n        {\n            // Use pattern matching to print type and value\n        }\n    }\n}",
                ExpectedOutput = "int: 42\nstring: hello\ndouble: 3.14",
                Solution       = "using System;\nusing System.Collections.Generic;\nclass Program\n{\n    static void Main()\n    {\n        var items = new List<object> { 42, \"hello\", 3.14 };\n        foreach (var item in items)\n        {\n            if      (item is int    i) Console.WriteLine($\"int: {i}\");\n            else if (item is string s) Console.WriteLine($\"string: {s}\");\n            else if (item is double d) Console.WriteLine($\"double: {d}\");\n        }\n    }\n}",
                Hints          = new[]
                {
                    "Use if (item is int i) — this checks the type and binds the value to i in one step.",
                    "Chain with else if for string and double.",
                    "Use string interpolation to format the output: $\"int: {i}\""
                }
            },

            new Exercise
            {
                Level          = "Advanced",
                Title          = "Immutable Record Type",
                Description    = "Define a record Point(int X, int Y). Create a point at (3, 4), then use 'with' to create a copy with Y = 10. Print both points.",
                Concept        = "Records (C# 9+) are immutable reference types with value-based equality. The 'with' expression creates a copy with specified properties changed — no mutation needed. This is the foundation of functional-style, immutable data modeling in modern C#.",
                StarterCode    = "using System;\nrecord Point(int X, int Y);\nclass Program\n{\n    static void Main()\n    {\n        var p1 = new Point(3, 4);\n        // Create p2 as a copy of p1 but with Y = 10\n        Console.WriteLine(p1);\n        Console.WriteLine(p2);\n    }\n}",
                ExpectedOutput = "Point { X = 3, Y = 4 }\nPoint { X = 3, Y = 10 }",
                Solution       = "using System;\nrecord Point(int X, int Y);\nclass Program\n{\n    static void Main()\n    {\n        var p1 = new Point(3, 4);\n        var p2 = p1 with { Y = 10 };\n        Console.WriteLine(p1);\n        Console.WriteLine(p2);\n    }\n}",
                Hints          = new[]
                {
                    "Use the 'with' expression: var p2 = p1 with { Y = 10 };",
                    "Records auto-generate a ToString() that prints all properties.",
                    "p1 is unchanged — records are immutable, 'with' makes a new copy."
                }
            },

            new Exercise
            {
                Level          = "Advanced",
                Title          = "Task.WhenAll Parallel Async",
                Description    = "Create two async tasks that each wait 300ms and return a string. Run them in parallel using Task.WhenAll and print both results.",
                Concept        = "Task.WhenAll() takes multiple tasks and returns a task that completes when all input tasks complete. Unlike awaiting them sequentially (500ms total), WhenAll runs them concurrently (300ms total). This is key to efficient I/O-bound async code.",
                StarterCode    = "using System;\nusing System.Threading.Tasks;\nclass Program\n{\n    static async Task<string> FetchA() { await Task.Delay(300); return \"Result A\"; }\n    static async Task<string> FetchB() { await Task.Delay(300); return \"Result B\"; }\n    static async Task Main()\n    {\n        // Run both in parallel and print results\n    }\n}",
                ExpectedOutput = "Result A\nResult B",
                Solution       = "using System;\nusing System.Threading.Tasks;\nclass Program\n{\n    static async Task<string> FetchA() { await Task.Delay(300); return \"Result A\"; }\n    static async Task<string> FetchB() { await Task.Delay(300); return \"Result B\"; }\n    static async Task Main()\n    {\n        string[] results = await Task.WhenAll(FetchA(), FetchB());\n        foreach (string r in results)\n            Console.WriteLine(r);\n    }\n}",
                Hints          = new[]
                {
                    "Call FetchA() and FetchB() without awaiting them first — this starts both tasks.",
                    "Pass both tasks to Task.WhenAll(...) and await the result.",
                    "Task.WhenAll returns Task<string[]> — all results in order."
                }
            },

            new Exercise
            {
                Level          = "Advanced",
                Title          = "Custom Comparer with IComparer",
                Description    = "Sort a list of strings {\"banana\",\"apple\",\"kiwi\",\"fig\"} by string length using a custom IComparer<string>. Print sorted results.",
                Concept        = "IComparer<T> defines a comparison strategy. Implement its Compare(x, y) method to return negative (x before y), zero (equal), or positive (y before x). Pass it to List<T>.Sort() to override the default sort order.",
                StarterCode    = "using System;\nusing System.Collections.Generic;\nclass LengthComparer : IComparer<string>\n{\n    // Implement Compare\n}\nclass Program\n{\n    static void Main()\n    {\n        var words = new List<string> { \"banana\", \"apple\", \"kiwi\", \"fig\" };\n        words.Sort(new LengthComparer());\n        foreach (string w in words)\n            Console.WriteLine(w);\n    }\n}",
                ExpectedOutput = "fig\nkiwi\napple\nbanana",
                Solution       = "using System;\nusing System.Collections.Generic;\nclass LengthComparer : IComparer<string>\n{\n    public int Compare(string x, string y) => x.Length.CompareTo(y.Length);\n}\nclass Program\n{\n    static void Main()\n    {\n        var words = new List<string> { \"banana\", \"apple\", \"kiwi\", \"fig\" };\n        words.Sort(new LengthComparer());\n        foreach (string w in words)\n            Console.WriteLine(w);\n    }\n}",
                Hints          = new[]
                {
                    "Implement: public int Compare(string x, string y) inside LengthComparer.",
                    "Compare lengths: return x.Length.CompareTo(y.Length);",
                    "Pass new LengthComparer() to words.Sort() as the second argument."
                }
            },
        };
    }
}

<h1>Handbook on Programming in C#</h1>

**For the use and help in C#**

Kayden Weatherford

<!-- This is a comment (which will not be displayed in the live file);
replace all "???" with your own text. -->




___





<h1>Table of Contents</h1>

- [1. Compiling and Running](#1-compiling-and-running)
- [2. Data Types](#2-data-types)
- [3. Console I/O](#3-console-io)
- [4. Arithmetic Operations](#4-arithmetic-operations)
- [5. Assignment Operations](#5-assignment-operations)
- [6. Comments](#6-comments)
- [7. Decision Structures](#7-decision-structures)
- [8. Conditional Operators](#8-conditional-operators)
- [9. Logic Operators](#9-logic-operators)
- [10. Advanced Decision Structures](#10-advanced-decision-structures)
- [11. String Methods](#11-string-methods)
- [12. Random Generation](#12-random-generation)
- [13. Looping Structures](#13-looping-structures)
- [14. Functions/Methods](#14-functionsmethods)
- [15. Elementary Data Structures](#15-elementary-data-structures)
  - [15.1 Arrays/Lists](#151-arrayslists)
  - [15.2 Matrices](#152-matrices)
- [References](#references)

<!-- 
- [16. Major Keywords](#16-major-keywords)
- [17. Error Handling](#17-error-handling)
- [18. Working with Files](#18-working-with-files)
- [19. Major Language Features](#19-major-language-features)
  - [19.1 Classes](#191-classes)
  - [19.2 Inheritance](#192-inheritance)
  - [19.3 Generic Typing (Templates)](#193-generic-typing-templates)
  - [19.4 Pointers](#194-pointers)
- [20. Importing Local Libraries](#20-importing-local-libraries)
- [21. Working with Time](#21-working-with-time)
- [22. Importing Libaries from Package managers](#22-importing-libaries-from-package-managers)
- [23. Bitwise Operators](#23-bitwise-operators)
- [24. Common Data Structures](#24-common-data-structures)
- [25. Advanced Language Features](#25-advanced-language-features)
-->




___





# 1. Compiling and Running

For C#, you must:
- Write code in a `.cs` file.
- Compile with the C# compiler (`csc Program.cs`) to produce an `.exe` file.
- Run the program with `Program.exe` (on Windows) or `dotnet run` if using the .NET SDK.
- CAN ONLY HAVE *__1__* ```private static void Main()``` entrypoint!!!

___

# 2. Data Types

Common C# data types:

```csharp
int age = 21;           // integer numbers  | Any number, NO DECIMALS!
double price = 19.99;   // decimal numbers  | Can support regular numbers
char letter = 'A';      // single character | Cannot be multiple!
string name = "KiKi";   // text
bool isOn = true;       // true/false       | 1 = True , 0 = False
```
Other examples:

```csharp 
float Money = 2.00      // decimal number   | different precision for decimals. 
long, short, byte       // different ranges | Can be any var type
```
# 3. Console I/O

Output (writing to console):
```csharp
Console.WriteLine("Hello, world!"); // with newline
Console.Write("Enter your name: "); // without newline
```

Input (reading from console):
```csharp
string input = Console.ReadLine();                  // always returns string
int number = Convert.ToInt32(Console.ReadLine());   // cast input to int
decimal money = Convert.ToDecimal(Console.ReadLine()); // read money/decimal
bool flag = Convert.ToBoolean(Console.ReadLine());  // "true"/"false" → bool
```


# 4. Arithmetic Operations

C# supports basic arithmetic:
```csharp
int a = 10, b = 3;

int sum = a + b;   // addition (13)
int diff = a - b;  // subtraction (7)
int prod = a * b;  // multiplication (30)
int div = a / b;   // division (3, integer division)
int mod = a % b;   // modulus/remainder (1)

double result = (double)a / b; // 3.333..., cast for float division
```

Operators:
```csharp
+ addition

- subtraction

* multiplication

/ division

% modulus
```
___





# 5. Assignment Operations
- Assignment uses `=` to store a value in a variable:
```csharp
int x = 10;          // assign 10 to x
x = x + 5;           // add 5 to x (x is now 15)
x += 3;              // shorthand for x = x + 3 (x is now 18)
x -= 2;              // x = x - 2 (x is now 16)
x *= 2;              // x = x * 2 (x is now 20)
x /= 4;              // x = x / 4 (x is now 2)
x %= 3;              // x = x % 3 (x is now 1)
```




___




# 6. Comments

Comments in C# are used to leave notes, explanations, or temporarily disable code.  
They are ignored by the compiler and do not affect the program’s execution.

There are **three main types of comments** in C#:

### 1. **Single-Line Comments**
Use `//` to write a comment on a single line.  
Everything after `//` on that line is ignored.

```csharp
// This is a single-line comment
int x = 10; // You can also place it after a statement
```

### 2. Multi-Line Comments

Use /* ... */ to comment across multiple lines.
This is useful for longer notes or disabling sections of code.
```csharp
/*
This is a multi-line comment.
It can span multiple lines.
*/
int y = 20;
```
### 3. XML Documentation Comments

Use /// to create XML-style comments above classes, methods, or properties.
These can be processed by documentation tools like Visual Studio’s IntelliSense.

```csharp
/// <summary>
/// Adds two numbers together.
/// </summary>
/// <param name="a">The first number.</param>
/// <param name="b">The second number.</param>
/// <returns>The sum of a and b.</returns>
int Add(int a, int b)
{
    return a + b;
}
```



___





# 7. Decision Structures

Decision structures in C# allow your program to make choices and execute certain code blocks based on conditions.  
They are essential for controlling the flow of execution.

There are **four main types of decision structures**:

### 1. **`if` Statement**
Executes a block of code **only if** a specified condition is true.

```csharp
int score = 90;

if (score >= 70)
{
    Console.WriteLine("You passed!");
}
```

### 2. **`if...else` Statement**

Executes one block of code if the condition is true,
and another block if it’s false.
```csharp
int score = 65;

if (score >= 70)
{
    Console.WriteLine("You passed!");
}
else
{
    Console.WriteLine("You failed!");
}

```

### 3. **`if...else` `if...else` Ladder**
Used to check multiple conditions in sequence.
```csharp
int score = 85;

if (score >= 90)
{
    Console.WriteLine("Grade: A");
}
else if (score >= 80)
{
    Console.WriteLine("Grade: B");
}
else if (score >= 70)
{
    Console.WriteLine("Grade: C");
}
else
{
    Console.WriteLine("Grade: F");
}
```

### 4. **`switch` Statement**

Simplifies checking a variable against multiple possible values.
Each case must end with a break, unless using return or other control statements.
```csharp
char grade = 'B';

switch (grade)
{
    case 'A':
        Console.WriteLine("Excellent!");
        break;
    case 'B':
        Console.WriteLine("Good job!");
        break;
    case 'C':
        Console.WriteLine("You passed.");
        break;
    default:
        Console.WriteLine("Invalid grade.");
        break;
}
```

___


# 8. Conditional Operators

Conditional operators in C# are **used to make decisions within expressions**, providing a more concise alternative to traditional `if` statements.

---

### 1. **The Ternary Operator (`?:`)**

The **ternary conditional operator** evaluates a condition and returns one of two values depending on whether the condition is `true` or `false`.

**Syntax:**
```csharp
condition ? value_if_true : value_if_false;
```

**Example:**
```csharp
int score = 85;
string result = (score >= 70) ? "Passed" : "Failed";
Console.WriteLine(result); 

// Output: Passed
```
### **2. The Null-Coalescing Operator (`??`)**
The null-coalescing operator returns the left-hand operand if it is not null; otherwise, it returns the right-hand operand.

**Syntax:**
```csharp
variable ?? defaultValue;
```
___





# 9. Logic Operators

???





___





# 10. Advanced Decision Structures

???





___





# 11. String Methods

???





___





# 12. Random Generation

???





___





# 13. Looping Structures

???





___





# 14. Functions/Methods

???





___





# 15. Elementary Data Structures

???





## 15.1 Arrays/Lists

???






## 15.2 Matrices

???





___





<!-- 
EVERYTHING BELOW IS OPTIONAL; 
UNCOMMENT BY REMOVING THE ARROW TAGS SURROUNDING
(i.e., delete the "< !--" and "-- >" tags)

CHANGE THE SECTION NUMBERS AS DESIRED
-->

<!-- # 16. Major Keywords

???





___ -->





<!-- # 17. Error Handling

???





___ -->





<!-- # 18. Working with Files

???





___ -->





<!-- # 19. Major Language Features

???







## 19.1 Classes

???





## 19.2 Inheritance

???





## 19.3 Generic Typing (Templates)

???





## 19.4 Pointers

???





___ -->





<!-- # 20. Importing Local Libraries

???





___ -->





<!-- # 21. Working with Time

???





___ -->





<!-- # 22. Importing Libaries from Package managers

???





___ -->





<!-- # 23. Bitwise Operators

???





___ -->





<!-- # 24. Common Data Structures

???





___ -->





<!-- # 25. Advanced Language Features

???





___ -->





# References

* [Markdown Cheatsheet](https://gist.github.com/jonschlinkert/5854601)
* [description](http://example.com)

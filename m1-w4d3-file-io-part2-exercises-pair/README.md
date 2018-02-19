# File I/O Part 2 Exercises (Pair)

## FindAndReplace

Write a program that can be used to open a file and find and replace all occurrences of one word with another word.  

The program should ask the user for 4 inputs

* The search phrase
* The replace phrase 
* The source file path.  *This must be an existing file.  If the user enters an invalid source file path, the program will indicate this to the user and go again.*
* The destination file path.  *The program will **create a copy** of the source file with the requested replacements at this location.  If a file or directory already exists at this location, the program will print an error and exit.*

Use `alices_adventures_in_wonderland.txt` for test input.
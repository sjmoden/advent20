# advent20


## Overview

Repo to take part in https://adventofcode.com.

Each Day has been split into its own project and there is some shared code in the tools folder. I have decided not to refactor code from previous days to work with future days. This would give a better end result, but is hell to keep up to date during the month without breaking everything... I made that mistake last year. This does however leave duplicate code throughout the days.


## SetUp
To avoid having to download the inputs from the website, I am getting the code to retrieve the data instead. As part of running this you will require the cookie details from being logged into advent of code. You can retrieve them here: https://github.com/wimglenn/advent-of-code-wim/issues/1

When running a day, you will  be prompted for this code. It will save it locally so you will not have to reenter it. You can set this location in the constant CS file: .\src\AdventCode20\Tools\Constants.cs

DO NOT COMMIT THE COOKIE TO THE REPO!!

## Tests

There is one integration test over the reading of input file. To ensure this passes, a cookies file must exist with the correct cookie in location set in .\src\AdventCode20\Tools\Constants.cs
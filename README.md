![year](https://img.shields.io/badge/2022-lightgrey?style=plastic)
![creators](https://img.shields.io/badge/Johnny,%20Jamie-yellow?style=plastic)
![dotnet](https://img.shields.io/badge/.NET-purple?style=plastic&logo=.NET)

# **Community Library**
In a world where Blockbusters are going broke to extinction, the new Community Library app is set
to revive the business. Upon launching, users will be greeted with an eye-catching main menu. This
menu then branches off to staff and members sub-menus with their respective functions.

Staff can register and remove members, add and remove movies or copies of movies, display a member’s
contact, and all members renting a specific movie.

Once registered, members can log in with their full name and a PIN. Members can view information
on all movies or a specific movie, borrow and return DVDs, list movies they are currently borrowing,
and display the top 3 most popular movies.

The app was developed with efficiency in mind, using a range of analysed algorithms behind the
scenes to ensure speedy and smooth functionality.

Build and run the project in Visual Studio.

# **Theoretical Analyses**
**IsValidContactNumber Algorithm**

<img src="/img/isvalidcontactnumber.png" alt="isvalidcontactnumber algo" width="400">

**IsValidPin Algorithm**

<img src="/img/isvalidpin.png" alt="isvalidpin algo" width="400">

**Add Algorithm**

<img src="/img/add.png" alt="add algo" width="400">

**Delete Algorithm**

<img src="/img/delete.png" alt="delete algo" width="400">

**Search Algorithm**

<img src="/img/search.png" alt="search algo" width="400">

# **Empirical Analysis**
**Pseudocode Design**

<img src="/img/top-three-pseudocode.png" alt="top three pseudocode" width="600">

**STEP 1: Experiment Purpose**

- To check the accuracy of a theoretical assertion on our algorithm’s worst-case efficiency. We have theorised the worst-case efficiency class to be O(n) as the algorithm contains a single loop that iterates over all elements in the input array A once.

**STEP 2: Efficiency Metric**

- The number of times the algorithm’s basic operation is executed in the worst-case scenario.

**STEP 3: Characteristics of Input Samples**

- **PROBLEM SIZE** of each sample is the length n of the array A. As we are only interested in the worst-case efficiency in this experiment, all input samples of A will be designed to trigger all basic operations. This means the NoBorrowings property for each movie will be set to ”0” so none qualify for the top 3 and therefore triggering all instances of the basic operation.
- **BASIC OPERATIONS** are the key comparisons, which occurs 3 times within the loop:</br> <img src="/img/basic-ops.png" alt="basic operations" width="100">

**STEP 4: Implementation in C#**

- **IMPLEMENTATION OF TOP THREE ALGORITHM**</br> <img src="/img/top-three.png" alt="implementation of top three algo" width="600">
- **IMPLEMENTATION OF EMPIRICAL ANALYSIS METHOD**</br> <img src="/img/empirical.png" alt="implementation of empirical analysis method" width="600">

**STEP 5: Input Samples**

- <img src="/img/samples.png" alt="input samples" width="600">

**STEP 6: Input Results**

- <img src="/img/results.png" alt="input results" width="600">
- Each result generated matched what was expected. Results were expected to be 3x the input size n in the worst-case, as there are 3 instances of the basic operation per iteration across all elements in A.

**STEP 7: Analysis**

- <img src="/img/analysis.png" alt="analysis" width="600">

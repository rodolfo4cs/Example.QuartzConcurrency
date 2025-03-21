# Example.QuartzConcurrency

---
This is a simple example of a .net framwork 4.6 program to show concurrent jobs in Quartz 3.0.7
---
Usage:
- By default
  - the program will run two jobs that takes 2 minutes total to run, but are scheduled to run every minute.
  - the job at **JobWithConcurrency.cs** will start a new execution every minute, like scheduled, ignoring if the previous execution has finished or not.
  - the job at **JobWithoutConcurrency.cs** will start a new execution every minute, like scheduled, but only once the previous one has finished. In this example, will run every two minutes.

The following is an example of the default output of the running jobs.

![image](https://github.com/user-attachments/assets/430c16f7-8bc5-4b08-88b6-07b4f8f6e169)

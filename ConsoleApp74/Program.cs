using System;

namespace GitCommitHistoryExample
{
    class GitCommitHistory
    {
        private GitCommitNode head = null;
        private GitCommitNode tail = null;
        private int totalCommits = 0;

        public void AddCommit(string commitMessage)
        {
            GitCommitNode newCommit = new GitCommitNode(commitMessage);

            if (head == null)
            {
                head = newCommit;
                tail = newCommit;
            }
            else
            {
                tail.next = newCommit;
                tail = newCommit;
            }

            totalCommits++;
        }

        public void PrintCommitLog()
        {
            GitCommitNode current = head;
            while (current != null)
            {
                Console.WriteLine(current.message);
                current = current.next;
            }
        }

        public void RevertToCommit(int commitIndex)
        {
            if (commitIndex < 0 || commitIndex >= totalCommits)
            {
                Console.WriteLine("Invalid commit index.");
                return;
            }

            GitCommitNode current = head;
            int currentIndex = 0;
            while (currentIndex < commitIndex)
            {
                current = current.next;
                currentIndex++;
            }

            Console.WriteLine($"Reverted to commit: {current.message}");
            // Implement logic to revert the codebase to the specified commit
        }
    }

    class GitCommitNode
    {
        public string message;
        public GitCommitNode next;

        public GitCommitNode(string m)
        {
            message = m;
            next = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GitCommitHistory commitHistory = new GitCommitHistory();

            commitHistory.AddCommit("Initial commit");
            commitHistory.AddCommit("Implement feature A");
            commitHistory.AddCommit("Fix bug in feature B");
            commitHistory.AddCommit("Refactor code structure");

            Console.WriteLine("Commit Log:");
            commitHistory.PrintCommitLog();

            Console.WriteLine("\nReverting to 2nd commit...");
            commitHistory.RevertToCommit(1);
        }
    }
}
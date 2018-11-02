using System;
using System.Linq;

using Minsk.CodeAnalysis;

namespace Minsk
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showTree = false;

            while (true)
            {

                Console.Write("> ");
                var line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                    break; 

                if (line == "#showTree")
                {
                    showTree = !showTree;
                    Console.WriteLine(showTree ? "Showing parse trees" : "Not showing parse trees");

                    continue;
                }
                else if (line == "cls")
                {
                    Console.Clear();
                    continue;
                }

                var syntexTree = SyntaxTree.Parse(line);
                var color = Console.ForegroundColor;
                if (showTree)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    PrettyPrint(syntexTree.Root);
                    Console.ForegroundColor = color;
                }
                if (!syntexTree.Diagnostics.Any())
                {
                    var e = new Evaluator(syntexTree.Root);
                    var result = e.Evaluate();
                    Console.WriteLine(result);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                    foreach (var diagnostic in syntexTree.Diagnostics)
                        System.Console.WriteLine(diagnostic);

                    Console.ForegroundColor = color;
                }
            }
        }

        static void PrettyPrint(SyntaxNode node, string indent = "", bool isLast = true)
        {
            var marker = isLast ? "└──" : "├──";

            Console.Write(indent);
            Console.Write(marker);
            Console.Write(node.Kind);

            if (node is SyntaxToken t && t.Value != null)
            {
                Console.Write("  ");
                Console.Write(t.Value);
            }
            Console.WriteLine();

            indent += isLast ? "    " : "│   ";

            var lastChild = node.GetChildren().LastOrDefault();

            foreach (var child in node.GetChildren())
            {
                PrettyPrint(child, indent, child == lastChild);
            }
        }
    }
}


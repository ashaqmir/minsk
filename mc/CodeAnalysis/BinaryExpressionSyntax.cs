using System.Collections.Generic;

namespace Minsk.CodeAnalysis
{
    public sealed class BinaryExpressionSyntax : ExpressionSyntax
    {
        public BinaryExpressionSyntax(ExpressionSyntax left, SyntaxToken operatorToke, ExpressionSyntax right)
        {
            Left = left;
            OperatorToke = operatorToke;
            Right = right;
        }

        public ExpressionSyntax Left { get; }
        public SyntaxToken OperatorToke { get; }
        public ExpressionSyntax Right { get; }

        public override SyntaxKind Kind => SyntaxKind.BinaryExpression;

        public override IEnumerable<SyntaxNode> GetChildren()
        {
           yield return Left;
           yield return OperatorToke;
           yield return Right;
        }
    }
}

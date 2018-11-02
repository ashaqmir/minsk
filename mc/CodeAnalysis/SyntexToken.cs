using System.Collections.Generic;
using System.Linq;

namespace Minsk.CodeAnalysis
{
    class SyntaxToken : SyntaxNode
    {
        public SyntaxToken(SyntaxKind kind, int _position, string text, object value)
        {
            Kind = kind;
            Position = _position;
            Text = text;
            Value = value;
        }

        public override SyntaxKind Kind { get; }
        public int Position { get; }
        public string Text { get; }
        public object Value { get; }

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            return Enumerable.Empty<SyntaxNode>();
        }
    }

}

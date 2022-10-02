using Ara.Ast.Nodes.Abstract;
using Ara.Ast.Nodes.Expressions;
using Ara.Ast.Nodes.Statements.Abstract;
using Ara.Ast.Types;
using Ara.Parsing;
using Ara.Parsing.Abstract;
using Type = Ara.Ast.Types.Abstract.Type;

namespace Ara.Ast.Nodes.Statements;

public record For(IParseNode Node, string Counter, Expression Start, Expression End, Block Block) : Statement(Node), ITyped
{
    readonly AstNode[] children = {  Start, End, Block  };

    public override IEnumerable<AstNode> Children => children;

    public Type Type
    {
        get => new IntegerType();
        set => throw new NotSupportedException();
    }
}

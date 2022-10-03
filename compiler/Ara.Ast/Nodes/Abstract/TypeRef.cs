using Ara.Parsing.Abstract;
using Type = Ara.Ast.Types.Abstract.Type;

namespace Ara.Ast.Nodes.Abstract;

public abstract record TypeRef(IParseNode Node) : AstNode(Node)
{
    public abstract Type ToType();
}

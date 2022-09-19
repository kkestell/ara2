using Ara.Parsing;

namespace Ara.Ast.Nodes;

public record Constant(Node Node, string Value) : Atom(Node);
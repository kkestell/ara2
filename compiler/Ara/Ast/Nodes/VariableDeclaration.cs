﻿using Ara.Ast.Types;
using Ara.Parsing;

namespace Ara.Ast.Nodes;

public record VariableDeclaration(Node Node, Identifier Type, Identifier Name, Expression Expression) : Statement(Node)
{
    public readonly InferredType? InferredType = new (Type.Value);
}

﻿using Ara.Ast.Nodes.Abstract;
using Ara.Ast.Nodes.Expressions.Abstract;
using Ara.Ast.Nodes.Statements.Abstract;
using Ara.Parsing;
using Ara.Parsing.Abstract;

namespace Ara.Ast.Nodes.Statements;

public record Assignment(IParseNode Node, string Name, Expression Expression) : Statement(Node)
{
    public override List<AstNode> Children { get; } = new() { Expression };
}

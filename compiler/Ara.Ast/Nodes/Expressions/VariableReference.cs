﻿using Ara.Ast.Errors;
using Ara.Ast.Nodes.Abstract;
using Ara.Ast.Nodes.Expressions.Abstract;
using Ara.Parsing;
using Ara.Parsing.Abstract;
using Type = Ara.Ast.Types.Abstract.Type;

namespace Ara.Ast.Nodes.Expressions;

public record VariableReference(IParseNode Node, string Name) : Expression(Node)
{
    public override List<AstNode> Children => new();

    public override Type Type
    {
        get
        {
            var b = NearestAncestor<Block>();
            while (true)
            {
                if (b is null)
                    throw new ReferenceException(this);

                if (b.Scope.ContainsKey(Name))
                {
                    if (b.Scope[Name] is not ITyped i)
                        throw new Exception();

                    return i.Type;
                }

                b = b.NearestAncestorOrDefault<Block>();
            }
        }
        
        set => throw new NotImplementedException();
    }
}

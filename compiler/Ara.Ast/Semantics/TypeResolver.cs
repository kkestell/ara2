using Ara.Ast.Errors;
using Ara.Ast.Nodes;
using Ara.Ast.Types;

namespace Ara.Ast.Semantics;

public class TypeResolver : Visitor
{
    protected override void VisitNode(AstNode node)
    {
        switch (node)
        {
            case Constant c:
                ResolveConstant(c);
                break;
            case VariableReference v:
                ResolveVariableReference(v);
                break;
            case BinaryExpression b:
                ResolveBinaryExpression(b);
                break;
            case UnaryExpression u:
                ResolveUnaryExpression(u);
                break;
            case Call c:
                ResolveCallExpression(c);
                break;
        }
    }

    static void ResolveConstant(Constant c)
    {
        c.InferredType = new InferredType(c.Type.Value);
    }

    static void ResolveVariableReference(VariableReference r)
    {
        var type = r.ResolveVariableReference(r.Name.Value);

        if (type is null)
            throw new ReferenceException(r);

        r.InferredType = type;
    }
    
    static void ResolveBinaryExpression(BinaryExpression b)
    {
        if (b.Left.InferredType is null || b.Right.InferredType is null)
            throw new BinaryExpressionTypeException(b);

        if (!b.Left.InferredType.Equals(b.Right.InferredType))
            throw new BinaryExpressionTypeException(b);

        if (b.Op is BinaryOperator.Equality or BinaryOperator.Inequality)
        {
            b.InferredType = new InferredType("bool");
        }
        else
        {
            b.InferredType = b.Left.InferredType;
        }        
    }

    static void ResolveUnaryExpression(UnaryExpression u)
    {
        u.InferredType = u.Right.InferredType;
    }

    static void ResolveCallExpression(Call c)
    {
        var func = c.NearestAncestor<SourceFile>()!
            .Definitions.SingleOrDefault(x => x is FunctionDefinition d && d.Name.Value == c.Name.Value);

        if (func is not FunctionDefinition functionDefinition)
            throw new ReferenceException(c);

        c.InferredType = new InferredType(functionDefinition.ReturnType.Value);
    }
}

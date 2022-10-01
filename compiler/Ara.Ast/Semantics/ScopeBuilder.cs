using Ara.Ast.Nodes;

namespace Ara.Ast.Semantics;

public class ScopeBuilder : Visitor
{
    public ScopeBuilder(SourceFile sourceFile) : base(sourceFile)
    {
    }
    
    protected override void VisitNode(AstNode node)
    {
        switch (node)
        {
            case For f:
                For(f);
                break;
            case FunctionDefinition f:
                FunctionDefinition(f);
                break;
            case VariableDeclaration v:
                VariableDeclaration(v);
                break;
        }
    }
    
    static void For(For f)
    {
        f.Block.Scope.Add(f.Counter, f);
    }
    
    static void FunctionDefinition(FunctionDefinition f)
    {
        foreach (var p in f.Parameters.Nodes)
        {
            f.Block.Scope.Add(p.Name, p);
        }
    }

    static void VariableDeclaration(VariableDeclaration d)
    {
        var blk = d.NearestAncestor<Block>();
        blk.Scope.Add(d.Name, d);
    }
}

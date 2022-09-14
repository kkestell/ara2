namespace Ara.CodeGen.IR.Types;

public abstract record IrType
{
    public abstract string ToIr();

    public static IrType FromString(string type)
    {
        return type switch
        {
            "void"  => Void,
            "int"   => Int,
            "bool"  => Bool,
            "float" => Float,
            
            _ => throw new NotImplementedException()
        };
    }

    public static readonly VoidType Void = new ();
    public static readonly IntType Int = new (32);
    public static readonly BitType Bool = new ();
    public static readonly FloatType Float = new ();
}

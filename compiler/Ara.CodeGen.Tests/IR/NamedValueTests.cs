using Ara.CodeGen.IR.Types;
using Ara.CodeGen.IR.Values;

namespace Ara.CodeGen.Tests.IR;

public class NamedValueTests : TestBase
{
    [Test]
    public void UseTheProvidedValue()
    {
        builder.Add(new IntegerValue(1), new IntegerValue(1), "foo");

        AssertIr(module.Emit(), @"
            define void @test () {
            entry:
              %""foo"" = add i32 1, 1
            }
        ");
    }
    
    [Test]
    public void GenerateUniqueNamesWithinABlock()
    {
        for (var i = 0; i < 3; i++)
        {
            builder.Add(new IntegerValue(1), new IntegerValue(1), "foo");
        }

        AssertIr(module.Emit(), @"
            define void @test () {
            entry:
              %""foo"" = add i32 1, 1
              %""foo.0"" = add i32 1, 1
              %""foo.1"" = add i32 1, 1
            }
        ");
    }
    
    [Test]
    public void GenerateUniqueNamesAcrossBlocks()
    {
        for (var i = 0; i < 3; i++)
        {
            builder.Alloca(IrType.Integer, 1, "foo");
            var child = builder.Block.AddChild("bar");
            builder = child.IrBuilder();
            builder.Alloca(IrType.Integer, 1, "bar");
        }

        var ir = module.Emit();
        AssertIr(ir, @"
            define void @test () {
            entry:
              %""foo"" = alloca i32, i32 1, align 4
            bar.0:
              %""bar.1"" = alloca i32, i32 1, align 4
              %""foo.0"" = alloca i32, i32 1, align 4
            bar.2.0:
              %""bar.3"" = alloca i32, i32 1, align 4
              %""foo.1"" = alloca i32, i32 1, align 4
            bar.4.0:
              %""bar.5"" = alloca i32, i32 1, align 4
            }
        ");
    }
}

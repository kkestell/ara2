namespace Ara.Tests.Instructions;

public class FMulTests : TestBase
{
    [Test]
    public void SubtractTwoFloats()
    {
        builder.FMul(new FloatValue(3.14f), new FloatValue(2.71f));

        var ir = module.Emit();
        Assert.That(ir, Is.EqualTo("define void @test () {\n%\"0\" = fmul float 0x40091EB860000000, 0x4005AE1480000000\n}"));
    }

    [Test]
    public void ThrowWhenArgumentsHaveDifferentTypes()
    {
        Assert.Throws<ArgumentException>(delegate
        {
            builder.FMul(new IntegerValue(1), new FloatValue(3.14f));
        });
    }

    [Test]
    public void ThrowWhenArgumentsAreNotFloats()
    {
        Assert.Throws<ArgumentException>(delegate
        {
            builder.FMul(new IntegerValue(1), new IntegerValue(1));
        });
    }
}
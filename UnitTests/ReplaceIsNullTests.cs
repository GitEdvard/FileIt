using FileIt.UserOptions.ReplaceIsNull2;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    class ReplacementTests
    {
        private Replacer _replacer;
        private string _actual;


        public ReplacementTests()
        {
            _replacer = new Replacer();
        }

        [Test]
        public void TestIsNullStraight()
        {
            string text = "IsNull(expression)";
            string expectedText = "expression == null";

            var n = _replacer.Replace(text, out _actual);
            Assert.AreEqual(expectedText, _actual);
            Assert.AreEqual(1, n);
        }

        [Test]
        public void TestNoOccurences()
        {
            string text = "no occurrences of isnull";
            var n = _replacer.Replace(text, out _actual);
            Assert.AreEqual("no occurrences of isnull", _actual);
            Assert.AreEqual(0, n);
        }

        [Test]
        public void TestIsNullInside()
        {
            string text = "text text IsNull(exp) more text";
            string expected = "text text exp == null more text";
            var n = _replacer.Replace(text, out _actual);
            Assert.AreEqual(expected, _actual);
            Assert.AreEqual(1, n);
        }

        [Test]
        public void TestEmptyString()
        {
            string text = "";
            var n = _replacer.Replace(text, out _actual);
            Assert.AreEqual(text, _actual);
            Assert.AreEqual(0, n);
        }

        [Test]
        public void TestBrackedTilted()
        {
            string text = "text IsNotNull(exp    ) text";
            var n = _replacer.Replace(text, out _actual);
            Assert.AreEqual("text exp != null text", _actual);
            Assert.AreEqual(1, n);
        }

        [Test]
        public void TestBothReplacements()
        {
            string text = "     if(IsNull(exp1) && IsNotNull(exp2))";
            var n = _replacer.Replace(text, out _actual);
            Assert.AreEqual("     if(exp1 == null && exp2 != null)", _actual);
            Assert.AreEqual(2, n);
        }

        [Test]
        public void TestNestedIsNull()
        {
            string text = "if(IsNull(getvalue(exp1)))";
            var n = _replacer.Replace(text, out _actual);
            Assert.AreEqual("if(getvalue(exp1) == null)", _actual);
            Assert.AreEqual(1, n);
        }

        [Test]
        public void TestNestedBoth()
        {
            string text = "if(IsNull(getvalue(exp1)) || IsNotNull(getvalue(exp2)))";
            var n = _replacer.Replace(text, out _actual);
            Assert.AreEqual("if(getvalue(exp1) == null || getvalue(exp2) != null)", _actual);
            Assert.AreEqual(2, n);
        }

        [Test]
        public void TestTwoIsNotNullNested()
        {
            string text = "while(IsNotNull(getvalue(exp1)) || IsNotNull(getvalue(exp2)))";
            var n = _replacer.Replace(text, out _actual);
            Assert.AreEqual("while(getvalue(exp1) != null || getvalue(exp2) != null)", _actual);
            Assert.AreEqual(2, n);
        }

        [Test]
        public void TestUnbalancedBrackets()
        {
            string text = "if(IsNull(exp1)";
            var n = _replacer.Replace(text, out _actual);
            Assert.AreEqual("if(exp1 == null", _actual);
        }

        [Test]
        public void TestUnbalancedBrackets2()
        {
            string text = "if(IsNull(exp1";
            Assert.Throws<System.IndexOutOfRangeException>(
                () => _replacer.Replace(text, out _actual));
        }
    }
}

using Day2;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Day2Tests.PasswordPolicyReaderTests
{
    [TestFixture]
    public class When_running_CheckPassword_on_valid_entry
    {
        [Test]
        public void Then_true_is_returned()
        {
            Assert.That(PasswordPolicyChecker.CheckPassword('a',1,3,@"abcde"), Is.True);
        }
    }
    
    [TestFixture]
    public class When_running_CheckPassword_on_invalid_entries
    {
        [Test]
        public void Then_false_is_returned_for_not_enough_entries()
        {
            Assert.That(PasswordPolicyChecker.CheckPassword('a',1,3,@"bcde"), Is.False);
        }
        [Test]
        public void Then_false_is_returned_for_too_many_entries()
        {
            Assert.That(PasswordPolicyChecker.CheckPassword('a',1,3,@"abacadae"), Is.False);
        }
    }
    
    [TestFixture]
    public class When_running_CheckOfficialPassword_on_valid_entry_with_only_one_item_correct
    {
        [Test]
        public void Then_true_is_returned()
        {
            Assert.That(PasswordPolicyChecker.CheckPassword('a',1,3,@"abcde"), Is.True);
        }
    }
    
    [TestFixture]
    public class When_running_CheckOfficialPassword_on_invalid_entries_with_two_items_correct
    {
        [Test]
        public void Then_false_is_returned()
        {
            Assert.That(PasswordPolicyChecker.CheckOfficialPassword('c',1,3,@"ccccccccc"), Is.False);
        }
    }
    
    [TestFixture]
    public class When_running_CheckOfficialPassword_on_invalid_entries_with_no_items_correct
    {
        [Test]
        public void Then_false_is_returned()
        {
            Assert.That(PasswordPolicyChecker.CheckOfficialPassword('b',1,3,@"cdefg"), Is.False);
        }
    }
}
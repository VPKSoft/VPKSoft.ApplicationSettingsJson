namespace VPKSoft.ApplicationSettingsJson.Tests;

[TestClass]
public class SettingsTests
{
    [TestMethod]
    public void TestString()
    {
        var fileName = Path.GetTempFileName();
        var settings = new Settings();

        Assert.AreEqual("Test", settings.StringNotNull);
        settings.StringNotNull = "abcd";
        settings.Save(fileName);

        settings.Load(fileName);
        Assert.AreEqual("abcd", settings.StringNotNull);
    }

    [TestMethod]
    public void TestBool()
    {
        var fileName = Path.GetTempFileName();
        var settings = new SettingsBool();
        settings.Load(fileName);
        Assert.AreEqual(true, settings.DefaultBool);

        settings.DefaultBool = false;
        settings.Save(fileName);
        settings.Load(fileName);
        Assert.AreEqual(false, settings.DefaultBool);
    }
}

internal class Settings : ApplicationJsonSettings
{
    [Settings(Default = "Test")]
    public string StringNotNull { get; set; } = string.Empty;
}

internal class SettingsBool : ApplicationJsonSettings
{
    [Settings(Default = true)]
    public bool DefaultBool { get; set; }
}
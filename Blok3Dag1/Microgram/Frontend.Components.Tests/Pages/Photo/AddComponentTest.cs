
using Bunit;
using Microgram.Frontend.Core.Repository;
using Microgram.Frontend.Infrastructure.Repository;
using Microgram.Pages.Photo;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;

namespace Frontend.Components.Tests.Pages.Photo;

[TestClass]
public class AddComponentTest
{
    [TestMethod]
    public void TestMethod1()
    {
        var ctx = new Bunit.TestContext();
        ctx.Services.AddSingleton<IPhotoRepository, PhotoRepository>();
        
        var fixture = ctx.RenderComponent<Add>();
        var sut = fixture.Instance;

        fixture.Render();

        var inputs = fixture.FindComponents<MudTextField<string>>();
        var fileUploads = fixture.FindComponents<MudFileUpload<IBrowserFile>>();
        Assert.AreEqual(1, fileUploads.Count);
        Assert.AreEqual(3, inputs.Count);
    }
}
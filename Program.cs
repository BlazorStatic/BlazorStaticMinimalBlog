using BlazorStatic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorStaticMinimalBlog.Components;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseStaticWebAssets();

builder.Services.AddBlazorStaticService(opt => {
    //opt. //check to change the defaults

    // opt.ShouldGenerateSitemap = true; //add this if you want sitemap.xml to be genedated
    //opt.SiteUrl = "https://BlazorStatic.net; //add your url

    // opt.IgnoredPathsOnContentCopy.Add("file-in-wwwroot-that-i-dont-want"); //e.g. pre-build css
    // opt.PagesToGenerate.Add(new PageToGenerate("the/url/to/request", "file/to/generate")); // add pages that BlazorStatic cannot discover (usually the pages without md file)
}
)
.AddBlazorStaticContentService<BlogFrontMatter>(opt => {
    // modify blog post before they are genedated to html
    // opt.AfterContentParsedAndAddedAction = (service, contentService) => {
    //     contentService.Posts.ForEach(post => {
    //         post.Url = $"{post.Url}-nice"; // add nice to every url
    //         post.FrontMatter.Published = DateTime.Now; //change post metadata
    //     });
    // };

    // opt.PageUrl = "my-blog"; // if you need to change the resulting url. Defaut is "blog"
    // opt.ContentPath = "MyContent/Posts"; // where resides your blog posts?


}) //
// .AddBlazorStaticContentService<MyFrontMatter>() // any other "content section" on your page with a differet FrontMatter? For example /projects
;

builder.Services.AddRazorComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.UseBlazorStaticGenerator(shutdownApp: !app.Environment.IsDevelopment());

app.Run();

public static class WebsiteKeys
{
    public const string GitHubRepo = "https://github.com/BlazorStatic/BlazorStaticMinimalBlog";
    public const string X = "https://x.com/";
    public const string Title = "BlazorStatic Minimal Blog";
    public const string BlogPostStorageAddress = $"{GitHubRepo}/tree/main/Content/Blog";
    public const string BlogLead = "Sample blog created with BlazorStatic and TailwindCSS";
}

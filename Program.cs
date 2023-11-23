using BlazorStaticMinimalBlog.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();


public static class WebsiteKeys
{
    public const string GitHubRepo = "https://github.com/tesar-tech/blazorStaticMinimalBlog";
    public const string Twitter = "https://twitter.com/";
    public const string Title = "BlazorStatic Minimal Blog";
    
}

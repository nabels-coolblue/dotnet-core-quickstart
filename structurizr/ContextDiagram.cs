using Structurizr;
using Structurizr.Api;
using Structurizr.Documentation;

namespace structurizr
{
    
    /// <summary>
    /// This is a simple example of how to get started with Structurizr for .NET.
    /// </summary>
    public class ContextDiagram
    {
        public static Workspace Create(long WorkspaceId, string ApiKey, string ApiSecret)
        {
            // a Structurizr workspace is the wrapper for a software architecture model, views and documentation
            Workspace workspace = new Workspace("Getting Started", "This is a model of my software system.");
            Model model = workspace.Model;

            // add some elements to your software architecture model
            Person user = model.AddPerson("User", "A user of my software system.");
            SoftwareSystem softwareSystem = model.AddSoftwareSystem("Software System", "My software system.");
            user.Uses(softwareSystem, "Uses");

            // define some views (the diagrams you would like to see)
            ViewSet views = workspace.Views;
            SystemContextView contextView = views.CreateSystemContextView(softwareSystem, "SystemContext",
                "An example of a System Context diagram.");
            contextView.PaperSize = PaperSize.A5_Landscape;
            contextView.AddAllSoftwareSystems();
            contextView.AddAllPeople();

            // add some documentation
            StructurizrDocumentationTemplate template = new StructurizrDocumentationTemplate(workspace);
            template.AddContextSection(softwareSystem, Format.Markdown,
                "Here is some context about the software system...\n" +
                "\n" +
                "![](embed:SystemContext)");

            // add some styling
            Styles styles = views.Configuration.Styles;
            styles.Add(new ElementStyle(Tags.SoftwareSystem) { Background = "#1168bd", Color = "#ffffff" });
            styles.Add(new ElementStyle(Tags.Person) { Background = "#08427b", Color = "#ffffff", Shape = Shape.Person });

            return workspace;
        }
    }

}
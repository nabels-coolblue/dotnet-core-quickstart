using System.IO;
using System.Linq;
using structurizr;
using Structurizr.Api;
using Structurizr.Core.Util;
using Structurizr.Documentation;
using Structurizr.Util;

namespace Structurizr.Examples
{
    
    /// <summary>
    /// This is an example workspace to illustrate the key features of Structurizr,
    /// based around a fictional Internet Banking System for Big Bank plc.
    ///
    /// The live workspace is available to view at https://structurizr.com/share/36141
    /// </summary>
    public class Program
    {
        private const long WorkspaceId = 37700;
        private const string ApiKey = "";
        private const string ApiSecret = "";

        static void Main(string[] args)
        {
            var workspace = BigBankPlc.Create(WorkspaceId, ApiKey, ApiSecret);
            UploadWorkspaceToStructurizr(workspace);
            
            var workspace2 = ContextDiagram.Create(WorkspaceId, ApiKey, ApiSecret);
            //UploadWorkspaceToStructurizr(workspace2);
        }

        private static void UploadWorkspaceToStructurizr(Workspace workspace) {
            StructurizrClient structurizrClient = new StructurizrClient(ApiKey, ApiSecret);
            structurizrClient.PutWorkspace(WorkspaceId, workspace);
        }

    }

}